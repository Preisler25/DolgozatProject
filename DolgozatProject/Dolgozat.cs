namespace DolgozatProject
{

    /*a. Az osztály egy adattaggal rendelkezzen. Ez egy egész érteke(ke)t tartalmazó lista
legyen, pontok néven. A lista elemei 0 és 100 közötti egész számok lehetnek, amelyek
a diákok elért pontszámait fogják reprezentálni. Előfordulhat, hogy egy diák nem írta
meg a dolgozatot, nála -1-es értéket kell tárolni a listában.
b. Hozz létre az osztályhoz egy paraméter nélküli konstruktort, amely inicializálja a
pontok listát.
c. Valósítsd meg az alábbi függvényeket:
i. void PontFelvesz(int x) – Hozzáad egy pontszámot a listához. Érvénytelen
paraméter esetén (x < -1 vagy x > 100) ez a függvény dobjon
ArgumentException-t.
ii. bool MindenkiMegirta() – Volt-e olyan diák, aki nem írt dolgozatot.
iii. int Bukas – Adja vissza hányan értek el 50 pontnál kevesebbet! C# gettert
használj! Figyeljen oda, hogy csak azokat a tanulókat számolja, akik megírták a
dolgozatot.
iv. int Elegseges – Adja vissza hányan értek el [50,60] pont közötti értéket. A
szélsőértékeket is számolja bele! C# gettert használj!
v. int Kozepes – Adja vissza hányan értek el [61,70] pont közötti értéket. A
szélsőértékeket is számolja bele! C# gettert használj!
vi. int Jo – Adja vissza hányan értek el [71,80] pont közötti értéket. A
szélsőértékeket is számolja bele! C# gettert használj!
vii. int Jeles – Adja vissza hányan értek el 81 pontnál többet. C# gettert használj.
viii. bool Gyanus(int kivalok) Adja vissza, hogy a kivalo tanulok számánál lett-e több
jeles osztályzat (db). (Pl.: kivalok=5 esetén 6 db jeles osztályzat született, akkor
a visszatérési érték IGAZ lesz! Lehetséges, hogy valamelyik tanuló extra
segítséget használt a dolgozat írása közben.). A kivalok számát 0-tól kezdődően
várja a függvény. Érvénytelen paraméter esetén ez a függvény is dobjon
ArgumentException-t.
ix. bool Ervenytelen – Adja vissza, hogy a dolgozat érvénytelen-e, és újra kell írni.
A dolgozat akkor lesz érvénytelen, ha a tanulók legalább fele nem írt
dolgozatot. C# gettert használj.*/

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
