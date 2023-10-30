import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import AprobanteView from '../views/AprobanteView.vue'
import SolicitanteView from '../views/SolicitanteView.vue'
import LoginView from '../views/LoginView.vue'
const router = createRouter({
  mode: 'history',
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'Login',
      component: LoginView
    },
    {
      path: '/home',
      name: 'home',
      component: HomeView
    },
    {
      path: '/Aprobante',
      name: 'Aprobante',
      component: AprobanteView
    },
    {
      path: '/Solicitante',
      name: 'Solicitante',
      component: SolicitanteView
    }
  ]
})

export default router
