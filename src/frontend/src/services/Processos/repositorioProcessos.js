import gateway from '../apiGateway'

export const obter = (identificador) => gateway.get(`/processos/${identificador}`);

export default {
    obter
}