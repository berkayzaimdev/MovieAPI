# Derleme aþamasý için SDK imajýný kullan
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Proje dosyalarýný kopyala
COPY ./WebAPI/WebAPI.csproj ./WebAPI/
COPY ./Entities/Entities.csproj ./Entities/
COPY ./Infrastructure/Infrastructure.csproj ./Infrastructure/
RUN dotnet restore ./WebAPI/WebAPI.csproj

# Kaynak kodunu kopyala
COPY ./WebAPI/ ./WebAPI/
COPY ./Entities/ ./Entities/
COPY ./Infrastructure/ ./Infrastructure/

# Uygulamayý derle ve yayýnla
RUN dotnet publish ./WebAPI/WebAPI.csproj -c Release -o out

# Çalýþma aþamasý için runtime imajýný kullan
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Çevresel deðiþkenleri tanýmla
ENV ConnectionStrings__sqlConnection="Server=sqlserver;initial Catalog=MovieApiDb;User Id=sa;Password=YourSecurePassword123-;TrustServerCertificate=true;"

ENTRYPOINT ["dotnet", "WebAPI.dll"]
