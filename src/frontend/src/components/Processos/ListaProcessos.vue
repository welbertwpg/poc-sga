<template>
  <md-list>
    <md-list-item v-if="!processos.length">
      <span>Nenhum processo criado.</span>
    </md-list-item>

    <md-list-item v-for="(processo, index) in processos" v-bind:key="processo.identificador">
      <div class="md-list-item-text">
        <span>
          <b>{{ index + 1 }}.</b>
          {{ processo.nome }}
        </span>
      </div>

      <md-button title="Editar" @click="editar(processo)" class="md-icon-button md-list-action">
        <md-icon>edit</md-icon>
      </md-button>
      <md-button title="Excluir" @click="excluir(processo)" class="md-icon-button md-list-action">
        <md-icon>delete</md-icon>
      </md-button>
    </md-list-item>

    <md-divider class="md-inset"></md-divider>
  </md-list>
</template>

<script>
import { mapActions, mapState } from "vuex";

export default {
  name: "listaProcessos",
  computed: {
    ...mapState("Processos", ["processos"])
  },
  methods: {
    editar() {},
    excluir() {},
    ...mapActions("Processos", ["atualizarProcessos"])
  },
  created() {
    this.atualizarProcessos();
  }
};
</script>

<style scoped>
.md-list {
  width: 400px;
  display: inline-block;
  vertical-align: top;
}

.md-inset {
  margin-left: 0px;
}
</style>