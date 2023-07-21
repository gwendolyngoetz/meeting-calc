# meeting-calc

This is a couldn't sleep so lets hack something silly together in a few hours thing.

## Pre-reqs

- Use dotnet 7.0.100.
- Create Azure AD app registration 
- Use settings:
  - ![image](https://github.com/gwendolyngoetz/meeting-calc/assets/195162/42e7e8d8-d8ef-413e-9701-4b484c3cb2c5)
- [Export wage data CSV from open data](https://data.seattle.gov/City-Business/City-of-Seattle-Wage-Data/2khk-5ukd)

## Run

Set values in Config.cs for Azure AD environment.

```
cd MeetingCalc
dotnet restore
dotnet build
dotnet run
```

## Example Output

```
Adele Vance	$61.50
Alex Wilber	$71.89
Joni Sherman	$61.16
Diego Siciliani	$61.29
Patti Fernandez	$73.20
Lynne Robbins	$19.09

Meeting 2 (135) Estimated meeting cost: $783.29

-----------------------------------------------
Adele Vance	$61.50
Grady Archie	$63.50
Diego Siciliani	$61.29
Nestor Wilke	$77.84

Meeting 1 (60) Estimated meeting cost: $264.13
```

## Notes

- Matching on DisplayName is fragile if your environment doesn't have a consistent naming format.
- Only pulls defaults for meetings for the specified user in the Config.cs.
