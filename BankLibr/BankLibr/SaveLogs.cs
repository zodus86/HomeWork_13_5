using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace BankLibr
{
    public class SaveLogs
    {
        /// <summary>
        /// save json
        /// </summary>
        /// <param name="log"></param>
        /// <param name="fileName"></param>
        public static void SaveJSON(ObservableCollection<string> log, string fileName)
        {
            string json = JsonConvert.SerializeObject(log);
            File.WriteAllText(fileName, json);
        }
        /// <summary>
        /// save xml
        /// </summary>
        /// <param name="log"></param>
        /// <param name="fileName"></param>
        public static void SaveXML(ObservableCollection<string> log, string fileName)
        {
            XmlSerializer xmlSerialize = new XmlSerializer(typeof(ObservableCollection<string>));
            using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                xmlSerialize.Serialize(stream, log);
            }
        }
    }
}
