<template>
  <div>
    <md-table :value="ativos">
      <md-table-toolbar>
        <div class="md-toolbar-section-start">
          <h1 class="md-title">Ativos</h1>
        </div>

        <div class="md-toolbar-section-end">
          <md-button class="md-primary md-raised" @click="novoAtivo">
            <md-icon>add</md-icon>
          </md-button>
        </div>
      </md-table-toolbar>

      <md-table-empty-state md-label="Nenhum ativo encontrado">
        <md-button class="md-primary md-raised" @click="novoAtivo">Criar novo ativo</md-button>
      </md-table-empty-state>

      <md-table-row slot="md-table-row" slot-scope="{ item }">
        <md-table-cell md-label="Patrimônio">{{ item.patrimonio }}</md-table-cell>
        <md-table-cell md-label="Nome">{{ item.nome }}</md-table-cell>
        <md-table-cell md-label="Tipo">{{ item.tipo }}</md-table-cell>
        <md-table-cell md-label="Data">{{ item.dataAquisicao }}</md-table-cell>
        <md-table-cell md-label="Observações">{{ item.observacoes }}</md-table-cell>
        <md-table-cell md-label="Ações">
          <md-button @click="removerAtivo(item)">
            <md-icon>delete</md-icon>
          </md-button>
        </md-table-cell>
      </md-table-row>
    </md-table>
    <dialog-criar-ativo v-model="exibirCriarAtivo" />
  </div>
</template>

<script>
import DialogCriarAtivo from "./DialogCriarAtivo";
import { mapGetters, mapActions } from "vuex";

export default {
  name: "listaAtivos",
  data: () => ({
    filtro: "",
    exibirCriarAtivo: false
  }),
  computed: {
    ...mapGetters("Ativos", ["ativos"])
  },
  methods: {
    novoAtivo() {
      this.exibirCriarAtivo = true;
    },
    ...mapActions("Ativos", ["atualizarAtivos", "removerAtivo"])
  },
  async created() {
    await this.atualizarAtivos();
  },
  components: {
    DialogCriarAtivo
  }
};
</script>

<style lang="scss" scoped>
.md-field {
  max-width: 500px;
}
</style>