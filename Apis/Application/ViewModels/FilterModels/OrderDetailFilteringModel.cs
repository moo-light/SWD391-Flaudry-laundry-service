namespace Application.ViewModels.FilterModels
{
    public class OrderDetailFilteringModel : BaseFilterringModel
    {
        public Guid?[]? OrderId { get; set; }
        public Guid?[]? ServiceId { get; set; }
        public string?[]? Weight { get; set; }
    }
}
