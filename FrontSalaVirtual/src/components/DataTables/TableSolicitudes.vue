<template>
	<div class="table-responsive">
		<DataTables class="table table-striped table-bordered display" :data="items" :columns="Columns"
			:options="dataTableOptions">
			<thead>
				<tr>
					<th>Detalles</th>
					<th>ID</th>
					<th>Nombre</th>
					<th>Expediente</th>
					<th>Estado</th>
					<th>Acciones</th> <!-- Nueva columna para los botones -->
				</tr>
			</thead>
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

const name = ref('Vue.js')
function greet(event) {
	alert(`Hello ${name.value}!`)
	// `event` is the native DOM event
	if (event) {
		alert(event.target.tagName)
	}
}

const handleDenegarClick = (id) => {
	console.log(`Denegando fila con ID: ${id}`);
	// Lógica para denegar
};

const Columns = [
	{
		data: null,
		render: (data, type, row) => {
			return `<button class="btn btn-primary btn-sm" @click="handleVerClick(${row.id})">Ver Mas</button>
                    
					`;
		}
	},
	{
		data: 'id'
		// data: null, render: function (data, type, row, meta) { return `${meta.row + 1}` }
	},
	{ data: 'nombre' },
	{ data: 'expediente' },
	{ data: 'estado' },
	{
		data: null,
		render: (data, type, row) => {
			return `
			<button @click="greet">Greet</button>
			<button class="btn btn-primary btn-sm" @click="ClickAprobar(${row.id})">Aprobar</button>
					<button class="btn btn-danger btn-sm" @click="handleDenegarClick(${row.id})">Denegar</button>
					`;
		}
	}
]

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
	// columns: [
	// 	{
	// 		render: (data, type, row, meta) => {
	// 			return `
	//             <button class="btn btn-info btn-sm" @click="toggleDetails(${meta.row})">
	//                 ${showDetails.value[meta.row] ? 'Ocultar' : 'Mostrar'}
	//             </button>
	//         `;
	// 		}
	// 	},
	// 	null, //ID
	// 	null, // Nombre
	// 	null, // Expediente
	// 	null, // Estado
	// 	{
	// 		render: (data, type, row) => {
	// 			return `
	// 				<button class="btn btn-primary btn-sm" @click="handleAprobarClick(${row.id})">Aprobar</button>
	// 				<button class="btn btn-danger btn-sm" @click="handleDenegarClick(${row.id})">Denegar</button>
	//     `;
	// 		}
	// 	}
	// ],
	// childRow: {
	// 	format: function (data) {
	// 		return `<div v-if="showDetails[data.index]">${data.detalles}</div>`;
	// 	}
	// }
});





</script>

<style scoped></style>