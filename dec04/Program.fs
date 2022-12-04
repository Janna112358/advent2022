open System.IO
open Cleanup

// let input = File.ReadLines("../input/dec04_test.txt")  
let input = File.ReadLines("../input/dec04.txt")

printfn "Part 1"
// input 
// |> Seq.map parseLine 
// |> Seq.filter hasCompleteOverlap 
// |> List.ofSeq 
// |> List.length 
// |> printfn "Pairs with complete overlap: %i"

printfn "Part 2"
input 
|> Seq.map parseLine 
|> Seq.filter (hasNoOverlap >> not)
|> List.ofSeq 
|> List.length 
|> printfn "Pairs with any overlap: %i"