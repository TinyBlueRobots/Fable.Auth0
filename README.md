Fable.Auth0
-

Go to [Auth0](https://auth0.com) and create a **Single Page Application** Client

Set the **Allowed Callback URLs** and **Allowed Origins (CORS)** to `http://localhost:8080`

Replace `let auth0Credentials = ("CLIENTID", "DOMAIN")` with your ClientId and Domain

Run `yarn`

Run `yarn start`

Open [http://localhost:8080](http://localhost:8080)