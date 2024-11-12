namespace BackEleccionsM.Models
{
    public class PartitPolitic
    {
        public int ID { get; set; }
        public string NomPartit { get; set; }
        public ICollection<Candidat> Candidats { get; set; }


        //para la relacion inversa
        public ICollection<VotsPerPartit> Vots { get; set; }


        //foreign keys
        public Municipi Municipi { get; set; } // Propiedad de navegación inversa
        public int MunicipiId { get; set; } // Clave foránea


        //public void borrarDatos()
        //{
        //    ID = 0;
        //    NomPartit = string.Empty;
        //    Candidats.Clear();
        //}
        //public override string ToString()
        //{
        //    return NomPartit;
        //}
    }
}
