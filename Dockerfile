# FROM mcr.microsoft.com/dotnet/aspnet:8.0 as base
# USER app
# WORKDIR /app
# EXPOSE 8080
# EXPOSE 8081

# FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# ARG BUILD_CONFIGURATION=Release
# WORKDIR /src
# COPY ["MinimalAPI.csproj", "MinimalAPI/"] 
# RUN dotnet restore "./MinimalAPI/./MinimalAPI.csproj"
# COPY . .
# WORKDIR "/src/MinimalAPI"
# RUN dotnet build "./MinimalAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

# FROM build
# ARG BUILD_CONFIGURATION=Release
# RUN dotnet publish "./MinimalAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# FROM base as Final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT [ "dotnet", "MinimalAPI.dll" ]



# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the project file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application code
COPY . ./
RUN dotnet publish  -c Release -o out

# Use the official .NET runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
COPY --from=build /app/out .

# Specify the entry point for the application
ENTRYPOINT ["dotnet", "MinimalAPI.dll"]
