# Shared.ErrorLogger
Shared Error Logger. This library will log errors to table `ErrorsLog`.

## Usage
In `Startup.cs` file, use the following code snippet.
```cs
public class Startup
{
    private readonly IConfiguration _config;

    public Startup(IConfiguration config)
    {
        _config = config;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.RegisterErrorLogServices(config);
    }
}
```

Then add the following to the configuration file `appsettings.YOUR ENV.json`
```json
"ErrorsLogging": {
    "ConnectionString": "https://URL"
}
```
