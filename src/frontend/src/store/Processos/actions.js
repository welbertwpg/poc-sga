import repositorioProcessos from '../../services/Processos/repositorioProcessos'
import uuid from "uuid/v4";

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

const criarNovoProcesso = async ({ commit }, nome) => {
    const processo = {
        nome: nome,
        etapas: [
            {
                identificador: uuid(),
                nome: 'Inicio',
                tipo: 0,
                etapasSaida: []
            },
            {
                identificador: uuid(),
                nome: 'Fim',
                tipo: 3,
                etapasSaida: []
            }
        ]
    }

    commit('atualizarProcesso', processo);
}

const salvarProcesso = async ({ commit, state }, etapas) => {
    let processo = state.processo;
    processo.etapas = etapas;

    const resposta = await repositorioProcessos.inserirOuAtualizar(processo);
    if (resposta.status != 200)
        throw resposta.data;

    await atualizarProcessos({ commit });
    commit('atualizarProcesso', processo);
}

export default {
    atualizarProcessos,
    atualizarProcesso,
    criarNovoProcesso,
    salvarProcesso
}