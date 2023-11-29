import { defineStore } from 'pinia';
import { axios } from '@/services/index';

import router from '../router/index.js';
export const useAuthStore = defineStore({
	id: 'usuario',
	state: () => ({
		user: JSON.parse(localStorage.getItem('user')),
	}),
	actions: {
		async login(username, password) {
			try {
				let respuesta = await axios.post('/api/Auth/Validar',
					{
						"nombre": username,
						"rol": password
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
				let respuesta = await fetch('http://localhost:5172/api/Auth/ValidarRuta', {
					method: 'POST',
					headers: {
						'Content-Type': 'application/json'
					},
					body: JSON.stringify(
						{
							"rol": rol,
							"ruta": ruta
						}
					)
				})
				let json = await respuesta.json();
				if (json.mensaje !== 'ok') {
					return false;
				}

				return json.response.auth
			} catch (error) {
				console.log(error)
			}
		},
		logout() {
			this.user = null;
			localStorage.removeItem('user');
			router.push({ name: 'login' });
		}
	}
});
