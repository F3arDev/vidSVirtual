<template>
	<div class="container">
		<div class="row">
			<div class="col">
				<div class="card">
					<div class="card-body">
						<h5 class="card-title">Envio de Solicitud para Reserva de Sala Virtual</h5>
						<div class="row justify-content-center g-2">
							<div class="col-4">
								<div class="card">
									<div class="card-body">
										<p> El sistema Solicitudes de Sala Virtuales
											Pide que por favor ingrese correctamente los datos acorde su solicitud.
											Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,
											when
											an
											unknown printer took a galley of type and scrambled it to make a type specimen
											book.
											It
											has survived not only five centuries, but also the leap into electronic
											typesetting
										</p>
									</div>
								</div>

							</div>

							<div class="col">
								<div class="card">
									<div class="card-body">
										<div class="row "> <!--justify-content-center align-items-center g-2-->
											<div class="col">
												<!-- Input Usuario -->
												<div class="input-group mb-3">
													<span class="col-3 input-group-text" id="inputGroup-sizing-default">
														Usuario
													</span>
													<input v-model="Usuario" type="text" class="form-control"
														aria-label="Sizing example input"
														aria-describedby="inputGroup-sizing-default">
												</div>
												<!-- Input Fechas -->
												<div class="row">
													<div class="col">
														<div class="col-5 input-group mb-3">
															<span class="input-group-text"
																id="inputGroup-sizing-default">Fecha Inicio</span>
															<input v-model="FechaInicio" type="date" class="form-control"
																aria-label="Sizing example input"
																aria-describedby="inputGroup-sizing-default">
														</div>
													</div>
													<div class="col">
														<div class=" input-group mb-3">
															<span class="col-5 input-group-text"
																id="inputGroup-sizing-default">Fecha Final</span>
															<input v-model="FechaFin" type="date" class="form-control"
																aria-label="Sizing example input"
																aria-describedby="inputGroup-sizing-default">
														</div>
													</div>
												</div>
												<!-- Input Horas -->
												<div class="row">
													<div class="col">
														<div class="input-group mb-3">
															<span class=" col-5 input-group-text"
																id="inputGroup-sizing-default">Hora Inicio</span>
															<input v-model="HoraInicio" type="time" class="form-control"
																aria-label="Sizing example input"
																aria-describedby="inputGroup-sizing-default">
														</div>
													</div>
													<div class="col">
														<div class="input-group mb-3">
															<span class=" col-5 input-group-text"
																id="inputGroup-sizing-default">Hora Final</span>
															<input v-model="HoraFin" type="time" class="form-control"
																aria-label="Sizing example input"
																aria-describedby="inputGroup-sizing-default">
														</div>
													</div>
												</div>

												<div class="input-group mb-3">
													<span class="input-group-text col-3" id="inputGroup-sizing-default">
														Expediente
													</span>
													<input v-model="Expediente" type="text" class="form-control"
														aria-label="Sizing example input"
														aria-describedby="inputGroup-sizing-default">
												</div>

												<div class="input-group">
													<span class="input-group-text " id="inputGroup-sizing-default">
														Actividad a realizar
													</span>
													<textarea v-model="Actividad" type="text" class="form-control"
														aria-label="Sizing example input"
														aria-describedby="inputGroup-sizing-default"></textarea>
												</div>

												<div class="row justify-content-center mt-3">
													<div class="col text-end">
														<button @click="getDataSolicitud" type="button" name="" id=""
															class="btn btn-primary ">Enviar</button>
													</div>
												</div>
											</div>
										</div>
									</div>
								</div>
							</div>

						</div>

					</div>
				</div>
			</div>
		</div>
	</div>
</template>

<script setup>
import { ref } from 'vue';
import solicitudServices from '@/services/solicitudServices'
const service = new solicitudServices();

let Usuario = ref('')
let FechaInicio = ref('')
let FechaFin = ref('')
let HoraInicio = ref('')
let HoraFin = ref('')
let VwDepMunicipioId = ref('')
let Expediente = ref('')
let Actividad = ref('')


const getDataSolicitud = async () => {
	let jsonSendSolicitud =
	{
		"solicitanteId": Usuario.value,
		"fechaRegistro": FechaInicio.value,
		"fechaInicio": FechaInicio.value,
		"fechaFin": FechaFin.value,
		"horaInicio": HoraInicio.value + ':00',
		"horaFin": HoraFin.value  + ':00',
		"vwDepMunicipioId": '1',
		"expediente": Expediente.value,
		"actividad": Actividad.value
	}
	// let jsonSendSolicitud =
	// {
	// 	"solicitanteId": '3',
	// 	"fechaRegistro": "2023-09-21T00:00:00",
	// 	"fechaInicio": "2023-09-23T00:00:00",
	// 	"fechaFin": "2023-09-24T00:00:00",
	// 	"horaInicio": "09:00:00",
	// 	"horaFin": "09:00:00",
	// 	"vwDepMunicipioId": '1',
	// 	"expediente": "Exp002",
	// 	"actividad": "Conferencia"
	// }

	let result = await service.sendSolicitudPEN(jsonSendSolicitud)
	console.log(result);
}


</script>

<style scoped></style>