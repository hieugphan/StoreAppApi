#.NET 5 SDK (heavy) use only for build
FROM mcr.microsoft.com/dotnet/sdk:5.0 as build

#Set up workdir
WORKDIR /app

#Copy all projects to make the application works
COPY *.sln ./
COPY BL/*.csproj BL/
COPY DL/*.csproj DL/
COPY Models/*.csproj Models/
COPY WebAPI/*.csproj WebAPI/

#Restore dependencies
RUN cd WebAPI && dotnet restore

COPY . ./

#Create the publish folder to be deployed
RUN dotnet publish WebAPI -c Release -o publish --no-restore

#-------------------------------------------------------------------------------------------
#Set environment to ASP.NET CORE Runtime (light-weight)
FROM mcr.microsoft.com/dotnet/aspnet:5.0 as runtime

WORKDIR /app

COPY --from=build /app/publish ./

#CMD to set WebAPI.dll (assembly) to be the default entry point
CMD [ "dotnet", "WebAPI.dll" ]

#Expose to port 80
EXPOSE 80