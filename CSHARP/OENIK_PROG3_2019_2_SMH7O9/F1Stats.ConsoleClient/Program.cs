using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace F1Stats.ConsoleClient
{
    public class Versenyzo
    {
        public int Rajtszam { get; set; }
        public string Nev { get; set; }
        public string CsapatNev { get; set; }
        public int Eletkor { get; set; }
        public int OsszPont { get; set; }
        public int IdenybeliPont { get; set; }
        public override string ToString()
        {
            return $"rajtszam={Rajtszam}\tNev={Nev}\tCsapatnev={CsapatNev}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Várjálmánaáespére");
            Console.ReadLine();
            string url = "http://localhost:2933/api/versenyzoapi/";
            using (HttpClient client = new HttpClient())
            {
                string json = client.GetStringAsync(url + "all").Result;
                var list = JsonConvert.DeserializeObject<List<Versenyzo>>(json);
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();

                Dictionary<string, string> postData;
                string response;

                postData = new Dictionary<string, string>();
                postData.Add(nameof(Versenyzo.Rajtszam), "256");
                postData.Add(nameof(Versenyzo.Nev), "Lakatos Gizejde");
                postData.Add(nameof(Versenyzo.CsapatNev), "Scuderia Ferrari Mission Winnow");
                postData.Add(nameof(Versenyzo.Eletkor), "101");
                postData.Add(nameof(Versenyzo.OsszPont), "256");
                postData.Add(nameof(Versenyzo.IdenybeliPont), "256");

                response = client.PostAsync(url + "add", new FormUrlEncodedContent(postData)).Result.Content.ReadAsStringAsync().Result;

                json = client.GetStringAsync(url + "all").Result;
                Console.WriteLine("ADD:" + response);
                Console.WriteLine("ALL:" + json);
                Console.ReadLine();

                int rajtszam = JsonConvert.DeserializeObject<List<Versenyzo>>(json).Single(x => x.Nev == "Lakatos Gizejde").Rajtszam;
                postData = new Dictionary<string, string>();
                postData.Add(nameof(Versenyzo.Rajtszam),rajtszam.ToString());
                postData.Add(nameof(Versenyzo.Nev), "Lakatos Gizejde");
                postData.Add(nameof(Versenyzo.CsapatNev), "Scuderia Ferrari Mission Winnow");
                postData.Add(nameof(Versenyzo.Eletkor), "101");
                postData.Add(nameof(Versenyzo.OsszPont), "150");
                postData.Add(nameof(Versenyzo.IdenybeliPont), "256");
                response = client.PostAsync(url + "mod", new FormUrlEncodedContent(postData)).Result.Content.ReadAsStringAsync().Result;

                json = client.GetStringAsync(url + "all").Result;
                Console.WriteLine("MOD:" + response);
                Console.WriteLine("ALL:" + json);
                Console.ReadLine();

                response = client.GetStringAsync(url + "del/" + rajtszam).Result;
                json = client.GetStringAsync(url + "all").Result;
                Console.WriteLine("DEL:" + response);
                Console.WriteLine("ALL:" + json);
                Console.ReadLine();
            }
        }
    }
}
