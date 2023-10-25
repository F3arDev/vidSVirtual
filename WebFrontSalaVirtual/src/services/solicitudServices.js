import { ref } from 'vue'

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
			const result = await fetch(url)
			const json = await result.json();
			this.SolicitudesREGISTRO.value = await json;
		} catch (error) {
			console.log(error)
		}
	}

	async fetchAllSolicitudPEN() {
		try {
			const url = 'http://localhost:5172/api/v1/Solicitud/ListaPEN';
			const result = await fetch(url)
			const json = await result.json();
			this.solicidudesPEN.value = await json.response;
		} catch (error) {
			console.log(error)
		}
	}

	async fetchAllSolicitudRegUSUARIO(id) {
		try {
			const url = `http://localhost:5172/api/v1/Solicitud/ListaRegUsuario/${id}`;
			const result = await fetch(url)
			const json = await result.json();
			this.SolicitudesRegUSUARIO.value = await json.response;
		} catch (error) {
			console.log(error)
		}
	}

	//POST
	async sendSolicitudPEN(sendSolicitud) {
		try {
			let result = await fetch('http://localhost:5172/api/v1/Solicitud/Guardar', {
				method: 'POST',
				headers: {
					'Content-Type': 'application/json'
				},
				body: JSON.stringify(sendSolicitud)
			})
			let response = await result.json();
			if (response.mensaje != 'ok') {
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



}

export default solicitudServices