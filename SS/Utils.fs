module Utils
open System
open System.Linq

let stringToList (s:string) = s.ToList() |> Seq.map Char.ToString |> Seq.toList 

let listStringToInt n = match n with 
    | [] -> 0 
    | _ -> String.concat "" n |> Int32.Parse

let intToStringList n =  n.ToString() |> stringToList