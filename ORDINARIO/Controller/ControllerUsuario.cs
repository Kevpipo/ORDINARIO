using ORDINARIO.Models.ComidaRapidaTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORDINARIO.Controller
{
    public class ControllerUsuario
    {
        public bool VerificarUsuario(string nombreUsuario, string contrasenaIngresada)
        {
            // Crear instancia del TableAdapter para obtener los datos del usuario
            userTableAdapter adapter = new userTableAdapter();

            // Obtener los datos del usuario por nombre
            var usuarioData = adapter.GetDataBy(nombreUsuario);

            // Verificar si se encontró un usuario
            if (usuarioData.Rows.Count > 0)
            {
                // Obtener la contraseña encriptada desde la base de datos
                string contrasenaEncriptada = usuarioData[0].contrasena;

                // Crear una instancia de AESCryptography y desencriptar la contraseña
                AESCryptography aesCrypto = new AESCryptography();
                string contrasenaDesencriptada = aesCrypto.Decrypt(contrasenaEncriptada);

                // Verificar si la contraseña ingresada es igual a la desencriptada
                if (contrasenaDesencriptada == contrasenaIngresada)
                {
                    return true; // Login exitoso
                }
            }

            return false; // Login fallido
        }

        public bool RegistrarUsuario(string nombreUsuario, string correo, string contrasenaEncriptada)
        {
            try
            {
                // Crear una instancia del TableAdapter
                userTableAdapter adapter = new userTableAdapter();

                // Verificar si el usuario ya existe
                var usuarioExistente = adapter.GetDataBy(nombreUsuario);
                if (usuarioExistente.Rows.Count > 0)
                {
                    return false; // El usuario ya existe
                }

                // Insertar el nuevo usuario
                adapter.Insert(nombreUsuario, correo, contrasenaEncriptada, DateTime.Now);
                return true;
            }
            catch (Exception)
            {
                return false; // Error durante el registro
            }
        }
    }
}