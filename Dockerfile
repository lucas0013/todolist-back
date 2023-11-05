#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ToDoList.API/ToDoList.API.csproj", "ToDoList.API/"]
COPY ["ToDoList.CrossCutting/ToDoList.CrossCutting.csproj", "ToDoList.CrossCutting/"]
COPY ["ToDoList.Application/ToDoList.Application.csproj", "ToDoList.Application/"]
COPY ["ToDoList.Domain/ToDoList.Domain.csproj", "ToDoList.Domain/"]
COPY ["ToDoList.Infrastructure/ToDoList.Infrastructure.csproj", "ToDoList.Infrastructure/"]
RUN dotnet restore "ToDoList.API/ToDoList.API.csproj"
COPY . .
WORKDIR "/src/ToDoList.API"
RUN dotnet build "ToDoList.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToDoList.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToDoList.API.dll"]