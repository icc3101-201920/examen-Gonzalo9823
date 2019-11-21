using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombateNaval
{
    public class Barco
    {
        int vida;
        int cantidad_de_movimientos;
        string nombre;
        Dictionary<string, int> posicion = new Dictionary<string, int>();
        char horientacion;
        bool addedToTablero = false;
        
        public Barco(int vida, int cantidad_de_movimientos, string nombre)
        {
            this.vida = vida;
            this.cantidad_de_movimientos = cantidad_de_movimientos;
            this.nombre = nombre;
        }

        public string getName()
        {
            return nombre;
        }

        public bool getAddedToTablero()
        {
            return addedToTablero;
        }

        public void addToTablero(int fila, int columna, char selectedHorientacion)
        {
            posicion["fila"] = fila;
            posicion["columna"] = columna;
            horientacion = selectedHorientacion;
            addedToTablero = true;
        }

        public int getCantidadDeMovimientos()
        {
            return cantidad_de_movimientos;
        }

        public int getVida()
        {
            return vida;
        }
    }
}
