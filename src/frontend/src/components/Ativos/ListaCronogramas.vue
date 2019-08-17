<template>
  <md-table v-model="resultadoPesquisa" md-sort="nome" md-sort-order="asc">
    <md-table-toolbar>
      <div class="md-toolbar-section-start">
        <h1 class="md-title">Cronogramas</h1>
      </div>

      <div class="md-toolbar-section-end">
        <md-field>
          <md-input placeholder="Pesquisar por nome..." v-model="filtro" @input="filtrarPorNome" />
        </md-field>
        <md-button class="md-primary md-raised" @click="novoCronograma">
          <md-icon>add</md-icon>
        </md-button>
      </div>
    </md-table-toolbar>

    <md-table-empty-state
      md-label="Nenhum cronograma encontrado"
      :md-description="`Nenhum cronograma encontrado para o termo '${filtro}'. Tente usar outro termo ou crie um novo cronograma.`"
    >
      <md-button class="md-primary md-raised" @click="novoCronograma">Criar novo cronograma</md-button>
    </md-table-empty-state>

    <md-table-row slot="md-table-row" slot-scope="{ item }">
      <md-table-cell md-label="Identificador" md-sort-by="identificador">{{ item.identificador }}</md-table-cell>
      <md-table-cell md-label="Frequencia" md-sort-by="frequencia">{{ item.frequencia }}</md-table-cell>
      <md-table-cell md-label="Tipo" md-sort-by="tipoAtivo">{{ item.tipoAtivo }}</md-table-cell>
      <md-table-cell md-label="Intervalo" md-sort-by="intervaloHorasUso">{{ item.intervaloHorasUso }}</md-table-cell>
    </md-table-row>
  </md-table>
</template>

<script>
import repositorioCronogramas from "../../services/Ativos/repositorioCronogramas";

const toLower = text => text.toString().toLowerCase();

export default {
  name: "listaCronogramas",
  data: () => ({
    filtro: '',
    resultadoPesquisa: [],
    cronogramas: []
  }),
  methods: {
    novoCronograma() {
      window.alert("Noop");
    },
    filtrarPorNome() {
      if (this.filtro) {
        this.resultadoPesquisa = this.cronogramas.filter(item =>
          toLower(item.nome).includes(toLower(this.filtro))
        );
      } else this.resultadoPesquisa = this.cronogramas;
    },
    async obterCronogramas() {
      const resposta = await repositorioCronogramas.obter();
      if (resposta.status == 200) return resposta.data;
    }
  },
  async created() {
    this.cronogramas = await this.obterCronogramas();
    this.resultadoPesquisa = this.cronogramas;
  }
};
</script>

<style lang="scss" scoped>
.md-field {
  max-width: 500px;
}
</style>