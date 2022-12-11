
open System.IO
open Stacks 

// let movesInput = File.ReadLines("../input/dec05_moves_test.txt")  
let movesInput = File.ReadLines("../input/dec05_moves.txt")  

movesInput 
|> Seq.choose tryParseMove
|> Seq.fold (fun supplies move -> applyMove supplies move) inputSupplies
|> getCode 
|> printfn "%s"