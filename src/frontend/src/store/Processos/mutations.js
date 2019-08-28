const atualizarProcessos = (state, processos) => state.processos = processos;
const atualizarProcesso = (state, processo) => state.processo = processo;

const excluirProcesso = (state, processo) => {
    const index = state.processos.findIndex((p) => p.identificador == processo.identificador);
    state.processos.splice(index, 1);
}

export default {
    atualizarProcessos,
    atualizarProcesso,
    excluirProcesso
}