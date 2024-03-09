FROM mcr.microsoft.com/dotnet/sdk:8.0

# ENV ASPNETCORE_URLS=http://+:5137
ENV ASPNETCORE_URLS=http://+:5137
ENV ASPNETCORE_HTTP_PORTS=5137

WORKDIR /var/www/aspnetcoreapp

COPY . .

EXPOSE 5137

ENTRYPOINT ["/bin/bash", "-c", "dotnet restore ./UserService.Api && dotnet run --project ./UserService.Api --urls=http://0.0.0.0:5137/"]