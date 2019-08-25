import repositorioProcessos from '../../services/Processos/repositorioProcessos'

export const atualizarProcessos = async ({ commit }) => {
    const resposta = await repositorioProcessos.obter();
    if (resposta.status == 200)
        commit('atualizarProcessos', resposta.data);
}

export const atualizarProcesso = async ({ commit }, processo) => {
    commit('atualizarProcesso', processo);
}

export default {
    atualizarProcessos,
    atualizarProcesso
}