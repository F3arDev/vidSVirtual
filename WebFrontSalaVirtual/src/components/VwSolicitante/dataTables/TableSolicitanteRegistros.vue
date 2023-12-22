<template>
	<div class="table-responsive">
		<table id="tbSolicitudRegUsuario" class="table table-bordered table-striped">
			<!-- <thead>
				<tr>
					<th>#</th>
					<th>ID</th>
					<th>Usuario</th>
					<th>Entidad</th>
					<th>Expediente</th>
					<th>fechaInicio</th>
					<th>horaInicio</th>
					<th>fechaFin</th>
					<th>horaFin</th>
					<th>URL Sesion</th>
					<th>Estado</th>
				</tr>
			</thead> -->
		</table>
	</div>

	<!-- Modal -->
	<div style="display: none;">
		<form id="modalDetallSoRegistros" action="submint">
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

				<div class="row justify-content-center align-items-center">
					<div class="col">
						<label class="form-label">URL GOOGLE MEETS</label>
						<div class="input-group mb-3">
							<input v-model="linkMeet" type="text" class="form-control"
								placeholder="https://meet.google.com/Example" aria-label="Recipient's username"
								aria-describedby="button-addon2" disabled>
						</div>
					</div>
				</div>

				<div class="row justify-content-center align-items-cente">
					<div class="col">
						<div>
							<label class="form-label">Observacion</label>
							<textarea v-model="Motivo" class="form-control"
								placeholder="Ejm: Ingrese correctamente su nombre" disabled>
							</textarea>
						</div>
					</div>
				</div>
			</div>
		</form>
	</div>
</template>

<script setup>
import { onMounted, onUnmounted, ref } from 'vue';
import $ from 'jquery';
import alertify from 'alertifyjs';
import { solicitudServices } from '@/services'
const service = new solicitudServices();

import { useAuthStore, useAlertifyStore } from '@/stores';
const userStore = new useAuthStore();
const alertifyStore = new useAlertifyStore();
let linkMeet = ref('');
let solicitante = ref('');
let entidad = ref('');
let expediente = ref('');
let Motivo = ref('');


let table;
let Usuario = userStore.usuario.usuarioId;
onMounted(async () => {
	await service.fetchAllSolicitudRegUSUARIO(Usuario);
	const solicidudes = await service.getSolicitudRegUSUARIO();
	table = $('#tbSolicitudRegUsuario').DataTable({
		data: solicidudes.value,
		columns: [
			{ defaultContent: `<button class="btn btn-primary btn-sm btnVer">+</button>`, title: '+', orderable: false, },
			{ data: 'solicitudId', title: 'ID' },
			{ data: 'solicitanteNombre', title: 'Solicitante' },
			{ data: 'entidad', title: 'Entidad' },
			{ data: 'expediente', title: 'Expediente' },
			{ data: 'fechaInicio', title: 'fechaInicio' },
			// { data: 'horaInicio', title: 'horaInicio' },
			{ data: 'fechaFin', title: 'fechaFin' },
			// { data: 'horaFin', title: 'horaFin' },
			// { data: 'urlSesion', title: 'URL Sesion' },
			{ data: 'estadoSolicitud', title: 'Estado' }
		],
		columnDefs: [
			{ "className": "dt-center", "targets": "_all" }
		],
		pageLength: 5,
		order: [[1, 'asc']],
		responsive: true,
		autoWidth: false,
		dom: 'Bfrtip',
		language: {
			search: 'Buscar',
			zeroRecords: 'No hay registros para mostrar',
			info: 'Mostrando del _START_ a _END_ de _TOTAL_ registros',
			paginate: { first: 'Primero', previous: 'Anterior', next: 'Siguiente', last: 'Ultimo' }
		},
	});
	let modalDetallSoRegistros = $('#modalDetallSoRegistros')[0];
	table.on('click', '.btnVer', function () {
		const data = table.row($(this).parents('tr')).data();
		alertifyStore.alertifyWaitingOpen();
		setTimeout(() => {
			alertify.alert('')
				.setHeader('<div style="text-align: center; font-size: 1.2em; font-weight: bold">Detalles Solicitud</div>')
				.setContent(modalDetallSoRegistros)
				.set({
					'closable': false, 'movable': false, label: 'OK',
					onok: async function () {
						console.log(data)
					}
				}).closeOthers();
		}, 1500)
		solicitante.value = data.solicitanteNombre
		entidad.value = data.entidad
		expediente.value = data.expediente
		linkMeet.value = data.urlSesion;
		Motivo.value = data.motivo
	})
});

onUnmounted(() => {
	// Destruye la tabla cuando el componente se desmonta para evitar pérdidas de memoria
	if (table) {
		table.destroy();
	}
});
</script>

<style scoped></style>





