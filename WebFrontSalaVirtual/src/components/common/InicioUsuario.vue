<template>
	<div class="row">
		<div class="col-4">
			<div class="divCard my-3">
				<h5> IMG/Foto </h5>
				<i class="bi bi-image-fill fs-1"></i>
			</div>
			<div class="divCard my-3">
				<h5> Notificaciones </h5>
				<div class="introDiv">
					<h6>Noti1</h6>
				</div>
			</div>
		</div>
		<div class="col">
			<div class="divCard my-3">
				<h5> Hola! {{ NomUsuario }} </h5>
				<p>Lorem, ipsum dolor sit amet consectetur adipisicing elit. Saepe neque, dolorem quaerat explicabo nobis, voluptatibus ipsa, dicta odio autem eos quisquam molestiae aut modi iste illo consectetur at non odit. Rem tempora consectetur eaque earum ratione similique eum quis. Velit quos minima iure aperiam voluptas nisi aut aliquam architecto assumenda, ipsa numquam nulla odio cupiditate rem temporibus amet, recusandae facilis culpa dicta sit? Nisi dicta laudantium tenetur nesciunt, soluta ullam earum! Consequatur possimus a veritatis blanditiis temporibus rerum, quo eligendi nihil, maxime facilis iusto doloribus esse ipsum perferendis quae enim, dolorem quas asperiores quod dolore. Sunt quae nam itaque mollitia?</p>
				<p>Lorem, ipsum dolor sit amet consectetur adipisicing elit. Saepe neque, dolorem quaerat explicabo nobis, voluptatibus ipsa, dicta odio autem eos quisquam molestiae aut modi iste illo consectetur at non odit. Rem tempora consectetur eaque earum ratione similique eum quis. Velit quos minima iure aperiam voluptas nisi aut aliquam architecto assumenda, ipsa numquam nulla odio cupiditate rem temporibus amet, recusandae facilis culpa dicta sit? Nisi dicta laudantium tenetur nesciunt, soluta ullam earum! Consequatur possimus a veritatis blanditiis temporibus rerum, quo eligendi nihil, maxime facilis iusto doloribus esse ipsum perferendis quae enim, dolorem quas asperiores quod dolore. Sunt quae nam itaque mollitia?</p>
			</div>
		</div>
	</div>
</template>

<script setup>
import { ref } from 'vue';
import { useAuthStore } from '@/stores';
let userStore = new useAuthStore()
let NomUsuario = ref(userStore.usuario.nombre)
</script>

<style scoped>
.introDiv {
	padding: 10px;
	background-color: rgba(224, 224, 224, 0.301);
	border-radius: 5px;
	box-shadow: inset 0px 0px 10px 0 rgba(20, 20, 20, 0.2);
}
</style>