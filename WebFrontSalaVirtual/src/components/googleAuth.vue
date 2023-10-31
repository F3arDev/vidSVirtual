<template>
	<div>google auth</div>

	<button @click="Login()">logingoogle</button>
	<button @click="LoadCalendar()">Load</button>
	<button @click="loadMeets()">Mostrar y crear meets</button>
</template>

<script setup>

import googleApiServices from '../services/googleApiServices.js'

const gapi = new googleApiServices();
var access_token;

const LoadCalendar = async () => {
	try {
		await gapi.ValidateToken()
		// access_token = await gapi.createEventMeet();
		console.log('token:' + await access_token.error)
	} catch (error) {
		console.log(error)
	}
};
const Login = async () => {
	gapi.getInitClient()
};

const loadMeets = async () => {
	gapi.createEventMeet();
	console.log('token:' + access_token)
};

</script>