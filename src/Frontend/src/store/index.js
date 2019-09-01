import Vue from 'vue'
import Vuex from 'vuex'

import Ativos from './Ativos'
import Monitoramento from './Monitoramento'
import Processos from './Processos'

Vue.use(Vuex)

export default new Vuex.Store({
    modules: {
        Ativos,
        Monitoramento,
        Processos
    }
});
