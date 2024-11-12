namespace BackEleccionsM.Models
{
    public class Candidat
    {
        public int ID { get; set; }
        public string NomCandidat { get; set; }

        public int PartitPoliticId { get; set; } // Clave foránea a PartitPolitic
        public PartitPolitic PartitPolitic { get; set; } // Navegación a PartitPolitic

        //public string ImprimirCandidat()
        //{
        //    return NomCandidat;
        //}
        //public void borrarDatos()
        //{
        //    ID = 0;
        //    NomCandidat = string.Empty;
        //}
    }
}
