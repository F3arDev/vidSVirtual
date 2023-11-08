import 'datatables.net';
import 'datatables.net-select';
import 'datatables.net-responsive';
import 'datatables.net-buttons-bs5';
import 'bootstrap/dist/js/bootstrap.bundle.min';
import 'bootstrap/dist/css/bootstrap.css';
import 'datatables.net-bs5/css/dataTables.bootstrap5.min.css';
import 'alertifyjs/build/css/alertify.min.css';
import 'alertifyjs/build/css/themes/bootstrap.css'

import './assets/datatablesConfig';
import './assets/main.css'

import { createApp } from 'vue'
import App from './App.vue'
import router from './router'


const app = createApp(App);
app.use(router);




app.mount('#app')