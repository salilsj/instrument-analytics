

## `App Config`

In appConfig.ts, replace (http://localhost:5037/api/) with the locally running version of the c# API.

apiBaseUrl: process.env.REACT_APP_API_BASE_URL || "http://localhost:5037/api/",
  

## Available Scripts

In the project directory, you can run:

### `npm start`

Runs the app in the development mode.\
Open [http://localhost:3000](http://localhost:3000) to view it in the browser.

The page will reload if you make edits.\
You will also see any lint errors in the console.

### `npm test`

Launches the test runner in the interactive watch mode.

### `npm run build`

Builds the app for production to the `build` folder.\
It bundles React in production mode and optimizes the build for the best performance.

The build is minified and the filenames include the hashes.

### `Local Prod style Build`

  npm run build

Install a local static web server
  npm install -g serve

Serve the built package

  serve -s build


## Considerations

Below additions are required but not implemented as this is just a simple task - 
- Unit Tests 
- Integration Tests
- Routing
- Authentication & Authorisation 
- Logging & Error handling
- Docker Compose to create services so that web app and API both can be run using a single command in an isolated environment 

