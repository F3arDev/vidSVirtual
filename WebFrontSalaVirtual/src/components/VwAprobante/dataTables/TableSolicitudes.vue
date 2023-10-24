<template>
	<div class="table-responsive">
		<table id="tblSolicitudes" class="table table-bordered">
			<thead>
				<tr>
					<th>ver</th>
					<th>id</th>
					<th>Solicitante</th>
					<th>Entidad</th>
					<th>expediente</th>
					<!-- <th>actividad</th>
					<th>fechaInicio</th>
					<th>horaInicio</th> -->
					<th>fechaFin</th>
					<th>horaFin</th>
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
								<input type="text" class="form-control" placeholder="Ingrese el Url de google Meets"
									aria-label="Recipient's username" aria-describedby="button-addon2">
								<button class="btn btn-outline-secondary" type="button" id="button-addon2">Generar
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
import { onMounted, onUnmounted } from 'vue';
import $ from 'jquery';
import alertify from 'alertifyjs';
import solicitudServices from '@/services/solicitudServices'
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
				defaultContent: ''
			},
			{ data: 'solicitudId' },
			{ data: 'solicitanteId' },
			{ data: 'vwDepMunicipioId' },
			// { data: 'expediente' },
			// { data: 'actividad' },
			// { data: 'fechaInicio' },
			{ data: 'horaInicio' },
			{ data: 'fechaFin' },
			{ data: 'horaFin' },
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
		setTimeout(function () {
			const data = table.row($(this).closest('tr')).data();
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
						labels: { "ok": "SI", "cancel": "NO" },
						resizable: true,
						onok: function () {
							console.log(data);
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
			
			



				${data.horaInicio}
			`
		);
	}

})

onUnmounted(() => {
	// Destruye la tabla cuando el componente se desmonta para evitar pérdidas de memoria
	if (table) {
		table.destroy();
	}
});
</script>

<style scoped></style>


