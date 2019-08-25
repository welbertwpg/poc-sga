import gateway from '../apiGateway'

export const obter = () => gateway.get('/processos/');

export default {
    obter
}