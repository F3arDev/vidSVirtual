import { ref } from 'vue'

import customAlertify from '@/assets/customAlertify'
const ac = new customAlertify();

import { axiosJwt } from '@/services';

class solicitudServices {
	error	//Alamacena El error para metodos post y Put
	success	//Almacena la Respuesta para metodos post y Put
	solicidudesPEN //almacena Todos los registros de Solicitudes con el Estado de Pendiente
	SolicitudesREGISTRO //Almacena todos los registros de solicitudes 
	SolicitudesRegUSUARIO
	constructor() {
		this.error = ref('')
		this.success = ref('')
		this.SolicitudesREGISTRO = ref([])
		this.solicidudesPEN = ref([])
		this.SolicitudesRegUSUARIO = ref([])
	}

	//Getters de data

	getError() {
		return this.error
	}

	getSuccess() {
		return this.success
	}

	getSolicitud() {
		return this.SolicitudesREGISTRO
	}

	getSolicitudPEN() {
		return this.solicidudesPEN
	}

	getSolicitudRegUSUARIO() {
		return this.SolicitudesRegUSUARIO
	}



	async fetchAllSolicitud() {
		try {
			const res = await axiosJwt.get('/api/v1/Solicitud/Lista')
			this.SolicitudesREGISTRO.value = res.data
		} catch (error) {
			console.log(error)
		}
	}
	async fetchAllSolicitudPEN() {
		try {
			const url = 'http://localhost:5172/api/v1/Solicitud/ListaPEN';
			const res = await axiosJwt.get(url)
			this.solicidudesPEN.value = await res.data.response;
		} catch (error) {
			console.error(error)
			ac.alertifyWaitingClose();
		}
	}
	async fetchAllSolicitudRegUSUARIO(id) {
		debugger
		try {
			const url = `/api/v1/Solicitud/ListaRegUsuario/${id}`;
			const res = await axiosJwt.get(url)
	
			this.SolicitudesRegUSUARIO.value = await res.data.response;
		} catch (error) {
			console.log(error)
		}
	}

	//POST
	async sendSolicitudPEN(sendSolicitud) {
		try {
			let res = await axiosJwt.post('/api/v1/Solicitud/Guardar', sendSolicitud)
			if (res.status !== 200) {
				this.error = 'Hubo un Error al enviar la Solicitud'
				return false
			}
			this.success = 'Se envio Correctamente'
			return true;
		} catch (error) {
			console.log(error)
		}
	}
	postSolicitudPEN() {
		return this.solicidudesPOST
	}
	async putSolicitud(putSolicitud) {
		try {
			let res = await axiosJwt.put('/api/v1/Solicitud/Editar', putSolicitud)
			if (res.status !== 200) {
				this.error = 'Hubo un Error al Guardar Cambios a la Solicitud'
				return false
			}
			this.success = 'Se Guardaron Cambios Correctamente'
			return true;
		} catch (error) {
			console.log(error)
		}
	}
}
export { solicitudServices }