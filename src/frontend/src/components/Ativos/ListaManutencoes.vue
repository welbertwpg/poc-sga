<template>
  <div>
    <md-list>
      <md-list-item v-for="manutencao in ativo.manutencoes" v-bind:key="manutencao.identificador">
        
        <div class="md-list-item-text">
          <span>{{ manutencao.dataHora }}</span>
          <span>{{ manutencao.tipo }}</span>
        </div>
        
        <md-icon v-if="manutencao.realizada" class="md-primary">check</md-icon>

        <md-button class="md-icon-button md-list-action" v-if="!manutencao.realizada">
          <md-icon>check</md-icon>
        </md-button>
      </md-list-item>
    </md-list>
  </div>
</template>

<script>
export default {
  name: "listaManutencoes",
  props: {
    ativo: {
      type: Object,
      required: true
    }
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