import gateway from '../apiGateway'

export const obter = () => gateway.get("/ativos/manutencao/cronogramas")
export const inserir = (cronograma) => gateway.post("/ativos/manutencao/cronogramas", cronograma)

export default {
    obter,
    inserir
}