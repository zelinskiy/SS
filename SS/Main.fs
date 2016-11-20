module Main

open System
open Suave
open Suave.Filters
open Suave.Operators
open Suave.Successful
open Suave.Json
open Suave.Writers

open Utils
open Program

let mainFunction (b1, b2, (n:string)) =
    
    let n1 = n.Split('.') |> Seq.head |> stringToList
    let n2 = n.Split('.') |> Seq.last |> stringToList
    let r1 = ((convertFun b1 b2) n1)
    let r2 = ((convertFunRem b1 (float b2) 7) n2) 
    r1 + "." + r2


let app =
    choose[ GET >=> choose [ 
                path "/" >=> Files.file "../../index.html"
                pathScan "/convert/%d/%d/%s" (mainFunction >> OK)
                path "/hello" >=> OK "Hello!"
                Files.browseHome
                RequestErrors.NOT_FOUND "Page not found." 
    ]]



[<EntryPoint>]
let main argv = 
    startWebServer defaultConfig app
    0


//[<EntryPoint>]
//let main argv = 
//    printfn "init base"
//    let b1 = Console.ReadLine() |> Int32.Parse
//    printfn "desired base"
//    let b2 = Console.ReadLine() |> Int32.Parse
//    printfn "number"
//    let n = Console.ReadLine()
//    let n1 = n.Split('.') |> Seq.head |> stringToList
//    let n2 = n.Split('.') |> Seq.last |> stringToList
//    let r1 = ((convertFun b1 b2) n1)
//    let r2 = ((convertFunRem b1 (float b2) 7) n2) 
//    printfn "%s" (r1 + "." + r2)
//    printfn "finished"
//
//    Console.ReadLine() |> ignore   
//    0