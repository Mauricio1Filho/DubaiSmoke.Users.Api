dotnet sonarscanner begin /k:"DubaiSmokeUsersApi" /d:sonar.token="sqp_e5048ddabe6ee243d80e386f2554e6f422c73d6c" /d:sonar.language="cs" /d:sonar.cs.opencover.reportsPaths=src/DubaiSmoke.Users.Test/coverage.opencover.xml

dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover

dotnet sonarscanner end /d:sonar.token="sqp_e5048ddabe6ee243d80e386f2554e6f422c73d6c"