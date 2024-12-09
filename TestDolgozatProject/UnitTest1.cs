using DolgozatProject;

namespace TestDolgozatProject
{
    public class Tests
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


        Dolgozat dolgozat;
        [SetUp]
        public void Setup()
        {
            dolgozat = new Dolgozat();
        }


        //Pont Felvétel tesztek

        [Test]
        [Category("PontFelvetel")]
        public void PontFelvesz_HelyesAdatokkal_NemDob()
        {
            Assert.DoesNotThrow(() => dolgozat.PontokFelvesz(5));
        }

        [Test]
        [Category("PontFelvetel")]
        public void PontFelvesz_HatarErtekAlattiPonttal_ArExceptiontDob()
        {
            Assert.Throws<ArgumentException>(() => dolgozat.PontokFelvesz(-2));
        }

        [Test]
        [Category("PontFelvetel")]
        public void PontFelvesz_HatarErtekFeletiPonttal_ArExceptiontDob()
        {
            Assert.Throws<ArgumentException>(() => dolgozat.PontokFelvesz(101));
        }

        [Test]
        [Category("PontFelvetel")]
        public void PontFelvesz_FelsoHatarErtekenLevoPonttal_NemDob()
        {
            Assert.DoesNotThrow(() => dolgozat.PontokFelvesz(100));
        }

        [Test]
        [Category("PontFelvetel")]
        public void PontFelvesz_AlsoHatarErtekenLevoPonttal_NemDob()
        {
            Assert.DoesNotThrow(() => dolgozat.PontokFelvesz(-1));
        }


        //Mindenki megírta tesztek
        [Test]
        [Category("MindenkiMegirta")]
        public void MindenkiMegirta_ListabanMindenkiMegirta_ReturnTrue()
        {
            dolgozat.PontokFelvesz(5);
            dolgozat.PontokFelvesz(5);
            Assert.IsTrue(dolgozat.MindenkiMegirta());
        }

        [Test]
        [Category("MindenkiMegirta")]
        public void MindenkiMegirta_ListabanValakiNemIrt_ReturnFalse()
        {
            dolgozat.PontokFelvesz(5);
            dolgozat.PontokFelvesz(-1);
            Assert.IsFalse(dolgozat.MindenkiMegirta());
        }

        [Test]
        [Category("MindenkiMegirta")]
        public void MindenkiMegirta_UresLista_ReturnTrue()
        {
            Assert.IsTrue(dolgozat.MindenkiMegirta());
        }


        //Bukás tesztek
        [Test]
        [Category("Bukas")]
        public void Bukas_Listaban1BukotDiakVan_Return1()
        {
            dolgozat.PontokFelvesz(5);
            dolgozat.PontokFelvesz(50);
            dolgozat.PontokFelvesz(-1);
            Assert.That(dolgozat.Bukas, Is.EqualTo(1));
        }

        [Test]
        [Category("Bukas")]
        public void Bukas_Listaban3BukotDiakVan_Return3()
        {
            dolgozat.PontokFelvesz(0);
            dolgozat.PontokFelvesz(5);
            dolgozat.PontokFelvesz(49);
            dolgozat.PontokFelvesz(-1);
            Assert.That(dolgozat.Bukas, Is.EqualTo(3));
        }

        [Test]
        [Category("Bukas")]
        public void Bukas_ListabanSenkiNemBukott_Return0()
        {
            dolgozat.PontokFelvesz(50);
            dolgozat.PontokFelvesz(50);
            dolgozat.PontokFelvesz(50);
            Assert.That(dolgozat.Bukas, Is.EqualTo(0));
        }

        [Test]
        [Category("Bukas")]
        public void Bukas_UresLista_Return0()
        {
            Assert.That(dolgozat.Bukas, Is.EqualTo(0));
        }

        //Elegseges tesztek
        [Test]
        [Category("Elegseges")]
        public void Elegseges_Listaban2ElegsegesDiakVan_Return2()
        {
            dolgozat.PontokFelvesz(49);
            dolgozat.PontokFelvesz(50);
            dolgozat.PontokFelvesz(60);
            dolgozat.PontokFelvesz(61);
            dolgozat.PontokFelvesz(70);
            Assert.That(dolgozat.Elegseges, Is.EqualTo(2));
        }

        [Test]
        [Category("Elegseges")]
        public void Elegseges_Listaban6ElegsegesDiakVan_Return6()
        {
            dolgozat.PontokFelvesz(50);
            dolgozat.PontokFelvesz(60);
            dolgozat.PontokFelvesz(61);
            dolgozat.PontokFelvesz(70);
            dolgozat.PontokFelvesz(50);
            dolgozat.PontokFelvesz(60);
            dolgozat.PontokFelvesz(61);
            dolgozat.PontokFelvesz(70);
            dolgozat.PontokFelvesz(50);
            dolgozat.PontokFelvesz(60);
            dolgozat.PontokFelvesz(61);
            dolgozat.PontokFelvesz(70);
            Assert.That(dolgozat.Elegseges, Is.EqualTo(6));
        }

        [Test]
        [Category("Elegseges")]
        public void Elegseges_ListabanSenkiNemElegseges_Return0()
        {
            dolgozat.PontokFelvesz(49);
            dolgozat.PontokFelvesz(70);
            Assert.That(dolgozat.Elegseges, Is.EqualTo(0));
        }

        [Test]
        [Category("Elegseges")]
        public void Elegseges_UresLista_Return0()
        {
            Assert.That(dolgozat.Elegseges, Is.EqualTo(0));
        }

        //Kozepes tesztek
        [Test]
        [Category("Kozepes")]
        public void Kozepes_Listaban2KozepesDiakVan_Return2()
        {
            dolgozat.PontokFelvesz(61);
            dolgozat.PontokFelvesz(70);
            Assert.That(dolgozat.Kozepes, Is.EqualTo(2));
        }

        [Test]
        [Category("Kozepes")]
        public void Kozepes_Listaban6KozepesDiakVan_Return6()
        {
            dolgozat.PontokFelvesz(61);
            dolgozat.PontokFelvesz(70);
            dolgozat.PontokFelvesz(61);
            dolgozat.PontokFelvesz(70);
            dolgozat.PontokFelvesz(61);
            dolgozat.PontokFelvesz(70);
            Assert.That(dolgozat.Kozepes, Is.EqualTo(6));
        }

        [Test]
        [Category("Kozepes")]
        public void Kozepes_ListabanSenkiNemKozepes_Return0()
        {
            dolgozat.PontokFelvesz(60);
            dolgozat.PontokFelvesz(71);
            Assert.That(dolgozat.Kozepes, Is.EqualTo(0));
        }

        [Test]
        [Category("Kozepes")]
        public void Kozepes_UresLista_Return0()
        {
            Assert.That(dolgozat.Kozepes, Is.EqualTo(0));
        }

        //Jo tesztek
        [Test]
        [Category("Jo")]
        public void Jo_Listaban2JoDiakVan_Return2()
        {
            dolgozat.PontokFelvesz(71);
            dolgozat.PontokFelvesz(80);
            Assert.That(dolgozat.Jo, Is.EqualTo(2));
        }

        [Test]
        [Category("Jo")]
        public void Jo_Listaban6JoDiakVan_Return6()
        {
            dolgozat.PontokFelvesz(71);
            dolgozat.PontokFelvesz(80);
            dolgozat.PontokFelvesz(71);
            dolgozat.PontokFelvesz(80);
            dolgozat.PontokFelvesz(71);
            dolgozat.PontokFelvesz(80);
            Assert.That(dolgozat.Jo, Is.EqualTo(6));
        }

        [Test]
        [Category("Jo")]
        public void Jo_ListabanSenkiNemJo_Return0()
        {
            dolgozat.PontokFelvesz(70);
            dolgozat.PontokFelvesz(81);
            Assert.That(dolgozat.Jo, Is.EqualTo(0));
        }

        [Test]
        [Category("Jo")]
        public void Jo_UresLista_Return0()
        {
            Assert.That(dolgozat.Jo, Is.EqualTo(0));
        }

        //Jeles tesztek
        [Test]
        [Category("Jeles")]
        public void Jeles_Listaban2JelesDiakVan_Return2()
        {
            dolgozat.PontokFelvesz(81);
            dolgozat.PontokFelvesz(100);
            Assert.That(dolgozat.Jeles, Is.EqualTo(2));
        }
        [Test]
        [Category("Jeles")]
        public void Jeles_Listaban6JelesDiakVan_Return6()
        {
            dolgozat.PontokFelvesz(81);
            dolgozat.PontokFelvesz(100);
            dolgozat.PontokFelvesz(81);
            dolgozat.PontokFelvesz(100);
            dolgozat.PontokFelvesz(81);
            dolgozat.PontokFelvesz(100);
            Assert.That(dolgozat.Jeles, Is.EqualTo(6));
        }

        [Test]
        [Category("Jeles")]
        public void Jeles_ListabanSenkiNemJeles_Return0()
        {
            dolgozat.PontokFelvesz(80);
            dolgozat.PontokFelvesz(-1);
            Assert.That(dolgozat.Jeles, Is.EqualTo(0));
        }

        [Test]
        [Category("Jeles")]
        public void Jeles_UresLista_Return0()
        {
            Assert.That(dolgozat.Jeles, Is.EqualTo(0));
        }

        //Gyanus tesztek
        [Test]
        [Category("Gyanus")]
        public void Gyanus_Listaban3KivaloDiakVan_De4Jeles_ReturnFalse()
        {
            dolgozat.PontokFelvesz(100);
            dolgozat.PontokFelvesz(100);
            dolgozat.PontokFelvesz(100);
            dolgozat.PontokFelvesz(100);
            Assert.IsFalse(dolgozat.Gyanus(3));
        }

        [Test]
        [Category("Gyanus")]
        public void Gyanus_Listaban3KivaloDiakVan_De3Jeles_ReturnFalse()
        {
            dolgozat.PontokFelvesz(100);
            dolgozat.PontokFelvesz(100);
            dolgozat.PontokFelvesz(100);
            Assert.IsFalse(dolgozat.Gyanus(3));
        }

        [Test]
        [Category("Gyanus")]
        public void Gyanus_Listaban3KivaloDiakVan_De2Jeles_ReturTrue()
        {
            dolgozat.PontokFelvesz(100);
            dolgozat.PontokFelvesz(100);
            Assert.IsTrue(dolgozat.Gyanus(3));
        }

        [Test]
        [Category("Gyanus")]
        public void Gyanus_Listaban3KivaloDiakVan_UresLista_ReturnTrue()
        {
            Assert.IsTrue(dolgozat.Gyanus(3));
        }

        [Test]
        [Category("Gyanus")]
        public void Gyanus_HelytelenKivaloInput_ArgumentExceptiontDob()
        {
            Assert.Throws<ArgumentException>(() => dolgozat.Gyanus(-1));
        }

        //Ervenytelen tesztek
        [Test]
        [Category("Ervenytelen")]
        public void Ervenytelen_Listaban3Diakbol2NemIrtDolgozatot_ReturnFalse()
        {
            dolgozat.PontokFelvesz(-1);
            dolgozat.PontokFelvesz(50);
            dolgozat.PontokFelvesz(50);
            Assert.IsFalse(dolgozat.Ervenytelen());
        }

        [Test]
        [Category("Ervenytelen")]
        public void Ervenytelen_Listaban3Diakbol2NemIrtDolgozatot_ReturnTrue()
        {
            dolgozat.PontokFelvesz(-1);
            dolgozat.PontokFelvesz(-1);
            dolgozat.PontokFelvesz(50);
            Assert.IsTrue(dolgozat.Ervenytelen());
        }
    }
}