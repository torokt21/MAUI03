

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
		// Lust�k vagyunk saj�t VM-et csin�lni ennek az oldalnak, sz�val ezt az oszt�lyt haszn�ljuk ink�bb
		this.BindingContext = this;
	}
}