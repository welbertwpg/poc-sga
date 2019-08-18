import Vue from 'vue'
import VueRouter from 'vue-router'
import VueMaterial from 'vue-material'
import 'vue-material/dist/vue-material.min.css'
import 'vue-material/dist/theme/default.css'

import App from './App.vue'
import router from './routes.js'
import store from './store'

Vue.use(VueMaterial)
Vue.use(VueRouter)
Vue.config.productionTip = false

new Vue({
  router,
  store,
  render: h => h(App),
}).$mount('#app')
