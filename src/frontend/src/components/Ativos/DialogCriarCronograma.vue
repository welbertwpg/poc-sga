<template>
  <md-dialog :md-close-on-esc="false" :md-click-outside-to-close="false" @md-clicked-outside="fechar" :md-active.sync="value">
    <md-toolbar md-elevation="0">
      <div class="md-toolbar-section-start">
        <h1 class="md-title">Criar cronograma</h1>
      </div>

      <div class="md-toolbar-section-end">
        <md-button title="Criar manutenção" @click="fechar">
          <md-icon>close</md-icon>
        </md-button>
      </div>
    </md-toolbar>

    <md-dialog-content>
      <formulario-criar-cronograma :aposSalvar="fechar" />
    </md-dialog-content>
  </md-dialog>
</template>

<script>
import FormularioCriarCronograma from "./FormularioCriarCronograma";

export default {
  name: "criarCronograma",
  props: ["value"],
  methods: {
    fechar() {
      this.$emit("input", this.false);
    }
  },
  components: {
    FormularioCriarCronograma
  }
};
</script>

<style lang="scss" scoped>
.md-dialog {
  max-width: 768px;
}
</style>
