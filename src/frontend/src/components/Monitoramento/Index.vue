<template>
  <div class="md-layout">
    <span class="md-title">Monitoramento</span>
    <grafico class="md-layout-item md-size-30 md-small-size-100" :chartData="dadosGrafico" />
  </div>
</template>

<script>
import Grafico from "./Grafico";
import { mapActions, mapGetters } from "vuex";
import HubSensores from "../../services/Monitoramento/hubSensores.js";

export default {
  name: "monitoramento",
  computed: {
    ...mapGetters("Monitoramento", ["limites", "resultadoSensores"]),
    dadosGrafico() {
      const resultadoSensores = this.resultadoSensores;
      const limites = this.limites;

      return {
        labels: [
          "Pressão",
          "Nível",
          "Deslocamento Horizontal",
          "Deslocamento Vertical"
        ],
        datasets: [
          {
            label: "Sensores",
            backgroundColor: "#42a5f5",
            data: resultadoSensores
          },
          {
            label: "Limites",
            backgroundColor: "#ef5350",
            data: limites
          }
        ]
      };
    }
  },
  methods: {
    ...mapActions("Monitoramento", [
      "preencherDados",
      "atualizarResultadosSensores"
    ])
  },
  created() {
    this.preencherDados();

    HubSensores.on(
      "AtualizarResultadosSensores",
      this.atualizarResultadosSensores
    );
  },
  components: {
    Grafico
  }
};
</script>