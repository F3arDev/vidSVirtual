import { ref } from 'vue'
import { axios } from '@/services/index';	// Importamos el servicio de axios

export class postService {
	posts

	constructor() {
		this.posts = ref([])

	}

	getPost() {
		return this.posts
	}

	async fetchAll() {
		try {
			const url = '/posts';
			const result = await axios.get(url)
			// No es necesario convertir a JSON ya que axios maneja la respuesta automáticamente
			this.posts.value = await result.data;
		} catch (error) {
			console.error(error)
		}
	}
}
