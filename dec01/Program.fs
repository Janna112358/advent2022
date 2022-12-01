open System.IO

let input = File.ReadLines("./input.txt")
// let input = File.ReadLines ("./test_input.txt")

type State = {
    CurrentCount : int 
    MaximumCount : int 
}

let initialState = {
    CurrentCount = 0 
    MaximumCount = 0
}

[<EntryPoint>]
let main args = 
    let finalState = 
        input 
        |> Seq.fold (fun state line -> 
            match line with 
            | "" -> 
                {
                    CurrentCount = 0 
                    MaximumCount = max state.CurrentCount state.MaximumCount 
                }    
            | something -> 
                match System.Int32.TryParse(something) with 
                | true, count -> 
                    { state with CurrentCount = state.CurrentCount + count }
                | false, _ -> 
                    printfn "Encountered invalid line %s" something
                    state 
        ) initialState
    max finalState.CurrentCount finalState.MaximumCount        
    |> printfn "Maximum found to be: %i"

    0
