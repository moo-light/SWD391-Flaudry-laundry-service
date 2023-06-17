using Application.ViewModels.UserViewModels;

namespace Application.Commons
{
    public class AppConfiguration
    {
        public string DatabaseConnection { get; set; }
        public string JWTSecretKey { get; set; }
        public UserLoginDTO AdminAccount { get;  set; }
    }
}
