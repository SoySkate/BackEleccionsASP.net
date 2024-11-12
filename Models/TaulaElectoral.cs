namespace BackEleccionsM.Models
{
    public class TaulaElectoral
    {
        public int ID { get; set; }
        public string NomTaula { get; set; }
        public int CensTaula { get; set; }
        public ResultatsTaula ResultatsTaula { get; set; }





        public Municipi Municipi { get; set; } // Propiedad de navegación inversa
        public int MunicipiId { get; set; } // Clave foránea



        //public string ImprimirNomICensTaula()
        //{
        //    return "Nom: " + NomTaula + "  Cens: " + CensTaula;
        //}

        //public override string ToString()
        //{
        //    return "Nom: " + NomTaula + "  Cens: " + CensTaula;
        //}

        //public void borrarDatos()
        //{
        //    ID = 0;
        //    NomTaula = string.Empty;
        //    CensTaula = 0;
        //    //no cal borrar res de resultats taula pq no els he de controlar per aqui
        //}
    }
}
