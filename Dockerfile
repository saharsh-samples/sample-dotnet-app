FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
COPY out .
EXPOSE 80
ENTRYPOINT ["dotnet", "sample-dotnet-app.dll"]