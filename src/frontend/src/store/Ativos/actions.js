import repositorioAtivos from '../../services/Ativos/repositorioAtivos';
import repositorioCronogramas from '../../services/Ativos/repositorioCronogramas';

const atualizarAtivos = async ({ commit }) => {
    const resposta = await repositorioAtivos.obter();
    if (resposta.status == 200)
        commit('atualizarAtivos', resposta.data);
}

const adicionarAtivo = async ({ commit }, ativo) => {
    const resposta = await repositorioAtivos.inserir(ativo);
    if (resposta.status == 200)
        commit('adicionarAtivo', ativo);
}

const adicionarManutencao = async ({ commit }, { identificador, manutencao }) => {
    const resposta = await repositorioAtivos.inserirManutencao(identificador, manutencao);
    if (resposta.status == 200) {
        manutencao.identificador = resposta.data;
        commit('adicionarManutencao', { identificador, manutencao });
    }
}

const realizarManutencao = async ({ commit }, { identificadorAtivo, identificadorManutencao }) => {
    const resposta = await repositorioAtivos.realizarManutencao(identificadorAtivo, identificadorManutencao);
    if (resposta.status == 200)
        commit('realizarManutencao', { identificadorAtivo, identificadorManutencao });
}

const removerAtivo = async ({ commit }, ativo) => {
    const resposta = await repositorioAtivos.excluir(ativo.identificador);
    if (resposta.status == 200) {
        ativo.identificador = resposta.data;
        commit('removerAtivo', ativo);
    }
}

const atualizarCronogramas = async ({ commit }) => {
    const resposta = await repositorioCronogramas.obter();
    if (resposta.status == 200)
        commit('atualizarCronogramas', resposta.data);
}

const adicionarCronograma = async ({ commit }, cronograma) => {
    const resposta = await repositorioCronogramas.inserir(cronograma);
    if (resposta.status == 200) {
        cronograma.identificador = resposta.data;
        commit('adicionarCronograma', cronograma);
    }
}

const removerCronograma = async ({ commit }, cronograma) => {
    const resposta = await repositorioCronogramas.excluir(cronograma.identificador);
    if (resposta.status == 200)
        commit('removerCronograma', cronograma);
}

export default {
    atualizarAtivos,
    adicionarAtivo,
    removerAtivo,
    adicionarManutencao,
    realizarManutencao,
    atualizarCronogramas,
    adicionarCronograma,
    removerCronograma
}
