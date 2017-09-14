# Restore NuGet packages
dotnet restore -v Minimal
# Build
dotnet build Jurassic.sln -v Minimal -c Release --version-suffix "$VERSION"
# Package
dotnet pack Jurassic.sln -v Minimal -c Release -o "$dir" --no-build --version-suffix "$VERSION"
