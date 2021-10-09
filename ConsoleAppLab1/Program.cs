using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Xml;
using System.Xml.XPath;

using BasedFunctionalFeatures;
using HtmlAgilityPack;

string Input(string message)
{
    Console.WriteLine(message);
    return Console.ReadLine() ?? "";
}

void Zadanie5()
{
    var hc = new HttpClient();
    // pobiera pierwszą stronę newsów
    var newsy = hc.GetAsync("https://en.wikipedia.org/wiki/Programming_language_generations").Result;

    if (newsy.IsSuccessStatusCode)
    {
        // odczytuje HTML
        var newsyHtml = newsy.Content.ReadAsStringAsync().Result;
        
        // ładuje do HtmlAgilityPack
        var htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(newsyHtml);
        
        // szukanie - wszystkie div/h3/a, które są wewnątrz elementu / html / body / div[1] / div / div[2] / div[3] / div[1]
        // tj. efektywnie wszystkie nagłówki newsów
        var tresc = htmlDocument
            .DocumentNode
            .SelectNodes("/html/body/div/div/div/div/div/ul")
            .First()
            .InnerText
            .Split("\n")
            .Where(s => !string.IsNullOrEmpty(s))
            .JoinBy("\n");
        
        $"Tresc strony internetowej: {tresc}".Print();
    }
}

Console.WriteLine();

var xmlpath = Path.Combine("Assets", "dane.xml");

var mejscowosc = Input("Jaka miejscowosc?");

"XML loaded by DOM Approach".Print();
XMLReadWithDOMApproach.Read(xmlpath, mejscowosc);
XMLReadWithDOMApproach.WKtorymWojewodztwieJestNajwiecejWybranychHurtowni(xmlpath, "Aktywna");
XMLReadWithDOMApproach.WKtorymWojewodztwieJestNajwiecejWybranychHurtowni(xmlpath, "Nieaktywna");

"XML loaded by SAX Approach".Print();
XMLReadWithSAXApproach.WKtorymWojewodztwieJestNajwiecejWybranychHurtowni(xmlpath, "Aktywna");
XMLReadWithSAXApproach.WKtorymWojewodztwieJestNajwiecejWybranychHurtowni(xmlpath, "Nieaktywna");

"XML loaded with XPath".Print();
XNKReadWithXLSTDOM.Read(xmlpath, mejscowosc);

"Zadanie 5 Odczyt i analiza danych strony internetowej".Print();
Zadanie5();

Console.ReadLine();

public static class XMLReadWithDOMApproach
{
    public static void Read(string filepath, string wybranaMiejscowosc)
    {
        var doc = new XmlDocument();
        doc.Load(filepath);

        var warehouse = doc.GetElementsByTagName("Hurtownia");

        static (string status, string miejscowosc) GetAttributes(XmlNode node)
        {
            string status = node.Attributes!.GetNamedItem("status")!.Value!;
            string miejscowosc = node.FirstChild!.Attributes!.GetNamedItem("miejscowosc")!.Value!;

            return (status, miejscowosc);
        }

        int ileAktywnych = warehouse
            .Nodes()
            .Select(GetAttributes)
            .Count(attr => attr == ("Aktywna", wybranaMiejscowosc));

        int ileNieaktywnych = warehouse
            .Nodes()
            .Select(GetAttributes)
            .Count(attr => attr == ("Nieaktywna", wybranaMiejscowosc));

        $"Liczba aktywnych hurtowni w {wybranaMiejscowosc}: {ileAktywnych}".Print();
        $"Liczba nieaktywnych hurtowni w {wybranaMiejscowosc}: {ileNieaktywnych}".Print();
    }

    public static void WKtorymWojewodztwieJestNajwiecejWybranychHurtowni(string filepath, string statusHurtowni)
    {
        var doc = new XmlDocument();
        doc.Load(filepath);

        var warehouse = doc.GetElementsByTagName("Hurtownia");

        static (string status, string wojewodstwo) GetAttributes(XmlNode node)
        {
            string status = node.Attributes!.GetNamedItem("status")!.Value!;
            string wojewodstwo = node.FirstChild!.Attributes!.GetNamedItem("wojewodztwo")!.Value!;

            return (status, wojewodstwo);
        }

        var wojewodzwo = warehouse.Nodes()
            .Select(GetAttributes)
            .GroupBy(x => x.wojewodstwo)
            .MaxBy(x => x.Count(y => y.status == statusHurtowni))
            !.Key;

        $"Wojewodstwo gdzie najwiecej hurtowni ze statusem \"{statusHurtowni}\": {wojewodzwo}".Print();
    }
}

public static class XMLReadWithSAXApproach
{
    public static void Read(string filepath, string wybranaMiejscowosc)
    {
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.IgnoreComments = true;
        settings.IgnoreProcessingInstructions = true;
        settings.IgnoreWhitespace = true;

        XmlReader reader = XmlReader.Create(filepath, settings);

        reader.MoveToContent();

        static IEnumerable<(string status, string miejscowosc)> GetNodesAttributes(XmlReader reader)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Hurtownia")
                {
                    string status = reader.GetAttribute("status")!;

                    reader.Read();

                    string miejscowosc = reader.GetAttribute("miejscowosc")!;

                    yield return (status, miejscowosc);
                }
            }
        }

        var ileAktywnych = GetNodesAttributes(reader)
            .Count(attr => attr == ("Aktywna", wybranaMiejscowosc));

        var ileNieaktywnych = GetNodesAttributes(reader)
            .Count(attr => attr == ("Nieaktywna", wybranaMiejscowosc));

        $"Liczba aktywnych hurtowni w {wybranaMiejscowosc}: {ileAktywnych}".Print();
        $"Liczba nieaktywnych hurtowni w {wybranaMiejscowosc}: {ileNieaktywnych}".Print();
    }

    public static void WKtorymWojewodztwieJestNajwiecejWybranychHurtowni(string filepath, string statusHurtowni)
    {
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.IgnoreComments = true;
        settings.IgnoreProcessingInstructions = true;
        settings.IgnoreWhitespace = true;

        XmlReader reader = XmlReader.Create(filepath, settings);

        reader.MoveToContent();

        static IEnumerable<(string status, string wojewodstwo)> GetHurtowniAttributes(XmlReader reader)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Hurtownia")
                {
                    string status = reader.GetAttribute("status")!;
                    
                    reader.Read();

                    string wojewodztwo = reader.GetAttribute("wojewodztwo")!;

                    yield return (status, wojewodztwo);
                }
            }
        }

        var wojewodzwo = GetHurtowniAttributes(reader)
            .GroupBy(x => x.wojewodstwo)
            .MaxBy(x => x.Count(y => y.status == statusHurtowni))
            !.Key;

        $"Wojewodstwo gdzie najwiecej hurtowni ze statusem \"{statusHurtowni}\": {wojewodzwo}".Print();
    }
}

public static class XNKReadWithXLSTDOM
{
    public static void Read(string filepath, string wybranaMiejscowosc)
    {
        XPathDocument docNav = new XPathDocument(filepath);
        XPathNavigator nav = docNav.CreateNavigator();
        string strExpression = $"count(./Hurtownie/Hurtownia[@status='Aktywna' and ./Adres[@miejscowosc='{wybranaMiejscowosc}']])";

        $"Liczba aktywnych hurtowni w {wybranaMiejscowosc}: {nav.Evaluate(strExpression)}".Print();
    }

    public static void WKtorymWojewodztwieJestNajwiecejWybranychHurtowni(string filepath, string statusHurtowni)
    {
        // nie wiem jak zrobic grupowanie + max przez xpath (google nie pomogl)
    }
}