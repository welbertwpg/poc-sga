<template>
  <div v-if="dadosFluxograma.nodeDataArray.length">
    <fluxograma ref="diag" :model-data="dadosFluxograma" class="fluxograma"></fluxograma>
    <div class="md-layout botoes">
      <md-button @click="adicionarEtapa" class="md-layout-item md-raised md-primary">Adicionar etapa</md-button>
      <md-button @click="salvar" class="md-layout-item md-raised md-primary">Salvar</md-button>
    </div>
  </div>
</template>

<script>
import Fluxograma from "./Fluxograma";
import uuid from "uuid/v4";
import { mapGetters } from "vuex";

export default {
  computed: {
    ...mapGetters("Processos", ["dadosFluxograma"])
  },
  methods: {
    model: function() {
      return this.$refs.diag.model();
    },
    adicionarEtapa() {
      let model = this.model();
      model.startTransaction();
      let data = { key: uuid(), text: "Novo", color: "lightblue", tipo: 1 };
      model.addNodeData(data);
      model.commitTransaction("added Node");
    },
    salvar() {
      let modelo = this.model();
      let processo = {};
      console.log(modelo.nodeDataArray);
      console.log(modelo.linkDataArray);
    }
  },
  components: {
    Fluxograma
  }
};
</script>

<style scoped>
.fluxograma {
  border: solid 1px black;
  width: 100%;
  height: 400px;
}

.botoes {
  max-width: 500px;
}
</style>