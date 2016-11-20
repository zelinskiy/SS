module Main
open System
open Utils
open Program



[<EntryPoint>]
let main argv = 
    printfn "init base"
    let b1 = Console.ReadLine() |> Int32.Parse
    printfn "desired base"
    let b2 = Console.ReadLine() |> Int32.Parse
    printfn "number"
    let n = Console.ReadLine()
    let n1 = n.Split('.') |> Seq.head |> stringToList
    let n2 = n.Split('.') |> Seq.last |> stringToList
    let r1 = ((convertFun b1 b2) n1)
    let r2 = ((convertFunRem b1 (float b2) 7) n2) 
    printfn "%s" (r1 + "." + r2)
    printfn "finished"

    Console.ReadLine() |> ignore   
    0