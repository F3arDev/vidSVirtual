<template>
	<div class="table-responsive">
		<table id="tblSolicitudRegistros" class="table table-bordered table-striped">
			<thead>
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
	await service.fetchAllSolicitud();
	const solicidudes = await service.getSolicitud();
	table = $('#tblSolicitudRegistros').DataTable({
		data: solicidudes.value,
		columns: [
			{ defaultContent: `<button class="btn btn-primary btn-sn btnAgregar">Ver</button>`, title: 'ver' },
			{ data: 'solicitudID', title: 'ID' },
			{ data: 'solicitanteNombre' , title: 'Usuario' },
			{ data: 'entidad' , title: 'Entidad' },
			{ data: 'expediente' , title: 'Expediente' },
			{ data: 'fechaInicio' , title: 'fechaInicio' },
			{ data: 'horaInicio' , title: 'horaInicio' },
			{ data: 'fechaFin' , title: 'fechaFin' },
			{ data: 'horaFin' , title: 'horaFin' },
			{ data: 'urlSesion' , title: 'URL Sesion'},
			{ data: 'estadoSolicitud', title: 'Estado' }
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


