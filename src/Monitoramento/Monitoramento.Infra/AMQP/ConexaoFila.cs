using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Threading;

namespace Monitoramento.Infra.AMQP
{
    public class ConexaoFila : IConexaoFila, IDisposable
    {
        private readonly IConnection conexao;
        private readonly IModel canal;
        private readonly string fila;

        public ConexaoFila(string host, string fila)
        {
            var factory = new ConnectionFactory() { HostName = host };

            conectar:
            try
            {
                conexao = factory.CreateConnection();
                canal = conexao.CreateModel();

                canal.QueueDeclare(queue: fila,
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                this.fila = fila;
            }
            catch
            {
                Thread.Sleep(2000);
                goto conectar;
            }
        }

        public void EnviarMensagem(object mensagem)
            => EnviarMensagem(JsonConvert.SerializeObject(mensagem));

        public void EnviarMensagem(string mensagem)
        {
            var properties = canal.CreateBasicProperties();
            properties.Persistent = true;

            canal.BasicPublish(exchange: "",
                                routingKey: fila,
                                basicProperties: properties,
                                body: Encoding.UTF8.GetBytes(mensagem));
        }

        public void Dispose()
        {
            if (canal != null)
                canal.Dispose();

            if (conexao != null)
                conexao.Dispose();
        }
    }
}
