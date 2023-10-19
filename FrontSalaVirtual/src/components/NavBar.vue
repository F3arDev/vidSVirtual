<template>
	<nav class="navbar navbar-expand-lg bg-custom">
		<div class="container-fluid">
			<Router-Link to="/">
				<a class="navbar-brand" href="#">SalasVirtuales</a>
			</Router-Link>

			<button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavAltMarkup"
				aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
				<span class="navbar-toggler-icon"></span>
			</button>
			<div class="collapse navbar-collapse" id="navbarNavAltMarkup">
				<div class="navbar-nav">
					<Router-Link to="/">
						<a class="nav-link active" >Inicio</a>
					</Router-Link>

					<Router-Link to="/Solicitante">
						<a class="nav-link active">Solicitante</a>
					</Router-Link>

					<Router-Link to="/Aprobante">
						<a class="nav-link active">Aprobante</a>
					</Router-Link>
				</div>
			</div>
		</div>
	</nav>
</template>

<script setup>
import { RouterLink } from 'vue-router';


</script>

<style scoped>
a {
	color: #ffffff;
	/* Cambia #00ff00 al código de color que desees */
}

.bg-custom {
	background-color: #4285f4;
	/* Reemplaza 'tu-color-preferido' con tu código de color personalizado */
}
</style>