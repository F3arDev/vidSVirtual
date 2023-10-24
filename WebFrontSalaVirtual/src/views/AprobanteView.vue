<template>
	<div class="row">
		<div class="col">
			<h3>Vista Aprobante</h3>
		</div>
	</div>
	<div class="row">
		<div class="col">
			<nav>
				<div class="nav nav-tabs" id="nav-tab" role="tablist">
					<button class="nav-link active" id="nav-home-tab" data-bs-toggle="tab" data-bs-target="#nav-home"
						type="button" role="tab" aria-controls="nav-home" aria-selected="true">
						Solicitudes
					</button>
					<button class="nav-link" id="nav-profile-tab" data-bs-toggle="tab" data-bs-target="#nav-profile"
						type="button" role="tab" aria-controls="nav-profile" aria-selected="false">
						Registros de Solicitudes
					</button>

				</div>
			</nav>

			<div class="tab-content" id="nav-tabContent">
				<div class="tab-pane fade show active" id="nav-home" role="tabpanel" aria-labelledby="nav-home-tab"
					tabindex="0">
					<div class="row mt-3">
						<div class="col">
							<button type="button" name="" id="" class="btn btn-primary">Exportar</button>
						</div>

					</div>
					<div class="row mt-3">
						<div class="col">
							<TableSolicitudes />
						</div>
					</div>

				</div>
				<div class="tab-pane fade" id="nav-profile" role="tabpanel" aria-labelledby="nav-profile-tab" tabindex="0">

					<div class="row mt-3">
						<div class="col">
							<button type="button" name="" id="" class="btn btn-primary">Exportar</button>
						</div>
					</div>
					<div class="row mt-3">
						<div class="col">
							<TableRegistros />
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
</template>

<script setup>
import TableSolicitudes from '@/components/VwAprobante/dataTables/TableSolicitudes.vue'
import TableRegistros from '@/components/VwAprobante/dataTables/TableRegistros.vue'

</script>

<style scoped></style>