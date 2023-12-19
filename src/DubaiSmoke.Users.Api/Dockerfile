# Build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /build

RUN dotnet nuget add source http://dubaismoke.corp.com:4000/v3/index.json -n NugetServer

COPY . /build
RUN dotnet restore
RUN dotnet publish src/DubaiSmoke.Users.Api/DubaiSmoke.Users.Api.csproj -c RELEASE --self-contained  -r linux-x64 -o src/out

# Runtime stage
FROM mcr.microsoft.com/dotnet/runtime:6.0

RUN sed -i 's/CipherString = DEFAULT@SECLEVEL=2/CipherString = DEFAULT@SECLEVEL=1/' /etc/ssl/openssl.cnf

WORKDIR /build
COPY --from=build /build/src/out ./

# Adiciona o script de inicialização
COPY entrypoint.sh /app/entrypoint.sh
RUN chmod +x /app/entrypoint.sh

ARG ASPNETCORE_ENVIRONMENT
ENV ASPNETCORE_ENVIRONMENT=$ASPNETCORE_ENVIRONMENT
EXPOSE 80

# Define o comando de inicialização
ENTRYPOINT ["/app/entrypoint.sh"]

CMD ["dotnet", "DubaiSmoke.Users.Api.dll"]
