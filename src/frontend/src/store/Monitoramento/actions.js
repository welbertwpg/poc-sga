import repositorioSensores from "../../services/Monitoramento/repositorioSensores"

const preencherDados = async ({ commit }) => {
    const respostaLimites = await repositorioSensores.obterLimites();
    const respostaSensores = await repositorioSensores.obterResultadoSensores();

    if (respostaLimites.status == 200)
        commit("atualizarLimites", respostaLimites.data)

    if (respostaSensores.status == 200)
        commit("atualizarResultadoSensores", respostaSensores.data)
}

const atualizarResultadoSensores = ({ commit }, resultado) => {
    commit("atualizarResultadoSensores", resultado)
}

export default {
    preencherDados,
    atualizarResultadoSensores
}