const atualizarProcessos = (state, processos) => {
    state.processos = processos;
}

const atualizarProcesso = (state, processo) => {
    state.processo = processo;
}

export default {
    atualizarProcessos,
    atualizarProcesso
}