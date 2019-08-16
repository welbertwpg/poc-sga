<template>
  <div>
    <lista-ativos class="tabela" />
  </div>
</template>

<script>
import ListaAtivos from "./ListaAtivos";

export default {
  name: "ativos",
  components: {
    ListaAtivos
  }
};
</script>