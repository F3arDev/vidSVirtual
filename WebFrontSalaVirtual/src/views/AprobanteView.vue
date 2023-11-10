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
					<div class="row">
						<div class="col m-2">
							<TableSolicitudes @update="eventUpdate" />
						</div>
					</div>
				</div>
				<div class="tab-pane fade" id="nav-profile" role="tabpanel" aria-labelledby="nav-profile-tab" tabindex="0">
					<div class="row">
						<div class="col m-2">
							<TableRegistros ref="componente" />
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
import { ref } from 'vue'
const componente = ref(null);


const eventUpdate = () => {
	console.log('Recepcion de Hijo1');
	// Emitir señal al Hijo2

	componente.value.updateTblSoliRegistro();
};
</script>

<style scoped></style>