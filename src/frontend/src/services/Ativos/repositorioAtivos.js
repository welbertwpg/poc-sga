import gateway from '../apiGateway'

export const obter = () => gateway.get("/ativos/")
export const inserir = (ativo) => gateway.post("/ativos/", ativo)

export default {
    obter,
    inserir
}