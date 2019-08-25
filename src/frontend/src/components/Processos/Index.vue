<template>
  <div>
    <div class="md-title">Processos</div>
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