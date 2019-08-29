<template>
  <div>
    <md-toolbar md-elevation="0" class="md-transparent">
      <div class="md-toolbar-section-start">
        <h1 class="md-title">Processos</h1>
      </div>

      <div class="md-toolbar-section-end">
        <md-button @click="exibirPromptCriar = true" class="md-primary md-raised">
          <md-icon>add</md-icon>
        </md-button>
      </div>
    </md-toolbar>

    <lista-processos />
    <formulario-processo />

    <md-dialog-prompt
      :md-active.sync="exibirPromptCriar"
      v-model="nome"
      md-title="Informe o nome do Processo"
      md-input-maxlength="100"
      md-input-placeholder="Nome..."
      md-confirm-text="Ok"
      md-cancel-text="Cancelar"
      @md-confirm="criar"
      @md-cancel="nome = null"
    />
  </div>
</template>

<script>
import ListaProcessos from "./ListaProcessos";
import FormularioProcesso from "./FormularioProcesso";
import { mapActions } from "vuex";
import { setTimeout } from "timers";

export default {
  name: "processos",
  data: () => ({
    exibirPromptCriar: false,
    nome: null
  }),
  methods: {
    ...mapActions("Processos", ["criarNovoProcesso"]),
    criar() {
      if (this.nome == null) {
        setTimeout(() => (this.exibirPromptCriar = true), 100);
        return;
      }
      this.criarNovoProcesso(this.nome);
    }
  },
  components: {
    ListaProcessos,
    FormularioProcesso
  }
};
</script>