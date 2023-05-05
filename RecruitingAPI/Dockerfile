FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

ENV RecruitingDb="Server=192.168.1.12,1433;Database=recruiting;User Id=sa;Password=root1234%;Integrated Security=False;TrustServerCertificate=True"
EXPOSE 80

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
# RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
# USER appuser

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["RecruitingAPI/RecruitingAPI.csproj", "RecruitingAPI/"]
COPY ["/Recruiting.Infrastructure/Recruiting.Infrastructure.csproj","Recruiting.Infrastructure/"] 
COPY ["/Recruiting.ApplicationCore/Recruiting.ApplicationCore.csproj","Recruiting.ApplicationCore/"] 
RUN dotnet restore "RecruitingAPI/RecruitingAPI.csproj"
COPY . .
WORKDIR "/src/RecruitingAPI"
RUN dotnet build "RecruitingAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RecruitingAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RecruitingAPI.dll"]


