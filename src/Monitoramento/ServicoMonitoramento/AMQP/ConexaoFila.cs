using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace ServidorMonitoramento.AMQP
{
    public class ConexaoFila : IConexaoFila, IDisposable
    {
        private readonly IConnection conexao;
        private readonly IModel canal;

        public ConexaoFila(string host, string fila)
        {
            var factory = new ConnectionFactory() { HostName = host };
            conexao = factory.CreateConnection();
            canal = conexao.CreateModel();

            canal.QueueDeclare(queue: fila,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
        }

        public void EnviarMensagem(object mensagem)
            => EnviarMensagem(JsonConvert.SerializeObject(mensagem));

        public void EnviarMensagem(string mensagem)
        {
            var properties = canal.CreateBasicProperties();
            properties.Persistent = true;

            canal.BasicPublish(exchange: "",
                                routingKey: "task_queue",
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
