const dadosFluxograma = (state) => {
    let nodeDataArray = [];
    let linkDataArray = [];

    if (state.processo.etapas == null) {
        return {
            nodeDataArray,
            linkDataArray
        }
    }

    state.processo.etapas.forEach(etapa => {
        nodeDataArray.push({
            key: etapa.identificador, text: etapa.nome, color: "lightblue"
        });

        etapa.etapasSaida.forEach(saida => linkDataArray.push({ from: etapa.identificador, to: saida }));
    });

    return {
        nodeDataArray,
        linkDataArray
    }
}

export default {
    dadosFluxograma
}