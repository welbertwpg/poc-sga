<template>
  <div>
    <div class="md-title">Processos</div>
    <lista-processos />
  </div>
</template>

<script>
import ListaProcessos from "./ListaProcessos";

export default {
  name: "processos",
  components: {
    ListaProcessos
  }
};
</script>