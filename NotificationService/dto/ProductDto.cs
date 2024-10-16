namespace NotificationService.dto
{
    public class ProductDto
    {
        public string? descripcion { get; set; }
        public string? precio { get; set; }
        public string? descuento { get; set; }
        public string? tipoMoneda { get; set; }
        public string? filePath { get; set; }
        public int? operationStatusCode { get; set; }
        public string? domainUrl { get; set;}
    }
}
