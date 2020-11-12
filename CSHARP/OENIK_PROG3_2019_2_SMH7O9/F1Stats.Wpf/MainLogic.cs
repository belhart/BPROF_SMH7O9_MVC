using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows.Markup.Localizer;

namespace F1Stats.Wpf
{
    class MainLogic
    {
        string url = "http://localhost:2933/api/versenyzoapi/";
        HttpClient client = new HttpClient();

        void SendMessage(bool success)
        {
            string msg = success ? "Operation completed" : "Operation failed";
            Messenger.Default.Send(msg, "VersenyzoResult");
        }

        public List<VersenyzoVM> ApiGetVersenyzo()
        {
            string json = client.GetStringAsync(url + "all").Result;
            var list = JsonConvert.DeserializeObject<List<VersenyzoVM>>(json);
            //SendMessage(true);
            return list;
        }

        public void ApiDelVersenyzo(VersenyzoVM versenyzo)
        {
            bool success = false;
            if (versenyzo != null)
            {
                string json = client.GetStringAsync(url + "del/" + versenyzo.Rajtszam).Result;
                JObject jObject = JObject.Parse(json);
                success = (bool)jObject["OperationResult"];
            }
            SendMessage(success);
        }

        bool ApiEditVersenyzo(VersenyzoVM versenyzo, bool isEditing)
        {
            if (versenyzo == null) return false;
            string myUrl = isEditing ? url + "mod" : url + "add";

            Dictionary<string, string> postData = new Dictionary<string, string>();
            postData.Add(nameof(VersenyzoVM.Rajtszam), versenyzo.Rajtszam.ToString());
            postData.Add(nameof(VersenyzoVM.Nev), versenyzo.Nev);
            postData.Add(nameof(VersenyzoVM.CsapatNev), versenyzo.CsapatNev);
            postData.Add(nameof(VersenyzoVM.Eletkor), versenyzo.Eletkor.ToString());
            postData.Add(nameof(VersenyzoVM.OsszPont), versenyzo.OsszPont.ToString());
            postData.Add(nameof(VersenyzoVM.IdenybeliPont), versenyzo.IdenybeliPont.ToString());

            string json = client.PostAsync(myUrl, new FormUrlEncodedContent(postData)).Result.Content.ReadAsStringAsync().Result;
            JObject obj = JObject.Parse(json);
            return (bool)obj["OperationResult"];
        }

        public void EditVersenyzo(VersenyzoVM versenyzo, Func<VersenyzoVM,bool> editor)
        {
            VersenyzoVM clone = new VersenyzoVM();
            if (versenyzo != null) clone.CopyFrom(versenyzo);
            bool? success = editor?.Invoke(clone);
            if (success == true)
            {
                if (versenyzo != null) success = ApiEditVersenyzo(clone, true);
                else success = ApiEditVersenyzo(clone, false);
            }
            SendMessage(success == true);
        }
    }
}
