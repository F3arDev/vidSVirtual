<template>
	<nav class="navbar navbar-expand-lg bg-custom">
		<div class="container-fluid">
			<RouterLink to="/">
				<a class="navbar-brand" href="#">SalasVirtuales</a>
			</RouterLink>

			<button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavAltMarkup"
				aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
				<span class="navbar-toggler-icon"></span>
			</button>
			<div class="collapse navbar-collapse" id="navbarNavAltMarkup">
				<div class="navbar-nav">
					<RouterLink to="/">
						<a class="nav-link active text-color" aria-current="page">Inicio</a>
					</RouterLink>
					<RouterLink to="/Solicitante">
						<a class="nav-link active text-color" aria-current="page">Solicitante</a>
					</RouterLink>
					<RouterLink to="/Aprobante">
						<a class="nav-link active text-color" aria-current="page">Aprobante</a>
					</RouterLink>
				</div>
			</div>
		</div>
	</nav>
</template>

<script setup>
import { RouterLink } from 'vue-router';


</script>

<style scoped>
.text-Color {
	color: #00ff00;
	/* Cambia #00ff00 al código de color que desees */
}

.bg-custom {
	background-color: skyblue;
	/* Reemplaza 'tu-color-preferido' con tu código de color personalizado */
}
</style>