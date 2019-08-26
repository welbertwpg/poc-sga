import repositorioProcessos from '../../services/Processos/repositorioProcessos'

const atualizarProcessos = async ({ commit }) => {
    const resposta = await repositorioProcessos.obter("");
    if (resposta.status == 200)
        commit('atualizarProcessos', resposta.data);
}

const atualizarProcesso = async ({ commit }, processo) => {
    const resposta = await repositorioProcessos.obter(processo.identificador);
    if (resposta.status == 200)
        commit('atualizarProcesso', resposta.data);
}

export default {
    atualizarProcessos,
    atualizarProcesso
}