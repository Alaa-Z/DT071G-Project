using weatherApp.Services;
namespace WeatherApp;


public partial class MainPage : ContentPage
{
	// List of type List 
	public List<weatherApp.Models.List> WeatherList;

	// To find the latitue
    private double latitude;

	// To find the longitud
    private double longitude;


    public MainPage()
	{
		InitializeComponent();

        // initialize the list
        WeatherList = new List<weatherApp.Models.List>();
	}

	protected async override void OnAppearing()
	{
		
		base.OnAppearing();

		// Call the location function
		await getMyLocation();



        // Get The weather  based on Lund latitude and longitude
        //var resultat = await ApiServices.GetWeather(55.704659, 13.191007);

        var result = await ApiServices.GetWeather(latitude, longitude);

        
        // Get the city based on result 
        myCity.Text = result.city.name;

		// Get the weather description
        description.Text = result.list[0].weather[0].description;

		// Get the temperatur 
        temperature.Text = result.list[0].main.temperature + "°C";

		// Get the  humidity from result
		humidity.Text = result.list[0].main.humidity + "%";

		// Get the wind 
		wind.Text= result.list[0].wind.speed + "km/h";

		// Get the the imgage dynamicly 
		weatherImg.Source = result.list[0].weather[0].satndardImg;

        // Iterate through the list in the response and add the values to WeatherList
        foreach (var element in result.list)
        {
            WeatherList.Add(element);

        }

		// Show the list using the collectionView
        CollectionViewWeather.ItemsSource = WeatherList;
    }

    // Function to find the Location using the Geolocation class 
    public async Task getMyLocation()
	{
		var myLocation = await Geolocation.GetLocationAsync();

		latitude = myLocation.Latitude;

		longitude = myLocation.Longitude;
	}


}

