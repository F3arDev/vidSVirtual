import { ref, computed } from 'vue'
import { defineStore } from 'pinia'

//Guia de Pinia: https://es-pinia.vercel.app/core-concepts/ 
export const useCounterStore = defineStore('counter', () => {
	const count = ref(0)

	const doubleCount = computed(() => count.value * 2)

	function increment() {
		count.value++
	}

	return { count, doubleCount, increment }
})

export const useDataUserStore = defineStore('DataUser', () => {
	const count = ref(0)

	const doubleCount = computed(() => count.value * 2)

	function increment() {
		count.value++
	}

	return { count, doubleCount, increment }
})