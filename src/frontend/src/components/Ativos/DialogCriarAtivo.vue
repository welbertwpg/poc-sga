<template>
  <md-dialog :md-close-on-esc="false" :md-click-outside-to-close="false" @md-clicked-outside="fechar" :md-active.sync="value">
    <md-dialog-title>Criar ativo</md-dialog-title>

    <md-dialog-content>
      <formulario-criar-ativo :aposSalvar="fechar" />
    </md-dialog-content>
  </md-dialog>
</template>

<script>
import FormularioCriarAtivo from "./FormularioCriarAtivo";

export default {
  name: "criarAtivo",
  props: ["value"],
  methods: {
    fechar() {
      this.$emit("input", this.false);
    }
  },
  components: {
    FormularioCriarAtivo
  }
};
</script>

<style lang="scss" scoped>
.md-dialog {
  max-width: 768px;
}
</style>
