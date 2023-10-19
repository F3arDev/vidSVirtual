<template>
	<div class="row justify-content-center align-items-center g-2">
		<div class="col-6">
			<div class="row">
				<div class="card text-start">
					<div class="d-flex justify-content-center align-items-center mt-3" >
						<svg xmlns="http://www.w3.org/2000/svg" width="125" height="125" fill="currentColor"
							class="bi bi-person-circle bi-4x d-flex justify-content-center align-items-center mt-3"
							viewBox="0 0 16 16">
							<path d="M11 6a3 3 0 1 1-6 0 3 3 0 0 1 6 0z" />
							<path fill-rule="evenodd"
								d="M0 8a8 8 0 1 1 16 0A8 8 0 0 1 0 8zm8-7a7 7 0 0 0-5.468 11.37C3.242 11.226 4.805 10 8 10s4.757 1.225 5.468 2.37A7 7 0 0 0 8 1z" />
						</svg>
					</div>
					<div class="card-body ">
						<h2 class="card-title">Inicio de Sesion</h2>
						<form>
							<div class="mb-3">
								<label for="exampleInputEmail1" class="form-label">Email address</label>
								<input v-model="Usuario" type="email" class="form-control">
							</div>
							<div class="mb-3">
								<label for="exampleInputPassword1" class="form-label">Password</label>
								<input v-model="pass" type="password" class="form-control" id="exampleInputPassword1">
							</div>

							<button type="submit" class="btn btn-primary">Submit</button>
							{{ Usuario }}
							{{ pass }}

						</form>
					</div>
				</div>
			</div>
		</div>
	</div>
</template>

<script setup>
import { ref } from 'vue';

let Usuario = ref('');
let pass = ref('');


</script>

<style></style>