import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import AprobanteView from '../views/AprobanteView.vue'
import SolicitanteView from '../views/SolicitanteView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/about',
      name: 'about',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/AboutView.vue')
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
