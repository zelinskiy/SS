module Program
open System
open System.Linq
open Utils

//BASE <-> DEC

let symbols = ["0";"1";"2";"3";"4";"5";"6";"7";"8";"9";
                "A";"B";"C";"D";"E";"F"]

let baseToDec b (n:string list) = match n with
    | [] -> []
    | _ -> List.map2 (fun p d -> (Seq.findIndex ((=) d) symbols) * (pown b p)) [0..(List.length n) - 1] (List.rev n)
        |> List.reduce (+)
        |> fun x -> x.ToString() 
        |> stringToList

let rec  _decToBase b t n = 
    if n / b > 0 || n % b > 0
    then (_decToBase b (symbols.[n % b] :: t) (n/b)) 
    else t 

let decToBase b (n:string list) = _decToBase b [] (listStringToInt n)

//REMAINDER BASE <-> DEC

let remBaseToDec (b:int) (n:string list) = match n with
    | [] -> 0.0
    | _ -> List.map2 (fun p d -> (float (Seq.findIndex ((=) d) symbols)) *  ((float b) ** (float (p * (-1))))) [1 .. (List.length n)] n
        |> List.reduce (+)


let rec _decToBaseRem (t:string list) (b:float) (r:int) (n:float)  = 
    let x = n * b
    let top = symbols.[Math.Floor x |> int]
    if r = 0 then List.rev t
    else (_decToBaseRem (top :: t) b (r - 1) (x % 1.0) )

let decToBaseRem = _decToBaseRem []

let test verbose (f1:string list -> string list) (f2:string list -> string list) n = 
    [ 1..n ]
    |> List.map intToStringList
    |> List.map f1
    |> List.map f2
    |> List.map listStringToInt
    |> List.map2 (fun a b -> (if verbose then printfn "%A" (a,b) |> ignore); b) [1..n]
    |> List.map2 (=) [1..n]
    |> List.reduce (&&)

let convertFun a b = (baseToDec a) >> (decToBase b) >> String.concat ""

let convertFunRem a b r = (remBaseToDec a) >> (decToBaseRem b r) >> String.concat ""



