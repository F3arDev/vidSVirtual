import { ref } from 'vue'
//googleApiServices
const gClientId = '860360797051-g73fju8qep80lnr7jfrg3dq8d1cmoqq0.apps.googleusercontent.com';
var client;
var access_token;
var TokenValide;

class gApiServices {
	token

	constructor() {
		this.token = ref()
	}

	getToken() {
		return this.token = access_token
	}

	async createEventMeet(name) {
		if (TokenValide) {
			try {
				const accessToken = access_token;
				// Reemplaza con tu token de acceso obtenido durante la autenticación
				const event = {
					"end": {
						"dateTime": '2023-11-01T16:00:00',
						"timeZone": "America/Managua"
					},
					"start": {
						"dateTime": '2023-11-01T14:00:00',
						"timeZone": "America/Managua"
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
					// const eventId = data.id; //id del meets para despues
					const conferenceData = data.conferenceData;
					if (conferenceData.createRequest.status.statusCode == 'success') {
						//link de Meets - Se puede acceder tambien por data.hangoutLink, 
						const meetLink = conferenceData.entryPoints.find(entry => entry.entryPointType === 'video').uri;
						console.log(meetLink);
						//=========retorno de meets========//
						return { ok: true, meetLink: meetLink}; //, eventId: eventId  
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
		} else {
			this.ValidateToken()
			console.log('porfavor vuelva a enviar la peticion')
		}
	}

	//valida el token y ejecuta luego la funcion
	async ValidateToken() {
		try {
			let response = await fetch(`https://www.googleapis.com/oauth2/v1/tokeninfo?access_token=${access_token}`, {
				method: 'GET',
				headers: {
					'Authorization': 'Bearer ' + access_token
				}
			});
			const data = await response.json();
			if (response.ok && data.access_type == 'online') {
				TokenValide = true;
				console.log('El token es valido');
			} else {
				TokenValide = false
				await this.getInitClient(false)
				throw new Error('Error en la solicitud: ');
			}
		} catch (error) {
			console.log('error')
		}
	}

	async getInitClient(retornoCB) {
		if (retornoCB) {
			this.ValidateToken()
			return true
		} else {
			await client.requestAccessToken();
		}
	}

	async initClient() {
		client = await window.google.accounts.oauth2.initTokenClient({
			client_id: gClientId,
			scope: 'https://www.googleapis.com/auth/calendar.readonly https://www.googleapis.com/auth/calendar.events',
			prompt: 'select_account',
			callback: (tokenResponse) => {
				access_token = tokenResponse.access_token;
				this.getInitClient(true); //verifica que se haya creado un nuevo Token
				console.log(access_token)
				return { ok: true }
			},
		});
	}
}

export default gApiServices