import $ from 'jquery';
import 'datatables.net-bs5/js/dataTables.bootstrap5.min.js';

$.extend(true, $.fn.dataTable.defaults, {
	// Configuraciones globales de DataTables que se aplicarán a todas las tablas
});

export default $;
