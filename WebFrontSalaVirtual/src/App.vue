<template>
  <RouterView />
</template>

<script setup>
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