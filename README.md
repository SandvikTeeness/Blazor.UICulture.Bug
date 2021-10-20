# Blazor.UICulture.Bug

Blazor server project made with template from
Microsoft Visual Studio Professional 2019
Version 16.11.5
.Net 5.0

Added basic internationalization according to description on [MSDocs Globalization](https://docs.microsoft.com/en-us/aspnet/core/blazor/globalization-localization?view=aspnetcore-5.0&pivots=server)
Added a timer and an event to the ```WeatherForecastService```

## BUG Description
When the timer is started, it will remember the UICulture that was current on startup.  Later if a razor component
is set up to use the ```WeatherForecastService.TimerTickEvent``` to trigger a page update by calling ```InvokeAsync(StateHasChanged)``` the component will 
be rendered using the timer's UICulture rather than the correct setting.

If page is rendered based on user interaction, the UICulture will change to the correct setting.

Imagine that it is not a timer, but a connection to an external device that takes some time to set up.  
We would need to disconnect and connect again to get the language setting right.
