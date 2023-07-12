namespace TPI_Prog3.Models.SerieModels
{
    public class Serie
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int Seasons { get; set; }

    }
}
