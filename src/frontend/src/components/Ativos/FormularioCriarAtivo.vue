<template>
  <form novalidate class="md-layout" @submit.prevent="validar">
    <div class="md-layout-item md-small-size-100">
      <div class="md-layout md-gutter">
        <div class="md-layout-item md-small-size-100">
          <md-field :class="obterClasseValidacao('patrimonio')">
            <label for="patrimonio">Patrimônio</label>
            <md-input
              name="patrimonio"
              id="patrimonio"
              v-model="form.patrimonio"
              :disabled="enviando"
            />
            <span class="md-error" v-if="!$v.form.patrimonio.required">O patrimônio é obrigatório</span>
            <span class="md-error" v-else-if="!$v.form.patrimonio.minlength">Patrimônio inválido</span>
          </md-field>
        </div>

        <div class="md-layout-item md-small-size-100">
          <md-field :class="obterClasseValidacao('nome')">
            <label for="nome">Nome</label>
            <md-input name="nome" id="nome" v-model="form.nome" :disabled="enviando" />
            <span class="md-error" v-if="!$v.form.nome.required">O nome é obrigatório</span>
            <span class="md-error" v-else-if="!$v.form.nome.minlength">Nome inválido</span>
          </md-field>
        </div>
      </div>

      <div class="md-layout md-gutter">
        <div class="md-layout-item md-small-size-100">
          <md-field :class="obterClasseValidacao('tipo')">
            <label for="tipo">Tipo</label>
            <md-select name="tipo" id="tipo" v-model="form.tipo" md-dense :disabled="enviando">
              <md-option></md-option>
              <md-option value="1">Equipamento</md-option>
              <md-option value="2">Máquina</md-option>
              <md-option value="3">Insumo</md-option>
            </md-select>
            <span class="md-error">O tipo é obrigatório</span>
          </md-field>
        </div>

        <div class="md-layout-item md-small-size-100">
          <md-field :class="obterClasseValidacao('mediaHorasUsoDiariamente')">
            <label for="mediaHorasUsoDiariamente">Horas de uso(Diário)</label>
            <md-input
              type="number"
              id="mediaHorasUsoDiariamente"
              name="mediaHorasUsoDiariamente"
              v-model="form.mediaHorasUsoDiariamente"
              :disabled="enviando"
            />
            <span
              class="md-error"
              v-if="!$v.form.mediaHorasUsoDiariamente.required"
            >Média de horas de uso obrigatório</span>
            <span
              class="md-error"
              v-else-if="!$v.form.mediaHorasUsoDiariamente.between"
            >Média de horas de uso inválida</span>
          </md-field>
        </div>
      </div>

      <div class="md-layout md-gutter">
        <div class="md-layout-item md-size-50 md-small-size-100">
          <md-datepicker
            :class="obterClasseValidacao('dataAquisicao')"
            v-model="form.dataAquisicao"
            md-dense
            :disabled="enviando"
          >
            <label>Data de aquisição</label>
            <span
              v-if="!$v.form.dataAquisicao.required"
              class="md-error"
            >A data de aquisição é obrigatória</span>
          </md-datepicker>
        </div>
      </div>

      <div class="md-layout md-gutter">
        <div class="md-layout-item md-small-size-100">
          <md-field :class="obterClasseValidacao('observacoes')">
            <label for="observacoes">Observações</label>
            <md-textarea
              id="observacoes"
              name="observacoes"
              v-model="form.observacoes"
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
import { required, between, minLength } from "vuelidate/lib/validators";
import repositorioAtivos from "../../services/Ativos/repositorioAtivos";

export default {
  name: "FormValidation",
  mixins: [validationMixin],
  props: {
    aposSalvar: {
      type: Function
    }
  },
  data: () => ({
    form: {
      patrimonio: null,
      nome: null,
      tipo: null,
      mediaHorasUsoDiariamente: null,
      dataAquisicao: null,
      observacoes: null
    },
    enviando: false
  }),
  validations: {
    form: {
      patrimonio: {
        required,
        minLength: minLength(3)
      },
      nome: {
        required,
        minLength: minLength(3)
      },
      mediaHorasUsoDiariamente: {
        required,
        between: between(1, 24)
      },
      tipo: {
        required
      },
      dataAquisicao: {
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
      repositorioAtivos.inserir(this.form).then(() => {
        this.enviando = false;
        if (this.aposSalvar) this.aposSalvar();
      });
    },
    validar() {
      this.$v.$touch();

      if (!this.$v.$invalid) {
        this.salvar();
      }
    }
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