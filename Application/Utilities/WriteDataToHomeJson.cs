using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utilities
{
    public class WriteDataToHomeJson
    {
        public static void WriteData(string data, string property)
        {
            JObject json = JObject.Parse(File.ReadAllText("Files\\Home.json"));
            JArray arrayProperty = (JArray)JsonConvert.DeserializeObject(data);
            json[property].Replace(arrayProperty);
            File.WriteAllText("Files\\Home.json", JsonConvert.SerializeObject(json));
        }
    }
}
