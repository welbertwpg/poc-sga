<template>
  <div>
    <md-toolbar md-elevation="0" class="md-transparent">
      <div class="md-toolbar-section-start">
        <h1 class="md-title">Cronogramas</h1>
      </div>

      <div class="md-toolbar-section-end">
        <md-button class="md-primary md-raised" @click="abrirDialogCriar">
          <md-icon>add</md-icon>
        </md-button>
      </div>
    </md-toolbar>
    <md-list>
      <md-list-item v-if="!cronogramas.length">
        <span>Nenhum cronograma.</span>
      </md-list-item>

      <md-list-item v-for="cronograma in cronogramas" v-bind:key="cronograma.identificador">
        <div class="md-list-item-text">
          <span>{{ cronograma.identificador }}</span>
          <span>{{ cronograma.frequencia }}</span>
          <span>{{ cronograma.tipoAtivo }}</span>
          <span>{{ cronograma.intervaloHorasUso }}</span>
        </div>

        <md-button class="md-icon-button md-list-action" title="Excluir" @click="removerCronograma(cronograma)">
          <md-icon>delete</md-icon>
        </md-button>
      </md-list-item>
    </md-list>

    <dialog-sga :title="'Criar cronograma'" v-model="exibirCriarCronograma">
      <formulario-criar-cronograma :aposSalvar="fecharDialogCriar" />
    </dialog-sga>
  </div>
</template>

<script>
import DialogSga from "../DialogSga";
import FormularioCriarCronograma from "./FormularioCriarCronograma";
import { mapGetters, mapActions } from "vuex";

export default {
  name: "listaCronogramas",
  data: () => ({
    filtro: "",
    exibirCriarCronograma: false
  }),
  computed: {
    ...mapGetters("Ativos", ["cronogramas"])
  },
  methods: {
    abrirDialogCriar() {
      this.exibirCriarCronograma = true;
    },
    fecharDialogCriar() {
      this.exibirCriarCronograma = false;
    },
    ...mapActions("Ativos", ["atualizarCronogramas", "removerCronograma"])
  },
  async created() {
    await this.atualizarCronogramas();
  },
  components: {
    DialogSga,
    FormularioCriarCronograma
  }
};
</script>

<style lang="scss" scoped>
.md-field {
  max-width: 500px;
}
</style>