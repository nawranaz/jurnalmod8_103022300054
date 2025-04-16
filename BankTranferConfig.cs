using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace jurnalmod8
{
    class Transfer
    {
        public int threshold { get; set; }
        public int low_fee { get; set; }
        public int high_fee { get; set; }
    }

    class Confirmation
    {
        public string en { get; set; }
        public string id { get; set; }
    }

    class BankTransferConfig
    {
        private string filePath = "bank_transfer_config.json";
        public Config config { get; set; }


        public BankTransferConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch (Exception)
            {
                setDefault();
                WriteNewConfigFile();
            }
        }
        public void setDefault() {
            config = new Config();
            config.lang = "en";
            config.transfer.threshold = 25000000;
            config.transfer.low_fee = 6500;
            config.transfer.high_fee = 15000;
            config.methods = [ "RTO(real - time)", "SKN", "RTGS", "BI FAST" ];
            config.confirmation.en = "yes";
            config.confirmation.id = "ya";

        }
       public class Config
        {
            public string lang { get; set; }
            public Transfer transfer { get; set; }
            public List<String> methods { get; set; }
            public Confirmation confirmation { get; set; }

        }

        public Config ReadConfigFile()
        {
            String configJsonData = File.ReadAllText(filePath);
            config = JsonSerializer.Deserialize<Config>(configJsonData);
            return config;
        }

        public void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            String jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filePath, jsonString);
        }



    }

}
