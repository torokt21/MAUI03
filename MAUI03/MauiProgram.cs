using MAUI03.ViewModels;
using Microsoft.Extensions.Logging;

/**
 * Mai téma az ablakok közötti váltás (kifejezetten mobilra irányulva)
 * 
 * Kisállatok kezelése a program célja
 * Main page kialakítása:
 *  - COllectionView
 *      - Benne állatkák (kijelölhetően)
 *  - Gomb: Details
 *  - Gomb: New
 *  
 *  Net nem lesz ZH-n segédanyag lesz
 *  
 *  Az AppShell-ben kell megadni, hogy hogyan viszonyulnak egymáshoz az oldalak
 *  
 *  
 *  Új oldal hozzáadása: Projektben új item > Maui > Maui Content Page (Xaml)
 *  Új oldal hozzáadásakor hozzá kell adni az AppShell-hez is
 *  
 *  AppSheel.xaml-ben át lehet állítani a FlyoutBehavoiourt "FlyOut"ra, és akkor megjelenik egy hamburger menü a bal felső sarokban
 *  (locked = a menü mindig nyitva van)
 *  
 *  <TabBar></TabBar>-ba rakva felül jelenik meg egy Tab menü (a FlyOut-ból kikerül)
 *  
 *  Ha FlyOutItem-be rakjuk, akkor az lesz a "Fő menü", azon belül automatikusan minden item az a TabBarba kerül (nem is kell létrehozni)
 *  
 *  A FlyOut itemet ki lehet dekorálni (nem néztük meg)
 *  - Header
 *  - Menu itemekkel (nem oldalt nyit meg, hanem Commandot futtat le)
 *  - Footer
 *  
 *  Routing:
 *  - A flyout itemhez lehet Route-ot megadni, pld "Main"
 *  - Azon belül vannak az oldalak saját routtal, pld "FoodPage"
 *  ---> Navigációnál a FoodPage úgy érhető el, hogy "Main/FoodPage" (Shell.Current.GoToAsync("Main/FoodPage");
 *  
 *  Csináljuk meg, hogy pet kiválasztása után a details gombra kattintva bejöjjön a details
 *  - Viszont nem akarjuk, hogy ez az oldal megjelenjen!
 *  - Ezt az AppShell.xaml.cs-ben lehet regisztrálni anélkül, hogy megjelenjen a menüben
 *  - Ezután a DetailsCommand-ban meghívjuk, hogy Shell.Current.GoToAsync("PetDetails")
 *  - Ahhoz hogy átadjuk a selectedPet-et, akkor a Commandba:
 *              var param = new ShellNavigationQueryParameters
                {
                    { "Pet", SelectedPet }
                };

 *    A PetDetailsPage-be attribútum
 *      [QueryProperty(nameof(Pet), "Pet")]
 *                                     ^ Az a név amivel átadtuk neki
 *                                     
 *  Vmiért nekem nem működik
 *      
 *      
 *  
 *  
 *  Shell.Current.GoToAsync("..") // <--- visszamegy az előző oldalra
 */

namespace MAUI03
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddSingleton<MainPage>();
            return builder.Build();
        }
    }
}
