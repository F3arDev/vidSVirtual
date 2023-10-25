import { ref } from 'vue'

class solicitudServices {
	solicidudesPEN
	SolicitudesREGISTRO

	constructor() {
		this.SolicitudesREGISTRO = ref([])
		this.solicidudesPEN = ref([])
	}

	getSolicitud() {
		return this.SolicitudesREGISTRO
	}

	getSolicitudPEN() {
		return this.solicidudesPEN
	}

	postSolicitudPEN() {
		return this.solicidudesPOST
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
			debugger
			console.log(response)
		} catch (error) {
			console.log(error)
		}
	}
}

export default solicitudServices