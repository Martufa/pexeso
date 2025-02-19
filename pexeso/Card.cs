namespace pexeso
{
    public class Card
    {
        private int row;
        private int col;
        public int num;
        public bool found;

        public Card(int row, int col)
        {
            this.row = row;
            this.col = col;
            found = false;
        }
    }
}