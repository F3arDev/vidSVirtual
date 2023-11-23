import { Layout, Inicio, Registros, Solicitar } from '../views/Solicitante';

export default {
	path: '/solicitante',
	component: Layout,
	name: 'solicitante',
	redirect: '/solicitante/inicio',
	children: [
		{ path: 'inicio', name: 'so Inicio', component: Inicio },
		{ path: 'solicitar', name: 'so solicitar', component: Solicitar },
		{ path: 'registros', name: 'so Registros', component: Registros }
	],
	meta: {
		requireAuth: true
	}
};