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
		async RequestRefreshToken() {
			try {
				let res = await axios.post('/api/v1/Auth/ObtenerRefreshToken',
					{
						"tokenExpirado": this.tokens.token,
						"refreshToken": this.tokens.refreshToken
					}
				)

				if (res.status !== 200) {
					router.push({ name: 'login' });
					return false;
				}
				this.tokens = await res.data;
				localStorage.setItem('tokens', JSON.stringify(this.tokens));

				return true;
			} catch (error) {
				console.log(error)
			}
		},
		async AuthRuta(rol, ruta) {
			try {
				let res = await axiosJwt.post('/api/v1/Auth/ValidarRuta', {
					"rol": rol,
					"ruta": ruta
				})
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
