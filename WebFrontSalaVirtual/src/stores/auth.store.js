import { defineStore } from 'pinia';

import router from '../router/index.js';


// const baseUrl = `${import.meta.env.VITE_API_URL}/users`;

export const useAuthStore = defineStore({
	id: 'usuario',
	state: () => ({
		// initialize state from local storage to enable user to stay logged in
		// JSON.parse(localStorage.getItem('usuario'))
		user: JSON.parse(localStorage.getItem('user')),
	}),
	actions: {
		async login(username, password) {
			try {
				let respuesta = await fetch('http://localhost:5172/api/Auth/Validar', {
					method: 'POST',
					headers: {
						'Content-Type': 'application/json'
					},
					body: JSON.stringify(
						{
							"nombre": username,
							"rol": password
						}
					)
				})
				// eslint-disable-next-line no-debugger
				debugger
				let json = await respuesta.json();
				if (json.mensaje !== 'ok') {
					router.push({ name: 'login' });
					return false;
				}
				this.user = await json.response.user;
				localStorage.setItem('user', JSON.stringify(this.user));
				// localStorage.setItem('usuario', JSON.stringify(json.response));
				router.push({ name: this.user.rol });
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
			// router.push('/');
		}
	}


});
