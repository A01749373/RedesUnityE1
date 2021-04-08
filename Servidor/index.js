//Importación de biblioteca para creación de servidores
const express = require("express")
//Biblioteca para generar rutas de acuerdo al sistema operativo
const path = require("path")
//Biblioteca para definir JSON
const bodyParser = require("body-parser")


//Creación de servidor 
const app = express();

//Middleware para configurar la definición de un JSON
app.use(bodyParser.json());

//Middleware para configurar la recepción de formularios
app.use(bodyParser.urlencoded({extended:true}))




let puerto=8080;
console.log('Conexion exitosa');
app.listen(puerto,()=>console.log("Servidor en línea en el puerto 8080"));