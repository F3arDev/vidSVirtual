import { defineStore } from 'pinia';

import alertify from 'alertifyjs';

export const useAlertifyStore = defineStore({
	id: 'Alertify',
	state: () => ({
	}),
	actions: {
		alertifyWaitingOpen() {

			var dialog = `
			<div id="dialogPreloader">
				<div data-role="preloader" data-type="square" data-style="color" class="preloader-square color-style">
					<div class="square">
					</div>
					<div class="square">
					</div>
					<div class="square">
					</div>
					<div class="square">
					</div>
				</div>
				<div>
					<span class="spinner-border spinner-border-sm" aria-hidden="true"></span>
					<span role="status"> Por favor, espere un momento...</span>
				</div>
			</div>
			`;

			alertify.alert()
				.set('basic', true)
				.setting({ 'closable': false, 'maximizable': false })
				.setContent(dialog)
				.show();
		},

		alertifyWaitingClose() {
			if (alertify.alert().isOpen()) {
				setTimeout(() => {
					alertify.alert().close();
				}, 2000);
			}
		}
	}
});