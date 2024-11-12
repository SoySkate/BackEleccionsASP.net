namespace BackEleccionsM.Models
{

    //aixo potser el seu nom es mes adient vots per partit no?
    public class VotsPerPartit
    {
        public int ID { get; set; }
        public int NumeroVotsLlista { get; set; }

        public int PartitId { get; set; }
        public PartitPolitic Partit { get; set; }

        public int ResultatsTaulaId { get; set; } // Clave foránea
        public ResultatsTaula ResultatsTaula { get; set; } // Referencia al ResultatsTaula
      
    }
}
