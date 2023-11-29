import Axios from 'axios';
import { useAlertifyStore } from '@/stores';

const axios = Axios.create({// Crea una instancia de Axios
	baseURL: 'http://localhost:5172/',
	timeout: 30000,	// 30 segundos
	headers: {
		'Content-Type': 'application/json',
		'Accept': 'application/json'
	}
});
// Interceptador de peticiones
axios.interceptors.request.use(function (config) {
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

	// Maneja errores de respuesta
	if (axios.isCancel(error)) {
		// La solicitud fue cancelada
		console.warn('Solicitud cancelada:', error.message);
	} else if (axios.isTimeout(error)) {
		// Error de tiempo de espera
		console.error('Error de tiempo de espera:', error);
	} else {
		// Otros errores
		console.error('Error en la respuesta:', error);
	}
	return Promise.reject(error);
});

export { axios };