using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sample.UI;

namespace Sample
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Sample.Resources.metadatas.EstateCollectDTO.json"))
            using (var sr = new StreamReader(stream))
            {
                var json = (JObject)JsonConvert.DeserializeObject(sr.ReadToEnd());
                var groups = json["groups"].ToObject<List<MetadataGroup>>();

                if (json != null)
                {
 
                }
            }
        }
    }
}