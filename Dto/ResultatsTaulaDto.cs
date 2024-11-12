namespace BackEleccionsM.Dto
{
    public class ResultatsTaulaDto
    {
        public int ID { get; set; }
        public int VotsBlanc { get; set; }
        public int VotsNul { get; set; }
        public int VotsTotals { get; set; }
        public int TaulaElectoralId { get; set; } //foreign key
    }
}
