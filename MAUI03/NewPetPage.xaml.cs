using MAUI03.Models;

namespace MAUI03;

public partial class NewPetPage : ContentPage
{
	public Pet NewPet { get; set; } = new();

	public NewPetPage()
	{
		InitializeComponent();
		BindingContext = this;
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		var param = new ShellNavigationQueryParameters
		{
			{"NewPet", this.NewPet }
		};
		Shell.Current.GoToAsync("..", param);
    }
}