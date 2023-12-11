import Axios from 'axios';
import { useAlertifyStore, useAuthStore } from '@/stores';

var token;

// var RefreshToken;

const getToken = () => {
	const AuthStore = useAuthStore();
	debugger
	token = AuthStore.tokens.token;
	// RefreshToken = AuthStore.RefreshToken;
}


export const axiosJwt = Axios.create({
	baseURL: 'http://localhost:5172/',
	timeout: 30000, // 30 segundos
});



// Interceptador de peticiones
axiosJwt.interceptors.request.use(function (config) {
	getToken();

	config.headers = {
		'Authorization': `Bearer ${token}`,
	}
	const alertifyStore = useAlertifyStore();
	alertifyStore.alertifyWaitingOpen()

	debugger
	return config;
}, function (error) {
	return Promise.reject(error);
});
// // Interceptador de respuesta
// axiosJwt.interceptors.response.use(function (response) {
// 	const alertifyStore = useAlertifyStore();
// 	alertifyStore.alertifyWaitingClose()
// 	return response;
// }, function (error) {

// 	const alertifyStore = useAlertifyStore();
// 	alertifyStore.alertifyWaitingClose()

// 	// Maneja errores de respuesta
// 	if (axiosJwt.isCancel(error)) {
// 		// La solicitud fue cancelada
// 		console.warn('Solicitud cancelada:', error.message);
// 	} else if (axiosJwt.isTimeout(error)) {
// 		// Error de tiempo de espera
// 		console.error('Error de tiempo de espera:', error);
// 	} else {
// 		// Otros errores
// 		console.error('Error en la respuesta:', error);
// 	}
// 	return Promise.reject(error);
// });


// Response interceptor for API calls
axiosJwt.interceptors.response.use((response) => {
	const alertifyStore = useAlertifyStore();
	alertifyStore.alertifyWaitingClose()
	return response
}, async function (error) {
	const originalRequest = error.config;
	// eslint-disable-next-line no-debugger
	debugger
	if (error) {
		originalRequest._retry = true;
		getToken();
		axiosJwt.defaults.headers.common['Authorization'] = 'Bearer ' + token;
		return axiosJwt(originalRequest);
	}
	const alertifyStore = useAlertifyStore();
	alertifyStore.alertifyWaitingClose()
	return Promise.reject(error);
});