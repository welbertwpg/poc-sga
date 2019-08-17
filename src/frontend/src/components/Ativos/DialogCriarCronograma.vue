<template>
  <md-dialog :md-close-on-esc="false" :md-click-outside-to-close="false" @md-clicked-outside="fechar" :md-active.sync="value">
    <md-dialog-title>Criar cronograma</md-dialog-title>

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
