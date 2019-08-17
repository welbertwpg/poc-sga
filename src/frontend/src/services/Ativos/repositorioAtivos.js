import gateway from '../apiGateway'

export const obter = () => gateway.get("/ativos/")
export const inserir = (ativo) => gateway.post("/ativos/", ativo)
export const excluir = (id) => gateway.delete(`/ativos/${id}`)

export default {
    obter,
    inserir,
    excluir
}