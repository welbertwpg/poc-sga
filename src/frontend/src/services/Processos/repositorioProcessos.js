import gateway from '../apiGateway'

export const obter = (identificador) => gateway.get(`/processos/${identificador}`);
export const inserirOuAtualizar = (processo) => gateway.put('/processos/', processo);
export const excluir = (identificador) => gateway.delete(`/processos/${identificador}`);
export const inserirParada = (parada) => gateway.post('/processos/paradas', parada);
export const inserirProblema = (problema) => gateway.post('/processos/problemas', problema);

export default {
    obter,
    inserirOuAtualizar,
    excluir,
    inserirParada,
    inserirProblema
}