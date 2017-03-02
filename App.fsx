#load "References.fsx"

open Fable.Arch
open Fable.Arch.App
open Fable.Arch.Html
open Fable.PowerPack
open Auth0

let auth0Credentials = ("CLIENTID", "DOMAIN")

let lock = Auth0Lock.Create auth0Credentials

type Actions =
  | Login
  | Authenticated of IAuthResult
  | SetUserProfile of IAuth0UserProfile

type Model = { Email: string; Picture: string; Name: string }

let initialModel = { Email = ""; Picture = ""; Name = "" }

let getUserProfile (authResult: IAuthResult) push =
  lock.getProfile (authResult.idToken, fun auth0Error userProfile -> SetUserProfile userProfile |> push)

let onAuthenticated push =
  lock.on_authenticated (fun authResult -> Authenticated authResult |> push)

let update model action =
  match action with
  | Login ->
    lock.show()
    model, []
  | Authenticated authResult ->
    model, [ getUserProfile authResult ]
  | SetUserProfile userProfile ->
    { model with Email = userProfile.email; Name = userProfile.name; Picture = userProfile.picture }, []

let view model =
  match model.Email with
    | "" -> [ button [ onMouseClick (fun _ -> Login) ] [ text "Login" ] ]
    | _ ->
      [
       div [] [ img [ property "src" model.Picture ] ]
       div [] [ text model.Name ]
       div [] [ text model.Email ]
      ]
  |> (div [])

createApp initialModel view update Virtualdom.createRender
|> withStartNodeSelector "#app"
|> withProducer onAuthenticated
|> start