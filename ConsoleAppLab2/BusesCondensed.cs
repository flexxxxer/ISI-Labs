namespace ConsoleAppLab2
{
    class BusesCondensed
    {
        public Bus[] buses { get; set; }
    }
    
    class Bus
    {
        public string nr_inwentarzowy { get; set; }
        public Basic danePodstawowe { get; set; }
        public Facilities udogodnienia { get; set; }
    }

    class Basic
    {
        public string operator_przewoznik { get; set; }
        public string rodzaj_pojazdu { get; set; }
        public string typ_pojazdu { get; set; }
        public string pojazd_dwukierunkowy { get; set; }
        public string dlugosc { get; set; }
        public string marka { get; set; }
        public string model { get; set; }
        public string rok_produkcji { get; set; }
        public string liczba_miejsc_siedzacych { get; set; }
        public string liczba_miejsc_stojacych { get; set; }
    }

    class Facilities
    {
        public string klimatyzacja { get; set; }
        public string monitoring { get; set; }
        public string wysokosc_podlogi { get; set; }
        public string przyklek { get; set; }
        public string rampa_dla_wozkow { get; set; }
        public string USB { get; set; }
        public string zapowiedzi_glosowe { get; set; }
        public string AED { get; set; }
        public string mocowanie_rowerow { get; set; }
        public string biletomat { get; set; }
        public string drzwi_pasazerskie { get; set; }
    }
}
