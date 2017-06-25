using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Diagnostics;
using Mar31Fire;




namespace Mar31Fire
{
    class RestService : IRestService
    {
        HttpClient client;

        public List<Building> Buildings { get; private set; }

        public string Return { get; private set; }

        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;

        }

        public async Task<confirmStatus> SendConfirmAsync(userValidation Id)
        {
            var uri1 = Constants.RestUrl1.ToString();

            try
            {
                var json = JsonConvert.SerializeObject(Id);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = new HttpResponseMessage();

                response = await client.PutAsync(uri1, content);

                if (response.IsSuccessStatusCode)
                {
                    confirmStatus stat = new confirmStatus();
                    stat.statusCode = true;
                    return stat;
                }

                else
                {
                    confirmStatus statfail = new confirmStatus();
                    statfail.statusCode = false;
                    return statfail;
                }

            }
            catch (Exception ex)
            {
                confirmStatus exfail = new confirmStatus();
                exfail.statusCode = false;
                return exfail;
            }



}
            



        public async Task<List<Building>> GetBuildingsAsync(valInfo Id)
        {
            //Buildings = new List<Building>();
           Uri  uri = new Uri(string.Format(Constants.RestUrl1, Id.valString));
           var uri1 = Constants.RestUrl1.ToString()+Id.valString;
            var test = "here now";

            try
            {
                var response = await client.GetAsync(uri1);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Buildings = JsonConvert.DeserializeObject<List<Building>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
                List<Building> BuildingsError = new List<Building>();
                BuildingsError.Add(new Building() { buildingPrimaryName = null, buildingStatus = "NO BUILDINGS" });
                return BuildingsError;


            }
            return Buildings;

        }

        public async Task<eMailStatus> SendEmailInfoAsync(eMail mail)
        {
            //string uri = Constants.RestUrl.ToString();
            var uri = new Uri(string.Format(Constants.RestUrl));

            try
            {
                var json = JsonConvert.SerializeObject(mail);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await client.PostAsync(uri, content);


                if (response.IsSuccessStatusCode)
                {
                    eMailStatus outStat = new eMailStatus();
                    outStat.statusCode = response.StatusCode.ToString();


                    Debug.WriteLine(@"				email successfully sent successfully saved.");
                    return outStat;
                   
                }
                else
                {
                    eMailStatus outStat = new eMailStatus();
                    outStat.statusCode = response.StatusCode.ToString();


                    return outStat;
                }

            }
            catch (Exception ex)
            {
                eMailStatus outStat = new eMailStatus();
                outStat.statusCode = "500";
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
                return outStat;
            }
        }

    }

}
