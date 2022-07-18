#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat 
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base

 

 

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY Job_post.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c release -o /app

 

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Job_post.dll"]
