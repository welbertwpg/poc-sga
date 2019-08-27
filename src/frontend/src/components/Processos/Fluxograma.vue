<template>
  <div></div>
</template>

<script>
import { mapState } from "vuex";
import {
  GraphObject,
  Node,
  Link,
  Shape,
  Diagram,
  TreeLayout,
  Binding,
  Model,
  GraphLinksModel,
  TextBlock,
  CommandHandler
} from "gojs";



export default {
  name: "formularioProcesso",
  computed: {
    ...mapState("Processos", ["processo"])
  },
  props: ["modelData"],
  mounted: function() {
    let self = this;

    let diagram = GraphObject.make(Diagram, this.$el, {
      layout: GraphObject.make(TreeLayout, {
        angle: 90,
        arrangement: TreeLayout.ArrangementHorizontal
      }),
      "undoManager.isEnabled": true,
      ModelChanged: function(e) {
        self.$emit("model-changed", e);
      },
      ChangedSelection: function(e) {
        self.$emit("changed-selection", e);
      }
    });

    diagram.nodeTemplate = GraphObject.make(
      Node,
      "Auto",
      GraphObject.make(
        Shape,
        {
          fill: "white",
          strokeWidth: 0,
          portId: "",
          fromLinkable: true,
          toLinkable: true,
          cursor: "pointer"
        },
        new Binding("fill", "color")
      ),
      GraphObject.make(
        TextBlock,
        { margin: 8, editable: true },
        new Binding("text").makeTwoWay()
      )
    );

    diagram.linkTemplate = GraphObject.make(
      Link,
      { relinkableFrom: true, relinkableTo: true },
      GraphObject.make(Shape),
      GraphObject.make(Shape, { toArrow: "OpenTriangle" })
    );

    const validarTipo = tipo => (tipo == 0 || tipo == 3);

    diagram.commandHandler.deleteSelection = () => {
      let node = diagram.selection.first();
      if (node instanceof Node && validarTipo(node.data.tipo))
        return;

      CommandHandler.prototype.deleteSelection.call(diagram.commandHandler);
    };

    diagram.commandHandler.editTextBlock = () => {
      let node = diagram.selection.first();
      if (node instanceof Node && validarTipo(node.data.tipo))
        return;

      CommandHandler.prototype.editTextBlock.call(diagram.commandHandler);
    };

    this.diagram = diagram;
    this.updateModel(this.modelData);
  },
  watch: {
    modelData: function(val) {
      this.updateModel(val);
    }
  },
  methods: {
    updateModel: function(val) {
      if (val instanceof Model) {
        this.diagram.model = val;
      } else {
        let m = new GraphLinksModel();
        if (val) {
          for (let p in val) {
            m[p] = val[p];
          }
        }
        this.diagram.model = m;
      }
    }
  }
};
</script> 