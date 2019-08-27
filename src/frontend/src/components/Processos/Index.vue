<template>
  <div>
    <md-toolbar md-elevation="0" class="md-transparent">
      <div class="md-toolbar-section-start">
        <h1 class="md-title">Processos</h1>
      </div>

      <div class="md-toolbar-section-end">
        <md-button class="md-primary md-raised">
          <md-icon>add</md-icon>
        </md-button>
      </div>
    </md-toolbar>
    <lista-processos />
    <formulario-processo />
  </div>
</template>

<script>
import ListaProcessos from "./ListaProcessos";
import FormularioProcesso from "./FormularioProcesso";

export default {
  name: "processos",
  components: {
    ListaProcessos,
    FormularioProcesso
  }
};
</script>