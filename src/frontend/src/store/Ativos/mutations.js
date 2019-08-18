const atualizarAtivos = (state, ativos) => {
    state.ativos = ativos
}

const adicionarAtivo = (state, ativo) => {
    state.ativos.push(ativo)
}

const removerAtivo = (state, ativo) => {
    const index = state.ativos.findIndex((a) => a.identificador == ativo.identificador)
    state.ativos.splice(index, 1)
}

const atualizarCronogramas = (state, cronogramas) => {
    state.cronogramas = cronogramas
}

const adicionarCronograma = (state, cronograma) => {
    state.cronogramas.push(cronograma)
}

const removerCronograma = (state, cronograma) => {
    const index = state.cronogramas.findIndex((c) => c.identificador == cronograma.identificador)
    state.cronogramas.splice(index, 1)
}

export default {
    atualizarAtivos,
    adicionarAtivo,
    removerAtivo,
    atualizarCronogramas,
    adicionarCronograma,
    removerCronograma
}
