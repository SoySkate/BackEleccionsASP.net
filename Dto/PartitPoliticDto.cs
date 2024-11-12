using BackEleccionsM.Models;

namespace BackEleccionsM.Dto
{
    public class PartitPoliticDto
    {
        public int ID { get; set; }
        public string NomPartit { get; set; }
        public int MunicipiId { get; set; } // Clave foránea

    }
}
