using BackEleccionsM.Models;

namespace BackEleccionsM.Dto
{
    public class CandidatDto
    {
        public int ID { get; set; }
        public string NomCandidat { get; set; }

        public int PartitPoliticId { get; set; } // Clave foránea a PartitPolitic
    }
}
