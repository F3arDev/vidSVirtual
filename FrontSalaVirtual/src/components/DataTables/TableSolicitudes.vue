<template>
	<div class="table-responsive">
		<DataTables class="table table-striped table-bordered display" :options="dataTableOptions">
			<thead>
				<tr>
					<th>Detalles</th>
					<th>Nombre</th>
					<th>Expediente</th>
					<th>Estado</th>
					<th>Acciones</th> <!-- Nueva columna para los botones -->
				</tr>
			</thead>
			<tbody>
				<tr v-for="(item, index) in items" :key="index">
					<td>
						<button class="btn btn-info btn-sm" @click="toggleDetails(index)">
							{{ showDetails[index] ? 'Ocultar' : 'Mostrar' }}
						</button>
					</td>
					<td>{{ item.nombre }}</td>
					<td>{{ item.expediente }}</td>
					<td>{{ item.estado }}</td>
					<td>
						<button class="btn btn-primary btn-sm" @click="handleAprobarClick(item.id)">Aprobar</button>
						<button class="btn btn-danger btn-sm" @click="handleDenegarClick(item.id)">Denegar</button>
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
	{ id: 1, nombre: 'Fredd', expediente: '123', estado: 'Pendiente', detalles: 'Detalles de la fila 1' },
	{ id: 2, nombre: 'John', expediente: '456', estado: 'Aprobado', detalles: 'Detalles de la fila 2' }
	// Agrega más objetos según tus datos
]);

const showDetails = ref(Array(items.value.length).fill(false));

const dataTableOptions = ref({
	responsive: true,
	autoWidth: false,
	dom: 'Bfrtip',
	language: {
		// ... tu configuración de idioma ...
	},
	select: {
		style: 'single'
	},
	columns: [
		{
			render: (data, type, row, meta) => {
				return `
						<button class="btn btn-info btn-sm" @click="toggleDetails(${meta.row})">
						{{ showDetails[${meta.row}] ? 'Ocultar' : 'Mostrar' }}
						</button>
					`;	
			}
		},
		null, // Nombre
		null, // Expediente
		null, // Estado
		{
			render: (data, type, row) => {
				return `
					<button class="btn btn-primary btn-sm" @click="handleAprobarClick(${row.id})">Aprobar</button>
					<button class="btn btn-danger btn-sm" @click="handleDenegarClick(${row.id})">Denegar</button>
        `;
			}
		}
	],
	childRow: {
		format: function (row) {
			return `<div v-if="showDetails[row.index]">${row.detalles}</div>`;
		}
	}
});

const handleAprobarClick = (id) => {
	console.log(`Aprobando fila con ID: ${id}`);
};

const handleDenegarClick = (id) => {
	console.log(`Denegando fila con ID: ${id}`);
};

const toggleDetails = (index) => {
	showDetails.value[index] = !showDetails.value[index];
};

</script>

<style scoped></style>