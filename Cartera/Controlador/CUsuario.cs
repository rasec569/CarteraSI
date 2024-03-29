﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Cartera.Modelo;

namespace Cartera.Controlador
{
    class CUsuario
    {
        public int crearUsuario(string nombre, string contraseña)
        {
            return MUsuario.crearUsuario(nombre, contraseña);
        }
        public DataTable listarUsuario()
        {
            return MUsuario.listarUsuario();
        }
        public int ActulizarUsuario(string Id_usuario,string nombre, string contraseña)
        {
            return MUsuario.ActulizarUsuario(Id_usuario, nombre, contraseña);
        }
        public int ActulizarContraseña(string id_usuario, string contraseña)
        {
            return MUsuario.ActulizarContraseña(id_usuario, contraseña);
        }
        public int EliminarUsuario(int usuario)
        {
            return MUsuario.EliminarUsuario(usuario);
        }



    }

}
