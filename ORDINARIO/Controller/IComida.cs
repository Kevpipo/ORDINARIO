using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORDINARIO
{
    interface IComida
    {
        List<Comida> ObtenerComida();
        void AgregarComida(string nombre, string categoria, string ingredientes, decimal precio, string calorias, string tamaño, int catidad_Disponible);
        void EliminarComida(int iD_Comida);
        void ActualizarComida(int iD_Comida, string nombre, string categoria, string ingredientes, decimal precio, string calorias, string tamaño, int catidad_Disponible);
        Comida VerificarId(int iD_Comida);
    }
}
