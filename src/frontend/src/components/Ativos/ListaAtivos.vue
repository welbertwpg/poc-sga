<template>
  <div>
    <md-table :value="ativos">
      <md-table-toolbar>
        <div class="md-toolbar-section-start">
          <h1 class="md-title">Ativos</h1>
        </div>

        <div class="md-toolbar-section-end">
          <md-button class="md-primary md-raised" @click="abrirDialogCriar">
            <md-icon>add</md-icon>
          </md-button>
        </div>
      </md-table-toolbar>

      <md-table-empty-state md-label="Nenhum ativo encontrado">
        <md-button class="md-primary md-raised" @click="abrirDialogCriar">Criar novo ativo</md-button>
      </md-table-empty-state>

      <md-table-row slot="md-table-row" slot-scope="{ item }">
        <md-table-cell md-label="Patrimônio">{{ item.patrimonio }}</md-table-cell>
        <md-table-cell md-label="Nome">{{ item.nome }}</md-table-cell>
        <md-table-cell md-label="Tipo">{{ item.tipo }}</md-table-cell>
        <md-table-cell md-label="Data">{{ item.dataAquisicao }}</md-table-cell>
        <md-table-cell md-label="Observações">{{ item.observacoes }}</md-table-cell>
        <md-table-cell md-label="Ações">
          <md-button title="Criar manutenção">
            <md-icon>build</md-icon>
          </md-button>
          <md-button title="Excluir" @click="removerAtivo(item)">
            <md-icon>delete</md-icon>
          </md-button>
        </md-table-cell>
      </md-table-row>
    </md-table>
    <dialog-sga :title="'Criar ativo'" v-model="exibirCriarAtivo">
      <formulario-criar-ativo :aposSalvar="fecharDialogCriar" />
    </dialog-sga>
  </div>
</template>

<script>
import DialogSga from "./DialogSga";
import FormularioCriarAtivo from "./FormularioCriarAtivo";
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
    abrirDialogCriar() {
      this.exibirCriarAtivo = true;
    },
    fecharDialogCriar(){
      this.exibirCriarAtivo = false;
    },
    ...mapActions("Ativos", ["atualizarAtivos", "removerAtivo"])
  },
  async created() {
    await this.atualizarAtivos();
  },
  components: {
    DialogSga,
    FormularioCriarAtivo
  }
};
</script>

<style lang="scss" scoped>
.md-field {
  max-width: 500px;
}
</style>