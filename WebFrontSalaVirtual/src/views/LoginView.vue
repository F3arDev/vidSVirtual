<template>
	<main class="form-signin w-100 m-auto">
		<div class="container-fluid">
			<form class="form" @submit.prevent="onSubmit">
				<div class="text-center">
					<i class="bi bi-person-circle mb-4"></i>
					<h1 class="h3 mb-3 fw-normal">INICIAR SESION</h1>
				</div>
				<div v-if="loginError" class="alert alert-danger" role="alert">
					Usuario y contraseña son inválidos.
				</div>
				<div class="form-floating">
					<input v-model="usuario" type="text" class="form-control" placeholder="Usuario"
						:class="{ 'is-invalid': errors.usuario }">
					<label for="floatingInput">Usuario</label>
					<div class="invalid-feedback">{{ errors.usuario }}</div>
				</div>
				<div class="form-floating">
					<input v-model="pass" type="password" class="form-control" placeholder="Contraseña"
						:class="{ 'is-invalid': errors.pass }">
					<label for="floatingPassword">Contraseña</label>
					<div class="invalid-feedback">{{ errors.pass }}</div>
				</div>
				<button class="btn btn-primary w-100 py-2" type="submit">Ingresar</button>
			</form>
		</div>
	</main>
</template>

<script setup>
import { ref } from 'vue';
import { useAuthStore } from '@/stores';

const usuario = ref('');
const pass = ref('');
const errors = ref({});
const loginError = ref(false);

const onSubmit = async () => {
	valForm();
	if (Object.keys(errors.value).length == 0) {
		const authStore = useAuthStore();
		const response = await authStore.login(usuario.value, pass.value);
		if (!response) {
			loginError.value = true;
			return;
		}
	}
};

const valForm = () => {
	errors.value = {};
	loginError.value = false;
	if (!usuario.value) {
		errors.value.usuario = 'El campo Usuario es obligatorio.';
	}
	if (!pass.value) {
		errors.value.pass = 'El campo Contraseña es obligatorio.';
	}
}

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

.form {
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
