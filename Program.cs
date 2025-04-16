// See https://aka.ms/new-console-template for more information


using jurnalmod8;

class Program
{
    static void Main()
    {
        BankTransferConfig config = new BankTransferConfig();
        config.ReadConfigFile();
        if (config.config.lang == "en")
        {
            Console.WriteLine("Please insert the amount of money to transfer");
        } else
        {
            Console.WriteLine("Masukkan jumlah uang yang akan di-transfer:");
        }

        int transfer = Convert.ToInt32(Console.ReadLine());
        if (transfer <= config.config.transfer.threshold){
            if (config.config.lang == "en")
            {
                Console.WriteLine($"Transfer fee = {transfer}");
                Console.WriteLine($"Total Amount = {transfer + config.config.transfer.low_fee}");
            } else
            {
                Console.WriteLine($"Biaya transfer = {transfer}");
                Console.WriteLine($"Total biaya = {transfer + config.config.transfer.low_fee}");
            }
        }
    }
}
