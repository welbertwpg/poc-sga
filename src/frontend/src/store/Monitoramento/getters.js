const limites = (state) => [
    state.limites.pressaoMaximaPermitida || 0,
    state.limites.nivelMaximoPermitido || 0,
    0,
    0
]

const resultadoSensores = (state) => [
    state.resultadoSensores.piezometro.pressao || 0,
    state.resultadoSensores.piezometro.nivel || 0,
    state.resultadoSensores.deslocamento.deslocamentoHorizontal || 0,
    state.resultadoSensores.deslocamento.deslocamentoVertical || 0
]

export default {
    limites,
    resultadoSensores
}