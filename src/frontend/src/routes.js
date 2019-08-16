import VueRouter from 'vue-router'

import Ativos from './components/Ativos/Index'
import Monitoramento from './components/Monitoramento/Index'
import Processos from './components/Processos/Index'

const routes = [
    { path: '/ativos', component: Ativos },
    { path: '/monitoramento', component: Monitoramento },
    { path: '/processos', component: Processos }
]

export default new VueRouter({ routes })