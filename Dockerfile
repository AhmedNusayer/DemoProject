FROM mcr.microsoft.com/dotnet/sdk:3.1
COPY . /app
WORKDIR /app/DemoProject
RUN apt-get update
RUN apt-get install dos2unix
RUN dotnet tool install dotnet-ef 
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
EXPOSE 80/tcp
RUN chmod +x ./entrypoint.sh
RUN dos2unix ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh