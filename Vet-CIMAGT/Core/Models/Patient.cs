using static System.Net.Mime.MediaTypeNames;

namespace Vet_CIMAGT.Core.Models
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public string Gender { get; set; }
        public bool IsNeutered { get; set; }
        public DateTime Birth { get; set; }
        public virtual ICollection<Consumption> Consumptions { get; set; }
        public virtual ICollection<Procedure> Procedures { get; set; }


    }
}
