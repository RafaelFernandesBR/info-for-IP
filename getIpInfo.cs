using System.Net;
using Newtonsoft.Json.Linq;

namespace telegramIp
{
    public class getInfo
    {

        private string getIpInfo(string ip)
        {
            string url = "http://ip-api.com/json/" + ip + "?fields=1113821&lang=pt-BR";
            string json = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                json = reader.ReadToEnd();
                reader.Close();
                stream.Close();
            }
            catch (Exception ex)
            {
                json = ex.Message;
            }
            return json;
        }

        //tratar o json para retorno
        public string[] buscaInfoIp(string ip)
        {
            string json = getIpInfo(ip);
            string[] retorno = null;

            var obj = JObject.Parse(json);
            if (Convert.ToString(obj["status"]) == "fail")
            {
                retorno[0] = "Ip inválido, tente novamente.";
            }
            else
            {
                retorno = new string[8];

                retorno[0] = "IP: " + obj["query"] + "\n";
                retorno[1] += "Cidade: " + obj["city"] + "\n";
                retorno[2] += "Região: " + obj["regionName"] + " " + obj["region"] + "\n";
                retorno[3] += "País: " + obj["country"] + "\n";
                retorno[4] += "Provedor: " + obj["isp"] + "\n";
                retorno[5] += "Fornecedora: " + obj["org"] + "\n";
                retorno[6] += "Latitude: " + obj["lat"] + "\n";
                retorno[7] += "Longitude: " + obj["lon"] + "\n";
            }

            return retorno;
        }

    }
}
