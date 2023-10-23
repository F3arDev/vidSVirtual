<template>
	<div class="table-responsive">
		<table id="tblSolicitudes" class="table table-bordered">
			<thead>
				<tr>
					<th>id</th>
					<th>Solicitante</th>
					<th>Entidad</th>
					<th>expediente</th>
					<th>actividad</th>
					<th>fechaInicio</th>
					<th>horaInicio</th>
					<th>fechaFin</th>
					<th>horaFin</th>
					<th>Acciones</th>

				</tr>
			</thead>
		</table>
	</div>
</template>

<script setup>
import { onMounted, onUnmounted } from 'vue';
import $ from 'jquery';
import solicitudServices from '@/services/solicitudServices'
const service = new solicitudServices();
let table;

onMounted(async () => {
	await service.fetchAllSolicitudPEN();
	const solicidudesPEN = await service.getSolicitudPEN();
	table = $('#tblSolicitudes').DataTable({
		data: solicidudesPEN.value,
		columns: [
			{ data: 'solicitudId' },
			{ data: 'solicitanteId' },
			{ data: 'vwDepMunicipioId' },
			{ data: 'expediente' },
			{ data: 'actividad' },
			{ data: 'fechaInicio' },
			{ data: 'horaInicio' },
			{ data: 'fechaFin' },
			{ data: 'horaFin' },
			{ defaultContent: `<button class="btn btn-primary btn-sn btnAgregar">Enviar</button>`, title: 'Acciones' }
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
})

onUnmounted(() => {
	// Destruye la tabla cuando el componente se desmonta para evitar pérdidas de memoria
	if (table) {
		table.destroy();
	}
});
</script>

<style scoped></style>


