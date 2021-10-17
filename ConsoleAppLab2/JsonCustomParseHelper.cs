public class Rootobject
{
    public Description description { get; set; }
    public Columns columns { get; set; }
    public int count { get; set; }
    public Result[] results { get; set; }
}

public class Description
{
    public string title { get; set; }
    public string language { get; set; }
    public string sourceDate { get; set; }
    public string generationDate { get; set; }
    public string owner { get; set; }
    public string source { get; set; }
}

public class Columns
{
    public string foto { get; set; }
    public string nr_inwentarzowy { get; set; }
    public string operator_przewoznik { get; set; }
    public string rodzaj_pojazdu { get; set; }
    public string typ_pojazdu { get; set; }
    public string pojazd_dwukierunkowy { get; set; }
    public string pojazd_zabytkowy { get; set; }
    public string dlugosc { get; set; }
    public string marka { get; set; }
    public string model { get; set; }
    public string rok_produkcji { get; set; }
    public string liczba_miejsc_siedzacych { get; set; }
    public string liczba_miejsc_stojacych { get; set; }
    public string klimatyzacja { get; set; }
    public string monitoring { get; set; }
    public string monitor_wewnetrzny { get; set; }
    public string wysokosc_podlogi { get; set; }
    public string przyklek { get; set; }
    public string rampa_dla_wozkow { get; set; }
    public string USB { get; set; }
    public string zapowiedzi_glosowe { get; set; }
    public string AED { get; set; }
    public string mocowanie_rowerow { get; set; }
    public string biletomat { get; set; }
    public string patron { get; set; }
    public string link { get; set; }
    public string drzwi_pasazerskie { get; set; }
}

public class Result
{
    public string foto { get; set; }
    public string nr_inwentarzowy { get; set; }
    public string operator_przewoznik { get; set; }
    public string rodzaj_pojazdu { get; set; }
    public string typ_pojazdu { get; set; }
    public string pojazd_dwukierunkowy { get; set; }
    public string pojazd_zabytkowy { get; set; }
    public string dlugosc { get; set; }
    public string marka { get; set; }
    public string model { get; set; }
    public string rok_produkcji { get; set; }
    public string liczba_miejsc_siedzacych { get; set; }
    public string liczba_miejsc_stojacych { get; set; }
    public string klimatyzacja { get; set; }
    public string monitoring { get; set; }
    public string monitor_wewnetrzny { get; set; }
    public string wysokosc_podlogi { get; set; }
    public string przyklek { get; set; }
    public string rampa_dla_wozkow { get; set; }
    public string USB { get; set; }
    public string zapowiedzi_glosowe { get; set; }
    public string AED { get; set; }
    public string mocowanie_rowerow { get; set; }
    public string biletomat { get; set; }
    public string patron { get; set; }
    public string link { get; set; }
    public string drzwi_pasazerskie { get; set; }
}
