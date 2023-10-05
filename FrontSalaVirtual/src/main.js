import './assets/main.css'

import { createApp } from 'vue'
import App from './App.vue'
import router from './router'

import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';
import 'datatables.net-bs5/css/dataTables.bootstrap5.min.css'; //Estilos de Bs5 DataTables


const app = createApp(App)

app.use(router)

app.mount('#app')
