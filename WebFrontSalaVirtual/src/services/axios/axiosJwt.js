import Axios from 'axios';
import { useAlertifyStore, useAuthStore } from '@/stores';

var token;
const getToken = () => {
	const AuthStore = useAuthStore();
	token = AuthStore.tokens.token;
}
export const axiosJwt = Axios.create({
	baseURL: 'http://localhost:5172',
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


// Response interceptor for API calls
axiosJwt.interceptors.response.use((response) => {
	const alertifyStore = useAlertifyStore();
	alertifyStore.alertifyWaitingClose()

	return response
}, async function (error) {
	const originalRequest = error.config;
	// eslint-disable-next-line no-debugger
	debugger
	if (error.response.status === 401) {
		originalRequest._retry = true;
		const AuthStore = useAuthStore();
		await AuthStore.RequestRefreshToken();
		return axiosJwt(originalRequest);
	}
	const alertifyStore = useAlertifyStore();
	alertifyStore.alertifyWaitingClose()
	return Promise.reject(error);
});