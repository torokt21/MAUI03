using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAUI03.Models;
using CommunityToolkit.Mvvm.Input;
using System.Xml.Linq;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MAUI03.ViewModels
{
    [QueryProperty(nameof(NewPet), "NewPet")]
    public partial class MainPageViewModel : ObservableObject
    {
        public ObservableCollection<Pet> Pets { get; set; }

        public Pet NewPet {  
            set
            {
                this.Pets.Add(value);
            }
        }
        [ObservableProperty]
        Pet selectedPet;

        public MainPageViewModel()
        {
            Pets = new ObservableCollection<Pet>()
            {
                new Pet()
                {
                    Name = "Guba",
                    Species = "Dog",
                    BirthDate = DateTime.Now.Subtract(new TimeSpan(10, 0, 0, 0)),
                },
                new Pet()
                {
                    Name = "Sodó",
                    Species = "Dog",
                    BirthDate = DateTime.Now.Subtract(new TimeSpan(300, 0, 0, 0)),
                },
                new Pet()
                {
                    Name = "Geronimo",
                    Species = "Sloth",
                    BirthDate = DateTime.Now.Subtract(new TimeSpan(300, 0, 0, 0)),
                }
            };
        }

        [RelayCommand]
        public async Task DetailsAsync()
        {
            if (SelectedPet != null)
            {
                // Paraméter átadása
                var param = new ShellNavigationQueryParameters
                {
                    { "Pet", SelectedPet }
                };
                await Shell.Current.GoToAsync("PetDetails", param);
            }
            
        }

        [RelayCommand]
        public async Task NewPetAsync()
        {
            await Shell.Current.GoToAsync("NewPet");
        }
    }
}
