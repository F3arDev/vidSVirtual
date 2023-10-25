<template>
	<div class="container">

		<div class="row justify-content-center g-2">
			<div class="col">
				<div class="input-group mb-3">
					<span class="input-group-text col-3">Solicitante</span>
					<input type="text" class="form-control" placeholder="Username" aria-label="Username"
						aria-describedby="basic-addon1" disabled>
				</div>
				<div class="input-group mb-3">
					<span class="input-group-text col-3">Numero</span>
					<input type="text" class="form-control" placeholder="Username" aria-label="Username"
						aria-describedby="basic-addon1" disabled>
				</div>

				<div class="input-group mb-3">
					<span class="input-group-text col-3">Entidad</span>
					<input type="text" class="form-control" placeholder="Username" aria-label="Username"
						aria-describedby="basic-addon1" disabled>
				</div>

				<div class="input-group mb-3">
					<span class="input-group-text col-3">Ciudad</span>
					<input type="text" class="form-control" placeholder="Username" aria-label="Username"
						aria-describedby="basic-addon1" disabled>
				</div>
				<div class="input-group mb-3">
					<span class="input-group-text col-3">Expediente</span>
					<input type="text" class="form-control" placeholder="Username" aria-label="Username"
						aria-describedby="basic-addon1" disabled>
				</div>
			</div>
			<div class="col">
				<!-- Input Fechas -->
				<div class="row">
					<div class="col">
						<div class="input-group mb-3">
							<span class="input-group-text col-5">Fecha Inicio</span>
							<input type="date" class="form-control" aria-label="Sizing example input"
								aria-describedby="inputGroup-sizing-default" disabled>
						</div>
					</div>
					<div class="col">
						<div class="input-group mb-3">
							<span class="input-group-text col-5">Fecha Final</span>
							<input type="date" class="form-control" aria-label="Sizing example input"
								aria-describedby="inputGroup-sizing-default" disabled>
						</div>
					</div>
				</div>
				<!-- Input Horas -->
				<div class="row">
					<div class="col">
						<div class="input-group mb-3">
							<span class="input-group-text  col-5">Hora Inicio</span>
							<input type="time" class="form-control" aria-label="Sizing example input"
								aria-describedby="inputGroup-sizing-default" disabled>
						</div>
					</div>
					<div class="col">
						<div class="input-group mb-3">
							<span class="input-group-text col-5">Hora Final</span>
							<input type="time" class="form-control" aria-label="Sizing example input"
								aria-describedby="inputGroup-sizing-default" disabled>
						</div>
					</div>
				</div>
				<div class="row justify-content-center align-items-center g-2">
					<div class="col">
						<div class="input-group">
							<span class="input-group-text">
								Actividad a realizar
							</span>
							<textarea type="text" class="form-control" aria-label="Sizing example input"
								aria-describedby="inputGroup-sizing-default" disabled></textarea>
						</div>
					</div>
				</div>

			</div>
		</div>


	</div>
</template>

<script setup>

</script>

<style scoped></style>