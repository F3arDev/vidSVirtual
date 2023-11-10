import { ref } from 'vue'

import customAlertify from '@/assets/customAlertify'
const ac = new customAlertify();
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
			const url = 'http://localhost:5172/api/v1/Solicitud/Lista';

			ac.alertifyWaitingOpen();
			const result = await fetch(url)
			
			ac.alertifyWaitingClose();

			const json = await result.json();
			
			this.SolicitudesREGISTRO.value = await json;
		} catch (error) {
			console.log(error)
			ac.alertifyWaitingClose();
		}
	}

	async fetchAllSolicitudPEN() {

		try {
			const url = 'http://localhost:5172/api/v1/Solicitud/ListaPEN';
			ac.alertifyWaitingOpen();
			const result = await fetch(url)
			ac.alertifyWaitingClose();
			const json = await result.json();
			this.solicidudesPEN.value = await json.response;
		} catch (error) {
			console.error(error)
			ac.alertifyWaitingClose();
		}
	}

	async fetchAllSolicitudRegUSUARIO(id) {
		try {
			const url = `http://localhost:5172/api/v1/Solicitud/ListaRegUsuario/${id}`;
			ac.alertifyWaitingOpen();
			const result = await fetch(url)
			ac.alertifyWaitingClose();
			const json = await result.json();
			this.SolicitudesRegUSUARIO.value = await json.response;
		} catch (error) {
			console.log(error)
			ac.alertifyWaitingClose();
		}
	}

	//POST
	async sendSolicitudPEN(sendSolicitud) {
		try {
			ac.alertifyWaitingOpen();
			let result = await fetch('http://localhost:5172/api/v1/Solicitud/Guardar', {
				method: 'POST',
				headers: {
					'Content-Type': 'application/json'
				},
				body: JSON.stringify(sendSolicitud)
			})
			ac.alertifyWaitingClose();
			let response = await result.json();
			if (response.mensaje != 'ok') {
				this.error = 'Hubo un Error al enviar la Solicitud'
				return false
			}
			this.success = 'Se envio Correctamente'
			return true;
		} catch (error) {
			console.log(error)
			ac.alertifyWaitingClose();
		}
	}

	postSolicitudPEN() {
		return this.solicidudesPOST
	}

	async putSolicitud(putSolicitud) {
		try {
			ac.alertifyWaitingOpen();
			let result = await fetch('http://localhost:5172/api/v1/Solicitud/Editar', {
				method: 'PUT',
				headers: {
					'Content-Type': 'application/json'
				},
				body: JSON.stringify(putSolicitud)
			})
			let response = await result.json();
			ac.alertifyWaitingClose();
			if (response.mensaje != 'ok') {
				this.error = 'Hubo un Error al Guardar Cambios a la Solicitud'
				return false
			}
			this.success = 'Se Guardaron Cambios Correctamente'
			return true;
		} catch (error) {
			console.log(error)
			ac.alertifyWaitingClose();
		}
	}
}

export default solicitudServices