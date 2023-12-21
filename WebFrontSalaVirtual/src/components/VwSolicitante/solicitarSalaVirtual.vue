<template>
	<div class="row ">

		<div class="col-4 card mx-1 p-3">
			<h3>Guia</h3>
			<p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Inventore ex deleniti qui ullam excepturi.
				Blanditiis, placeat numquam molestias amet voluptatem architecto laboriosam expedita voluptate odio quam.
				Culpa, fuga corporis! Fugiat.</p>
		</div>

		<div class="col card mx-1 p-3">
			<!-- Input Usuario -->
			<div class="input-group mb-3">
				<span class="col-3 input-group-text">Usuario</span>
				<input v-model="Usuario" type="text" class="form-control" disabled>
			</div>
			<!-- Input Fechas -->
			<div class="row">
				<div class="col">
					<div class="input-group mb-3">
						<span class=" col-5 input-group-text">Fecha Inicio</span>
						<input v-model="FechaInicio" type="date" class="form-control"
							:class="{ 'is-invalid': errors.FechaInicio }">
						<div class="invalid-feedback">{{ errors.FechaInicio }}</div>
					</div>
				</div>
				<div class="col">
					<div class=" input-group mb-3">
						<span class="col-5 input-group-text">Fecha Final</span>
						<input v-model="FechaFin" type="date" class="form-control"
							:class="{ 'is-invalid': errors.FechaFin }">
						<div class="invalid-feedback">{{ errors.FechaFin }}</div>
					</div>
				</div>
			</div>
			<!-- Input Horas -->
			<div class="row">
				<div class="col">
					<div class="input-group mb-3">
						<span class=" col-5 input-group-text">Hora Inicio</span>
						<input v-model="HoraInicio" type="time" class="form-control"
							:class="{ 'is-invalid': errors.HoraInicio }">
						<div class="invalid-feedback">{{ errors.HoraInicio }}</div>
					</div>
				</div>
				<div class="col">
					<div class="input-group mb-3">
						<span class=" col-5 input-group-text">Hora Final</span>
						<input v-model="HoraFin" type="time" class="form-control" :class="{ 'is-invalid': errors.HoraFin }">
						<div class="invalid-feedback">{{ errors.HoraFin }}</div>
					</div>
				</div>
			</div>
			<div class="input-group mb-3">
				<span class="input-group-text col-3">
					Expediente
				</span>
				<input v-model="Expediente" type="text" class="form-control" :class="{ 'is-invalid': errors.Expediente }">
				<div class="invalid-feedback">{{ errors.Expediente }}</div>
			</div>
			<div class="input-group">
				<span class="input-group-text ">
					Actividad a realizar
				</span>
				<textarea v-model="Actividad" type="text" class="form-control" :class="{ 'is-invalid': errors.Actividad }">
				</textarea>
				<div class="invalid-feedback">{{ errors.Actividad }}</div>
			</div>
			<div class="row justify-content-center mt-3">
				<div class="col text-end">
					<button @click="getDataSolicitud" type="button" class="btn btn-primary ">Enviar</button>
				</div>
			</div>
		</div>
	</div>
</template>

<script setup>
import { onMounted, ref } from 'vue';
import { solicitudServices } from '@/services'
const service = new solicitudServices();
import alertify from 'alertifyjs';
import { useAuthStore } from '@/stores';


let Usuario = ref('');
let FechaInicio = ref('')
let FechaFin = ref('')
let HoraInicio = ref('')
let HoraFin = ref('')
// let VwDepMunicipioId = ref('')
let Expediente = ref('')
let Actividad = ref('')

const errors = ref({});

const valForm = () => {
	errors.value = {};
	if (!FechaInicio.value) {
		errors.value.FechaInicio = 'Fecha Inicio es obligatorio.';
	}

	if (!FechaFin.value) {
		errors.value.FechaFin = 'Fecha Fin es obligatorio.';
	}

	if (!HoraInicio.value) {
		errors.value.HoraInicio = 'Hora Inicio es obligatorio.';
	}

	if (!HoraFin.value) {
		errors.value.HoraFin = 'Hora Fin es obligatorio.';
	}

	if (!Expediente.value) {
		errors.value.Expediente = 'El expediente es obligatorio.';
	}

	if (!Actividad.value) {
		errors.value.Actividad = 'La actividad es obligatorio.';
	}
}

const getDataSolicitud = async () => {
	valForm()
	if (Object.keys(errors.value).length == 0) {
		let userStore = new useAuthStore()
		let jsonSendSolicitud =
		{
			"solicitanteId": userStore.usuario.usuarioID,
			"fechaRegistro": FechaInicio.value,
			"fechaInicio": FechaInicio.value,
			"fechaFin": FechaFin.value,
			"horaInicio": HoraInicio.value + ':00',
			"horaFin": HoraFin.value + ':00',
			"vwDepMunicipioId": '1',
			"expediente": Expediente.value,
			"actividad": Actividad.value
		}
		let result = await service.sendSolicitudPEN(jsonSendSolicitud)
		if (result == true) {
			alertify.success('Success notification message.');
		} else {
			alert(await service.getError())
		}
	}

}

onMounted(() => {
	let userStore = new useAuthStore()
	Usuario.value = userStore.usuario.nombre
}) 
</script>

<style scoped>
.card {
	box-shadow: 0 0 5px rgba(0, 0, 0, 0.1);
	background-color: #ffffff;
}
</style>