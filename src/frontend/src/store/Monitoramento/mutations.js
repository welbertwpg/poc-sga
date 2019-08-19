const atualizarLimites = (state, limites) => {
    state.limites = limites;
}

const atualizarResultadoSensores = (state, resultado) => {
    state.resultadoSensores = resultado;
}

export default {
    atualizarLimites,
    atualizarResultadoSensores
}