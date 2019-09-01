<template>
  <form novalidate class="md-layout" @submit.prevent="validar">
    <div class="md-layout-item md-small-size-100">
      <div class="md-layout md-gutter">
        <div class="md-layout-item md-small-size-100">
          <md-field :class="obterClasseValidacao('turno')">
            <label for="turno">Turno</label>
            <md-select name="turno" id="turno" v-model="form.turno" md-dense :disabled="enviando">
              <md-option></md-option>
              <md-option value="1">Manhã</md-option>
              <md-option value="2">Tarde</md-option>
              <md-option value="3">Noite</md-option>
            </md-select>
            <span class="md-error">O turno é obrigatório</span>
          </md-field>
        </div>

        <div class="md-layout-item md-small-size-100">
          <md-field :class="obterClasseValidacao('etapa')">
            <label for="etapa">Etapa</label>
            <md-select name="etapa" id="etapa" v-model="form.etapa" md-dense :disabled="enviando">
              <md-option></md-option>
              <md-option
                v-for="etapa in etapas"
                :key="etapa.identificador"
                :value="etapa.identificador"
              >{{etapa.nome}}</md-option>
            </md-select>
          </md-field>
        </div>
      </div>

      <div class="md-layout md-gutter">
        <div class="md-layout-item md-small-size-100">
          <md-field :class="obterClasseValidacao('descricao')">
            <label for="descricao">Descrição</label>
            <md-textarea
              id="descricao"
              name="descricao"
              v-model="form.descricao"
              md-autogrow
              :disabled="enviando"
            />
          </md-field>
        </div>
      </div>

      <div class="md-layout md-gutter md-layout-item md-alignment-center-right">
        <md-button type="submit" class="md-primary md-raised" :disabled="enviando">Salvar</md-button>
      </div>

      <md-progress-bar md-mode="indeterminate" v-if="enviando" />
    </div>
  </form>
</template>

<script>
import { validationMixin } from "vuelidate";
import { required } from "vuelidate/lib/validators";
import repositorioProcessos from "../../services/Processos/repositorioProcessos";

export default {
  name: "formularioCriarParada",
  mixins: [validationMixin],
  props: {
    inserir: {
      type: Function,
      required: true
    },
    identificadorProcesso: {
      type: String,
      required: true
    },
    aposSalvar: {
      type: Function
    }
  },
  data: () => ({
    etapas: [],
    form: {
      turno: null,
      descricao: null,
      etapa: null
    },
    enviando: false
  }),
  validations: {
    form: {
      turno: {
        required
      },
      descricao: {
        required
      }
    }
  },
  methods: {
    obterClasseValidacao(fieldName) {
      const field = this.$v.form[fieldName];

      if (field) {
        return {
          "md-invalid": field.$invalid && field.$dirty
        };
      }
    },
    salvar() {
      this.enviando = true;

      const novoRegistro = {
        identificadorProcesso: this.identificadorProcesso,
        turno: this.form.turno,
        descricao: this.form.descricao,
        identificadorEtapa: this.form.etapa,
        data: new Date()
      };

      this.inserir(novoRegistro).then(resposta => {
        this.enviando = false;
        if (resposta.status == 200 && this.aposSalvar) this.aposSalvar();
      });
    },
    validar() {
      this.$v.$touch();

      if (!this.$v.$invalid) this.salvar();
    }
  },
  async mounted() {
    const resposta = await repositorioProcessos.obter(
      this.identificadorProcesso
    );
    if (resposta.status == 200) this.etapas = resposta.data.etapas;
  }
};
</script>

<style lang="scss" scoped>
.md-progress-bar {
  position: absolute;
  top: 0;
  right: 0;
  left: 0;
}
</style>