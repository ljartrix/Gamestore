using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameStore2.Models
{
    public class CarritoItems
    {
        public string Path { get; set; }
        private Producto _Producto;

        public Producto Producto
        {
            get { return _Producto; }
            set { _Producto = value; }
        }

        public int Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        private int _Cantidad;

        public CarritoItems()
        {


        }

        public CarritoItems(Producto Producto , int Cantidad)
        {
            this._Producto = Producto;
            this._Cantidad = Cantidad;

        }
    }
}