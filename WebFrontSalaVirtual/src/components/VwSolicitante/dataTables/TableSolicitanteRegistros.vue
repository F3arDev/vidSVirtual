<template>
	<div class="table-responsive">
		<DataTable class="table table-striped table-bordered display" :options="dataTableOptions">
			<thead>
				<tr>
					<th>Ver</th>
					<th>ID</th>
					<th>Nombre</th>
					<th></th>
				</tr>
			</thead>
			<tbody>
				<tr v-for="item in items" :key="item.id">
					<td>
						<button class="btn btn-primary btn-sm" @click="toggleChildRow(item.id)">Ver</button>
					</td>
					<td>{{ item.id }}</td>
					<td>{{ item.nombre }}</td>
				</tr>
			</tbody>
		</DataTable>
	</div>
</template>

<script setup>
import { ref } from 'vue';
import DataTable from 'datatables.net-vue3';
import DataTablesLib from 'datatables.net-bs5';

DataTable.use(DataTablesLib);

const items = ref([
	{ id: 1, nombre: 'Fredd' },
	{ id: 2, nombre: 'John' },
	{ id: 3, nombre: 'Moises' },
	{ id: 4, nombre: 'Juan' },
	{ id: 5, nombre: 'Carlos' },
	// Agrega más objetos según tus datos
]);

const dataTableOptions = ref({
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
</script>

<style scoped>

</style>


