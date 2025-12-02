# Feliz.ViewEngine build commands
# Install just: https://github.com/casey/just

src_path := "src"
test_path := "test"
bulma_path := "Feliz.Bulma.ViewEngine"

# Default recipe - show available commands
default:
    @just --list

# Clean build artifacts
clean:
    rm -rf {{src_path}}/obj {{test_path}}/obj {{bulma_path}}/obj
    rm -rf {{src_path}}/bin {{test_path}}/bin {{bulma_path}}/bin

# Restore all dependencies
restore:
    dotnet tool restore
    dotnet paket restore

# Build all projects
build:
    dotnet build --configuration Release

# Run all tests
test:
    dotnet test {{test_path}}

# Build and run tests
check: build test

# Create NuGet packages
pack:
    dotnet pack -c Release

# Create NuGet packages with specific version (used in CI)
pack-version version:
    dotnet pack -c Release -p:PackageVersion={{version}}

# Full setup and test
setup: restore build test
