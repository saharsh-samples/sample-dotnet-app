FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY out .
EXPOSE 80
ENTRYPOINT ["dotnet", "sample-dotnet-app.dll"]