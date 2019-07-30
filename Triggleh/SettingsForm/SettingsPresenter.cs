using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Triggleh
{
    public class SettingsPresenter
    {
        private readonly ISettingsGUI screen;
        readonly ModelRepository repository = new ModelRepository();

        public SettingsPresenter(ISettingsGUI screen)
        {
            this.screen = screen;
            screen.Register(this);
            InitialiseForm();
        }

        private void InitialiseForm()
        {
            UpdateView();
        }

        private void UpdateView()
        {

        }

        async private Task<JObject> ValidateSettings()
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage()
            {
                RequestUri = new Uri("https://api.twitch.tv/helix/users?login=" + screen.Username),
                Method = HttpMethod.Get
            };
            request.Headers.Add("Client-ID", "4svh28tgbd14fe4j5co9tuwjxbc0j7");

            HttpResponseMessage response = client.SendAsync(request).Result;
            JObject parsed = JObject.Parse(response.Content.ReadAsStringAsync().Result);

            return (parsed["data"].Count<JToken>() > 0) ? (JObject) parsed["data"][0] : null;
        }

        public void Btn_SaveSettings_Click()
        {
            Task<JObject> validate = ValidateSettings();
            // validate.Wait();
            if (validate.Result != null)
            {
                Console.WriteLine(validate.Result["display_name"]);
            }
            else
            {
                Console.WriteLine("reeeeeeeee user doesn't exist");
            }
        }
    }
}
