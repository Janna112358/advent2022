open System.IO

open ElfScript

type tracker<'T> = {
    CurrentCount: int 
    Top: 'T
}

let countUntilNewLine (updater: 'T -> int -> 'T) (initialTop: 'T) (input: seq<string>) = 
    let finalState = 
        input 
        |> Seq.fold (fun (state: tracker<'T>) line -> 
            line 
            |> toElfline 
            |> function 
            | Break -> 
                let newTop = updater state.Top state.CurrentCount 
                { state with CurrentCount = 0; Top = newTop }
            | Int count -> 
                { state with CurrentCount = state.CurrentCount + count }
            | Invalid -> 
                printfn "Invalid line encountered"
                state
            ) { CurrentCount = 0; Top = initialTop }
    updater finalState.Top finalState.CurrentCount 

let findMax = fun input -> countUntilNewLine max 0 input 

let findTopThree = 
    let updateTopThree currentTopThree newCount = 
        newCount :: currentTopThree
        |> List.sort 
        |> List.tail 
    fun input -> countUntilNewLine updateTopThree [0; 0; 0] input 


[<EntryPoint>]
let main args = 

    let input = File.ReadLines("./input.txt")
    // let input = File.ReadLines ("./test_input.txt")

    printfn "Part 1"
    findMax input 
    |> printfn "Maximum is: %i" 

    printfn "Part 2"
    findTopThree input 
    |> List.sum 
    |> printfn "Sum of top three is: %i"

    0
