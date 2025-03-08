# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
# Environment variable to connect to the DB securely //Should be encrypted
#ENV BuildXpertDB="Data Source=SQL_Server,1433;Database=BuildExpertDB;Integrated Security=false;User Id=sa;Password=password12345!;TrustServerCertificate=true;"

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BX.Backend/BX.Backend.csproj", "BX.Backend/"]
COPY ["BX.Models/BX.Models.csproj", "BX.Models/"]
RUN dotnet restore "./BX.Backend/BX.Backend.csproj"
COPY . .
WORKDIR "/src/BX.Backend"
RUN dotnet build "./BX.Backend.csproj" -c $BUILD_CONFIGURATION -o /app/build

RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BX.Backend.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_Kestrel__Certificates__Default__Path="/https_cert.pfx"
ENV ASPNETCORE_Kestrel__Certificates__Default__Password="p1o2i3u4y5t6"
ENTRYPOINT ["dotnet", "BX.Backend.dll"]