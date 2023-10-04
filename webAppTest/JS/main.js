let data = [];
$(document).ready(function () {
	let tablaSolicitud = $('#tablaSolicitud').DataTable({
		columns: [
			{ data: 'solicitudId', title: 'ID' },
			{ data: 'solicitanteId', title: 'Sol' },
			{ data: 'fechaInicio', title: 'Fecha' },
			{ data: 'fechaFin', title: 'Fecha' },
			{ data: 'horaInicio', title: 'Hora' },
			{ data: 'horaFin', title: 'Hora' },
			{ data: 'vwDepMunicipioId', title: 'DepM' },
			{ data: 'expediente', title: 'Exped' },
			{ data: 'actividad', title: 'Act' },
			{ data: 'urlSesion', title: 'URL' },
			{ data: 'motivo', title: 'Mot' },
			{ data: 'estadoSolicitudId', title: 'EstadoS' },
			{ data: 'estadoRegistroId', title: 'EstadoR' }
		],

		select: {
			style: 'single',
		},
		language: {
			url: '//cdn.datatables.net/plug-ins/1.13.6/i18n/es-MX.json',
		},
	});

	$('#btnCargarSolicitud').on('click', function () {
		console.log(data);
		tablaSolicitud.rows.add(data).draw();
	});

	$('#btnEnviarSolicitud').on('click', function () {
		getSolicitud();
	});
})

async function getSolicitud() {
	try {
		let url = 'http://localhost:5172/api/v1/Solicitud/Lista';
		const response = await axios.get(url);
		data = response.data;
		console.log(data);
	} catch (error) {
		console.error(error);
	}
}

function updateTable() {
	tablaSolicitud.clear().rows.add(data).draw();
}

function postSolicitud() {


}