namespace AuthAPI.Models
{
    public record APILog
    {


        public long Id { get; set; }
        public string LogLevel { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string? RequestMethod { get; set; }
        public string? RequestPath { get; set; }
        public int? StatusCode { get; set; }
        public long? DurationMs { get; set; }
        public string? ExceptionMessage { get; set; }
        public DateTime CreatedAt { get; set; }

    }

}
