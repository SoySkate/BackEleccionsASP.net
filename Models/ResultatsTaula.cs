namespace BackEleccionsM.Models
{
    public class ResultatsTaula
    {
        public int ID { get; set; }
        public int VotsBlanc { get; set; }
        public int VotsNul { get; set; }
        public int VotsTotals { get; set; }
        public ICollection<VotsPerPartit> VotsPartit { get; set; }


        public int TaulaElectoralId { get; set; } //foreign key


        //public string ImprimirResultatsTaula()
        //{
        //    //imprimir la llista dels votsPartits i despres els blanc i els nul
        //    return "votsblanc:" + VotsBlanc + "votsNuls:" + VotsNul + "votsTotals:" + VotsTotals;
        //}
    }
}
