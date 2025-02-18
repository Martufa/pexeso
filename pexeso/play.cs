using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace pexeso
{
    public class Game
    {
        private int remaining;
        private Table gameboard;
        public Game(Table table)
        {
            remaining = table.cards.Length / 2;
            gameboard = table;
        }

        public void play()
        {
            while (remaining > 0)
            {
                draw_table();
                Card[] g_cards = new Card[2];
                int success = 0;

                try {
                    for (int i = 0; i < 2; i++)
                    {
                        Tuple<int, int> g = get_guess();
                        if (g.Item1 >= gameboard.row || g.Item2 >= gameboard.col)
                        {
                            throw new OutOfBoundsException("Příliš vysoké číslo");
                        }
                        g_cards[i] = gameboard.cards[g.Item1*gameboard.col + g.Item2];
                        toggle_show(g_cards[i]);
                        draw_table();
                        success++;
                    }

                    if (g_cards[0].num != g_cards[1].num)
                    {
                        toggle_show(g_cards[0]);
                        toggle_show(g_cards[1]);
                    }
                    else
                    {
                        remaining--;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("To není platný index :(\nzkus to znovu");
                    for (int i = 0; i < success; i++)
                    {
                        toggle_show(g_cards[i]);
                    }
                }

                Console.WriteLine("Zmáčkni libovolnou klávesu pro další kolo.");
                Console.ReadKey();
            }
        
            Console.WriteLine("Gratuluju, vyhrála jsi :3");
        }

        public Tuple<int, int> get_guess()
        {
            int g_row;
            int g_col;
            try{
                Console.WriteLine("Zadej index řádku");
                string? g_input = Console.ReadLine();
                if (g_input == null) {throw new ArgumentNullException();}
                g_row = Int32.Parse(g_input);

                Console.WriteLine("Zadej index sloupce");
                g_input = Console.ReadLine();
                if (g_input == null) {throw new ArgumentNullException();}
                g_col = Int32.Parse(g_input);
            }
            catch (FormatException)
            {
                throw;
            }

            return new Tuple<int, int>(g_row, g_col);
        }

        public void toggle_show(Card toggle)
        {
            if (toggle.found) {toggle.found = false;}
            else {toggle.found = true;}
        }

        private void draw_table()
        {
            Console.WriteLine("Tvoje hra:");
            Console.WriteLine(new string('%', gameboard.col * 5));
            for (int i = 0; i < gameboard.row; i++)
            {
                for (int j = 0; j < gameboard.col; j++)
                {
                    int index = i*gameboard.col + j;
                    if (index >= gameboard.cards.Length) break;
                    if (gameboard.cards[i*gameboard.col + j].found){
                        Console.Write(gameboard.cards[i*gameboard.col + j].num);
                    }
                    else {
                        Console.Write("X");
                    }
                    Console.Write("    ");
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }
    }
}