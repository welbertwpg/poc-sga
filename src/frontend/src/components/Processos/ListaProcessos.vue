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

      <md-button title="Editar" @click="atualizarProcesso(processo)" class="md-icon-button md-list-action">
        <md-icon>edit</md-icon>
      </md-button>

      <md-button title="Excluir" @click="excluirProcesso(processo)" class="md-icon-button md-list-action">
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
    ...mapActions("Processos", ["atualizarProcessos", "atualizarProcesso", "excluirProcesso"])
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