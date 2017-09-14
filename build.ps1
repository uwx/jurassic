dotnet restore
msbuild "C:\projects\dsp\Jurassic.sln" /verbosity:minimal /logger:"C:\Program Files\AppVeyor\BuildAgent\Appveyor.MSBuildLogger.dll"
dotnet test "Unit Tests\Unit Tests.csproj" -c Release
