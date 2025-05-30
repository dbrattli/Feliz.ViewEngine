#!/bin/sh

## ask for --api-key interactively 

echo "Please enter your NuGet API key:"
read -s NUGET_API_KEY
echo "Pushing package to NuGet..."

dotnet nuget push ./Feliz.ViewEngine.Jkone27.0.25.0-alpha.1.nupkg --source https://api.nuget.org/v3/index.json --api-key "$NUGET_API_KEY"