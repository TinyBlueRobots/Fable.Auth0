#load "References.fsx"

open Fable.Core
open Fable.Core.JsInterop
open System

type IAuth0Error =
  abstract member error: obj with get, set
  abstract member errorDescription: string with get, set

type IAuth0UserProfile =
  abstract member email: string with get, set
  abstract member name: string with get, set
  abstract member picture: string with get, set

type IAuthResult =
  abstract idToken: string with get, set

type IAuth0Lock =
  [<Emit"new $0($1...)">]
  abstract Create: clientId: string * domain: string -> IAuth0Lock

  abstract show: unit -> unit

  [<Emit("$0.on('authenticated',$1...)")>]
  abstract on_authenticated: callback: Func<IAuthResult, unit> -> unit

  abstract getProfile: token: string * callback: Func<IAuth0Error, IAuth0UserProfile, unit> -> unit

let Auth0Lock: IAuth0Lock = importDefault "auth0-lock"