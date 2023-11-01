<template>
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
		<!-- Modal -->
		<div style="display: none;">
			<form id="modalDetallSolicitud" action="submint">
				<div class="mb-3">
					<div class="row justify-content-center align-items-center g-2">
						<div class="col">
							<div class="input-group input-group-sm mb-3">
								<span class="input-group-text" id="inputGroup-sizing-sm">Solicitante</span>
								<input v-model="solicitante" type="text" class="form-control"
									aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" disabled>
							</div>

						</div>
						<div class="col">
							<div class="input-group input-group-sm mb-3">
								<span class="input-group-text" id="inputGroup-sizing-sm">Entidad</span>
								<input v-model="entidad" type="text" class="form-control" aria-label="Sizing example input"
									aria-describedby="inputGroup-sizing-sm" disabled>
							</div>
						</div>
					</div>

					<div class="row justify-content-center align-items-center g-2">
						<div class="col">
							<div class="input-group input-group-sm mb-3">
								<span class="input-group-text" id="inputGroup-sizing-sm">Expediente</span>
								<input v-model="expediente" type="text" class="form-control"
									aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" disabled>
							</div>
						</div>
					</div>

					<div class="row justify-content-center align-items-center g-2">
						<div class="col">
							<label for="exampleFormControlInput1" class="form-label">URL GOOGLE MEETS</label>
							<div class="input-group mb-3">
								<input v-model="linkMeet" type="text" class="form-control"
									placeholder="Ingrese el Url de google Meets" aria-label="Recipient's username"
									aria-describedby="button-addon2" disabled>
								<button @click="btnCrearMeets()" class="btn btn-outline-secondary" type="button">Generar
									Link</button>
							</div>
						</div>
					</div>

					<div class="row justify-content-center align-items-center g-2">
						<div class="col">
							<div class="mb-3">
								<label for="exampleFormControlInput1" class="form-label">Observacion</label>
								<input v-model="Motivo" type="text" class="form-control"
									placeholder="Ejm: Ingrese correctamente su nombre">
							</div>
						</div>
					</div>
				</div>
			</form>
		</div>

	</div>
</template>

<script setup>
import { onMounted, onUnmounted, ref, defineEmits } from 'vue';
import $ from 'jquery';
import alertify from 'alertifyjs';
import solicitudServices from '@/services/solicitudServices.js'
import googleApiServices from '@/services/googleApiServices.js'
const gapi = new googleApiServices();
const service = new solicitudServices();
let tblsoliPEN;
let solicidudesPEN
const emit = defineEmits(['update']);

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
								<button class="btn btn-primary btn-sn btnRechazar">Rechazar</button>`,
				title: 'Acciones'
			}
		],
		columnDefs: [
			{ "className": "dt-center", "targets": "_all" }
		],
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

	let modalDetallSolicitud = $('#modalDetallSolicitud')[0];
	$('#tblSolicitudes').on('click', '.btnAprobar', function () {
		const data = tblsoliPEN.row($(this).closest('tr')).data();


		setTimeout(function () {
			// Lógica para aprobar el elemento, por ejemplo:
			alertify.confirm('')
				.setHeader('<div style="text-align: center; font-size: 1.2em; font-weight: bold">Detalles Solicitud</div>')
				.setContent(modalDetallSolicitud)
				.set('resizable', true)
				.resizeTo('70%', '65%')
				.set(
					{
						'closable': false,
						'movable': false,
						labels: { "ok": "Aprobar", "cancel": "Cancelar" },
						resizable: true,
						onok: async function () {
							let jsonPutSolicitud = {
								"solicitudId": data.solicitudID,
								"urlSesion": linkMeet.value,
								"motivo": Motivo.value,
								"estadoSolicitudId": 2,
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
				)
		}, 1500)

		solicitante.value = data.solicitanteNombre
		entidad.value = data.entidad
		expediente.value = data.expediente
		linkMeet.value = '';
	});

	$('#tblSolicitudes').on('click', '.btnRechazar', function () {
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

let linkMeet = ref('')
let solicitante = ref('')
let entidad = ref('')
let expediente = ref('')
let Motivo = ref('')

const btnCrearMeets = async () => {
	if (linkMeet.value == '') {
		try {
			let result = await gapi.createEventMeet();
			linkMeet.value = await result.meetLink
			alertify.success('Link de Meet Creado Correctamente')
		} catch (error) {
			alertify.error('Necesita que Inicie Sesion con Google')
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

<style scoped></style>