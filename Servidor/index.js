const bodyParser = require("body-parser");
const path = require("path")
const express = require('express');
const Sequelize = require('sequelize')
const sequelize = new Sequelize('TareaRedes','sa','Password1234$',{
    dialect: 'mssql',
    dialectOptions:{
        options:{
            useUTC: false,
            dateFirst: 1
        }
    },
    define: {
        timestamps: false,
        freezeTableName: true
    }
});
const app=express()

app.use(express.static(path.join(__dirname,"public")));
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({extended:true}));

const TablaRedes = sequelize.define('TablaRedes',{
    NombreUsuario:{
        type: Sequelize.STRING(50),
        allowNull: false,
        primaryKey:true
    },
    Password:{
        type: Sequelize.STRING(50),
        allowNull: false
    }
});

//Agregar Registros
app.get('/registro', (req,res)=>{
    res.sendFile(path.join(__dirname,'views','registro.html'))
});

app.post('/registro', (req,res)=>{
    console.log(req.body);    
    TablaRedes.create({
        NombreUsuario: req.body.usuarioUsuario,
        Password: req.body.passwordUsuario
    }).then(resultado=>console.log("Registro exitoso"))
      .catch(error=>console.log(error));
      res.send('Registro exitoso')
});

app.post ('/BuscarUsuario', (req,res)=>{
    TablaRedes.findAll({
    where: {
        NombreUsuario: req.body.usuarioUsuarioo,
        Password: req.body.passwordUsuarioo
      }
    })
    .then(registros=>{
        //console.log(registros)
        var data=[];
        registros.forEach(registro=>{
            data.push(registro.dataValues);
        });
        console.log(data)
        if (registros.length == 0){
            res.send('Usuario o contraseña incorrecto')
        }else{
            res.send('')
        }
    })
});

//Agregar Tiempo a base de datos

const Tiempo = sequelize.define('Tiempo',{
    id:{
        type: Sequelize.INTEGER,
        allowNull: false,
        primaryKey: true,
        autoIncrement: true
    },
    TiempoInicio:{
        type: Sequelize.STRING(50),
        allowNull: false
    },
    TiempoFinal:{
        type: Sequelize.STRING(50),
        allowNull: false
    },
    usuario:{
        type: Sequelize.STRING(50),
        allowNull: false
    }
});
app.post('/AgregarTiempo', (req,res)=>{
    console.log(req.body);    
    Tiempo.create({
        TiempoInicio: req.body.TiempoInicio,
        TiempoFinal: req.body.TiempoFinal,
        usuario: req.body.TiempoUsuario
    }).then(resultado=>console.log("Tiempo Agregado"))
      .catch(error=>console.log(error));
      res.send('TiempoAgregado')
});

const puerto=8080;

sequelize.sync()
    .then(resultado=>{
        console.log('Conexión exitosa');
        //Lanza el servidor para escuchar peticiones
        app.listen(puerto,()=>console.log("Servidor en línea en el puerto 8080"));
    })
    .catch(error=>console.log(error));