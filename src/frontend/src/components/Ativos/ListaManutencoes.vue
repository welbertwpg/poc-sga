<template>
  <div>
    <md-list>
      <md-list-item v-if="!ativo.manutencoes.length">
        <span>Nenhuma manutenção para este ativo</span>
      </md-list-item>

      <md-list-item v-for="manutencao in ativo.manutencoes" v-bind:key="manutencao.identificador">
        <div class="md-list-item-text">
          <span>{{ manutencao.dataHora }}</span>
          <span>{{ manutencao.tipo }}</span>
        </div>

        <md-icon v-if="manutencao.realizada" class="md-primary">check</md-icon>

        <md-button
          v-if="!manutencao.realizada"
          @click="realizar(manutencao)"
          class="md-icon-button md-list-action"
        >
          <md-icon>check</md-icon>
        </md-button>
      </md-list-item>
    </md-list>
  </div>
</template>

<script>
import { mapActions } from "vuex";

export default {
  name: "listaManutencoes",
  props: {
    ativo: {
      type: Object,
      required: true
    }
  },
  methods: {
    realizar(manutencao) {
        this.realizarManutencao({identificadorAtivo: this.ativo.identificador, identificadorManutencao: manutencao.identificador});
        manutencao.realizada = true;
    },
    ...mapActions("Ativos", ["realizarManutencao"])
  }
};
</script>

<style lang="scss" scoped>
.md-list {
  min-width: 320px;
  max-width: 100%;
  display: inline-block;
  vertical-align: top;
}
</style>