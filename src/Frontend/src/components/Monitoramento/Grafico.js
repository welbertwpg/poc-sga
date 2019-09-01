import { Bar, mixins } from 'vue-chartjs'
 
export default {
  extends: Bar,
  props: ['chartData', 'options'],
  mixins: [mixins.reactiveProp],
  mounted () {
    // Overwriting base render method with actual data.
    this.renderChart(this.chartData, this.options)
  }
}