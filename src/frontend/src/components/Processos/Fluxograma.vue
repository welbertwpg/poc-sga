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
  TextBlock
} from "gojs";

export default {
  name: "formularioProcesso",
  computed: {
    ...mapState("Processos", ["processo"])
  },
  props: ["modelData"], // accept model data as a parameter
  mounted: function() {
    var self = this;
    var myDiagram = GraphObject.make(Diagram, this.$el, {
      layout: GraphObject.make(TreeLayout, {
        angle: 90,
        arrangement: TreeLayout.ArrangementHorizontal
      }),
      "undoManager.isEnabled": true,
      // Model ChangedEvents get passed up to component users
      ModelChanged: function(e) {
        self.$emit("model-changed", e);
      },
      ChangedSelection: function(e) {
        self.$emit("changed-selection", e);
      }
    });
    myDiagram.nodeTemplate = GraphObject.make(
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
    myDiagram.linkTemplate = GraphObject.make(
      Link,
      { relinkableFrom: true, relinkableTo: true },
      GraphObject.make(Shape),
      GraphObject.make(Shape, { toArrow: "OpenTriangle" })
    );
    this.diagram = myDiagram;
    this.updateModel(this.modelData);
  },
  watch: {
    modelData: function(val) {
      this.updateModel(val);
    }
  },
  methods: {
    model: function() {
      return this.diagram.model;
    },
    updateModel: function(val) {
      // No GoJS transaction permitted when replacing Diagram.model.
      if (val instanceof Model) {
        this.diagram.model = val;
      } else {
        var m = new GraphLinksModel();
        if (val) {
          for (var p in val) {
            m[p] = val[p];
          }
        }
        this.diagram.model = m;
      }
    },
    updateDiagramFromData: function() {
      this.diagram.startTransaction();
      // This is very general but very inefficient.
      // It would be better to modify the diagramData data by calling
      // Model.setDataProperty or Model.addNodeData, et al.
      this.diagram.updateAllRelationshipsFromData();
      this.diagram.updateAllTargetBindings();
      this.diagram.commitTransaction("updated");
    }
  }
};
</script> 