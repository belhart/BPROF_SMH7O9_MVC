namespace F1Stats.Program
{
    using System;
    using System.Xml.Linq;
    using F1Stats.Data.Models;
    using F1Stats.Logic;

    public class Program
    {
        public static void Main(string[] args)
        {
            int kivalsztottFoMenupont = 1;
            while (kivalsztottFoMenupont != 0)
            {
                Console.Clear();
                Console.WriteLine("F1Stats\n\nMenüpot választásáshoz írd be a menüpont számát");
                Console.WriteLine("1, Csapatok Menüpont");
                Console.WriteLine("2, Versenyzők menüpont");
                Console.WriteLine("3, Versenyhétvégék menűpont");
                Console.WriteLine("4, Eredmények menüpont");
                Console.WriteLine("5, A versenyzők és az általuk elért pontok az utóbbi 3 versenyen ha elértek legalább 1 pontot");
                Console.WriteLine("6, A csapat kiírása akinek a versenyzői általal elért összes pontot összeadva a legtöbb van");
                Console.WriteLine("7, Egy versenyhétvége számát megadva a top10 eredmény-t elérő csapatok motorjának gyártója kiírása");
                Console.WriteLine("8, JAVA webapp meghívása");
                Console.WriteLine("0, Kilépés a programból\n");
                Console.Write("A kiválasztott menüelem: ");
                kivalsztottFoMenupont = int.Parse(Console.ReadLine());
                switch (kivalsztottFoMenupont)
                {
                    case 1:
                        Console.Clear();
                        ElsoMenupont();
                        break;
                    case 2:
                        Console.Clear();
                        MasodikMenupont();
                        break;
                    case 3:
                        Console.Clear();
                        HarmadikMenupont();
                        break;
                    case 4:
                        Console.Clear();
                        NegyedikMenupont();
                        break;
                    case 5:
                        OtodikMenupont();
                        break;
                    case 6:
                        HatodikMenupont();
                        break;
                    case 7:
                        Console.Clear();
                        HetedikElsMenupont();
                        break;
                    case 8:
                        NyolcadikMenupont();
                        break;
                    default:
                        break;
                }
            }
        }

        public static void ElsoMenupont()
        {
            Console.WriteLine("1, Csapatok listázása");
            Console.WriteLine("2, Csapat hozzáadása");
            Console.WriteLine("3, Csapat módosítása");
            Console.WriteLine("4, Csapat törlése");
            Console.WriteLine("0, Kilépés a főmenübe");
            int kivalasztottMenupont = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (kivalasztottMenupont)
            {
                case 1:
                    Console.WriteLine("A jelenlegi idényben résztvevő csapatok\n");
                    CsapatLogic csapRepo = new CsapatLogic();
                    foreach (var item in csapRepo.GetAllCsapat())
                    {
                        Console.WriteLine(item.csapat_nev);
                    }

                    break;
                case 2:
                    Csapat mycsapat = new Csapat();
                    Console.Write("Csapat neve: ");
                    mycsapat.csapat_nev = Console.ReadLine();
                    Console.Write("Motor gyártója: ");
                    mycsapat.motor = Console.ReadLine();
                    Console.Write("Versenyek száma: ");
                    mycsapat.versenyek_szama = int.Parse(Console.ReadLine());
                    Console.Write("Győzelmek száma: ");
                    mycsapat.gyozelmek = int.Parse(Console.ReadLine());
                    CsapatLogic cslogic = new CsapatLogic();
                    cslogic.CreateCsapat(mycsapat);
                    break;
                case 3:
                    CsapatModositas();
                    Console.Clear();
                    break;
                case 4:
                    CsapatLogic csapatlogic = new CsapatLogic();
                    Console.Write("Törölni kívánt csapat neve: ");
                    csapatlogic.DeleteCsapat(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("Rossz menüpont");
                    break;
            }

            Console.ReadLine();
            return;
        }

        public static void MasodikMenupont()
        {
            Console.WriteLine("1, Versenyzők listázása");
            Console.WriteLine("2, Versenyző hozzáadása");
            Console.WriteLine("3, Versenyző módosítása");
            Console.WriteLine("4, Versenyző törlése");
            Console.WriteLine("0, Kilépés a főmenübe");
            int kivalasztottMenupont = int.Parse(Console.ReadLine());
            Console.Clear();
            VersenyzoLogic versenyzoLogic = new VersenyzoLogic();
            switch (kivalasztottMenupont)
            {
                case 1:
                    Console.WriteLine("A jelenlegi idényben résztvevő versenyzők\n");
                    foreach (var item in versenyzoLogic.GetAllVersenyzo())
                    {
                        Console.WriteLine(item.nev);
                    }

                    break;
                case 2:
                    Versenyzo versenyzo = new Versenyzo();
                    Console.Write("Versenyző neve: ");
                    versenyzo.nev = Console.ReadLine();
                    Console.Write("Versenyző rajtszáma: ");
                    versenyzo.rajtszam = int.Parse(Console.ReadLine());
                    Console.Write("Versenyző csapata: ");
                    versenyzo.csapat_nev = Console.ReadLine();
                    Console.Write("Versenyző életkora: ");
                    versenyzo.eletkor = int.Parse(Console.ReadLine());
                    Console.Write("Versenyző összes pontja: ");
                    versenyzo.ossz_pont = int.Parse(Console.ReadLine());
                    Console.WriteLine("Versenyzo idenybeli pontjai: ");
                    versenyzo.idenybeli_pont = int.Parse(Console.ReadLine());
                    versenyzoLogic.CreateVersenyzo(versenyzo);
                    break;
                case 3:
                    break;
                case 4:
                    Console.Clear();
                    Console.Write("Törölni kívánt versenyző rajtszáma: ");
                    versenyzoLogic.DeleteVersenyzo(int.Parse(Console.ReadLine()));
                    break;
                default:
                    break;
            }

            Console.WriteLine("asdasd");
            Console.ReadLine();
        }

        public static void HarmadikMenupont()
        {
            Console.WriteLine("1, Versenyhetvegek listázása");
            Console.WriteLine("2, Versenyhétvége hozzáadása");
            Console.WriteLine("3, Versenyhétvége módosítása");
            Console.WriteLine("4, Versenyhétvége törlése");
            Console.WriteLine("0, Kilépés a főmenübe");
            int kivalasztottMenupont = int.Parse(Console.ReadLine());
            Console.Clear();
            VersenyhetvegeLogic versenyhetvegeLogic = new VersenyhetvegeLogic();
            switch (kivalasztottMenupont)
            {
                case 1:
                    Console.WriteLine("Az idénybeli versenyhétvégék\n");
                    foreach (var item in versenyhetvegeLogic.GetAllVersenyhetvege())
                    {
                        Console.WriteLine(item.nev);
                    }

                    break;
                case 2:
                    Versenyhetvege versenyhetvege = new Versenyhetvege();
                    Console.Write("Versenyhétvége neve: ");
                    versenyhetvege.nev = Console.ReadLine();
                    Console.Write("Versenyhetvege szama: ");
                    versenyhetvege.VERSENYHETVEGE_SZAMA = int.Parse(Console.ReadLine()); //nézni hogy már van ilyen
                    Console.Write("Versenyhetvege hossza: ");
                    versenyhetvege.hossz = int.Parse(Console.ReadLine());
                    Console.Write("Versenyhetvege kör száma: ");
                    versenyhetvege.kor = int.Parse(Console.ReadLine());
                    DateTime idopont;
                    while (true)
                    {
                        Console.Write("Versenyhetvege időpontja: ");
                        if (DateTime.TryParse(Console.ReadLine(), out idopont))
                        {
                            versenyhetvege.idopont = idopont;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Rossz időpont formátum");
                        }
                    }

                    Console.WriteLine("Versenyhetvege helyszíne: ");
                    versenyhetvegeLogic.CreateVersenyhetvege(versenyhetvege);
                    versenyhetvege.helyszin = Console.ReadLine();
                    break;
                case 3:
                    break;
                case 4:
                    Console.WriteLine("Törölni kívánt versenyhétvége száma: ");
                    versenyhetvegeLogic.DeleteVersenyhetvege(int.Parse(Console.ReadLine()));
                    break;
                default:
                    break;
            }

            Console.ReadLine();
        }

        public static void NegyedikMenupont()
        {
            Console.WriteLine("1, Eredmények listázása");
            Console.WriteLine("2, Eredmeny hozzáadása");
            Console.WriteLine("3, Eredmeny módosítása");
            Console.WriteLine("4, Eredmeny törlése");
            Console.WriteLine("0, Kilépés a főmenübe");
            int kivalasztottMenupont = int.Parse(Console.ReadLine());
            Console.Clear();
            EredmenyLogic eredmenylogic = new EredmenyLogic();
            switch (kivalasztottMenupont)
            {
                case 1:
                    Console.WriteLine("A jelenlegi eredmények\n");
                    foreach (var item in eredmenylogic.GetAllEredmeny())
                    {
                        Console.WriteLine(item.versenyhetvege_szam + "\t" + item.helyezes + "\t" + item.pont);
                    }

                    break;

                case 2:
                    Eredmeny eredmeny = new Eredmeny();
                    Console.Write("Eredmény versenyhetvege száma: ");
                    eredmeny.versenyhetvege_szam = int.Parse(Console.ReadLine());
                    Console.WriteLine("Eredményt elért rajtszám: ");
                    eredmeny.rajtszam = int.Parse(Console.ReadLine());
                    Console.WriteLine("Eredményt ekért vesenyző helyezése: ");
                    eredmeny.helyezes = int.Parse(Console.ReadLine());
                    Console.WriteLine("Eredmény pontszáma: ");
                    eredmeny.pont = int.Parse(Console.ReadLine());
                    eredmenylogic.CreateEredmeny(eredmeny);
                    break;
                case 3:
                    break;
                case 4:
                    Console.Write("Törölni kívánt eredmény id-je: ");
                    int eredmenyid = int.Parse(Console.ReadLine());
                    eredmenylogic.DeleteEredmeny(eredmenyid);
                    break;
                default:
                    break;
            }

            Console.ReadLine();
        }

        public static void OtodikMenupont()
        {
            /*foreach (var item in Blogic.GetDriversPoints())
            {
                Console.WriteLine(item.DriverName + " " + item.Points);
            }

            Console.ReadLine();*/
        }

        public static void HatodikMenupont()
        {
            /*Console.WriteLine(Blogic.GetTeamWithMostPoints());
            Console.ReadLine();*/
        }

        public static void HetedikElsMenupont()
        {
            /*Console.WriteLine("Versenyhétvége száma: ");
            int raceNumber = int.Parse(Console.ReadLine());
            foreach (var item in Blogic.GetResultWithEngineNames(raceNumber))
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadLine();*/
        }

        public static void NyolcadikMenupont()
        {
            Console.Write("Versenyző rajtszáma: ");
            int rajtszam = int.Parse(Console.ReadLine());
            Console.Write("Utolsó elért helyezése: ");
            int lastposition = int.Parse(Console.ReadLine());
            string url = $"http://localhost:8080/f1stats/prediction?rajtszam={rajtszam}&lasposition={lastposition}";
            XDocument xDoc = XDocument.Load(url);

            VersenyzoLogic versenyzoLogic = new VersenyzoLogic();
            Versenyzo versenyzo = versenyzoLogic.GetOneVersenyzo(rajtszam);
            Console.Write("A versenyző neve: " + versenyzo.nev);
            Console.WriteLine("A lehetséges helyezések és pontok hozzá: ");
            foreach (var eredmeny in xDoc.Descendants("eredmenyek"))
            {
                Console.WriteLine(eredmeny.Element("helyezes") + " " + eredmeny.Element("pont"));
            }
        }

        public static void CsapatModositas()
        {
            Console.Write("Módosítani kívánt csapat neve: ");
            string myCsapat = Console.ReadLine();
            Console.WriteLine("1, Csapat motor módosítás");
            Console.WriteLine("2, Csapat versenyszámának módosítása");
            Console.WriteLine("3, Csapat győzelemszámának módosítása");
            Console.Write("Kiválasztott menü: ");
            CsapatLogic csapatLogic = new CsapatLogic();
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("\n");
                    Console.Write("Csapat új motorja: ");//exception nézés
                    csapatLogic.UpdateMotor(myCsapat, Console.ReadLine());
                    break;
                case 2:
                    Console.WriteLine("\n");
                    Console.Write("Csapat új versenyszáma: ");
                    csapatLogic.UpdateVersenySzam(myCsapat, int.Parse(Console.ReadLine()));
                    break;
                case 3:
                    Console.WriteLine("\n");
                    Console.WriteLine("Csapat új győzelemszáma");
                    csapatLogic.UpdateGyozelmek(myCsapat, int.Parse(Console.ReadLine()));
                    break;
                default:
                    Console.WriteLine("Nincs ilyen menüpont");
                    break;
            }
        }

        public static void VersenyzoModositas()
        {

        }
    }
}
