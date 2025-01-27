using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Vet_CIMAGT.Core.DTOs
{
    public class ConsumptionDTOs
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime InitDateTime { get; set; }
        public double Total { get; set; }
        public string Product { get; set; } //Revisar
    }
}
