# Используем официальный .NET SDK для сборки
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Копируем csproj и восстанавливаем зависимости
COPY Survey.ServiceDefaults/Survey.ServiceDefaults.csproj Survey.ServiceDefaults/
COPY Survey.EntityFramework/Survey.EntityFramework.csproj Survey.EntityFramework/
COPY Survey.Api/Survey.Api.csproj Survey.Api/
RUN dotnet restore Survey.Api/Survey.Api.csproj

# Копируем остальные файлы и публикуем приложение
COPY Survey.ServiceDefaults/ Survey.ServiceDefaults/
COPY Survey.EntityFramework/ Survey.EntityFramework/
COPY Survey.Api/ Survey.Api/
WORKDIR /app/Survey.Api
RUN dotnet publish -c Release -o out

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/Survey.Api/out ./
EXPOSE 80
ENTRYPOINT ["dotnet", "Survey.Api.dll"] 