using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AESCrypter.Classes
{
    public class config
    {
        
        public bool az_klein  { get; set; }
        public bool AZ_gross { get; set; }
        public bool Zahlen09 { get; set; }
        public bool Specialchars { get; set; }
        public int laenge_gesamt { get; set; }
        public int anzahl_sonderzeichen { get; set; }
        public List<Historie> Historie { get; set; }

        #region Config Laden

        public void laden(string configdatei)
	    {
            string ConfigDatei = File.ReadAllText(configdatei);
            config c = JSONDeserialise<config>(ConfigDatei);

            az_klein = c.az_klein;
            AZ_gross = c.AZ_gross;
            Zahlen09 = c.Zahlen09;
            Specialchars = c.Specialchars;
            laenge_gesamt = c.laenge_gesamt;
            anzahl_sonderzeichen = c.anzahl_sonderzeichen;
            Historie = c.Historie;
        }

        public void laden()
        {
            laden(Path.Combine(Application.StartupPath,"config.json"));    
        }

        #endregion

        #region Config Speichern
        public void speichern(string configdatei)
        {
            File.WriteAllText(configdatei,JSONSerialize<config>(this));
        }
        
        public void speichern()
        {
            speichern(Path.Combine(Application.StartupPath, "config.json"));
        }
        #endregion

        public static T JSONDeserialise<T>(string json)
        {
            T obj = Activator.CreateInstance<T>();
            using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
                obj = (T)serializer.ReadObject(ms);
                return obj;
            }
        }

        public static string JSONSerialize<T>(T obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, obj);
                return Encoding.Default.GetString(ms.ToArray());
            }
        }

    }

    public class Historie
    {
        public DateTime Datum { get; set; }
        public string Klartext { get; set; }
        public string Crypttext { get; set; }
    }
}
