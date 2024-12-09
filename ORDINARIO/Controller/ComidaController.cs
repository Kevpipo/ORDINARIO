using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ORDINARIO.Models.ComidaRapidaTableAdapters;

namespace ORDINARIO
{
    public class ComidaController 
    {
        private comidarapidaTableAdapter TableAdapter = new comidarapidaTableAdapter();
        public List<Comida> ObtenerComida()
        {
            var comidarapida = TableAdapter.GetData();
            return comidarapida.Select(comidas => new Comida(comidas.ID_Comida, comidas.Nombre, comidas.Categoria, comidas.Ingredientes, comidas.Precio, comidas.Calorias, comidas.Tamaño, comidas.Cantidad_Disponible)).ToList();
        }
        public void AgregarComida(string nombre, string categoria, string ingredientes, decimal precio, string calorias, string tamaño, int catidad_Disponible)
        {
            TableAdapter.AgregarComida(nombre, categoria, ingredientes, precio, calorias, tamaño, catidad_Disponible);
        }
        public void ActualizarComida(int iD_Comida, string nombre, string categoria, string ingredientes, decimal precio, string calorias, string tamaño, int catidad_Disponible)
        {
            TableAdapter.ActualizarComida(nombre, categoria, ingredientes, precio, calorias, tamaño, catidad_Disponible, iD_Comida);
        }
        public void EliminarComida(int iD_Comida)
        {
            TableAdapter.EliminarComida(iD_Comida);
        }
        public Comida VerificarId(int iD_Comida)
        {
            var comida = TableAdapter.GetDataById(iD_Comida).FirstOrDefault();
            if (comida != null)
            {
                return new Comida(comida.ID_Comida, comida.Nombre, comida.Categoria, comida.Ingredientes, comida.Precio, comida.Calorias, comida.Tamaño, comida.Cantidad_Disponible);
            }
            return null;
        }
    }
}