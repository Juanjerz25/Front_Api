using DojoApplicationWeb.Models;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace DojoApplicationWeb.ConsumpoApi
{
    public class ConexionApi
    {
        public static async Task<string> PostItem(HttpServiceModel httpServiceModel)
        {
            var data = JsonConvert.SerializeObject(httpServiceModel.Parametros); ;
            var url = $"https://localhost:44358/Api/"+httpServiceModel.Controlador+"/"+ httpServiceModel.Accion;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(data);
                await streamWriter.FlushAsync();
                streamWriter.Close();
            }
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return string.Empty;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            return responseBody;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                return ex.Message;
            }
        }

    }
}