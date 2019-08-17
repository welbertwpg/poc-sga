<template>
  <md-table v-model="resultadoPesquisa" md-sort="nome" md-sort-order="asc">
    <md-table-toolbar>
      <div class="md-toolbar-section-start">
        <h1 class="md-title">Ativos</h1>
      </div>

      <div class="md-toolbar-section-end">
        <md-field>
          <md-input placeholder="Pesquisar por nome..." v-model="filtro" @input="filtrarPorNome" />
        </md-field>
        <md-button class="md-primary md-raised" @click="novoAtivo">
          <md-icon>add</md-icon>
        </md-button>
      </div>
    </md-table-toolbar>

    <md-table-empty-state
      md-label="Nenhum ativo encontrado"
      :md-description="`Nenhum ativo encontrado para o termo '${filtro}'. Tente usar outro termo ou crie um novo ativo.`"
    >
      <md-button class="md-primary md-raised" @click="novoAtivo">Criar novo ativo</md-button>
    </md-table-empty-state>

    <md-table-row slot="md-table-row" slot-scope="{ item }">
      <md-table-cell md-label="Patrimônio" md-sort-by="patrimonio">{{ item.patrimonio }}</md-table-cell>
      <md-table-cell md-label="Nome" md-sort-by="nome">{{ item.nome }}</md-table-cell>
      <md-table-cell md-label="Tipo" md-sort-by="tipo">{{ item.tipo }}</md-table-cell>
      <md-table-cell md-label="Data" md-sort-by="dataAquisicao">{{ item.dataAquisicao }}</md-table-cell>
    </md-table-row>
  </md-table>
</template>

<script>
import repositorioAtivos from "../../services/Ativos/repositorioAtivos";

const toLower = text => text.toString().toLowerCase();

export default {
  name: "listaAtivos",
  data: () => ({
    filtro: '',
    resultadoPesquisa: [],
    ativos: []
  }),
  methods: {
    novoAtivo() {
      window.alert("Noop");
    },
    filtrarPorNome() {
      if (this.filtro) {
        this.resultadoPesquisa = this.ativos.filter(item =>
          toLower(item.nome).includes(toLower(this.filtro))
        );
      } else this.resultadoPesquisa = this.ativos;
    },
    async obterAtivos() {
      const resposta = await repositorioAtivos.obter();
      if (resposta.status == 200) return resposta.data;
    }
  },
  async created() {
    this.ativos = await this.obterAtivos();
    this.resultadoPesquisa = this.ativos;
  }
};
</script>

<style lang="scss" scoped>
.md-field {
  max-width: 500px;
}
</style>