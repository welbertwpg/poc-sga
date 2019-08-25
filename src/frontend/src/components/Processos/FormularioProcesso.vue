<template>
  <simple-flowchart :scene.sync="data"></simple-flowchart>
</template>

<script>
import SimpleFlowchart from "vue-simple-flowchart";
import "vue-simple-flowchart/dist/vue-flowchart.css";

export default {
  name: "formularioProcesso",
  data() {
    return {
      data: {
        centerX: 1024,
        centerY: 140,
        scale: 1,
        nodes: [
          {
            id: 2,
            x: -700,
            y: -69,
            type: "Action",
            label: "test1"
          },
          {
            id: 4,
            x: -357,
            y: 80,
            type: "Script",
            label: "test2"
          },
          {
            id: 6,
            x: -557,
            y: 80,
            type: "Rule",
            label: "test3"
          }
        ],
        links: [
          {
            id: 3,
            from: 2, // node id the link start
            to: 4 // node id the link end
          }
        ]
      }
    };
  },
  components: {
    SimpleFlowchart
  }
};
</script>