FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/WorldStore.Microservices.IamMicroservice.Admin.Api/WorldStore.Microservices.IamMicroservice.Admin.Api.csproj", "src/WorldStore.Microservices.IamMicroservice.Admin.Api/"]
COPY ["src/WorldStore.Microservices.IamMicroservice.Admin.EntityFramework.Shared/WorldStore.Microservices.IamMicroservice.Admin.EntityFramework.Shared.csproj", "src/WorldStore.Microservices.IamMicroservice.Admin.EntityFramework.Shared/"]
COPY ["src/WorldStore.Microservices.IamMicroservice.Admin.EntityFramework.SqlServer/WorldStore.Microservices.IamMicroservice.Admin.EntityFramework.SqlServer.csproj", "src/WorldStore.Microservices.IamMicroservice.Admin.EntityFramework.SqlServer/"]
COPY ["src/WorldStore.Microservices.IamMicroservice.Admin.EntityFramework.PostgreSQL/WorldStore.Microservices.IamMicroservice.Admin.EntityFramework.PostgreSQL.csproj", "src/WorldStore.Microservices.IamMicroservice.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/WorldStore.Microservices.IamMicroservice.Admin.EntityFramework.MySql/WorldStore.Microservices.IamMicroservice.Admin.EntityFramework.MySql.csproj", "src/WorldStore.Microservices.IamMicroservice.Admin.EntityFramework.MySql/"]
RUN dotnet restore "src/WorldStore.Microservices.IamMicroservice.Admin.Api/WorldStore.Microservices.IamMicroservice.Admin.Api.csproj"
COPY . .
WORKDIR "/src/src/WorldStore.Microservices.IamMicroservice.Admin.Api"
RUN dotnet build "WorldStore.Microservices.IamMicroservice.Admin.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WorldStore.Microservices.IamMicroservice.Admin.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "WorldStore.Microservices.IamMicroservice.Admin.Api.dll"]