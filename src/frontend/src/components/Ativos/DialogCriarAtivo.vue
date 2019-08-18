<template>
  <md-dialog :md-close-on-esc="false" :md-click-outside-to-close="false" @md-clicked-outside="fechar" :md-active.sync="value">
    <md-toolbar md-elevation="0">
      <div class="md-toolbar-section-start">
        <h1 class="md-title">Criar ativo</h1>
      </div>

      <div class="md-toolbar-section-end">
        <md-button title="Criar manutenção" @click="fechar">
          <md-icon>close</md-icon>
        </md-button>
      </div>
    </md-toolbar>

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
