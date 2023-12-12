import { createRouter, createWebHistory } from 'vue-router'

import { useAuthStore } from '@/stores';

import aprobanteRouter from './aprobante.router'
import solicitanteRouter from './solicitante.router'

import LoginView from '../views/LoginView.vue'


const router = createRouter({
    mode: 'history',
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        //Login
        { ...aprobanteRouter },
        { ...solicitanteRouter },
        {
            path: '/',
            name: 'login',
            component: LoginView
        },
    ]
})

//Antes de acceder a las rutas, Que ejecute lo que queremos y si no se ejecuta no permite entrar
//to: hacia donde quiere el usuario
//from: de donde viene el usuario
//Next: Hacia donde va el usuario
router.beforeEach(async (to, from, next) => {
    const authStore = await useAuthStore();
    let auth = await authStore.usuario;  // Simulando que el usuario está autenticado
    // eslint-disable-next-line no-debugger
    debugger
    if (to.name !== 'login') {
        if (!auth) {
            next({ name: 'login' });
        } else {
            let userRole = authStore.usuario.rol;
            // Realizar la validacion contra el backend antes de permitir el acceso
            let authbacken = await authStore.AuthRuta(userRole, to.path);
            if (!authbacken) {
                // Si no tiene permiso segun el backend, redirigir al "home" del rol actual
                let homeRoute = `/${userRole}`;
                next(homeRoute);
            } else {
                next();
            }
        }
    } else {
        next();
    }
});

export default router