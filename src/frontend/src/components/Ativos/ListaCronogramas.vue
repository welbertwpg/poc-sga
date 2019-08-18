<template>
  <div>
    <md-table :value="cronogramas">
      <md-table-toolbar>
        <div class="md-toolbar-section-start">
          <h1 class="md-title">Cronogramas</h1>
        </div>

        <div class="md-toolbar-section-end">
          <md-button class="md-primary md-raised" @click="novoCronograma">
            <md-icon>add</md-icon>
          </md-button>
        </div>
      </md-table-toolbar>

      <md-table-empty-state md-label="Nenhum cronograma encontrado">
        <md-button class="md-primary md-raised" @click="novoCronograma">Criar novo cronograma</md-button>
      </md-table-empty-state>

      <md-table-row slot="md-table-row" slot-scope="{ item }">
        <md-table-cell md-label="Identificador">{{ item.identificador }}</md-table-cell>
        <md-table-cell md-label="Frequencia">{{ item.frequencia }}</md-table-cell>
        <md-table-cell md-label="Tipo">{{ item.tipoAtivo }}</md-table-cell>
        <md-table-cell md-label="Intervalo">{{ item.intervaloHorasUso }}</md-table-cell>
        <md-table-cell md-label="Ações">
          <md-button title="Excluir" @click="removerCronograma(item)">
            <md-icon>delete</md-icon>
          </md-button>
        </md-table-cell>
      </md-table-row>
    </md-table>
    <dialog-criar-cronograma v-model="exibirCriarCronograma" />
  </div>
</template>

<script>
import DialogCriarCronograma from "./DialogCriarCronograma";
import { mapGetters, mapActions } from "vuex";

export default {
  name: "listaCronogramas",
  data: () => ({
    filtro: "",
    exibirCriarCronograma: false
  }),
  computed: {
    ...mapGetters("Ativos", ["cronogramas"])
  },
  methods: {
    novoCronograma() {
      this.exibirCriarCronograma = true;
    },
    ...mapActions("Ativos", ["atualizarCronogramas", "removerCronograma"])
  },
  async created() {
    await this.atualizarCronogramas();
  },
  components: {
    DialogCriarCronograma
  }
};
</script>

<style lang="scss" scoped>
.md-field {
  max-width: 500px;
}
</style>