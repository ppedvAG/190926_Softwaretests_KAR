 namespace ppedv.Personeverwaltung.Domain
{
    public class Person : Entity
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public byte Alter { get; set; }
        public decimal Kontostand { get; set; }
    }

}
