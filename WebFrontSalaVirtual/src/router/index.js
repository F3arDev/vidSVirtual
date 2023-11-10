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
      component: AprobanteView,
      meta: {
        requireAuth: true
      }
    },
    {
      path: '/Solicitante',
      name: 'Solicitante',
      component: SolicitanteView
    }
  ]
})

//Antes de acceder a las rutas, Que ejecute lo que queremos y si no se ejecuta no permite entrar

//to: hacia donde quiere el usuario
//from: de donde viene el usuario
//Next: Hacia donde va el usuario
router.beforeEach((to, from, next) => {
  const auth = true //obtiene jwt Auth del backend
  const needAuth = to.meta.requireAuth
  if (needAuth && !auth) {
    next('/')
  } else {
    next()                                                 
  }
})

export default router
