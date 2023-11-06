<template>
  <NavBar />
  <!-- PruebasUbuntu server -->
  <div class="container my-4">
    <RouterView />
  </div>
</template>

<script setup>

import NavBar from '@/components/NavBar.vue';
import { RouterView } from 'vue-router';
import { onBeforeMount } from 'vue';
import alertify from 'alertifyjs';


alertify.defaults.transition = "fade";
alertify.defaults.theme.ok = "btn btn-primary";
alertify.defaults.theme.cancel = "btn btn-default btn-outline-dark";
alertify.defaults.theme.input = "form-control";

import googleApiServices from './services/googleApiServices';

const gapi = new googleApiServices();

onBeforeMount(async () => {
  await gapi.initClient();
})





</script>