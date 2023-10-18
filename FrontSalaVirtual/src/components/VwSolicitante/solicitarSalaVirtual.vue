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
													<span class="input-group-text" id="inputGroup-sizing-default">
														Usuario
													</span>
													<input type="text" class="form-control"
														aria-label="Sizing example input"
														aria-describedby="inputGroup-sizing-default">
												</div>
												<!-- Input Fechas -->
												<div class="row">
													<div class="col">
														<div class="input-group mb-3">
															<span class="input-group-text"
																id="inputGroup-sizing-default">Fecha Inicio</span>
															<input type="date" class="form-control"
																aria-label="Sizing example input"
																aria-describedby="inputGroup-sizing-default">
														</div>
													</div>
													<div class="col">
														<div class="input-group mb-3">
															<span class="input-group-text"
																id="inputGroup-sizing-default">Fecha Final</span>
															<input type="date" class="form-control"
																aria-label="Sizing example input"
																aria-describedby="inputGroup-sizing-default">
														</div>
													</div>
												</div>
												<!-- Input Horas -->
												<div class="row">
													<div class="col">
														<div class="input-group mb-3">
															<span class="input-group-text"
																id="inputGroup-sizing-default">Hora Inicio</span>
															<input type="time" class="form-control"
																aria-label="Sizing example input"
																aria-describedby="inputGroup-sizing-default">
														</div>
													</div>
													<div class="col">
														<div class="input-group mb-3">
															<span class="input-group-text"
																id="inputGroup-sizing-default">Hora Final</span>
															<input type="time" class="form-control"
																aria-label="Sizing example input"
																aria-describedby="inputGroup-sizing-default">
														</div>
													</div>
												</div>
												<div class="input-group mb-3">
													<span class="input-group-text" id="inputGroup-sizing-default">
														Expediente
													</span>
													<input type="text" class="form-control"
														aria-label="Sizing example input"
														aria-describedby="inputGroup-sizing-default">
												</div>
												<div class="input-group">
													<span class="input-group-text " id="inputGroup-sizing-default">
														Actividad a realizar
													</span>
													<textarea  type="text" class="form-control"
														aria-label="Sizing example input"
														aria-describedby="inputGroup-sizing-default"></textarea>
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
// let startDate = document.getElementById('startDate')
// let endDate = document.getElementById('endDate')

// startDate.addEventListener('change', (e) => {
// 	let startDateVal = e.target.value
// 	document.getElementById('startDateSelected').innerText = startDateVal
// })

// endDate.addEventListener('change', (e) => {
// 	let endDateVal = e.target.value
// 	document.getElementById('endDateSelected').innerText = endDateVal
// })  
</script>

<style scoped></style>