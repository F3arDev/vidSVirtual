import { defineStore } from 'pinia';
import { axios, axiosJwt } from '@/services/index';

import router from '@/router/index.js';

export const useAuthStore = defineStore({
	id: 'usuario',
	state: async () => ({
		usuario: JSON.parse(localStorage.getItem('usuario')),
		tokens: JSON.parse(localStorage.getItem('tokens')),
	}),
	actions: {
		async login(usuario, clave) {
			try {
				let res = await axios.post('/api/v1/Auth/Autenticar', {
					"nombre": usuario,
					"rol": clave
				})

				// eslint-disable-next-line no-debugger
				debugger;
				if (res.status !== 200) {
					router.push({ name: 'login' });
					return false;
				}

				this.usuario = await res.data.respuesta.usuario;
				this.tokens = await res.data.respuesta.tokens;

				localStorage.setItem('usuario', JSON.stringify(this.usuario));
				localStorage.setItem('tokens', JSON.stringify(this.tokens));

				router.push({ name: this.usuario.rol });
				return true;
			} catch (error) {
				console.log(error)
			}
		},
		async RequestRefreshToken(jwtExpire, refreshTkoen) {
			try {
				let respuesta = await axios.post('/api/Auth/Validar',
					{
						"nombre": jwtExpire,
						"rol": refreshTkoen
					})
				let json = await respuesta.data;
				if (json.mensaje !== 'ok') {
					router.push({ name: 'login' });
					return false;
				}
				this.user = await json.response.user;
				localStorage.setItem('user', JSON.stringify(this.user));
				// localStorage.setItem('usuario', JSON.stringify(json.response));
				router.push({ name: this.user.rol });
				return true;
			} catch (error) {
				console.log(error)
			}
		},
		async AuthRuta(rol, ruta) {
			try {
				debugger
				let res = await axiosJwt.post('/api/v1/Auth/ValidarRuta', {
					"rol": rol,
					"ruta": ruta
				})
				debugger
				if (res.status !== 200) {
					return false;
				}
				return res.data.response.auth
			} catch (error) {
				console.log(error)
			}
		},
		logout() {
			this.user = null;
			this.tokens = null;
			localStorage.removeItem('usuario');
			localStorage.removeItem('tokens');
			router.push({ name: 'login' });
		},
	}
});
