<template>
  <md-dialog :md-close-on-esc="false" :md-click-outside-to-close="false" @md-clicked-outside="fechar" :md-active.sync="value">
    <md-toolbar md-elevation="0">
      <div class="md-toolbar-section-start">
        <h1 class="md-title">{{ title }}</h1>
      </div>

      <div class="md-toolbar-section-end">
        <md-button title="Fechar" @click="fechar">
          <md-icon>close</md-icon>
        </md-button>
      </div>
    </md-toolbar>

    <md-dialog-content>
      <slot />
    </md-dialog-content>
  </md-dialog>
</template>

<script>
export default {
  name: "dialogSga",
  props: ["value", "title"],
  methods: {
    fechar() {
      this.$emit("input", this.false);
    }
  },
};
</script>

<style lang="scss" scoped>
.md-dialog {
  max-width: 768px;
}
</style>
