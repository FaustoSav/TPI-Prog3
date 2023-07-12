namespace TPI_Prog3.Models.DocumentalModels
{
    public class UpdateDocumentalRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Duration { get; set; }
        public string Director { get; set; } = string.Empty;
    }
}
