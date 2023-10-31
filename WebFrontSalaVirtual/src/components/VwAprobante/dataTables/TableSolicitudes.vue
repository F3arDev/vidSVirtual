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
							<label for="exampleFormControlInput1" class="form-label">Nomb_Solicitante</label>

						</div>
						<div class="col">
							<label for="exampleFormControlInput1" class="form-label">Expediente o Asunto</label>
						</div>
					</div>

					<div class="row justify-content-center align-items-center g-2">
						<div class="col">
							<label for="exampleFormControlInput1" class="form-label">Entidad Solicitante</label>
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
								<input type="email" class="form-control" id="exampleFormControlInput1"
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
import { onMounted, onUnmounted, ref } from 'vue';
import $ from 'jquery';
import alertify from 'alertifyjs';
import solicitudServices from '@/services/solicitudServices.js'
import googleApiServices from '@/services/googleApiServices.js'
const gapi = new googleApiServices();
const service = new solicitudServices();
let table;
// const rowData = ref(null);

onMounted(async () => {
	await service.fetchAllSolicitudPEN();
	const solicidudesPEN = await service.getSolicitudPEN();

	table = $('#tblSolicitudes').DataTable({
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
			infoFiltered: '(Filtrados de _Max_ registros.)',
			paginate: { first: 'Primero', previous: 'Anterior', next: 'Siguiente', last: 'Ultimo' }
		}
	});

	let modalDetallSolicitud = $('#modalDetallSolicitud')[0];
	$('#tblSolicitudes').on('click', '.btnAprobar', function () {
		const data = table.row($(this).closest('tr')).data();
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


						}
					}
				)
		}, 1500)
	});

	$('#tblSolicitudes').on('click', '.btnRechazar', function () {
	});

	//ChildRow - detalles
	$('#tblSolicitudes').on('click', 'td.dt-control', function () {
		const row = table.row($(this).closest('tr'));
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
})

let linkMeet = ref('')
const btnCrearMeets = async () => {
	console.log('hola')
	let result = await gapi.createEventMeet(titulo);
	console.log(result)
	linkMeet.value = await result.meetLink
};

onUnmounted(() => {
	// Destruye la tabla cuando el componente se desmonta para evitar pérdidas de memoria
	if (table) {
		table.destroy();
	}
});
</script>

<style scoped></style>


