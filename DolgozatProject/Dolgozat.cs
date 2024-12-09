namespace DolgozatProject
{

    public class Dolgozat
    {
        private List<int> pontok;

        public Dolgozat()
        {
            pontok = new List<int>();
        }

        public void PontokFelvesz(int pont)
        {
            if (pont < -1 || pont > 100)
            {
                throw new ArgumentException("A pontnak 0 és 100 között kell lennie.");
            }

            pontok.Add(pont);
        }

        public bool MindenkiMegirta()
        {
            if (pontok.Contains(-1))
            {
                return false;
            }
            return true;

        }

        public int Bukas 
        {
            get
            {
            List<int> bukasok = pontok.Where(x => x < 50 && x != -1).ToList();
            return bukasok.Count;
            }
        }

        public int Elegseges
        {
            get
            {
                List<int> elegsegesek = pontok.Where(x => x >= 50 && x <= 60).ToList();
                return elegsegesek.Count;
            }
        }

        public int Kozepes
        {
            get
            {
                List<int> kozepesek = pontok.Where(x => x >= 61 && x <= 70).ToList();
                return kozepesek.Count;
            }
        }

        public int Jo
        {
            get
            {
                List<int> jok = pontok.Where(x => x >= 71 && x <= 80).ToList();
                return jok.Count;
            }
        }

        public int Jeles
        {
            get
            {
                List<int> jelesek = pontok.Where(x => x > 80).ToList();
                return jelesek.Count;
            }
        }

        public bool Gyanus(int kivalok)
        {
            if (kivalok < 0) {
                throw new ArgumentException("A kivalok száma nem lehet negatív.");
            }
            if (kivalok > Jeles) {
                return true;
            }
            return false;
        }

        public bool Ervenytelen()
        {
            if (pontok.Count(x => x == -1) >= pontok.Count / 2.0)
            {
                return true;
            }
            return false;
        }
    }
}
