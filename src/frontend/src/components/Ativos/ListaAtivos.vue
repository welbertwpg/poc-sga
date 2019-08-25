<template>
  <div>
    <md-toolbar md-elevation="0" class="md-transparent">
      <div class="md-toolbar-section-start">
        <h1 class="md-title">Ativos</h1>
      </div>

      <div class="md-toolbar-section-end">
        <md-button class="md-primary md-raised" @click="abrirDialogCriar">
          <md-icon>add</md-icon>
        </md-button>
      </div>
    </md-toolbar>
    <md-list :md-expand-single="true">
      <md-list-item v-if="!ativos.length">
        <span>Nenhuma ativo.</span>
      </md-list-item>

      <md-list-item md-expand v-for="ativo in ativos" v-bind:key="ativo.identificador">
        <div class="md-list-item-text">
          <span>{{ ativo.nome }}</span>
          <span>{{ ativo.patrimonio }}</span>
          <span>{{ ativo.tipo }}</span>
          <span>{{ ativo.dataAquisicao }}</span>
          <span>{{ ativo.observacoes }}</span>
        </div>

        <md-list slot="md-expand">
          <md-list-item class="md-inset">
            <md-button title="Visualizar manutenções" @click="abrirDialogManutencoes(ativo)">
              <md-icon>search</md-icon>
              <span>Visualizar manutenções</span>
            </md-button>
          </md-list-item>
          <md-list-item class="md-inset">
            <md-button title="Criar manutenção" @click="abrirDialogCriarManutencao(ativo)">
              <md-icon>add</md-icon>
              <span>Criar manutenção</span>
            </md-button>
          </md-list-item>
          <md-list-item class="md-inset">
            <md-button title="Excluir" @click="removerAtivo(ativo)">
              <md-icon>delete</md-icon>
              <span>Excluir</span>
            </md-button>
          </md-list-item>
        </md-list>
      </md-list-item>
    </md-list>

    <dialog-sga :title="'Manutenções'" v-model="exibirManutencoes">
      <lista-manutencoes :ativo="ativoManutencao" />
    </dialog-sga>
    <dialog-sga :title="'Criar manutenção'" v-model="exibirCriarManutencao">
      <formulario-criar-manutencao
        :ativo="ativoManutencao"
        :aposSalvar="fecharDialogCriarManutencao"
      />
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
.md-list-item-text {
  max-width: 300px;
  overflow-wrap: break-word;
}
</style>