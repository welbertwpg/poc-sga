import Moment from "moment";

const obterDescricaoFrequencia = (tipo) => {
    switch (tipo) {
        case 1:
            return "Diária";
        case 2:
            return "Semanal";
        case 3:
            return "Mensal";
        case 4:
            return "Anual";
        case 5:
            return "Intervalo";
    }
}

const obterDescricaoTipoAtivo = (frequencia) => {
    switch (frequencia) {
        case 1:
            return "Equipamento";
        case 2:
            return "Máquina";
        case 3:
            return "Insumo";
    }
}

const ativos = (state) => state.ativos.map((ativo) => {
    return {
        identificador: ativo.identificador,
        nome: ativo.nome,
        patrimonio: ativo.patrimonio,
        tipo: obterDescricaoTipoAtivo(ativo.tipo),
        dataAquisicao: Moment(String(ativo.dataAquisicao)).format("DD/MM/YYYY"),
        observacoes: ativo.observacoes,
        mediaHorasUsoDiariamente: ativo.mediaHorasUsoDiariamente,
        manutencoes: ativo.manutencoes
    }
})

const cronogramas = (state) => state.cronogramas.map((cronograma) => {
    return {
        identificador: cronograma.identificador,
        frequencia: obterDescricaoFrequencia(cronograma.frequencia),
        tipoAtivo: obterDescricaoTipoAtivo(cronograma.tipoAtivo),
        intervaloHorasUso: cronograma.intervaloHorasUso
    }
})

export default {
    ativos,
    cronogramas
}