open System
open System.Linq

type SystemBase = BIN | OCT | DEC | HEX

let stringToList (s:string) = s.ToList() |> Seq.map Char.ToString |> Seq.toList 

let listStringToInt n = match n with 
    | [] -> 0 
    | _ -> String.concat "" n |> Int32.Parse

//BIN <-> DEC

let rec _decToBin t n = 
    if n / 2 > 0 || n % 2 > 0
    then (_decToBin ((n%2).ToString() :: t) (n/2)) 
    else t 

let decToBin:(string list -> string list) = 
    String.concat "" 
    >> Int32.Parse 
    >> _decToBin []  

let baseToDec b (n:string list) = match n with
    | [] -> []
    | _ -> List.map2 (fun p d -> (Int32.Parse d) * (pown b p)) [0..(List.length n) - 1] (List.rev n)
        |> List.reduce (+)
        |> fun x -> x.ToString() 
        |> stringToList

let binToDec = baseToDec 2

//OCT <-> DEC

let octToDec = baseToDec 8

let rec _decToOct t n = 
    if n / 8 > 0 || n % 8 > 0
    then (_decToOct ((n%8).ToString() :: t) (n/8)) 
    else t 

let decToOct:(string list -> string list) = 
    String.concat "" 
    >> Int32.Parse
    >> _decToOct []  

//BIN <-> OCT

let rec group size fill (acc:string list list) (n:string list) = 
    if List.length n < size then (n@(List.replicate (size - (List.length n)) fill)) :: acc
    else group size fill ((List.take size n) :: acc) (List.skip size n)

let binToOctTriads = 
    List.rev
    >> group 3 "0" []
    >> List.map List.rev
    >> List.map binToDec
    >> List.concat

let octToBinTriads = List.map (stringToList >> decToBin >> String.concat "")

let test verbose (f1:string list -> string list) (f2:string list -> string list) n = 
    [ 1..n ]
    |> List.map (fun x -> x.ToString() |> stringToList)
    |> List.map f1
    |> List.map f2
    |> List.map listStringToInt
    |> List.map2 (fun a b -> (if verbose then printfn "%A" (a,b) |> ignore); b) [1..n]
    |> List.map2 (=) [1..n]
    |> List.reduce (&&)


[<EntryPoint>]
let main argv = 
    List.map (fun x -> x.ToString() |> stringToList |> decToOct |> octToBinTriads ) [1..100]
    |> printfn "%A"
    Console.ReadLine() 
    |> ignore   
    0


