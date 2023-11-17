<template>
	<header class="navbar sticky-top bg-primary flex-md-nowrap p-0 shadow">
		<a class="navbar-brand col-md-3 col-lg-2 me-0 px-3 fs-6 text-white">
			CSJ - DGTIC
		</a>
		<!-- 
		<ul class="navbar-nav flex-row d-md-none">
			<li class="nav-item text-nowrap">

			</li>

			<li class="nav-item text-nowrap">

			</li>

		</ul> -->
	</header>

	<div class="container-fluid">
		<div class="row">
			<div class="sidebar-fluid border border-right col-md-3 col-lg-2  bg-body-tertiary">
				<div tabindex="-1" id="sidebarMenu">
					<div class="d-flex flex-column p-0 pt-lg-3 ">
						<div class="dropdown">
							<a class="d-flex align-items-center link-body-emphasis text-decoration-none dropdown-toggle"
								data-bs-toggle="dropdown" aria-expanded="false">
								<img src="../assets/imgIcon.jpg" alt="" width="32" height="32" class="rounded-circle me-2">
								<strong>Usuario</strong>
							</a>
							<ul class="dropdown-menu text-small shadow">
								<li><a class="dropdown-item">Config</a></li>
								<li><a class="dropdown-item">Perfil</a></li>
								<li>
									<hr class="dropdown-divider">
								</li>
								<li><a class="dropdown-item">Sign out</a></li>
							</ul>
						</div>
						<hr>
						<ul class="nav nav-pills flex-column mb-auto" id="pills-tab" role="tablist">
							<li class="nav-item" role="presentation">

								<router-link to="/aprobante/inicio" class="nav-link"
									:class="{ 'active': isRouteActive('/aprobante/inicio') }" exact>
									<i class="bi bi-house mx-1"></i>
									Inicio
								</router-link>
							</li>
							<li class="nav-item" role="presentation">
								<router-link to="/aprobante/solicitudes" class="nav-link"
									:class="{ 'active': isRouteActive('/aprobante/solicitudes') }">
									<i class="bi bi-file-earmark-text mx-1"></i>
									Solicitudes
								</router-link>
							</li>
							<li class="nav-item" role="presentation">
								<router-link to="/aprobante/registros" class="nav-link"
									:class="{ 'active': isRouteActive('/aprobante/registros') }">
									<i class="bi bi-file-earmark-text mx-1"></i>
									Registros
								</router-link>
							</li>
						</ul>
						<hr>
					</div>
				</div>
			</div>
			<!-- Inyecta vista en el slot -->
			<slot></slot>
		</div>
	</div>
</template>

<script setup>
import { useRoute } from 'vue-router';
//simple funcion que ocupa para verificar y pintar un estilo dependido donde se encuentre
const isRouteActive = (route) => {
	const currentRoute = useRoute();
	return currentRoute.path == route;
};
</script>


<style scoped>
.row {
	height: 90vh;
}

.nav-scroller .nav {
	display: flex;
	flex-wrap: nowrap;
	padding-bottom: 1rem;
	margin-top: -1px;
	overflow-x: auto;
	text-align: center;
	white-space: nowrap;
	-webkit-overflow-scrolling: touch;
}

.bd-mode-toggle .dropdown-menu .active .bi {
	display: block !important;
}

.bi {
	display: inline-block;
	width: 1rem;
	height: 1rem;
}

.sidebar .nav-link {
	font-size: .875rem;
	font-weight: 500;
}

/*
 * Navbar
 */

.navbar-brand {
	padding-top: .75rem;
	padding-bottom: .75rem;
	background-color: rgba(0, 0, 0, .25);
	box-shadow: inset -1px 0 0 rgba(0, 0, 0, .25);
}

.navbar .form-control {
	padding: .75rem 1rem;
}


.dropdown-toggle {
	outline: 0;
}
</style>