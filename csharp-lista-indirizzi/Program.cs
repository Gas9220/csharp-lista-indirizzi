using csharp_lista_indirizzi;
using System.Runtime.Versioning;

List<Address> addresses = new List<Address>();

// Path to my-addresses.csv file
string pathTofile = AppDomain.CurrentDomain.BaseDirectory + "//my-addresses.csv";

try
{
    // Open the file
    StreamReader fileToRead = File.OpenText(pathTofile);

    // Read test
    //Console.WriteLine(fileToRead.ReadToEnd());

    // Line number counter
    int lineNumber = 0;

    while (!fileToRead.EndOfStream)
    {
        string line = fileToRead.ReadLine();
        // Skip the first line
        lineNumber++;

        if (lineNumber > 1)
        {
            string[] splittedWords = line.Split(',');

            if (splittedWords.Length < 6)
            {
                Console.WriteLine("Unable to read this line");
            }
            else
            {
                for (int i = 0; i < splittedWords.Length; i++)
                {
                    splittedWords[i].TrimStart();
                }

                string name = splittedWords[0];
                string surname = splittedWords[1];
                string street = splittedWords[2];
                string city = splittedWords[3];
                string province = splittedWords[5];
                int zip = int.Parse(splittedWords[5]);

                Address address = new Address(name, surname, street, city, province, zip);
                addresses.Add(address);
                address.GetAddress();

            }
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}



