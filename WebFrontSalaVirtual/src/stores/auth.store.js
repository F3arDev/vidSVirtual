import { defineStore } from 'pinia';
import axios from 'axios';
import { useAlertifyStore } from '../stores';

import router from '../router/index.js';

// Interceptador de solicitud
axios.interceptors.request.use(function (config) {
	// Obtiene la instancia del store
	const alertifyStore = useAlertifyStore();
	alertifyStore.alertifyWaitingOpen()
	return config;
}, function (error) {
	return Promise.reject(error);
});


// Interceptador de respuesta
axios.interceptors.response.use(function (response) {
	const alertifyStore = useAlertifyStore();
	alertifyStore.alertifyWaitingClose()
	return response;
}, function (error) {
	const alertifyStore = useAlertifyStore();
	alertifyStore.alertifyWaitingClose()
	return Promise.reject(error);
});

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
				let respuesta = await axios.post('http://localhost:5172/api/Auth/Validar',

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
