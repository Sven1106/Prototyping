dotnet publish -f netcoreapp2.2 ConsoleApp.csproj -c Release
docker build --tag shaddyd/puppeteersharp .
pause