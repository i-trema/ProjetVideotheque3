using ProjetVideotheque3.Services;
using Xamarin.Forms;
using Microsoft.EntityFrameworkCore;


namespace ProjetVideotheque3
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            var dbContext = new VideothequeDbContext();
            dbContext.Database.Migrate();
            DependencyService.RegisterSingleton(dbContext);

            
            DependencyService.Register<FilmsDataStore>();
            DependencyService.Register<RestService>();
            DependencyService.Register<ImagesDataStore>();
            //DependencyService.Register<PersonnesDataStore>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
