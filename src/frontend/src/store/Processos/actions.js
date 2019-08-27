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

const salvarProcesso = async ({ commit }, processo) => {
    const resposta = await repositorioProcessos.inserirOuAtualizar(processo);
    if (resposta.status == 200) {
        await atualizarProcessos({ commit });
        commit('atualizarProcesso', processo);
    }
}

export default {
    atualizarProcessos,
    atualizarProcesso,
    salvarProcesso
}