using System.Net;

namespace DataApi
{
    public class DataService
    {
        public async Task<bool> RefreshUnits()
        {
            try
            {
                //HttpClient client = new();

                //var result = await client.GetAsync("https://www.google.de");


                //var request = WebRequest.Create("https://www.conquerorsbladehub.com/units/armiger_lancers.html");

                string text = "";
                //var response = (HttpWebResponse)request.GetResponse();

                //using (var sr = new StreamReader(response.GetResponseStream()))
                //{
                //    text = sr.ReadToEnd();
                //}

                Console.WriteLine(text);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
