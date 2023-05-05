#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
ENV InterviewDB="Server=192.168.1.12,1433;Database=interviewApi;User Id=sa;Password=root1234%;Integrated Security=False;TrustServerCertificate=True"

EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["interviewWebApi/interviewWebApi.csproj", "interviewWebApi/"]
COPY ["Interview.Infrastructure/Interview.Infrastructure.csproj", "Interview.Infrastructure/"]
COPY ["Interview.ApplicationCore/Interview.ApplicationCore.csproj", "Interview.ApplicationCore/"]
RUN dotnet restore "interviewWebApi/interviewWebApi.csproj"
COPY . .
WORKDIR "/src/interviewWebApi"
RUN dotnet build "interviewWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "interviewWebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "interviewWebApi.dll"]
