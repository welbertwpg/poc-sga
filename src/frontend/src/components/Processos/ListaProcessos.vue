<template>
  <md-list>
    <md-list-item v-if="!processos.length">
      <span>Nenhum processo criado.</span>
    </md-list-item>

    <md-list-item v-for="(processo, index) in processos" v-bind:key="processo.identificador">
      <md-button title="Selecionar" @click="atualizarProcesso(processo)" class="md-list-item-text">
        <span>
          <b>{{ index + 1 }}.</b>
          {{ processo.nome }}
        </span>
      </md-button>

      <md-button title="Excluir" @click="excluir(processo)" class="md-icon-button md-list-action">
        <md-icon>delete</md-icon>
      </md-button>
    </md-list-item>
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
    ...mapActions("Processos", ["atualizarProcessos", "atualizarProcesso"])
  },
  created() {
    this.atualizarProcessos();
  }
};
</script>

<style scoped>
.md-inset {
  margin-left: 0px;
}
</style>