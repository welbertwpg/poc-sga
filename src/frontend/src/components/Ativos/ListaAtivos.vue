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
          <md-button title="Visualizar manutenções" @click="abrirDialogManutencoes(item)">
            <md-icon>search</md-icon>
            <md-icon>build</md-icon>
          </md-button>
          <md-button title="Criar manutenção" @click="abrirDialogCriarManutencao(item)">
            <md-icon>add</md-icon>
            <md-icon>build</md-icon>
          </md-button>
          <md-button title="Excluir" @click="removerAtivo(item)">
            <md-icon>delete</md-icon>
          </md-button>
        </md-table-cell>
      </md-table-row>
    </md-table>
    <dialog-sga :title="'Manutenções'" v-model="exibirManutencoes">
      <lista-manutencoes :ativo="ativoManutencao" />
    </dialog-sga>
    <dialog-sga :title="'Criar manutenção'" v-model="exibirCriarManutencao">
      <formulario-criar-manutencao :ativo="ativoManutencao" :aposSalvar="fecharDialogCriarManutencao" />
    </dialog-sga>
    <dialog-sga :title="'Criar ativo'" v-model="exibirCriarAtivo">
      <md-tabs>
        <md-tab id="criar" md-label="Criar">
          <formulario-criar-ativo :aposSalvar="fecharDialogCriar" />
        </md-tab>
        <md-tab id="adquirir" md-label="Adquirir">
          <lista-adquiriveis :aposSalvar="fecharDialogCriar" />
        </md-tab>
      </md-tabs>
    </dialog-sga>
  </div>
</template>

<script>
import DialogSga from "./DialogSga";
import FormularioCriarAtivo from "./FormularioCriarAtivo";
import ListaAdquiriveis from "./ListaAdquiriveis";
import FormularioCriarManutencao from "./FormularioCriarManutencao";
import ListaManutencoes from "./ListaManutencoes";
import { mapGetters, mapActions } from "vuex";

export default {
  name: "listaAtivos",
  data: () => ({
    filtro: "",
    exibirCriarAtivo: false,
    exibirCriarManutencao: false,
    exibirManutencoes: false,
    ativoManutencao: null
  }),
  computed: {
    ...mapGetters("Ativos", ["ativos"])
  },
  methods: {
    abrirDialogCriar() {
      this.exibirCriarAtivo = true;
    },
    fecharDialogCriar() {
      this.exibirCriarAtivo = false;
    },
    abrirDialogManutencoes(ativo) {
      this.ativoManutencao = ativo;
      this.exibirManutencoes = true;
    },
    abrirDialogCriarManutencao(ativo) {
      this.ativoManutencao = ativo;
      this.exibirCriarManutencao = true;
    },
    fecharDialogCriarManutencao() {
      this.ativoManutencao = null;
      this.exibirCriarManutencao = false;
    },
    ...mapActions("Ativos", ["atualizarAtivos", "removerAtivo"])
  },
  async created() {
    await this.atualizarAtivos();
  },
  components: {
    DialogSga,
    FormularioCriarAtivo,
    ListaAdquiriveis,
    FormularioCriarManutencao,
    ListaManutencoes
  }
};
</script>

<style lang="scss" scoped>
.md-field {
  max-width: 500px;
}
</style>