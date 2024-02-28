namespace MAUI03
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("PetDetails", typeof(PetDetailsPage));
        }
    }
}
