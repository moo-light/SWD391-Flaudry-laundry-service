namespace Application.Interfaces
{
    public interface IClaimsService
    {
        public Guid GetCurrentUserId { get; }
        public string GetCurrentUserRole { get; }
    }
}
