<template>
  <form novalidate class="md-layout" @submit.prevent="validar">
    <div class="md-layout-item md-small-size-100">
      <div class="md-layout md-gutter">
        <div class="md-layout-item md-small-size-100">
          <md-field :class="obterClasseValidacao('frequencia')">
            <label for="frequencia">Frequência</label>
            <md-select
              name="frequencia"
              id="frequencia"
              v-model="form.frequencia"
              md-dense
              :disabled="enviando"
            >
              <md-option></md-option>
              <md-option value="1">Diária</md-option>
              <md-option value="2">Semanal</md-option>
              <md-option value="3">Mensal</md-option>
              <md-option value="4">Anual</md-option>
              <md-option value="5">Intervalo</md-option>
            </md-select>
            <span class="md-error">A frequencia é obrigatória</span>
          </md-field>
        </div>

        <div class="md-layout-item md-small-size-100">
          <md-field :class="obterClasseValidacao('tipoAtivo')">
            <label for="tipoAtivo">Tipo de ativo</label>
            <md-select
              name="tipoAtivo"
              id="tipoAtivo"
              v-model="form.tipoAtivo"
              md-dense
              :disabled="enviando"
            >
              <md-option></md-option>
              <md-option value="1">Equipamento</md-option>
              <md-option value="2">Máquina</md-option>
              <md-option value="3">Insumo</md-option>
            </md-select>
            <span class="md-error">O tipo de ativo é obrigatório</span>
          </md-field>
        </div>
      </div>

      <div class="md-layout md-gutter" v-if="form.frequencia == '5'">
        <div class="md-layout-item md-small-size-100">
          <md-field :class="obterClasseValidacao('intervaloHorasUso')">
            <label for="intervaloHorasUso">Intervalo (horas)</label>
            <md-input
              type="number"
              id="intervaloHorasUso"
              name="intervaloHorasUso"
              v-model="form.intervaloHorasUso"
              :disabled="enviando"
            />
            <span
              class="md-error"
              v-if="!$v.form.intervaloHorasUso.required"
            >Intervalo de horas de uso obrigatório</span>
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
import repositorioCronogramas from "../../services/Ativos/repositorioCronogramas";

export default {
  name: "formularioCriarCronograma",
  mixins: [validationMixin],
  props: {
    aposSalvar: {
      type: Function
    }
  },
  data: () => ({
    form: {
      frequencia: null,
      tipoAtivo: null,
      intervaloHorasUso: null
    },
    enviando: false
  }),
  validations: {
    form: {
      frequencia: {
        required
      },
      tipoAtivo: {
        required
      },
      intervaloHorasUso: {
        required() {
          if (this.form.frequencia != "5") return true;
          return (
            this.form.intervaloHorasUso != null &&
            this.form.intervaloHorasUso != ""
          );
        }
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
      if (this.form.frequencia != "5") this.form.intervaloHorasUso = null;
      this.enviando = true;
      repositorioCronogramas.inserir(this.form).then(() => {
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