<template>
  <div>
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

        <md-button
          title="Adicionar problema"
          @click="criarProblema(processo.identificador)"
          class="md-icon-button md-list-action"
        >
          <md-icon>add_alert</md-icon>
        </md-button>

        <md-button
          title="Adicionar parada"
          @click="criarParada(processo.identificador)"
          class="md-icon-button md-list-action"
        >
          <md-icon>alarm_add</md-icon>
        </md-button>

        <md-button
          title="Editar"
          @click="atualizarProcesso(processo)"
          class="md-icon-button md-list-action"
        >
          <md-icon>edit</md-icon>
        </md-button>

        <md-button
          title="Excluir"
          @click="excluirProcesso(processo)"
          class="md-icon-button md-list-action"
        >
          <md-icon>delete</md-icon>
        </md-button>
      </md-list-item>
    </md-list>

    <dialog-sga :title="'Criar problema'" v-model="exibirCriarProblema">
      <formulario-acontecimento
        :inserir="inserirProblema"
        :identificadorProcesso="identificadorProcesso"
        :aposSalvar="() => exibirCriarProblema = false"
      />
    </dialog-sga>

    <dialog-sga :title="'Criar parada'" v-model="exibirCriarParada">
      <formulario-acontecimento
        :inserir="inserirParada"
        :identificadorProcesso="identificadorProcesso"
        :aposSalvar="() => exibirCriarParada = false"
      />
    </dialog-sga>
  </div>
</template>

<script>
import DialogSga from "../DialogSga";
import FormularioAcontecimento from "./FormularioAcontecimento";
import {
  inserirParada,
  inserirProblema
} from "../../services/Processos/repositorioProcessos";
import { mapActions, mapState } from "vuex";

export default {
  name: "listaProcessos",
  data: () => ({
    identificadorProcesso: "",
    exibirCriarProblema: false,
    exibirCriarParada: false
  }),
  computed: {
    ...mapState("Processos", ["processos"])
  },
  methods: {
    inserirParada,
    inserirProblema,
    criarProblema(identificadorProcesso) {
      this.identificadorProcesso = identificadorProcesso;
      this.exibirCriarProblema = true;
    },
    criarParada(identificadorProcesso) {
      this.identificadorProcesso = identificadorProcesso;
      this.exibirCriarParada = true;
    },
    ...mapActions("Processos", [
      "atualizarProcessos",
      "atualizarProcesso",
      "excluirProcesso"
    ])
  },
  created() {
    this.atualizarProcessos();
  },
  components: {
    DialogSga,
    FormularioAcontecimento
  }
};
</script>

<style scoped>
.md-inset {
  margin-left: 0px;
}
</style>