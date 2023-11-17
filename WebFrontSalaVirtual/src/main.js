import 'datatables.net';
import 'datatables.net-select';
import 'datatables.net-responsive';
import 'datatables.net-buttons-bs5';

import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap/dist/js/bootstrap.bundle.min';
import 'bootstrap-icons/font/bootstrap-icons.css';

import 'datatables.net-bs5/css/dataTables.bootstrap5.min.css';
import 'alertifyjs/build/css/alertify.min.css';
import 'alertifyjs/build/css/themes/bootstrap.css'

import './assets/datatablesConfig';
import './assets/main.css'

import { createApp } from 'vue'
import { createPinia } from 'pinia'

//plugins VueJs
import App from './App.vue'
import router from './router'

const app = createApp(App)


//usa los plugins
app.use(createPinia())
app.use(router)

//Monta en index #app
app.mount('#app')