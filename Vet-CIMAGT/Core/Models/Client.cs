namespace Vet_CIMAGT.Core.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime FEntry { get; set; }
        public string CI { get; set; }
    }
}
