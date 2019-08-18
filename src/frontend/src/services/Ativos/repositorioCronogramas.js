import gateway from '../apiGateway'

export const obter = () => gateway.get("/ativos/manutencoes/cronogramas")
export const inserir = (cronograma) => gateway.post("/ativos/manutencoes/cronogramas", cronograma)
export const excluir = (id) => gateway.delete(`/ativos/manutencoes/cronogramas/${id}`)

export default {
    obter,
    inserir,
    excluir
}