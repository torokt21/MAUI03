

using MAUI03.Models;

namespace MAUI03;

[QueryProperty(nameof(ThePet), "Pet")]
public partial class PetDetailsPage : ContentPage
{

	private Pet pet;

	public Pet ThePet
	{
		get { return pet; }
		set { pet = value; OnPropertyChanged(); }
	}

	public PetDetailsPage()
	{
		InitializeComponent();
		// Lusták vagyunk saját VM-et csinálni ennek az oldalnak, szóval ezt az osztályt használjuk inkább
		this.BindingContext = this;
	}
}