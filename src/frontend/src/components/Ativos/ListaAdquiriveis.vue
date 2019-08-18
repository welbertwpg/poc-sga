<template>
  <md-list>
    <md-list-item v-for="adquirivel in adquiriveis" v-bind:key="adquirivel.identificador">
      <div class="md-list-item-text">
        <span>{{ adquirivel.nome }}</span>
        <span>{{ adquirivel.descricao }}</span>
      </div>

      <md-button @click="adquirir(adquirivel.identificador)" class="md-icon-button md-list-action">
        <md-icon class="md-primary">add_shopping_cart</md-icon>
      </md-button>
    </md-list-item>
  </md-list>
</template>

<script>
import { mapState, mapActions } from "vuex";

export default {
  name: "listaAdquiriveis",
  props: {
    aposSalvar: {
      type: Function
    }
  },
  methods: {
    async adquirir(identificador) {
      await this.adquirirAtivo(identificador);
      if (this.aposSalvar) this.aposSalvar();
    },
    ...mapActions("Ativos", ["atualizarAdquiriveis", "adquirirAtivo"])
  },
  computed: {
    ...mapState("Ativos", ["adquiriveis"])
  },
  async created() {
    this.atualizarAdquiriveis();
  }
};
</script>