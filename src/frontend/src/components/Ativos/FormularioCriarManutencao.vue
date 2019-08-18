<template>
  <form novalidate class="md-layout" @submit.prevent="validar">
    <div class="md-layout-item md-small-size-100">
      <div class="md-layout md-gutter">
        <div class="md-layout-item md-size-50 md-small-size-100">
          <md-datepicker
            :class="obterClasseValidacao('dataHora')"
            v-model="form.dataHora"
            md-dense
            :disabled="enviando"
          >
            <label>Data</label>
            <span v-if="!$v.form.dataHora.required" class="md-error">A data é obrigatória</span>
          </md-datepicker>
        </div>

        <div class="md-layout-item md-small-size-100">
          <md-field :class="obterClasseValidacao('tipo')">
            <label for="tipo">Tipo</label>
            <md-select name="tipo" id="tipo" v-model="form.tipo" md-dense :disabled="enviando">
              <md-option></md-option>
              <md-option value="1">Preventiva</md-option>
              <md-option value="2">Corretiva</md-option>
            </md-select>
            <span class="md-error">O tipo é obrigatório</span>
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
import { mapActions } from "vuex";

export default {
  name: "formularioCriarCronograma",
  mixins: [validationMixin],
  props: {
    aposSalvar: {
      type: Function
    },
    ativo: {
      type: Object,
      required: true
    }
  },
  data: () => ({
    form: {
      dataHora: null,
      tipo: null,
    },
    enviando: false
  }),
  validations: {
    form: {
      dataHora: {
        required
      },
      tipo: {
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
      this.adicionarManutencao({
        identificador: this.ativo.identificador,
        manutencao: this.form
      }).then(() => {
        this.enviando = false;
        if (this.aposSalvar) this.aposSalvar();
      });
    },
    validar() {
      this.$v.$touch();

      if (!this.$v.$invalid) {
        this.salvar();
      }
    },
    ...mapActions("Ativos", ["adicionarManutencao"])
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