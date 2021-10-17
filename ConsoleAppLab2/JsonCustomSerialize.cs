using System.Text.Json;

namespace ConsoleAppLab2
{
    public static class JsonCustomSerialize
    {
        internal static void Run(Rootobject busesDb, string savePath)
        {
            var customBuses = new BusesCondensed()
            {
                buses = busesDb.results.Select(ResultToBus).ToArray(),
            };

            static Bus ResultToBus(Result r) => new()
            {
                nr_inwentarzowy = r.nr_inwentarzowy,
                danePodstawowe = new Basic()
                {
                    dlugosc = r.dlugosc,
                    liczba_miejsc_siedzacych = r.liczba_miejsc_siedzacych,
                    liczba_miejsc_stojacych = r.liczba_miejsc_stojacych,
                    marka = r.marka,
                    model = r.model,
                    operator_przewoznik = r.operator_przewoznik,
                    pojazd_dwukierunkowy = r.pojazd_dwukierunkowy,
                    rok_produkcji = r.rok_produkcji,
                    rodzaj_pojazdu = r.rodzaj_pojazdu,
                    typ_pojazdu = r.typ_pojazdu,
                },
                udogodnienia = new Facilities()
                {
                    AED = r.AED,
                    biletomat = r.biletomat,
                    drzwi_pasazerskie = r.drzwi_pasazerskie,
                    klimatyzacja = r.klimatyzacja,
                    mocowanie_rowerow = r.mocowanie_rowerow,
                    monitoring = r.monitoring,
                    przyklek = r.przyklek,
                    rampa_dla_wozkow = r.rampa_dla_wozkow,
                    USB = r.USB,
                    wysokosc_podlogi = r.wysokosc_podlogi,
                }
            };

            customBuses.buses = busesDb.results.Select(ResultToBus).ToArray();
            var json = JsonSerializer.Serialize(customBuses);
            File.WriteAllText(savePath, json);
        }
    }
}
