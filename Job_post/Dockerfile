#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat 

FROM microsoft/dotnet-framework:4.7.2-sdk-windowsservercore-1803 AS build
WORKDIR /app

 

# copy csproj and restore as distinct layers
COPY *.sln .
COPY Job_post/*.csproj ./Job_post/
COPY Job_post/*.config ./Job_post/
RUN nuget restore

 

# copy everything else and build app
COPY Job_post/. ./Job_post/
WORKDIR /app/Job_post
RUN msbuild /p:Configuration=Release

 


FROM microsoft/aspnet:4.7.2-windowsservercore-1803 AS runtime
WORKDIR /inetpub/wwwroot
COPY --from=build /app/Job_post/. ./