import { defineStore } from 'pinia';

import { useRoute } from 'vue-router';
const router = new useRoute();


// const baseUrl = `${import.meta.env.VITE_API_URL}/users`;

export const useAuthStore = defineStore({
	id: 'auth',
	state: () => ({
		// initialize state from local storage to enable user to stay logged in
		user: JSON.parse(localStorage.getItem('user')),
		returnUrl: null
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
				// update pinia state
				let json = await respuesta.json();
				this.user = await json.response;

				// store user details and jwt in local storage to keep user logged in between page refreshes
				localStorage.setItem('user', JSON.stringify(json));
				// redirect to previous url or default to home page

				let redirectPath = '/';
				if (json.roles.includes('APROBANTE')) {
					redirectPath = '/admin-dashboard'; // Ruta para administradores
				} else if (json.roles.includes('Solicitante')) {
					redirectPath = '/employee-dashboard'; // Ruta para empleados
				}

				router.push(this.returnUrl || '/');
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
