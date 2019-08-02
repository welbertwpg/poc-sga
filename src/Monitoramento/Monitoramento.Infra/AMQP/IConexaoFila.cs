namespace Monitoramento.Infra.AMQP
{
    public interface IConexaoFila
    {
        void EnviarMensagem(object mensagem);
    }
}
