open System.IO
open Rucksack

[<EntryPoint>]
let main args = 

    // let input = File.ReadLines("../input/dec03_test.txt")  
    let input = File.ReadLines("../input/dec03.txt")

    input 
    |> Seq.choose tryParseLine
    |> Seq.map (findCommon >> scoreChar)
    |> Seq.sum
    |> printfn "Total is: %i"

    0