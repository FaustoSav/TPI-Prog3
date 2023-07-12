namespace TPI_Prog3.Models.DocumentalModels
{
    public class Documental
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Duration { get; set; }
        public string Director { get; set; } = string.Empty;

    }
}
