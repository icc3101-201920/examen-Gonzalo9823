using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombateNaval
{
    public class Juego
    {
        List<Jugador> jugadores = new List<Jugador>();
        private bool playing = true;
        int turn = 0;


        // TODO:
        // Al atacar quitar vida en barcos y usuario (vida usuario suma vida barcos??), agregar moverse
        // Habilidades espeaciales
        // No mostrar como opcion barcos ya muertos.
        // Mover barcos

        public Juego()
        {
            Jugador jugador_1 = new Jugador(new Tablero(), "Gonzalo");
            Jugador jugador_2 = new Jugador(new Tablero(), "Andres");

            jugadores.Add(jugador_1);
            jugadores.Add(jugador_2);

            jugador_1.firstTurn();
            jugador_2.firstTurn();

            while(playing)
            {


                //Use user option
                switch (jugadores[turn].playTurn())
                {
                    case 1:
                        attack(jugadores[turn], jugadores[1 - turn]);
                        break;
                    case 2:
                        Console.WriteLine(2);
                        break;
                    case 3:
                        Console.WriteLine(2);
                        break;
                    default:
                        break;
                }



                // For checking whos playing
                if (turn == 0)
                {
                    turn = 1;
                } else
                {
                    turn = 0;
                }

                // For checking if someone won
                if(jugador_1.getVida() < 1 || jugador_2.getVida() < 1)
                {
                    playing = false;
                    Console.Clear();

                    if(jugador_1.getVida() > 0)
                    {
                        Console.WriteLine("GANO EL JUGADOR 1");
                    } else
                    {
                        Console.WriteLine("GANO EL JUGADOR 2");
                    }
                }
            }
        }

        private void attack(Jugador atacando, Jugador atacado)
        {
            bool playing = true;
            while (playing)
            {
                Console.Clear();
                atacando.printMainInfo();
                Console.WriteLine("¿Con que barco deseas atacar?");
                int selectedBarco = Int32.Parse(Console.ReadLine());

                if (selectedBarco - 1 >= 0 && selectedBarco - 1 < atacando.getBarcos().Count)
                {
                    Console.Write("Fila (1-10): ");
                    int fila = Int32.Parse(Console.ReadLine()) - 1;

                    Console.Write("Columna (1-10): ");
                    int columna = Int32.Parse(Console.ReadLine()) - 1;


                    if (atacado.checkIfHitted(fila, columna))
                    {
                        atacado.setOnTablero(fila, columna, -2);
                        atacando.setOnTablero(fila, columna, -2);
                    }
                    else
                    {
                        atacando.setOnTablero(fila, columna, -1);
                    }

                    playing = false;
                }
                else
                {
                    atacando.printErrorMessage();
                }
            }
        }
    }
}
