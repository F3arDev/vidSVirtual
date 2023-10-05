<template>
	<div class="table-responsive">
		<DataTables class="table table-striped table-bordered display" :options="{
			responsive: true, autoWidth: false, dom: 'Bfrtip', language: {
				search: 'Buscar', zeroRecords: 'No hay registros para mostrar',
				info: 'Mostrando del _START_ a _END_ de _TOTAL_ registros',
				infoFiltered: '(Filtrados de _Max_ registros.)',
				paginate: { first: 'Primero', previous: 'Anterior', next: 'Siguiente', last: 'Ultimo' }
			}
		}">
			<thead>
				<tr>
					<th>Nombre</th>
					<th>Expediente</th>
					<th>Estado</th>
				</tr>
			</thead>

		</DataTables>
	</div>
</template>

<script setup>
import DataTables from 'datatables.net-vue3';
import DataTablesLib from 'datatables.net-bs5';

DataTables.use(DataTablesLib);


</script>

<style scoped>

</style>