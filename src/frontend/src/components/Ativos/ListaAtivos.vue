<template>
  <div>
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
        <md-table-cell md-label="Observações" md-sort-by="observacoes">{{ item.observacoes }}</md-table-cell>
        <md-table-cell md-label="Ações">
          <md-button @click="excluir(item)">
            <md-icon>delete</md-icon>
          </md-button>
        </md-table-cell>
      </md-table-row>
    </md-table>
    <dialog-criar-ativo v-model="exibirCriarAtivo" />
  </div>
</template>

<script>
import repositorioAtivos from "../../services/Ativos/repositorioAtivos";
import DialogCriarAtivo from "./DialogCriarAtivo";

const toLower = text => text.toString().toLowerCase();

export default {
  name: "listaAtivos",
  data: () => ({
    filtro: "",
    resultadoPesquisa: [],
    exibirCriarAtivo: false,
    ativos: []
  }),
  methods: {
    novoAtivo() {
      this.exibirCriarAtivo = true;
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
    },
    async excluir(ativo) {
      await repositorioAtivos.excluir(ativo.identificador);
      const index = this.ativos.indexOf(ativo);
      this.ativos.splice(index, 1);
    }
  },
  async created() {
    this.ativos = await this.obterAtivos();
    this.resultadoPesquisa = this.ativos;
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