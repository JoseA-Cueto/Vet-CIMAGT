namespace Vet_CIMAGT.Core.DTOs
{
    public class PatientDTOs
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public string Gender { get; set; }
        public bool IsNeutered { get; set; }
        public DateTime Birth { get; set; }
    }
}
