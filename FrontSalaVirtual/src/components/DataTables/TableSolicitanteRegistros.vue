<template>
	<div class="table-responsive">
		<DataTables class="table table-striped table-bordered display" :options="dataTableOptions">
			<thead>
				<tr>
					<th>Ver</th>
					<th>ID</th>
					<th>Nombre</th>
					<th>Acciones</th>
				</tr>
			</thead>
			<tbody>
				<tr v-for="item in items" :key="item.id">
					<td>
						<button class="btn btn-primary btn-sm" @click="toggleChildRow(item.id)">Ver</button>
					</td>
					<td>{{ item.id }}</td>
					<td>{{ item.nombre }}</td>
					<td>
						<button class="btn btn-primary btn-sm" @click="ClickAprobar(item.id)">Aprobar</button>
					</td>
				</tr>
				<tr v-if="showChildRow">
					<td :colspan="colspan">
						<div class="child-row-content">
							Contenido del Child Row para el elemento con aaID: {{ selectedItemId }}
						</div>
					</td>
				</tr>
			</tbody>
		</DataTables>
	</div>
</template>

<script setup>
import { ref } from 'vue';
import DataTables from 'datatables.net-vue3';
import DataTablesLib from 'datatables.net-bs5';

DataTables.use(DataTablesLib);

const items = ref([
	{ id: 1, nombre: 'Fredd' },
	{ id: 2, nombre: 'John' },
	{ id: 3, nombre: 'Moises' },
	{ id: 4, nombre: 'Juan' },
	{ id: 5, nombre: 'Carlos' },
	// Agrega más objetos según tus datos
]);

const showChildRow = ref(false);
const selectedItemId = ref(null);
const colspan = 4;

const ClickAprobar = (id) => {
	console.log(`Aprobando fila con ID: ${id}`);
	// Lógica para denegar
};
const toggleChildRow = (id) => {
	showChildRow.value = !showChildRow.value;
	selectedItemId.value = id;
};

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
	},
	select: {
		style: 'single'
	}
});
</script>

<style scoped>
.child-row-content {
	background-color: #f0f0f0;
	padding: 10px;
	border: 1px solid #ccc;
	border-radius: 5px;
	color: #333;
}
</style>


