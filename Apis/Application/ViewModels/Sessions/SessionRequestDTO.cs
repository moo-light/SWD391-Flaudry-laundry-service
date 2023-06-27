namespace Application.ViewModels.Sessions
{
    public class SessionRequestDTO
    {
        public Guid? BatchId { get; set; }
        public Guid? BuildingId { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? StartTime { get; set; }
    }
}