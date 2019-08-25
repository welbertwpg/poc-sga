export const atualizarProcessos = (state, processos) => {
    state.processos = processos;
}

export const atualizarProcesso = (state, processo) => {
    state.processo = processo;
}

export default {
    atualizarProcessos,
    atualizarProcesso
}