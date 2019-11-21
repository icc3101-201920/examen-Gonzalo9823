using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombateNaval
{
    public class Tablero
    {
        List<List<int>> tablero = new List<List<int>>();

        public Tablero()
        {
            tablero.Add(new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            tablero.Add(new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            tablero.Add(new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            tablero.Add(new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            tablero.Add(new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            tablero.Add(new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            tablero.Add(new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            tablero.Add(new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            tablero.Add(new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            tablero.Add(new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
        }

        public void printTablero()
        {
            Console.WriteLine("- - - - - - - - - - - - - - - -");
            foreach(List<int> row in tablero)
            {
                string rowString = "";
                foreach(int lugar in row)
                {
                    rowString += $" {lugar} ";
                }
                Console.WriteLine(rowString);
            }
            Console.WriteLine("- - - - - - - - - - - - - - - -");
        }

        public List<List<int>> getTablero()
        {
            return tablero;
        }

        public bool addBarcoToTablero(Barco barco, int fila, int columna, char horientacion, int index)
        {
            if ((fila >= 1 && fila < 11) && (columna >= 1 && columna < 11) && (horientacion == 'V' || horientacion == 'H'))
            {
                if(tablero[fila - 1][columna - 1] == 0)
                {
                    if (horientacion == 'V')
                    {
                        if (fila - 1 + barco.getCantidadDeMovimientos() < 11)
                        {                            
                            for(int i = fila - 1; i < fila - 1 + barco.getCantidadDeMovimientos(); i++)
                            {
                                tablero[i][columna - 1] = index;
                            }
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (horientacion == 'H')
                    {
                        if (columna - 1 + barco.getCantidadDeMovimientos() < 11)
                        {
                            for (int i = columna - 1; i < columna - 1 + barco.getCantidadDeMovimientos(); i++)
                            {
                                tablero[fila - 1][i] = index;
                            }

                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    } else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            } else
            {
                return false;
            }
        }

        public bool moveBarcoEnTablero(Barco barco, char direction, int index)
        {
            return true;
        }
    }
}
