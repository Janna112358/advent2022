open System.IO 

open RPS

let tryParseTwoLetters (s: string) : Option<string * string> = 
    let letters = s.Split [|' '|]
    match letters with 
    | [|a; b|] -> 
        Some (a, b)
    | _ -> 
        None 

let tryParseOpponent (letter: string) =
    match letter with 
    | "A" -> Some Rock 
    | "B" -> Some Paper 
    | "C" -> Some Scissors 
    | _ -> None 

let tryParseMe (letter: string) =   
    match letter with 
    | "X" -> Some Rock 
    | "Y" -> Some Paper 
    | "Z" -> Some Scissors 
    | _ -> None 

let tryParseOutcome (letter: string) = 
    match letter with 
    | "X" -> Some Loss 
    | "Y" -> Some Draw  
    | "Z" -> Some Win
    | _ -> None 

let tryParseLine 
    (leftParser: string -> Option<'L>) 
    (rightParser: string -> Option<'R>)
    (line: string) =    
    tryParseTwoLetters line 
    |> Option.bind (fun (a, b) -> 
        let left = leftParser a
        let right = rightParser b
        match left, right with 
        | Some l, Some r -> Some (l, r) 
        | _, _ -> None 
    )

[<EntryPoint>]
let main args = 
    // let input = File.ReadLines("../input/dec02_test.txt")
    let input = File.ReadLines("../input/dec02.txt")

    printfn "part 1"
    input 
    |> Seq.choose (tryParseLine tryParseOpponent tryParseMe)
    |> Seq.map (fun (opponent, me) -> score opponent me) 
    |> Seq.sum 
    |> printfn "total score is: %i"


    printfn "part 2"
    input 
    |> Seq.choose (tryParseLine tryParseOpponent tryParseOutcome)
    |> Seq.map (fun (opponent, outcome) -> scoreFromOutcome opponent outcome) 
    |> Seq.sum 
    |> printfn "total score is: %i"

    0




