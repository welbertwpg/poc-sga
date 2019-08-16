import gateway from '../apiGateway'

export const obter = () => gateway.get("/ativos/")

export default {
    obter
}