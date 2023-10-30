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
	try {
		access_token = await gapi.createEventMeet();
		console.log('token:' + access_token.error)
		debugger
		if (access_token.error == 401) {
			miFuncion();
		}

	} catch (error) {
		console.log(error)
	}


};
const Login = async () => {
	gapi.getInitClient()
};

const loadMeets = async () => {

	console.log('token:' + access_token)
};
// function revokeToken() {
// 	google.accounts.oauth2.revoke(access_token, () => { console.log('access token revoked') });
// }
// Define tu función aquí
async function miFuncion() {
	await gapi.getInitClient()
	await gapi.createEventMeet();
}
</script>