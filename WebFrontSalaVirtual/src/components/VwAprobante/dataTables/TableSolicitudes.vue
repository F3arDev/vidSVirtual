<template>
	<div class="table-responsive">
		<p>asdd</p>
	</div>
</template>

<script setup>
import DataTable from 'datatables.net-vue3';
import DataTablesLib from 'datatables.net-bs5';
DataTable.use(DataTablesLib);


// onMounted(async () => {
// 	try {
// 		const response = await axios.get(url);

// 		items.value = response.data;
// 	} catch (error) {
// 		console.log(error)
// 	}
// });

// const dataTableOptions = ref({
// 	responsive: true,
// 	autoWidth: false,
// 	dom: 'Bfrtip',
// 	language: {
// 		search: 'Buscar',
// 		zeroRecords: 'No hay registros para mostrar',
// 		info: 'Mostrando del _START_ a _END_ de _TOTAL_ registros',
// 		infoFiltered: '(Filtrados de _Max_ registros.)',
// 		paginate: { first: 'Primero', previous: 'Anterior', next: 'Siguiente', last: 'Ultimo' }
// 	}
// });


</script>

<style scoped></style>


