import { Layout, Inicio, Registros, Solicitudes } from '../views/Aprobante';

export default {
	path: '/aprobante',
	component: Layout,
	name: 'aprobante',
	redirect: '/aprobante/inicio',
	children: [
		{ path: 'inicio', name: 'ApInicio', component: Inicio },
		{ path: 'solicitudes', name: 'ApSolicitudes', component: Solicitudes },
		{ path: 'registros', name: 'ApRegistros', component: Registros }
	],
	meta: {
		requireAuth: true,
		requireRole: 'aprobante'
	}
};
