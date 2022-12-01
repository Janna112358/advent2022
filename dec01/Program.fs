open System.IO

let input = File.ReadLines("./input.txt")
// let input = File.ReadLines ("./test_input.txt")


let findMaxCount input = 

    let initialState = {| CurrentCount = 0; MaximumCount = 0|}
 
    let finalState = 
        input 
        |> Seq.fold (fun state line -> 
            match line with 
            | "" -> 
                {| CurrentCount = 0; MaximumCount = max state.CurrentCount state.MaximumCount |}    
            | something -> 
                match System.Int32.TryParse(something) with 
                | true, count -> 
                    {| state with CurrentCount = state.CurrentCount + count |}
                | false, _ -> 
                    printfn "Encountered invalid line %s" something
                    state 
        ) initialState
    
    max finalState.CurrentCount finalState.MaximumCount


let findTopThree input = 

    let initialState = {|
        CurrentCount = 0 
        TopThree = [0; 0; 0]
    |}

    let updateTopThree currentTopThree newCount = 
        newCount :: currentTopThree
        |> List.sort 
        |> List.tail 

    let finalState = 
        input 
        |> Seq.fold (fun state line -> 
            match line with 
            | "" -> 
                {| CurrentCount = 0; TopThree = updateTopThree state.TopThree state.CurrentCount |}
            | something -> 
                match System.Int32.TryParse(something) with 
                | true, count -> 
                    {| state with CurrentCount = state.CurrentCount + count |}
                | false, _ -> 
                    printfn "Encountered invalid line %s" something 
                    state 
        ) initialState 
    
    updateTopThree finalState.TopThree finalState.CurrentCount


[<EntryPoint>]
let main args = 

    printfn "Part 1"
    findMaxCount input 
    |> printfn "Maximum is: %i" 

    printfn "Part 2"
    findTopThree input 
    |> List.sum 
    |> printfn "Sum of top three is: %i"

    0
