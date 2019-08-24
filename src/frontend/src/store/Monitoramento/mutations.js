const atualizarLimites = (state, limites) => {
    state.limites = limites;
}

const atualizarResultadosSensores = (state, resultado) => {
    state.resultadoSensores = resultado;
}

export default {
    atualizarLimites,
    atualizarResultadosSensores
}