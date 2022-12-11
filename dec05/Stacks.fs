module Stacks 

open System 
open System.Text.RegularExpressions

type Crate = Crate of char 
type Supplies = Map<int, Crate list>

let getCode (supplies: Supplies) = 
    supplies 
    |> Map.map (fun key stack -> 
        stack 
        |> List.rev 
        |> List.head 
        |> function 
        | Crate c -> c |> string
    )
    |> Map.values
    |> Seq.fold (fun code letter -> code + letter) ""

type Move = {
    From: int 
    To: int 
    Number: int
}

let applyMove (supplies: Supplies) (move: Move) = 
    let sourceStack = 
        supplies 
        |> Map.find move.From
    let newSourceStack, cratesToMove = 
        sourceStack
        |> List.splitAt (List.length sourceStack - move.Number)
    let newTargetStack = 
        cratesToMove 
        |> List.rev 
        |> List.append (supplies |> Map.find move.To)
    
    supplies 
    |> Map.add move.From newSourceStack 
    |> Map.add move.To newTargetStack

let parseSupplies (rawSupplies: list<string list>) = 
    rawSupplies 
    |> List.mapi (fun idx c -> (idx + 1), c)
    |> Map.ofList 
    |> Map.map (fun key rawCrates -> 
        rawCrates 
        |> List.map (char >> Crate))

let testSupplies = 
    [
        [ "Z"; "N" ]
        [ "M"; "C"; "D" ]
        [ "P" ] 
    ]
    |> parseSupplies

let inputSupplies = 
    [
        [ "V"; "C"; "D"; "R"; "Z"; "G"; "B"; "W" ]
        [ "G"; "W"; "F"; "C"; "B"; "S"; "T"; "V" ]
        [ "C"; "B"; "S"; "N"; "W" ]
        [ "Q"; "G"; "M"; "N"; "J"; "V"; "C"; "P" ]
        [ "T"; "S"; "L"; "F"; "D"; "H"; "B" ]
        [ "J"; "V"; "T"; "W"; "M"; "N" ]
        [ "P"; "F"; "L"; "C"; "S"; "T"; "G" ]
        [ "B"; "D"; "Z" ]
        [ "M"; "N"; "Z"; "W" ]
    ]
    |> parseSupplies

let tryParseMove (line: string) = 
    let pattern = "move (\d+) from (\d+) to (\d+)"
    let matcher = Regex.Match(line, pattern)

    if matcher.Success then 
        let number = matcher.Groups.[1].Value |> int 
        let source = matcher.Groups.[2].Value |> int 
        let target = matcher.Groups.[3].Value |> int 
        {
            From = source
            To = target
            Number = number 
        } |> Some
    else 
        printfn "Error parsing line: %s" line 
        None
