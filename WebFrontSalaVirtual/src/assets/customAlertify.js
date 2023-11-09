import alertify from "alertifyjs";

class customAlertify {
	alertifyWaitingOpen() {
	
			var dialog = '<div id="dialogPreloader"><div data-role="preloader" data-type="square" data-style="color" class="preloader-square color-style"><div class="square"></div><div class="square"></div><div class="square"></div><div class="square"></div></div>Por favor, espere un momento...</div>';
			alertify.alert().set('basic', true).setting({ 'closable': false, 'maximizable': false }).setContent(dialog).show();
		
	}

	alertifyWaitingClose() {
		if (alertify.alert().isOpen()) {
			setTimeout(() => {
				alertify.alert().close();
			}, 1000);
		}
	}
}

export default customAlertify