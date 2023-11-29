<template>
	<div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
		<h1 class="h2">solicitudes</h1>
	</div>


	<div class="divCard">
		<div class="table-responsive">
			<table id="tblSolicitudes" class="table table-bordered table-striped">
				<thead>
					<tr>
						<th>ver</th>
						<th>Solicitante</th>
						<th>Entidad</th>
						<th>Ciudad</th>
						<th>Expediente/Asunto</th>
						<th>Acciones</th>
					</tr>
				</thead>
			</table>
		</div>
	</div>
	<!-- Modal -->
	<div style="display: none;">
		<form id="modalDetallSolicitud" action="submint">
			<div class="my-2">
				<div class="row justify-content-center align-items-center g-2">
					<div class="col">
						<div class="input-group input-group-sm mb-3">
							<span class="input-group-text">Solicitante</span>
							<input v-model="solicitante" type="text" class="form-control" aria-label="Sizing example input"
								aria-describedby="inputGroup-sizing-sm" disabled>
						</div>

					</div>
					<div class="col">
						<div class="input-group input-group-sm mb-3">
							<span class="input-group-text">Entidad</span>
							<input v-model="entidad" type="text" class="form-control" aria-label="Sizing example input"
								aria-describedby="inputGroup-sizing-sm" disabled>
						</div>
					</div>
				</div>

				<div class="row justify-content-center align-items-center">
					<div class="col">
						<div class="input-group input-group-sm mb-3">
							<span class="input-group-text">Expediente</span>
							<input v-model="expediente" type="text" class="form-control" aria-label="Sizing example input"
								aria-describedby="inputGroup-sizing-sm" disabled>
						</div>
					</div>
				</div>

				<div v-show="isVisible" id="divMeet" class="row justify-content-center align-items-center">
					<div class="col">
						<label class="form-label">URL GOOGLE MEETS</label>
						<div class="input-group mb-3">
							<input v-model="linkMeet" type="text" class="form-control"
								placeholder="https://meet.google.com/Example" aria-label="Recipient's username"
								aria-describedby="button-addon2" disabled>
							<button @click="btnCrearMeets()" class="btn btn-outline-secondary" type="button">Generar
								Link</button>
						</div>
					</div>
				</div>

				<div class="row justify-content-center align-items-cente">
					<div class="col">
						<div>
							<label class="form-label">Observacion</label>
							<input v-model="Motivo" type="text" class="form-control"
								placeholder="Ejm: Ingrese correctamente su nombre">
						</div>
					</div>
				</div>
			</div>
		</form>
	</div>

	<!-- <TableSolicitudes @update="eventUpdate" /> -->
</template>


<script setup>
import { onMounted, onUnmounted, ref } from 'vue';
import $ from 'jquery';
import alertify from 'alertifyjs';
import { solicitudServices } from '@/services'
import googleApiServices from '@/services/googleApiServices.js'
import customAlertify from '@/assets/customAlertify'

//Instancias
const gapi = new googleApiServices();
const service = new solicitudServices();
const ac = new customAlertify();
// Variables
let tblsoliPEN;
let solicidudesPEN
//Emits
const emit = defineEmits(['update']);

//Variables Vacias ref()
let linkMeet = ref('');
let solicitante = ref('');
let entidad = ref('');
let expediente = ref('');
let Motivo = ref('');
let isVisible = ref();
let dataforMeet = ref();
onMounted(async () => {
	await service.fetchAllSolicitudPEN();
	solicidudesPEN = await service.getSolicitudPEN();
	tblsoliPEN = $('#tblSolicitudes').DataTable({
		data: solicidudesPEN.value,
		columns: [
			{
				className: 'dt-control',
				orderable: false,
				data: null,
				defaultContent: '',
				title: 'Ver'
			},
			{ data: 'solicitanteNombre', title: 'Solicitante' },
			{ data: 'entidad', title: 'Entidad' },
			{ data: 'departamento', title: 'Departamento' },
			{ data: 'expediente', title: 'Asunto/Expediente' },
			{
				defaultContent: `<button class="btn btn-primary btn-sn btnAprobar">Aprobar</button>
								<button class="btn btn-danger btn-sn btnRechazar">Rechazar</button>`,
				title: 'Acciones',
				orderable: false,
			}
		],
		order: [[1, 'asc']],
		columnDefs: [
			{ "className": "dt-center", "targets": "_all" }
		],
		pageLength: 5,
		responsive: true,
		autoWidth: false,
		dom: 'Bfrtip',
		language: {
			search: 'Buscar',
			zeroRecords: 'No hay registros para mostrar',
			info: 'Mostrando del _START_ a _END_ de _TOTAL_ registros',
			paginate: { first: 'Primero', previous: 'Anterior', next: 'Siguiente', last: 'Ultimo' }
		}
	});

	var modalDetallSolicitud = $('#modalDetallSolicitud')[0];
	$('#tblSolicitudes').on('click', '.btnAprobar', function () {
		let data = tblsoliPEN.row($(this).closest('tr')).data();
		isVisible.value = ref(true);
		dataforMeet.value = data;
		ac.alertifyWaitingOpen();
		setTimeout(() => {
			// Lógica para aprobar el elemento, por ejemplo:
			alertify.confirm('')
				.setHeader('<div style="text-align: center; font-size: 1.2em; font-weight: bold">Detalles Solicitud</div>')
				.setContent(modalDetallSolicitud)
				.set(
					{
						'closable': false,
						'movable': false,
						labels: { "ok": "Aprobar", "cancel": "Cancelar" },
						onok: async function () {
							let jsonPutSolicitud = {
								"solicitudId": data.solicitudID,
								"urlSesion": linkMeet.value,
								"motivo": Motivo.value,
								"estadoSolicitudId": 2,//Estado Aprobado
							}
							let result = await service.putSolicitud(jsonPutSolicitud)
							if (result == true) {
								await updateTables();
								alertify.success('Success notification message.');
							} else {
								alert(service.getError())
							}
						}
					}
				).closeOthers();
		}, 1500)

		solicitante.value = data.solicitanteNombre
		entidad.value = data.entidad
		expediente.value = data.expediente
		linkMeet.value = '';
	});

	$('#tblSolicitudes').on('click', '.btnRechazar', function () {
		let data = tblsoliPEN.row($(this).closest('tr')).data();
		isVisible.value = false;
		ac.alertifyWaitingOpen();
		setTimeout(() => {
			// Lógica para aprobar el elemento, por ejemplo:
			alertify.confirm('')
				.setHeader('<div style="text-align: center; font-size: 1.2em; font-weight: bold">Detalles Solicitud</div>')
				.setContent(modalDetallSolicitud)
				.set(
					{
						'closable': false,
						'movable': false,
						labels: { "ok": "Rechazar", "cancel": "Cancelar" },
						onok: async function () {
							let jsonPutSolicitud = {
								"solicitudId": data.solicitudID,
								"urlSesion": linkMeet.value,
								"motivo": Motivo.value,
								"estadoSolicitudId": 3, //Estado Rechazado
							}
							let result = await service.putSolicitud(jsonPutSolicitud)
							if (result == true) {
								await updateTables();
								alertify.success('Success notification message.');
							} else {
								alert(service.getError())
							}
						},
					}
				).closeOthers();
		}, 1500)
		solicitante.value = data.solicitanteNombre
		entidad.value = data.entidad
		expediente.value = data.expediente
		linkMeet.value = '';
	});

	//ChildRow - detalles
	$('#tblSolicitudes').on('click', 'td.dt-control', function () {
		const row = tblsoliPEN.row($(this).closest('tr'));
		if (row.child.isShown()) {
			// This row is already open - close it
			row.child.hide();
		}
		else {
			// Open this row
			row.child(format(row.data())).show();
		}
	});
	function format(data) {
		return (
			`
			<div class="container">
				<div class="row justify-content-center g-2">
					<div class="col">
						<div class="input-group mb-3">
							<span class="input-group-text col-3">Solicitante</span>
							<input value="${data.solicitanteNombre}" type="text" class="form-control" aria-label="Username"
								aria-describedby="basic-addon1" disabled>
						</div>
						<div class="input-group mb-3">
							<span class="input-group-text col-3">Numero</span>
							<input  value="${data.solicitanteNombre}" type="text" class="form-control" aria-label="Username"
								aria-describedby="basic-addon1" disabled>
						</div>

						<div class="input-group mb-3">
							<span class="input-group-text col-3">Entidad</span>
							<input value="${data.entidad}" type="text" class="form-control" aria-label="Username"
								aria-describedby="basic-addon1" disabled>
						</div>

						<div class="input-group mb-3">
							<span class="input-group-text col-3">Departamento</span>
							<input value="${data.departamento}"   type="text" class="form-control" aria-label="Username"
								aria-describedby="basic-addon1" disabled>
						</div>

						<div class="input-group mb-3">
							<span class="input-group-text col-3">Expediente</span>
							<input value="${data.expediente}"  type="text" class="form-control" aria-label="Username"
								aria-describedby="basic-addon1" disabled>
						</div>
					</div>
					<div class="col">
						<!-- Input Fechas -->
						<div class="row">
							<div class="col">
								<div class="input-group mb-3">
									<span class="input-group-text col-5">Fecha Inicio</span>
									<input value="${data.fechaInicio}" type="date" class="form-control" aria-label="Username"
								aria-describedby="basic-addon1" disabled>
								</div>
							</div>

							<div class="col">
								<div class="input-group mb-3">
									<span class="input-group-text col-5">Fecha Final</span>
									<input value="${data.fechaFin}" type="date" class="form-control" aria-label="Username"
								aria-describedby="basic-addon1" disabled>
								</div>
							</div>
						</div>
						<!-- Input Horas -->
						<div class="row">
							<div class="col">
								<div class="input-group mb-3">
									<span class="input-group-text  col-5">Hora Inicio</span>
									<input value="${data.horaInicio}" type="time" class="form-control" aria-label="Username"
								aria-describedby="basic-addon1" disabled>
								</div>
							</div>

							<div class="col">
								<div class="input-group mb-3">
									<span class="input-group-text col-5">Hora Final</span>
									<input value="${data.horaFin}" type="time" class="form-control" aria-label="Username"
									aria-describedby="basic-addon1" disabled>
								</div>
							</div>
						</div>
						<div class="row justify-content-center align-items-center g-2">
							<div class="col">
								<div class="input-group">
									<span class="input-group-text">
										Actividad a realizar
									</span>
									<textarea placeholder="${data.actividad}" type="text" class="form-control"  aria-label="Sizing example input"
										aria-describedby="inputGroup-sizing-default" disabled></textarea>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
			`
		);
	}

	async function updateTables() {
		await service.fetchAllSolicitudPEN();
		await service.fetchAllSolicitud();
		solicidudesPEN = await service.getSolicitudPEN();
		tblsoliPEN.clear().rows.add(solicidudesPEN.value).draw();
		emit('update');
	}
})


const btnCrearMeets = async () => {
	if (linkMeet.value == '' || linkMeet.value == 'Inicie Sesion con Google') {
		try {
			linkMeet.value = 'Creando Link de Google Meet...'


			let result = await gapi.createEventMeet(
				dataforMeet.value.horaFin,
				dataforMeet.value.fechaFin,
				dataforMeet.value.horaInicio,
				dataforMeet.value.fechaInicio,
				dataforMeet.value.expediente

			);
			linkMeet.value = await result.meetLink



			alertify.success('Link de Meet Creado Correctamente')
		} catch (error) {
			linkMeet.value = 'Inicie Sesion con Google'
			alertify.error('Necesita que inicie sesion con Google')
		}
	}
};

onUnmounted(() => {
	// Destruye la tabla cuando el componente se desmonta para evitar pérdidas de memoria
	if (tblsoliPEN) {
		tblsoliPEN.destroy();
	}
});
</script>
<!-- 
<script setup>
// import TableSolicitudes from '@/components/VwAprobante/dataTables/TableSolicitudes.vue'
// import { ref } from 'vue'
// const componente = ref(null);
// const eventUpdate = () => {
// 	console.log('Recepcion de Hijo1');
// 	// Emitir señal al Hijo2

// 	componente.value.updateTblSoliRegistro();
// };
</script> -->

<style scoped></style>