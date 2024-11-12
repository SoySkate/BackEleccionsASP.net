namespace BackEleccionsM.Dto
{
    public class TaulaElectoralDto
    {
        public int ID { get; set; }
        public string NomTaula { get; set; }
        public int CensTaula { get; set; }

        //QUIZAS AQUI SEA NECESARIO UN FOREIGN KEY PARA RESULTAT TAULA? O NO?

        public int MunicipiId { get; set; } // Clave foránea
    }
}
