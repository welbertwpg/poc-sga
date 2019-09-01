import { HubConnectionBuilder, LogLevel } from '@aspnet/signalr'

const conexao = new HubConnectionBuilder()
    .withUrl('http://localhost:8080/hubs/monitoramento/sensores')
    .configureLogging(LogLevel.Information)
    .build();

conexao.start();

export default conexao;