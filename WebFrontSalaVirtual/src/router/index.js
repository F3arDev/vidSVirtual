import { createRouter, createWebHistory } from 'vue-router'

import { useAuthStore } from '@/stores';



import AprobanteView from '@/views/AprobanteViews/AprobanteView.vue'
import ApInicioView from '@/views/AprobanteViews/InicioView.vue'
import ApSolicitudes from '@/views/AprobanteViews/SolicitudesView.vue'
import ApRegistros from '@/views/AprobanteViews/RegistrosView.vue'


// import SolicitanteView from '../views/SolicitanteView.vue'

import LoginView from '../views/LoginView.vue'


const router = createRouter({
  mode: 'history',
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    //Login
    {
      path: '/',
      name: 'login',
      component: LoginView
    },
    //Aprobante Views y sus hijos
    {
      path: '/aprobante',
      name: 'aprobante',
      component: AprobanteView,
      redirect: '/aprobante/inicio',
      children: [
        { path: 'inicio', name: 'ApInicio', component: ApInicioView },
        { path: 'solicitudes', name: 'ApSolicitudes', component: ApSolicitudes },
        { path: 'registros', name: 'ApRegistros', component: ApRegistros }
      ],
      meta: {
        requireAuth: true
      }
    },
    //Solicitante Views y  sus hijos
    // {
    //   path: '/solicitante',
    //   name: 'solicitante',
    //   component: SolicitanteView
    // }
  ]
})

//Antes de acceder a las rutas, Que ejecute lo que queremos y si no se ejecuta no permite entrar

//to: hacia donde quiere el usuario
//from: de donde viene el usuario
//Next: Hacia donde va el usuario
router.beforeEach(async (to) => {
  // clear alert on route change
  // redirect to login page if not logged in and trying to access a restricted page
  const publicPages = ['/'];
  const authRequired = !publicPages.includes(to.path);
  const authStore = useAuthStore();
  if (authRequired && !authStore.user) {
    authStore.returnUrl = to.fullPath;
    return '/';
  }
});

export default router
