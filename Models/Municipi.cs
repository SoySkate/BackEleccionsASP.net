namespace BackEleccionsM.Models
{
    public class Municipi
    {
        public int ID { get; set; }
        public string NomMunicipi { get; set; }
        public int NumeroRegidors { get; set; }
        //Potser la list de llista partits del municipi té més sentit...?
        public ICollection<PartitPolitic> LlistaPartits { get; set; }
        public ICollection<TaulaElectoral> TaulesElectorals { get; set; }
        //aqui en el constructor buit inicialtzo la List que no sabia que s'havia de fer xdd 

        //public string ImprimirDatosMunicipio()
        //{
        //    return "-" + NomMunicipi + "  -Regidors: " + NumeroRegidors + " -TaulesElec: ";//+ taulesElectorals.Count();
        //}

        //public override string ToString()
        //{
        //    return "-" + NomMunicipi + "  -Regidors: " + NumeroRegidors + " -TaulesElec: ";//+ taulesElectorals.Count();
        //}
        //public void borrarDatos()
        //{
        //    ID = 0;
        //    NomMunicipi = string.Empty;
        //    NumeroRegidors = 0;
        //    LlistaPartits.Clear();
        //    TaulesElectorals.Clear();
        //}
    }
}
