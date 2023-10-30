import { ref } from 'vue'
//googleApiServices
const gClientId = '860360797051-g73fju8qep80lnr7jfrg3dq8d1cmoqq0.apps.googleusercontent.com';
var client;
var access_token;
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

	async createEventMeet(name, fInicio, hInicio, fFin, hFin) {
		try {
			const accessToken = access_token; // Reemplaza con tu token de acceso obtenido durante la autenticación
			const event = {
				"end": {
					"dateTime": fFin + 'T' + hFin,
					"timeZone": "America/Chicago"
				},
				"start": {
					"dateTime": fInicio + 'T' + hInicio,
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
				"summary": name
			};
			const response = await fetch('https://www.googleapis.com/calendar/v3/calendars/primary/events?conferenceDataVersion=1', {
				method: 'POST',
				headers: {
					'Authorization': 'Bearer ' + accessToken,
					'Content-Type': 'application/json'
				},
				body: JSON.stringify(event)
			});

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