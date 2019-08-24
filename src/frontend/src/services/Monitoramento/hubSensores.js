import { HubConnectionBuilder, LogLevel } from '@aspnet/signalr'

const conexao = new HubConnectionBuilder()
    .withUrl('http://localhost/hubs/monitoramento/sensores')
    .configureLogging(LogLevel.Information)
    .build();

conexao.start();

export default conexao;