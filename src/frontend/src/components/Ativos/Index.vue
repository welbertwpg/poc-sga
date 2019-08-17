<template>
  <div>
    <lista-ativos />
    <lista-cronogramas />
  </div>
</template>

<script>
import ListaAtivos from './ListaAtivos';
import ListaCronogramas from './ListaCronogramas' 

export default {
  name: 'ativos',
  components: {
    ListaAtivos,
    ListaCronogramas
  }
};
</script>