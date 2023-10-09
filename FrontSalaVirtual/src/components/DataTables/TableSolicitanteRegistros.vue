<template>
	<div class="table-responsive">
		<DataTables :options="dataTableOptions">
			<thead>
				<tr>
					<th></th>
					<th>Name</th>
					<th>Position</th>
					<th>Office</th>
					<th>Salary</th>
				</tr>
			</thead>
		</DataTables>
	</div>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import DataTables from 'datatables.net-vue3';
import 'datatables.net-bs5/css/dataTables.bootstrap5.min.css';

// Formatting function for row details - modify as needed
const formatDetails = (data) => {
	return `<dl>
				<dt>Full name:</dt>
				<dd>${data.name}</dd>
				<dt>Position:</dt>
				<dd>${data.position}</dd>
				<dt>Office:</dt>
				<dd>${data.office}</dd>
				<dt>Salary:</dt>
				<dd>${data.salary}</dd>
			</dl>`;
};

const dataTableOptions = ref({
	data: [
		{ name: 'John Doe', position: 'Developer', office: 'New York', salary: '$80,000' },
		{ name: 'Jane Smith', position: 'Designer', office: 'London', salary: '$75,000' },
		// Add more objects as needed
	],
	columns: [
		{
			className: 'details-control',
			orderable: false,
			data: null,
			defaultContent: ''
		},
		{ data: 'name' },
		{ data: 'position' },
		{ data: 'office' },
		{ data: 'salary' }
	],
	order: [[1, 'asc']]
});

onMounted(() => {
	const table = new DataTables.DataTable('#example', {
		data: dataTableOptions.value.data,
		columns: dataTableOptions.value.columns,
		order: dataTableOptions.value.order
	});

	// Add event listener for opening and closing details
	table.on('click', 'td.details-control', function () {
		let tr = $(this).closest('tr');
		let row = table.row(tr);

		if (row.child.isShown()) {
			// This row is already open - close it
			row.child.hide();
			tr.removeClass('shown');
		} else {
			// Open this row
			row.child(formatDetails(row.data())).show();
			tr.addClass('shown');
		}
	});
});
</script>


<style scoped></style>