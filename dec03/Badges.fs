module Badges

open System
open Rucksack

let parseGroups (groupSize: int) (input: seq<string>) = 
    input 
    |> Seq.mapi (fun idx line -> 
        let groupNumber = idx / groupSize  
        (groupNumber, line))
    |> Seq.groupBy fst 
    |> Seq.map (fun (_, group) -> 
        group 
        |> Seq.map (snd >> set))

let findBadge (group: seq<Set<char>>) = 
    let badge = 
        group 
        |> Set.intersectMany
        |> Set.toList 
        |> List.head 
    badge