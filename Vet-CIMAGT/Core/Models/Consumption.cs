using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vet_CIMAGT.Core.Models
{
    public class Consumption
    {
        public Guid Id { get; set; }
        [Required]
        public Guid PatientId { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; init; }
        public DateTime DateTime { get; set; }
        public DateTime InitDateTime { get; set; }
        public double Total { get; set; }
        public string Product { get; set; } //Revisar

    }
}
