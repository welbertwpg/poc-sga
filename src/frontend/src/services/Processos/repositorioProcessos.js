import gateway from '../apiGateway'

export const obter = (identificador) => gateway.get(`/processos/${identificador}`);
export const inserirOuAtualizar = (processo) => gateway.put('/processos/', processo);
export const excluir = (identificador) => gateway.delete(`/processos/${identificador}`);

export default {
    obter,
    inserirOuAtualizar,
    excluir
}