import gateway from '../apiGateway'

export const obter = () => gateway.get("/ativos/")
export const inserir = (ativo) => gateway.post("/ativos/", ativo)
export const inserirManutencao = (identificadorAtivo, manutencao) => gateway.post(`/ativos/${identificadorAtivo}/manutencoes`, manutencao)
export const realizarManutencao = (identificadorAtivo, identificadorManutencao) => gateway.put(`/ativos/${identificadorAtivo}/manutencoes/${identificadorManutencao}`)
export const excluir = (id) => gateway.delete(`/ativos/${id}`)
export const obterAdquiriveis = () => gateway.get("/ativos/adquirir")
export const adquirir = (id) => gateway.post(`/ativos/adquirir/${id}`)

export default {
    obter,
    inserir,
    inserirManutencao,
    realizarManutencao,
    excluir,
    obterAdquiriveis,
    adquirir
}