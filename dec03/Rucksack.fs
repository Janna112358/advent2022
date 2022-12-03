module Rucksack 

open System

let tryParseLine (s: string) = 
    match s with 
    | "" -> None 
    | something -> 
        let fullSize = String.length something 
        let compSize = fullSize / 2
        let compOne = something.[0..compSize-1]
        let compTwo = something.[compSize..fullSize]
        Some (compOne, compTwo)

let hasChar (s: string) (c: char) =
    match s.IndexOf(c) with 
    | -1 -> false 
    | index -> 
        true 

let findCommon (compOne, compTwo) = 
    compOne 
    |> String.filter (hasChar compTwo)
    |> (fun s -> s.[0])

let scoreChar (c: char) =
    let i = c |> int 
    match Char.IsLower(c) with 
    | true -> (i - 96) 
    | false -> (i - 38)
    
    