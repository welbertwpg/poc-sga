import gateway from '../apiGateway'

export const obter = (identificador) => gateway.get(`/processos/${identificador}`);
export const inserirOuAtualizar = (processo) => gateway.put('/processos/', processo);

export default {
    obter,
    inserirOuAtualizar
}