# Início da análise no SonarQube
dotnet sonarscanner begin /k:"DubaiSmokeUsersApi" /d:sonar.login="sqp_e5048ddabe6ee243d80e386f2554e6f422c73d6c"

# Compilação do projeto .NET
dotnet build --no-incremental

# Execução dos testes com Cobertura de Código usando Coverlet
coverlet .\src\DubaiSmoke.Users.Test\bin\Debug\net6.0\DubaiSmoke.Users.Test.dll --target "dotnet" --targetargs "test --no-build" -f=opencover -o="coverage.xml"

# Fim da análise no SonarQube
dotnet sonarscanner end /d:sonar.login="sqp_e5048ddabe6ee243d80e386f2554e6f422c73d6c"

dotnet test ./src/DubaiSmoke.Users.Test/DubaiSmoke.Users.Test.csproj /p:ColectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput=Coverage/
reportgenerator "src/DubaiSmoke.Users.Test/Coverage/coverage.opencover.xml" "-targetdir:src/DubaiSmoke.Users.Test/Coverage"