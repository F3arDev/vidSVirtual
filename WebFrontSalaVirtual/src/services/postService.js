import { ref } from 'vue'
import axios from 'axios'

class postService {
	posts

	constructor() {
		this.posts = ref([])
		// Agregar interceptores al constructor
		this.setupInterceptors()
	}

	// Configurar interceptores de solicitud y respuesta
	setupInterceptors() {
		// Interceptador de solicitud
		axios.interceptors.request.use(function (config) {
			alert('Hola antes de la solicitud');
			return config;
		}, function (error) {
			return Promise.reject(error);
		});

		// Interceptador de respuesta
		axios.interceptors.response.use(function (response) {
			alert('Hola desde el interceptor de respuesta');
			return response;
		}, function (error) {
			return Promise.reject(error);
		});
	}

	getPost() {
		return this.posts
	}

	async fetchAll() {
		try {
			const url = 'https://jsonplaceholder.typicode.com/posts';
			const result = await axios.get(url)
			// No es necesario convertir a JSON ya que axios maneja la respuesta automáticamente
			this.posts.value = await result.data;
		} catch (error) {
			console.error(error)
		}
	}
}

export default postService
