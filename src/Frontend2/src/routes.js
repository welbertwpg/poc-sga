import VueRouter from 'vue-router'

import Ativos from './components/Ativos/Index'
import Monitoramento from './components/Monitoramento/Index'
import Processos from './components/Processos/Index'
import BemVindo from './components/BemVindo'

const routes = [
    { path: '/', component: BemVindo},
    { path: '/ativos', component: Ativos },
    { path: '/monitoramento', component: Monitoramento },
    { path: '/processos', component: Processos },
    { path: '*', redirect: '/' }
]

export default new VueRouter({ routes })