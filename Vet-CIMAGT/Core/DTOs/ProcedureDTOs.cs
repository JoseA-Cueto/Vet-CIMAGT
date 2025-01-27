using System.ComponentModel.DataAnnotations.Schema;


namespace Vet_CIMAGT.Core.DTOs
{
    public class ProcedureDTOs
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public string Surgeon { get; set; }
        public string Anesthesiologist { get; set; }
        public DateTime Date { get; set; }
        public string Procedures { get; set; }
        public string Alert { get; set; }
    }
}
