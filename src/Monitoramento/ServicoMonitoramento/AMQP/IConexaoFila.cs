namespace ServidorMonitoramento.AMQP
{
    public interface IConexaoFila
    {
        void EnviarMensagem(object mensagem);
    }
}
