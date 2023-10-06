# dotnet-weather-console
dotnet app that will get the current weather from an api.  One you kick this off with a latitude and longitude it will make several calls to the public weather api at [OpenWeather](https://openweathermap.org/). It will take a few mins to simulate a longer running process and output the results to the console out.

## Running the app

To run the app do the following:
1) Clone the repo
2) Run `dotnet build`
3) Navigate the the bin folder where the output is and run `dotnet WeatherApp.dll <latitude> <longitude`
