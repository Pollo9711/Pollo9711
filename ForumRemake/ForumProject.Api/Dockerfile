#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["ForumProject.Api/ForumProject.Api.csproj", "ForumProject.Api/"]
COPY ["ForumProject.Dal.Context/ForumProject.Dal.Context.csproj", "ForumProject.Dal.Context/"]
COPY ["ForumProject.Dal.Repositories/ForumProject.Dal.Repositories.csproj", "ForumProject.Dal.Repositories/"]
COPY ["ForumProject.Biz.Domain/ForumProject.Biz.Domain.csproj", "ForumProject.Biz.Domain/"]
COPY ["ForumProject.Biz.Interfaces/ForumProject.Biz.Interfaces.csproj", "ForumProject.Biz.Interfaces/"]
COPY ["ForumProject.Mapper/ForumProject.Mapper.csproj", "ForumProject.Mapper/"]
COPY ["ForumProject.Biz.Services/ForumProject.Biz.Services.csproj", "ForumProject.Biz.Services/"]
RUN dotnet restore "ForumProject.Api/ForumProject.Api.csproj"
COPY . .
WORKDIR "/src/ForumProject.Api"
RUN dotnet build "ForumProject.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ForumProject.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ForumProject.Api.dll"]