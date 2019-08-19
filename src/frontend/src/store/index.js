import Vue from 'vue'
import Vuex from 'vuex'
import Ativos from './Ativos'
import Monitoramento from './Monitoramento'

Vue.use(Vuex)

export default new Vuex.Store({
    modules: {
        Ativos,
        Monitoramento
    }
});
