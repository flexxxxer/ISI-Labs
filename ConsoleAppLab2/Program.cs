using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using ConsoleAppLab2;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

var jsonPath = Path.Combine("Assets", "data.json");
var jsonString = File.ReadAllText(jsonPath);

var busesDb = JsonSerializer.Deserialize<Rootobject>(jsonString)!;

Console.WriteLine($"Nazwa bazy: {busesDb.description.title}");
Console.WriteLine($"Liczba elementów w bazie: { busesDb.count} ");

var ileGdansk = busesDb.results.Count(x => x.operator_przewoznik is "Gdańskie Autobusy i Tramwaje");
var ileZabytkowych = busesDb.results.Count(x => x.pojazd_zabytkowy is "tak");
var ilePo2000 = busesDb.results.Count(x => int.Parse(x.rok_produkcji) > 2000);
var sredniaStojacych = busesDb.results.Average(x => int.Parse(x.liczba_miejsc_stojacych));
var sredniaSiedzacych = busesDb.results.Average(x => int.Parse(x.liczba_miejsc_siedzacych));

Console.WriteLine($"Liczba autobusów przynależnych do przewoźnika Gdańskie Autobusy i Tramwaje: {ileGdansk}");
Console.WriteLine($"Ile jest pojazdów zabytkowych: {ileZabytkowych}");
Console.WriteLine($"Ile jest pojazdów wyprodukowanych po 2000 roku: {ilePo2000}");
Console.WriteLine($"Jaka jest średnia liczba miejsc stojących: {sredniaStojacych}");
Console.WriteLine($"Jaka jest średnia liczba miejsc siedzących: {sredniaSiedzacych}");

Console.WriteLine("Serializacja danych z poziomu c# do JSON");
string jsonSavePath = Path.Combine("Assets", "data2.json");
JsonCustomSerialize.Run(busesDb, jsonSavePath);

Console.WriteLine("Serializacja danych z poziomu python do c#");
JsonPythonDeserialize.Run();

void Zadanie6()
{
    static string XmlToJson(string xml)
    {
        var doc = new XmlDocument();
        doc.LoadXml(xml);

        return JsonConvert.SerializeXmlNode(doc);
    }

    static string JsonToXml(string json) 
        => JsonConvert.DeserializeXNode(json, "Root")?.ToString() ?? string.Empty;

    var xml = File.ReadAllText(Path.Combine("Assets", "dane.xml"));

    Console.WriteLine("Originalny XML: dane.xml");

    Console.WriteLine("Przekonwertowany do JSON: dane_json.json");
    File.WriteAllText(Path.Combine("Assets", "dane_json.json"), XmlToJson(xml));

    Console.WriteLine("Przekonwertowany JSON do XML: dane_json_xml.xml");
    File.WriteAllText(Path.Combine("Assets", "dane_json_xml.xml"), JsonToXml(XmlToJson(xml)));
}

Zadanie6();