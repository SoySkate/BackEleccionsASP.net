using BackEleccionsM.Models;

namespace BackEleccionsM.Dto
{
    public class VotsPerPartitDto
    {
        public int ID { get; set; }
        public int NumeroVotsLlista { get; set; }

        public int PartitId { get; set; }// Clave foránea

        public int ResultatsTaulaId { get; set; } // Clave foránea
    }
}
