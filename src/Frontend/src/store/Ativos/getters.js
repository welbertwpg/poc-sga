import Moment from "moment";

const obterDescricaoFrequencia = (tipo) => {
    switch (tipo) {
        case 1:
        case "1":
            return "Diária";
        case 2:
        case "2":
            return "Semanal";
        case 3:
        case "3":
            return "Mensal";
        case 4:
        case "4":
            return "Anual";
        case 5:
        case "5":
            return "Intervalo";
    }
}

const obterDescricaoTipoAtivo = (frequencia) => {
    switch (frequencia) {
        case 1:
        case "1":
            return "Equipamento";
        case 2:
        case "2":
            return "Máquina";
        case 3:
        case "3":
            return "Insumo";
    }
}

const obterDescricaoTipoManutencao = (tipo) => {
    switch (tipo) {
        case 1:
        case "1":
            return "Preventiva";
        case 2:
        case "2":
            return "Corretiva";
    }
}

const ativos = (state) => state.ativos.map((ativo) => ({
    identificador: ativo.identificador,
    nome: ativo.nome,
    patrimonio: ativo.patrimonio,
    tipo: obterDescricaoTipoAtivo(ativo.tipo),
    dataAquisicao: Moment(String(ativo.dataAquisicao)).format("DD/MM/YYYY"),
    observacoes: ativo.observacoes,
    mediaHorasUsoDiariamente: ativo.mediaHorasUsoDiariamente,
    manutencoes: ativo.manutencoes.map((manutencao) => ({
        identificador: manutencao.identificador,
        dataHora: Moment(String(manutencao.dataHoraRealizada || manutencao.dataHora)).format("DD/MM/YYYY"),
        tipo: obterDescricaoTipoManutencao(manutencao.tipo),
        realizada: manutencao.realizada
    }))
}))

const cronogramas = (state) => state.cronogramas.map((cronograma) => ({
    identificador: cronograma.identificador,
    frequencia: obterDescricaoFrequencia(cronograma.frequencia),
    tipoAtivo: obterDescricaoTipoAtivo(cronograma.tipoAtivo),
    intervaloHorasUso: cronograma.intervaloHorasUso
}))

export default {
    ativos,
    cronogramas
}