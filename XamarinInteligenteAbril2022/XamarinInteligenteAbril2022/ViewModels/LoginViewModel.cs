using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinInteligenteAbril2022.AppBase.Objects;
using XamarinInteligenteAbril2022.Views;

namespace XamarinInteligenteAbril2022.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            Title = AppBase.Constants.Titles.LOGINPAGE;
            Subtitle = AppBase.Constants.Subtitles.LOGINPAGE;
            PageId = AppBase.Constants.PageIds.LOGINPAGE;

            SignupCommand = new(async () => await SignupAsync());

#if DEBUG
            UserName = "Oscarzx";
            Password = "123";
#endif
        }

        public Command SignupCommand { get; set; }

        private string userName;

        public string UserName
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }

        private string password;
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        async Task SignupAsync() => await Application.Current.MainPage.Navigation.PushAsync(new NavigationPage(new SignupPage()));
    }
}
