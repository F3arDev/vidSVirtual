<template>
	<div class="dropdown">
		<a class="d-flex align-items-center link-body-emphasis text-decoration-none dropdown-toggle"
			data-bs-toggle="dropdown" aria-expanded="false">
			<img src="@/assets/imgIcon.jpg" alt="" width="32" height="32" class="rounded-circle me-2">
			<strong>{{ nomUser }}</strong>
		</a>
		<ul class="dropdown-menu text-small shadow">
			<li><a class="dropdown-item">Perfil</a></li>
			<li>
				<hr class="dropdown-divider">
			</li>
			<li><a class="dropdown-item" @click="userStore.logout()">Cerrar Session</a></li>
		</ul>
	</div>
</template>

<script setup>
import { ref } from 'vue'
import { useAuthStore } from '@/stores';
let userStore = new useAuthStore()


let nomUser = ref(userStore.usuario.nombre)
</script>

<style scoped></style>