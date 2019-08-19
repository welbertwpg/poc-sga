import gateway from '../apiGateway'

export const obterLimites = () => gateway.get("/monitoramento/limites/")
export const obterResultadoSensores = () => gateway.get("/monitoramento/sensores/")

export default {
    obterLimites,
    obterResultadoSensores
}