module Useless
//open Utils
//open Program
//open System
//
////BIN <-> DEC
//
//let rec _decToBin t n = 
//    if n / 2 > 0 || n % 2 > 0
//    then (_decToBin ((n%2).ToString() :: t) (n/2)) 
//    else t 
//
//let decToBin:(string list -> string list) = 
//    String.concat "" 
//    >> Int32.Parse 
//    >> _decToBin []  
//    
//let binToDec = baseToDec 2
//
////OCT <-> DEC
//
//let octToDec = baseToDec 8
//
//let rec _decToOct t n = 
//    if n / 8 > 0 || n % 8 > 0
//    then (_decToOct ((n%8).ToString() :: t) (n/8)) 
//    else t 
//
//let decToOct:(string list -> string list) = 
//    String.concat "" 
//    >> Int32.Parse
//    >> _decToOct []  
//
////BIN <-> OCT
//
//let rec group size fill (acc:string list list) (n:string list) = 
//    if List.length n < size then (n@(List.replicate (size - (List.length n)) fill)) :: acc
//    else group size fill ((List.take size n) :: acc) (List.skip size n)
//
//let binToOctTriads = 
//    List.rev
//    >> group 3 "0" []
//    >> List.map List.rev
//    >> List.map binToDec
//    >> List.concat
//
//let octToBinTriads = List.map (stringToList >> decToBin >> String.concat "")
