<template>
  <div v-if="dadosFluxograma.nodeDataArray.length">
    <fluxograma ref="diag" :model-data="dadosFluxograma" class="fluxograma"></fluxograma>
    <div class="md-layout botoes">
      <md-button @click="adicionarEtapa" class="md-layout-item md-raised md-primary">Adicionar etapa</md-button>
      <md-button @click="salvar" class="md-layout-item md-raised md-primary">Salvar</md-button>
    </div>
    <md-snackbar
      :md-position="'center'"
      :md-duration="4000"
      :md-active.sync="mostrarMensagem"
      md-persistent
    >
      <span>{{mensagem}}</span>
    </md-snackbar>
  </div>
</template>

<script>
import Fluxograma from "./Fluxograma";
import uuid from "uuid/v4";
import { mapGetters, mapActions } from "vuex";

export default {
  computed: {
    ...mapGetters("Processos", ["dadosFluxograma"])
  },
  data() {
    return {
      mensagem: "",
      mostrarMensagem: false
    };
  },
  methods: {
    ...mapActions("Processos", ["salvarProcesso"]),
    model: function() {
      return this.$refs.diag.model();
    },
    adicionarEtapa() {
      const model = this.model();
      model.startTransaction();
      const data = { key: uuid(), text: "Novo", color: "lightblue", tipo: 1 };
      model.addNodeData(data);
      model.commitTransaction("added Node");
    },
    async salvar() {
      const modelo = this.model();
      const etapas = modelo.nodeDataArray.map(node => ({
        identificador: node.key,
        nome: node.text,
        tipo: node.tipo,
        etapasSaida: modelo.linkDataArray
          .filter(link => link.from == node.key)
          .map(link => link.to)
      }));

      try {
        await this.salvarProcesso(etapas);
      } catch (erro) {
        this.mensagem = erro.toString();
        this.mostrarMensagem = true;
      }
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