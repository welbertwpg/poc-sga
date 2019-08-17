import gateway from '../apiGateway'

export const obter = () => gateway.get("/ativos/manutencao/cronogramas")

export default {
    obter
}