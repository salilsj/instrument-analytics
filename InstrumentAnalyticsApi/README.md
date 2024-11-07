# Info 

This api has been built in VS Code on Mac. Uses .net 8.0
There is no Auth implemented and is intended to run locally

External Dependancy: 
The API depends upon below external endpoints: 

- https://mocki.io/v1/5c913cd3-77b2-43b7-9c74-0982e6174298
- https://mocki.io/v1/11ab88f0-0a9a-44ad-ac40-334005fc5117
- https://mocki.io/v1/1cf057a5-e4c7-4cd3-9701-fbf29d379a39

## Considerations

Below additions are required but not implemented as this is just a simple task - 
- Unit Tests 
- Integration Tests
- Authentication & Authorisation 
- Logging & Error handling
- Docker Compose to create services so that web app and API both can be run using a single command in an isolated environment 

### CORS

Cors is enabled only for http://localhost:3000. If the Web App is running on another URl, the API will reject the request. URL needs to be amended on Program.cs 


## Run The APIs

In the project directory, run below command in the integrated terminal: 

dotnet run
