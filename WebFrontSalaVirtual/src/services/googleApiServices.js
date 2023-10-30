import { ref } from 'vue'
//googleApiServices
const gClientId = '860360797051-g73fju8qep80lnr7jfrg3dq8d1cmoqq0.apps.googleusercontent.com';
var client;
var access_token = 'ya29.a0AfB_byCphP682RhYLEFkLkv9e_27Twb750s5yUl1gInktYhh930k_XHyNKpzklxO7mlfkpSvEW0GfgjP0vy9Pp0la5sogi5afw1Oxj8LXYheaCLtO8SqeYCDOpRz-TFf9wiL2OIbJs65v_SO9cXFqb6rEfq1iX9J1QaCgYKARkSARMSFQGOcNnCeHMQxsVO1VcuYGCZisouLw0169';
class gApiServices {
	token

	constructor() {
		this.token = ref()
	}

	getToken() {
		return this.token = access_token
	}

	async getInitClient() {
		await client.requestAccessToken();
	}

	async createEventMeet() {
		try {
			const accessToken = access_token; // Reemplaza con tu token de acceso obtenido durante la autenticación
			const event = {
				"end": {
					"dateTime": '2023-11-01T16:00:00',
					"timeZone": "America/Chicago"
				},
				"start": {
					"dateTime": '2023-11-01T14:00:00',
					"timeZone": "America/Chicago"
				},
				"conferenceData": {
					"createRequest": {
						"conferenceSolutionKey": {
							"type": "hangoutsMeet"
						},
						"requestId": "random-unique-string"
					}
				},
				"summary": 'test'
			};
			const response = await fetch('https://www.googleapis.com/calendar/v3/calendars/primary/events?conferenceDataVersion=1', {
				method: 'POST',
				headers: {
					'Authorization': 'Bearer ' + accessToken,
					'Content-Type': 'application/json'
				},
				body: JSON.stringify(event)
			});
			debugger
			if (response.status == 401) {

				return {
					ok: false,
					error: response.status
				};
			}
			debugger
			if (response.ok) {
				const data = await response.json(); // data del evento
				const eventId = data.id;
				const conferenceData = data.conferenceData;

				if (conferenceData.createRequest.status.statusCode == 'success') {
					//link de Meets - Se puede acceder tambien por data.hangoutLink, 
					const meetLink = conferenceData.entryPoints.find(entry => entry.entryPointType === 'video').uri;
					console.log(meetLink);
					return { ok: true, meetLink: meetLink, eventId: eventId };
				} else {
					throw new Error('Error al crear el enlace de Google Meet.');
				}
			} else {
				throw new Error('Error al crear el evento. Código de estado: ' + response.status.statusCode);
			}
		} catch (error) {
			console.error('Error:', error);
			return { ok: false, error: error.message };
		}
	}

	async initClient() {
		client = window.google.accounts.oauth2.initTokenClient({
			client_id: gClientId,
			scope: 'https://www.googleapis.com/auth/calendar.readonly https://www.googleapis.com/auth/calendar.events',
			callback: (tokenResponse) => {
				access_token = tokenResponse.access_token;
				console.log(access_token)
			},
		});
	}
}

export default gApiServices