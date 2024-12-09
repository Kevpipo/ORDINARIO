using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORDINARIO
{
    public class Comida
    {
        public Comida(int iD_Comida, string nombre, string categoria, string ingredientes, decimal precio, string calorias, string tamaño, int cantidad_Disponible)
        {
            ID_Comida = iD_Comida;
            Nombre = nombre;
            Categoria = categoria;
            Ingredientes = ingredientes;
            Precio = precio;
            Calorias = calorias;
            Tamaño = tamaño;
            Cantidad_Disponible = cantidad_Disponible;
        }

        public int ID_Comida { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string Ingredientes { get; set; }
        public decimal Precio { get; set; }
        public string Calorias { get; set; }
        public string Tamaño { get; set; }
        public int Cantidad_Disponible { get; set; }
    }
    
}