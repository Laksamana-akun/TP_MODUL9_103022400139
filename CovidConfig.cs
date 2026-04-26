using System;
using System.IO;
using Newtonsoft.Json;

namespace TP_MODUL9_NIM
{
    class CovidConfig
    {
        public string satuan_suhu = "celcius";
        public int batas_hari_demam = 14;
        public string pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
        public string pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

        public void LoadConfig()
        {
            string filePath = "covid_config.json";

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                CovidConfig data = JsonConvert.DeserializeObject<CovidConfig>(json);

                satuan_suhu = data.satuan_suhu;
                batas_hari_demam = data.batas_hari_demam;
                pesan_ditolak = data.pesan_ditolak;
                pesan_diterima = data.pesan_diterima;
            }
            else
            {
                SaveConfig();
            }
        }

        public void SaveConfig()
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText("covid_config.json", json);
        }

        public void UbahSatuan()
        {
            if (satuan_suhu == "celcius")
                satuan_suhu = "fahrenheit";
            else
                satuan_suhu = "celcius";

            SaveConfig();
        }
    }
}