using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace pexeso
{
    public class Table
    {
        public int row;
        public int col;
        private Symbol[]? symbols;
        public Card[] cards;
        public int remaining;

        public class Symbol
        {
            public int id;
            public int occurance;
            public Symbol(int id)
            {
                this.id = id;
                occurance = 0;
            }
        }
        public Table()
        {
            try{
                Console.WriteLine("Kolik řádků?");
                string? row_input = Console.ReadLine();
                if (row_input == null) {throw new ArgumentNullException();}
                row = Int32.Parse(row_input);

                Console.WriteLine("Kolik sloupců?");
                string? col_input = Console.ReadLine();
                if (col_input == null) {throw new ArgumentNullException();}
                col = Int32.Parse(col_input);
                Console.WriteLine("Dík <3");
            }
            catch (FormatException)
            {
                Console.WriteLine("Nu-uh, čísla pwosím :3...jdu zemřít\n");
                throw;
            }
            catch (ArgumentNullException){
                Console.WriteLine("Nu-uh nully, jdu zemřít\n");
                throw;
            }

            gen_symbols();
            gen_cards();
            remaining = cards.Length / 2;
        }
    
        private void gen_symbols()
        {
            int all_sym = col * row / 2;
            symbols = new Symbol[all_sym];
            for (int i = 0; i < all_sym; i++)
            {
                symbols[i] = new Symbol(i);
            }
        }

        private void gen_cards()
        {
            // potřebujeme sudý počet karet, takže kdyžtak bude o jednu míň
            int all_cards = (col * row % 2 == 0)? (row * col) : (row * col - 1);
            cards = new Card[all_cards];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    int index = i*col + j;
                    if (index >= all_cards) break;
                    Card this_card = new Card(i, j);
                    cards[index] = this_card;
                    this_card.num = assign_symbol();
                }
            }
        }
        private int assign_symbol()
        {
            Random gen = new Random();
            while (true)
            {
                int i = gen.Next(symbols.Length);
                if (symbols[i].occurance >= 2) {continue;}

                symbols[i].occurance++;
                return symbols[i].id;
            }
        }
    }
}