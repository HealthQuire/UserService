FROM mcr.microsoft.com/dotnet/sdk:8.0

# ENV ASPNETCORE_URLS=http://+:5137
ENV ASPNETCORE_URLS=http://+:5137
ENV ASPNETCORE_HTTP_PORTS=5137

WORKDIR /var/www/aspnetcoreapp

COPY . .

EXPOSE 5137

# RUN ["dotnet", "restore"]
# RUN ["dotnet", "run", "--project", "./UserService.Api"]

# RUN ["dotnet", "restore"]

# ENTRYPOINT [ "/bin/bash/User", "-c", "dotnet run --project ./UserService.Api" ]

ENTRYPOINT ["/bin/bash", "-c", "dotnet restore ./UserService.Api && dotnet run --project ./UserService.Api"]

# Note that this is only for demo and is intended to keep things simple. 
# A multi-stage dockerfile would normally be used here to build the .dll and use
# the mcr.microsoft.com/dotnet/core/aspnet image for the final image

# Legacy linking commands. While these work, they aren't the preferred way now.
# Instead, use networks (see the docker-compose.yml file for an example).

# docker build -f aspnetcore.dockerfile -t danwahlin/aspnetcore .
# docker run -d --name my-postgres -e POSTGRES_PASSWORD=password postgres
# docker run -d -p 5000:5000 --link my-postgres:postgres danwahlin/aspnetcore