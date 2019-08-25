<template>
  <md-app md-waterfall md-mode="fixed">
    <md-app-toolbar class="md-primary" md-elevation="0">
      <md-button class="md-icon-button" @click="toggleMenu" v-if="!menuVisible">
        <md-icon>menu</md-icon>
      </md-button>
      <span class="md-title">Sistema de Gestão Ambiental</span>
    </md-app-toolbar>

    <md-app-drawer :md-active.sync="menuVisible" md-persistent="mini">
      <md-toolbar class="md-transparent" md-elevation="0">
        <span>Navegação</span>

        <div class="md-toolbar-section-end">
          <md-button class="md-icon-button md-dense" @click="toggleMenu">
            <md-icon>keyboard_arrow_left</md-icon>
          </md-button>
        </div>
      </md-toolbar>

      <md-list>
        <md-list-item to="/ativos">
          <md-icon>apps</md-icon>
          <span class="md-list-item-text">Ativos</span>
        </md-list-item>

        <md-list-item to="/monitoramento">
          <md-icon>personal_video</md-icon>
          <span class="md-list-item-text">Monitoramento</span>
        </md-list-item>

        <md-list-item to="/processos">
          <md-icon>sync</md-icon>
          <span class="md-list-item-text">Processos</span>
        </md-list-item>
      </md-list>
    </md-app-drawer>

    <md-app-content class="md-layout">
      <router-view class="md-layout-item" />
    </md-app-content>
  </md-app>
</template>

<style lang="scss" scoped>
.md-app {
  height: 100vh;
  border: 1px solid rgba(#000, 0.12);
}

.md-drawer {
  width: 230px;
  max-width: calc(100vw - 125px);
}
</style>

<script>
export default {
  name: "app",
  data: () => ({
    menuVisible: false
  }),
  methods: {
    toggleMenu() {
      this.menuVisible = !this.menuVisible;
    }
  }
};
</script>