open System.IO 
open Queue

// let input = File.ReadLines("../input/dec06_test.txt")
let input = File.ReadLines("../input/dec06.txt")

type tracker = {
    Index: int 
    Candidate: Queue<char>
    MarkerIndex: int option 

}

// use marker size 4 for part 1, and size 14 for part 2
// let markerSize = 4
let markerSize = 14

input 
|> Seq.map (fun line -> 
    let initialTracker = {
        Index = 0
        Candidate = Queue.fromList markerSize []
        MarkerIndex = None
    }
    line 
    |> Seq.fold (fun tracker letter -> 
        let newIndex = tracker.Index + 1
        let newCandidate, poppedLetter = addToQueue tracker.Candidate letter

        let newMarkerIndex = 
            match tracker.MarkerIndex with 
            | Some alreadyFoundIdx -> Some alreadyFoundIdx 
            | None -> 
                if not (hasDuplicates newCandidate) && (isFull newCandidate) then 
                    printfn "marker found! %A" newCandidate.Items
                    Some newIndex 
                else 
                    None 
        {
            Index = newIndex 
            Candidate = newCandidate 
            MarkerIndex = newMarkerIndex
        }
    ) initialTracker
)
|> Seq.iter (fun tracker -> 
    match tracker.MarkerIndex with 
    | Some idx -> 
        printfn "Marker found at index %i" idx
    | None ->
        printfn "No marker found"
)