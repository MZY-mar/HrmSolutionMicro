FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

ENV OnboardingDb="Server=192.168.1.12,1433;Database=onboarding;User Id=sa;Password=root1234%;Integrated Security=False;Encrypt=false;"
EXPOSE 80


# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers≈

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["OnboardingAPI/OnboardingAPI.csproj", "OnboardingAPI/"]
COPY ["/Onboarding.ApplicationCore/Onboarding.ApplicationCore.csproj","Onboarding.ApplicationCore/"]
COPY ["/Onboarding.Infrastructure/Onboarding.Infrastructure.csproj","Onboarding.Infrastructure/"] 
RUN dotnet restore "OnboardingAPI/OnboardingAPI.csproj"
COPY . .
WORKDIR "/src/OnboardingAPI"
RUN dotnet build "OnboardingAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OnboardingAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OnboardingAPI.dll"]
