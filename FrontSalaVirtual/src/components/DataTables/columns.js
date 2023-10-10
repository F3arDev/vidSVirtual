export const Columns = [
{
data: null,
render: (data, type, row) => {
return `<button class="btn btn-primary btn-sm" @click="handleVerClick(${row.id})">Ver Mas</button>
                    
					`;
}
},
{
data: 'id'
// data: null, render: function (data, type, row, meta) { return `${meta.row + 1}` }
},
{ data: 'nombre' },
{ data: 'expediente' },
{ data: 'estado' },
{
data: null,
render: (data, type, row) => {
return `<button class="btn btn-primary btn-sm" @click="handleAprobarClick(${row.id})">Aprobar</button>
            		<button class="btn btn-danger btn-sm" @click="handleDenegarClick(${row.id})">Denegar</button>`;
}
}
];
