<template>
	<div>google auth</div>

	<button @click="Login()">logingoogle</button>
	<button @click="LoadCalendar()">Load</button>
	<button @click="loadMeets()">Mostrar y crear meets</button>
</template>

<script setup>

import googleApiServices from '../services/googleApiServices.js'

const gapi = new googleApiServices();
var result;
var access_token;
const LoadCalendar = async () => {
	access_token = gapi.createEventMeet();

	console.log('token:' + access_token)
};
const Login = async () => {
	gapi.getInitClient()
};

const loadMeets = async () => {
	result = await gapi.createEventMeet();

	console.log(result)
};
// function revokeToken() {
// 	google.accounts.oauth2.revoke(access_token, () => { console.log('access token revoked') });
// }

</script>