<template>
	<div class="row">
		<div class="col">
			<h3>Vista Solicitante</h3>
		</div>
	</div>
	<div class="row">
		<div class="col">
			<nav>
				<div class="nav nav-tabs" id="nav-tab" role="tablist">
					<button class="nav-link active" id="nav-EnvSolicitud-tab" data-bs-toggle="tab"
						data-bs-target="#nav-EnvSolicitud" type="button" role="tab" aria-controls="nav-EnvSolicitud"
						aria-selected="true">
						Enviar Solicitud
					</button>
					<button class="nav-link" id="nav-RegSolicitante-tab" data-bs-toggle="tab"
						data-bs-target="#nav-RegSolicitante" type="button" role="tab" aria-controls="nav-RegSolicitante"
						aria-selected="false">
						Registros
					</button>

				</div>
			</nav>

			<div class="tab-content" id="nav-tabContent">
				<div class="tab-pane fade show active" id="nav-EnvSolicitud" role="tabpanel"
					aria-labelledby="nav-EnvSolicitud-tab" tabindex="0">
					<div class="row mt-3">
						<div class="col">
							<button type="button" name="" id="" class="btn btn-primary">Exportar</button>
						</div>

					</div>
					<div class="row mt-3">
						<div class="col">

						</div>
					</div>

				</div>

				<div class="tab-pane fade" id="nav-RegSolicitante" role="tabpanel" aria-labelledby="nav-RegSolicitante-tab" tabindex="0">

					<div class="row mt-3">
						<div class="col">
							<button type="button" name="" id="" class="btn btn-primary">Exportar</button>
						</div>

					</div>
					<div class="row mt-3">
						<div class="col">
							<TableSolicitanteRegistros />
						</div>
					</div>

				</div>
			</div>
		</div>
	</div>
</template>

<script setup>
import TableSolicitanteRegistros from '../components/DataTables/TableSolicitanteRegistros.vue';

</script>

<style scoped></style>