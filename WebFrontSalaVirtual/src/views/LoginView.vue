<template>
	<main class="form-signin w-100 m-auto">
		<div class="container-fluid">
			<form>
				<div class="text-center">
					<i class="bi bi-person-circle mb-4"></i>
					<h1 class="h3 mb-3 fw-normal">INICIAR SESION</h1>
				</div>

				<div class="form-floating">
					<input v-model="usuario" type="text" class="form-control" id="inputUser" placeholder="Usuario">
					<label for="floatingInput">Usuario</label>
				</div>
				<div class="form-floating">
					<input v-model="pass" type="password" class="form-control" id="inputPass" placeholder="Contraseña">
					<label for="floatingPassword">Contraseña</label>
				</div>
				<button @click="login()" class="btn btn-primary w-100 py-2" type="submit">Ingresar</button>
			</form>
		</div>
	</main>
</template>

<script setup>
import { ref } from 'vue';
import { useRouter } from 'vue-router';

let usuario = ref('');
let pass = ref('');

const router = useRouter();

const login = () => {
	// Simulación del inicio de sesión, verifica las credenciales aquí
	if (usuario.value == 'admin' && pass.value == '123') {
		// Redirigir a la ruta principal después del inicio de sesi ón
		router.push('/Aprobante');
	}
	else if (usuario.value == 'usuario' && pass.value == '123') {
		// Redirigir a la ruta principal después del inicio de sesi ón
		router.push('/Solicitante');
	}
	else {
		alert('Erro con las credenciales');
	}
};
</script>

<style scoped>
main {
	display: flex;
	flex-direction: column;
	align-items: center;
	justify-content: center;
	height: 100vh;
	/* Color de fondo */
}

form {
	width: 100%;
	max-width: 330px;
	padding: 15px 30px 25px 30px;

	margin: auto;
	background-color: #fff;
	/* Color de fondo del formulario */
	border-radius: 10px;
	/* Bordes redondeados */
	box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
	/* Sutil sombra */
}

.form-floating {
	margin-bottom: 15px;
}

.btn-primary {
	background-color: #3498db;
	/* Color principal para botones */
	border-color: #3498db;
	/* Borde del botón */
}

.btn-primary:hover {
	background-color: #2980b9;
	/* Color al pasar el mouse sobre el botón */
	border-color: #2980b9;
}

.bi-person-circle {
	font-size: 102px;
	color: #2e92cc;
	/* Color del icono de usuario */
}
</style>
