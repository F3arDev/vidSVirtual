import { ref } from 'vue'

class solicitudServices {
	solicidudes
	constructor() {
		this.solicidudes = ref([])
	}
	getPost() {
		return this.solicidudes
	}
	async fetchAll() {
		try {
			const url = 'http://localhost:5172/api/v1/Solicitud/Lista';
			const result = await fetch(url)
			const json = await result.json();
			this.solicidudes.value = await json;
		} catch (error) {
			console.log(error)
		}
	}
}

export default solicitudServices