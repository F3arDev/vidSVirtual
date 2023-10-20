import { ref } from 'vue'

class postService {
	posts
	constructor() {
		this.posts = ref([])
	}
	getPost() {
		return this.posts
	}
	async fetchAll() {
		try {
			const url = 'https://jsonplaceholder.typicode.com/posts';
			const result = await fetch(url)
			const json = await result.json();
			this.posts.value = await json;
		} catch (error) {
			console.log(error)
		}
	}
}

export default postService