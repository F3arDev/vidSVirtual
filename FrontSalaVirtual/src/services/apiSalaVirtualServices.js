import { ref } from 'vue';
import Axios from 'axios';
class apiSalaVirtualServices {
	solicitudes;

	constructor(){
		this.solicitudes = ref([])
	}

	getSolicitudes(){
		return this.solicitudes
	}

	async fetchAll(){
		try{
			const url = "";
			const result = await Axios.get(url);
			debugger
			const json= await result.json()
			this.solicitudes.value = await json

		}catch(error){
			console.log(error)
		}
	}
}

export default apiSalaVirtualServices;