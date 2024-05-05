# Derleme a�amas� i�in SDK imaj�n� kullan
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Proje dosyalar�n� kopyala
COPY ./WebAPI/WebAPI.csproj ./WebAPI/
COPY ./Entities/Entities.csproj ./Entities/
COPY ./Infrastructure/Infrastructure.csproj ./Infrastructure/
RUN dotnet restore ./WebAPI/WebAPI.csproj

# Kaynak kodunu kopyala
COPY ./WebAPI/ ./WebAPI/
COPY ./Entities/ ./Entities/
COPY ./Infrastructure/ ./Infrastructure/

# Uygulamay� derle ve yay�nla
RUN dotnet publish ./WebAPI/WebAPI.csproj -c Release -o out

# �al��ma a�amas� i�in runtime imaj�n� kullan
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# �evresel de�i�kenleri tan�mla
ENV ConnectionStrings__sqlConnection="Server=sqlserver;initial Catalog=MovieApiDb;User Id=sa;Password=YourSecurePassword;TrustServerCertificate=true;"

ENTRYPOINT ["dotnet", "WebAPI.dll"]
