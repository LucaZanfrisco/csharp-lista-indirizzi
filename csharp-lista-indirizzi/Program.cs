// See https://aka.ms/new-console-template for more information

using csharp_lista_indirizzi;
using System.IO.Enumeration;

// FUNZIONI

// Funzione che restituisce un lista di indirizzi letti da un file CSV
List<Address> ReadFile()
{
    List<Address> addresses = new List<Address>();

    StreamReader readedFile = File.OpenText("C:\\Users\\user\\Desktop\\DotNet\\csharp-lista-indirizzi\\csharp-lista-indirizzi\\my-addresses.csv");

    int i = 0;
    while(!readedFile.EndOfStream)
    {
        string line = readedFile.ReadLine().TrimStart(',');
        
        if(i > 0)
        {
            string[] splitedLine = line.Split(",");
            
            if(splitedLine.Length == 6)
            {
                string name = splitedLine[0];
                string surname = splitedLine[1];
                string street = splitedLine[2];
                string city = splitedLine[3];
                string province = splitedLine[4];
                int zip = int.Parse(splitedLine[5]);
                Address address = new Address(name, surname, street, city, province,zip);
                addresses.Add(address);
               
            }else
            {
                Console.WriteLine($"L'indirizzo {line} non è corretto");
            }
        }
        i++;
    }
   
    readedFile.Close();

    return addresses;
}

// Funzione che stampa in un file la lista di indirizzi
void PrintFile(string fileName, List<Address> addresses)
{
    string path = $"C:\\Users\\user\\Desktop\\DotNet\\csharp-lista-indirizzi\\csharp-lista-indirizzi\\{fileName}";

    StreamWriter writer = File.CreateText(path);

    foreach(Address address in addresses)
    {
        writer.WriteLine(address);
    }

    writer.Close();

}



// MAIN
List<Address> addresses = ReadFile();
foreach( Address address in addresses)
{
    Console.WriteLine(address);
}

Console.Write("Inserire il nome del file su cui stampare: ");
string fileName = Console.ReadLine();

PrintFile(fileName, addresses);

