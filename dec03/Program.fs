open System.IO
open Rucksack
open Badges

[<EntryPoint>]
let main args = 

    // let input = File.ReadLines("../input/dec03_test.txt")  
    let input = File.ReadLines("../input/dec03.txt")

    // printfn "part 1"
    // input 
    // |> Seq.choose tryParseLine
    // |> Seq.map (findCommon >> scoreChar)
    // |> Seq.sum
    // |> printfn "Total is: %i"

    printfn "part 2"
    input 
    |> parseGroups 3
    |> Seq.map (findBadge >> scoreChar)
    |> Seq.sum
    |> printfn "Toal is: %i"

    0