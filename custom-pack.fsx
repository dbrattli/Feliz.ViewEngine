#r "nuget: Fake.DotNet.Cli, 5.24.7"

open Fake.DotNet

let proj = "./src/Feliz.ViewEngine.fsproj"

DotNet.pack (fun packParams ->
    { packParams with
        Configuration = DotNet.BuildConfiguration.Release
        OutputPath = Some "."
        MSBuildParams = 
            { packParams.MSBuildParams with
                Properties = [
                    "PackageId", "Feliz.ViewEngine.Jkone27"
                    "Version", "0.25.0-alpha.2"
                    "Authors", "Dag Brattli, jkone27"
                    "RepositoryUrl", "https://github.com/jkone27/Feliz.ViewEngine"
                    "PackageReleaseNotes", "Preview fork with custom changes by jkone27"
                    "PackageLicenseFile", "./LICENSE"
                    "Readme", "./README.md"
                ]
            }
    })
    proj