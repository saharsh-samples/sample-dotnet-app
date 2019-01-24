# Sample .NET Application

## Description

This is a very basic ASP.NET 2.2 WebAPI project. It creates an example RESTful API with the following endpoints:

- `GET /api/values`
- `POST /api/values` (accepts a JSON string in request body)
- `GET /api/values/{id}`
- `PUT /api/values/{id}` (accepts a JSON string in request body)
- `DELETE /api/values/{id}`

The intention here is provide a repo that can be forked to quickly get a simple ASP.NET 2.2 app running for whatever purpose.

## Build

### .NET binaries

        dotnet publish -c Release -o out

### Container Image

        docker build -t sample-dotnet-app .

## Run

Once built, the container can be started using a command like below.

        docker run -d -p 8080:80 \
                -v $PWD/config/appusers.json:/app/config/appusers.json \
                -e VALUES_SERVICE_TYPE="simple" \
                --name sample-dotnet-app sample-dotnet-app

Things to note:

- `-v $PWD/config/appusers.json:/app/config/appusers.json`: This mounts the configuration file containing authorized users into the container instance. One of these users must be specified using Basic Authentication on each API request. If not provided, the app becomes unusable as all requests will return a `401 UNAUTHORIZED`.

- `-e VALUES_SERVICE_TYPE="simple"`: To play around with polymorphism and dependency injection, two implementations of the underlying service that manages values storage have been provided. Use this environment variable to pick between them. Available choices are `simple` and `default`. As expected, if not specified, the `default` implementation is used.

## Consume

Following is an example flow to use the web service. The user information is contained in the [config/appusers.json](config/appusers.json) file.

- Create a value

        curl -i -X POST \
                -H "Authorization: saharsh:password" \
                -H "Content-Type: application/json" \
                -d '"My Original Value"' \
                localhost:8080/api/values

- Fetch all stored values

        curl -i localhost:8080/api/values \
                -H "Authorization: saharsh:password"

- Change value

        curl -i -X PUT \
                -H "Authorization: saharsh:password" \
                -H "Content-Type: application/json" \
                -d '"My Changed Value"' \
                localhost:8080/api/values/1

- Fetch value by ID

        curl -i localhost:8080/api/values/1 \
                -H "Authorization: saharsh:password"

- Delete value by ID

        curl -i -X DELETE \
                -H "Authorization: saharsh:password" \
                localhost:8080/api/values/1
                
