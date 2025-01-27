using System.ComponentModel.DataAnnotations.Schema;

namespace Vet_CIMAGT.Core.Models
{
    public class Procedure
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; init; }
        public string Surgeon { get; set; }
        public string Anesthesiologist { get; set; }
        public DateTime Date { get; set; }
        public string Procedures { get; set; }
        public string Alert { get; set; }

    }
}
