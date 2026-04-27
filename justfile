# Feliz.ViewEngine build commands
# Install just: https://github.com/casey/just

set dotenv-load

src_path := "src"
test_path := "test"
bulma_path := "Feliz.Bulma.ViewEngine"
bench_path := "benchmarks"

# Default recipe - show available commands
default:
    @just --list

# Clean build artifacts
clean:
    rm -rf {{src_path}}/obj {{test_path}}/obj {{bulma_path}}/obj {{bench_path}}/obj
    rm -rf {{src_path}}/bin {{test_path}}/bin {{bulma_path}}/bin {{bench_path}}/bin

# Restore all dependencies
restore:
    dotnet tool restore
    dotnet paket restore

# Build all projects
build:
    dotnet build --configuration Release

# Build benchmarks
build-bench:
    dotnet build {{bench_path}} -c Release

# Run all tests
test:
    dotnet test {{test_path}}

# Build and run tests
check: build test

# Create NuGet packages with version from CHANGELOG.md
pack:
    #!/usr/bin/env bash
    set -euo pipefail
    VERSION=$(grep -m1 '^## ' CHANGELOG.md | sed 's/^## \[\?\([^] ]*\).*/\1/')
    dotnet pack -c Release -p:PackageVersion=$VERSION -p:InformationalVersion=$VERSION

# Create NuGet packages with specific version
pack-version version:
    dotnet pack -c Release -p:PackageVersion={{version}} -p:InformationalVersion={{version}}

# Release: pack and push both packages to NuGet (used in CI)
release: pack
    dotnet nuget push '{{src_path}}/bin/Release/*.nupkg' -s https://api.nuget.org/v3/index.json -k $NUGET_KEY
    dotnet nuget push '{{bulma_path}}/bin/Release/*.nupkg' -s https://api.nuget.org/v3/index.json -k $NUGET_KEY

# Run EasyBuild.ShipIt for release management
shipit *args:
    dotnet shipit {{args}}

# Full setup and test
setup: restore build test

# Run benchmarks (all benchmark classes)
bench:
    dotnet run -c Release --project {{bench_path}} -- --filter '*'

# Run specific benchmark class (e.g., just bench-class LongPageBenchmarks)
bench-class class:
    dotnet run -c Release --project {{bench_path}} -- --filter '*{{class}}*'

# Run quick benchmarks (fewer iterations, for development)
bench-quick:
    dotnet run -c Release --project {{bench_path}} -- --filter '*' --job short
