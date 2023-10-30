import { gapi } from './googleAuth.vue.js';

// function revokeToken() {
// 	google.accounts.oauth2.revoke(access_token, () => { console.log('access token revoked') });
// }
// Define tu función aquí
export async function miFuncion() {
await gapi.getToken();
await gapi.createEventMeet();
}
