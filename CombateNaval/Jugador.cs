using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombateNaval
{
    class Jugador
    {
        List<Barco> barcos = new List<Barco>();
        int vida = 15;
        Tablero tablero;
        string name;

        public Jugador(Tablero tablero, string name)
        {
            this.tablero = tablero;
            this.name = name;

            barcos.Add(new Barco(5, 1, "Portaaviones"));
            barcos.Add(new Barco(4, 2, "Fragata"));
            barcos.Add(new Barco(3, 3, "Submario"));
            barcos.Add(new Barco(2, 3, "Reparador"));
            barcos.Add(new Barco(1, 1, "Radar"));
        }

        public void firstTurn()
        {
            bool playing = true;
            while(playing)
            {
                Console.Clear();
                if(getSelectedBarcos() < 5)
                {
                    printMainInfo();
                    Console.WriteLine("Estos son tus barcos disponibles para poner en el tablero: ");
                    printNotSelectedBarcos();
                    Console.Write("¿Que barco deeas agregar?: ");
                    int selectedBarco = Int32.Parse(Console.ReadLine());

                    if (selectedBarco - 1 >= 0 && selectedBarco - 1 < barcos.Count)
                    {
                        Console.Write("Fila (1-10): ");
                        int fila = Int32.Parse(Console.ReadLine());

                        Console.Write("Columna (1-10): ");
                        int columna = Int32.Parse(Console.ReadLine());

                        Console.Write("Horientación (V - H): ");
                        string horientacion = Console.ReadLine();

                        if (!tablero.addBarcoToTablero(barcos[selectedBarco - 1], fila, columna, horientacion[0], selectedBarco))
                        {
                            printErrorMessage();
                        }
                        else
                        {
                            barcos[selectedBarco - 1].addToTablero(fila, columna, horientacion[0]);
                        }
                    }
                    else
                    {
                        printErrorMessage();
                    }
                } else
                {
                    playing = false;
                }
            }

            Console.WriteLine("Turno terminado...");
            Console.ReadKey();
        }

        public int playTurn()
        {

            bool playing = true;


            while(playing)
            {
                printMainInfo();
                Console.WriteLine("¿Que acción deseas hacer?");
                Console.WriteLine(" -(1) Atacar");
                Console.WriteLine(" -(2) Mover barco");
                Console.WriteLine(" -(3) Acción especial");

                int playerOption = Int32.Parse(Console.ReadLine());

                if (playerOption >= 1 && playerOption < 4)
                {
                    switch(playerOption)
                    {
                        case 1:
                            return 1;
                        case 2:
                            return 2;
                        case 3:
                            return 3;
                        default:
                            printErrorMessage();
                            break;
                    }
                } else
                {
                    printErrorMessage();
                }
            }

            return -1;
        }

        // --------- MOVE BARCO

        public void moveBarco()
        {
            printMainInfo();
            Console.WriteLine("Estos son tus barcos disponibles: ");
            printAllBarcos();
            Console.Write("¿Que barco deeas mover?: ");
            int selectedBarco = Int32.Parse(Console.ReadLine());

            Console.Write("¿Hacia que lado?: ");
            string direction = Console.ReadLine();

            if (selectedBarco - 1 >= 0 && selectedBarco - 1 < barcos.Count && (direction[0] == 'A' || direction[0] == 'W' || direction[0] == 'S' || direction[0] == 'D'))
            {
                tablero.moveBarcoEnTablero(barcos[selectedBarco], direction[0], selectedBarco);
            }
            else
            {
                printErrorMessage();
            }
        }

        // --------- FOR PRINTING AND INFO

        public void printErrorMessage()
        {
            Console.Clear();
            Console.Write("Porfavor elige opciones correctas...");
            Console.ReadKey();
        }

        public void printMainInfo()
        {
            Console.Clear();
            Console.WriteLine($"Hola {name}!\n");
            Console.WriteLine("Tus Barcos: ");
            printAllBarcos();

            Console.WriteLine("\n Tablero:");
            tablero.printTablero();
            Console.WriteLine("\n-----------------------------");

        }

        public void printNotSelectedBarcos()
        {
            foreach(Barco barco in barcos)
            {
                if(!barco.getAddedToTablero())
                {
                    Console.WriteLine($"({barcos.IndexOf(barco) + 1}) " + barco.getName());
                }
            }
        }

        public void printAllBarcos()
        {
            foreach (Barco barco in barcos)
            {
                if(barco.getVida() > 0)
                {
                    Console.WriteLine($"({barcos.IndexOf(barco) + 1}) " + barco.getName());
                }
            }
        }

        public int getSelectedBarcos()
        {
            int selectedBarcos = 0;
            foreach (Barco barco in barcos)
            {
                if (barco.getAddedToTablero())
                {
                    selectedBarcos += 1;
                }
            }

            return selectedBarcos;
        }

        public int getVida()
        {
            return vida;
        }

        public List<Barco> getBarcos()
        {
            return barcos;
        }

        public bool checkIfHitted(int fila, int columna)
        {
            // 0 no hay nada, -1 ya atacaron ahí, -2 muerto
            if(tablero.getTablero()[fila][columna] != 0 && tablero.getTablero()[fila][columna] != -1 && tablero.getTablero()[fila][columna] != -2)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public void setOnTablero(int fila, int columna, int set)
        {
            tablero.getTablero()[fila][columna] = set;
        }
    }
}
