import Axios from 'axios';
import { useAlertifyStore, useAuthStore } from '@/stores';

const AuthStore = useAuthStore();

export const axiosJwt = Axios.create({
	baseURL: 'http://localhost:5172/',
	timeout: 30000, // 30 segundos
	headers: {
		'Content-Type': 'application/json',
		'Accept': 'application/json',
		// Agrega el token de autenticación si está disponible
		'Authorization': `Bearer ${AuthStore.tokens.token || ''}`
	}
});



// Interceptador de peticiones
axiosJwt.interceptors.request.use(function (config) {
	const alertifyStore = useAlertifyStore();
	alertifyStore.alertifyWaitingOpen()


	return config;
}, function (error) {
	return Promise.reject(error);
});
// Interceptador de respuesta
axiosJwt.interceptors.response.use(function (response) {
	const alertifyStore = useAlertifyStore();
	alertifyStore.alertifyWaitingClose()
	return response;
}, function (error) {

	const alertifyStore = useAlertifyStore();
	alertifyStore.alertifyWaitingClose()

	// Maneja errores de respuesta
	if (axiosJwt.isCancel(error)) {
		// La solicitud fue cancelada
		console.warn('Solicitud cancelada:', error.message);
	} else if (axiosJwt.isTimeout(error)) {
		// Error de tiempo de espera
		console.error('Error de tiempo de espera:', error);
	} else {
		// Otros errores
		console.error('Error en la respuesta:', error);
	}
	return Promise.reject(error);
});