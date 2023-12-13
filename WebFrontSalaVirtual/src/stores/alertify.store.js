import { defineStore } from 'pinia';

import alertify from 'alertifyjs';

alertify.dialog('myAlert', function factory() {
	return {
		main: function (message) {
			this.message = message;
		},
		setup: function () {
			return {
				buttons: [{ text: "cool!", key: 27/*Esc*/ }],
				focus: { element: 0 }
			};
		},
		prepare: function () {
			this.setContent(this.message);
		}
	}
})

export const useAlertifyStore = defineStore({
	id: 'Alertify',
	state: () => ({
	}),
	actions: {
		alertifyWaitingOpen() {
			var dialog = `
			<div class="container">
				<div class="row">
					<div>
						<span class="spinner-border spinner-border-sm" aria-hidden="true"></span>
						<span role="status"> -- Por favor, espere un momento...</span>
					</div>
				</div>
			</div>
			`;
			if (!alertify.waiting) { // se define una vez y luego se utiliza
				//define a new dialog
				alertify.dialog('waiting', function factory() {
					return {
						main: function (message) {
							this.message = message;
						},
						setup: function () {
							return {
								buttons: [{ text: "cool!", key: 27/*Esc*/ }],
								focus: { element: 0 }
							};
						},
						prepare: function () {
							this.setContent(this.message);
						}
					}
				});
			}
			alertify.waiting('')
				.setting({ 'closable': false, 'maximizable': false, 'basic': true })
				.setContent(dialog);
		},

		alertifyWaitingClose() {
			if (alertify.waiting().isOpen()) {
				setTimeout(() => {
					alertify.waiting().close();
				}, 2000);
			}
		}
	}
});