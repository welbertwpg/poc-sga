<template>
  <fluxograma v-if="dadosFluxograma.nodeDataArray.length" ref="diag" :model-data="dadosFluxograma" class="fluxograma"></fluxograma>
</template>

<script>
import Fluxograma from "./Fluxograma";
import { mapGetters } from "vuex";

export default {
  computed: {
    ...mapGetters("Processos", ["dadosFluxograma"])
  },
  components: {
    Fluxograma
  }
};
</script>

<style scoped>
.fluxograma {
  border: solid 1px black;
  width: 100%;
  height: 400px;
}
</style>