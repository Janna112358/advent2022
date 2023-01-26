open System.IO 
open Tree 

let input = File.ReadLines("../input/dec07_test.txt")
// let input = File.ReadLines("../input/dec07.txt")


let map1 = 
    [
        'a', 1
        'b', 2
        'c', 3
    ] |> Map.ofList 

let map2 = 
    [ 
        'c', 3
        'd', 4
    ] |> Map.ofList 


// let testTree = Dir {
//     Name = "/"
//     Children = [
//         Node.File { Name = "level1.txt"; Size = 10 }
//         Node.Dir {
//             Name = "A"
//             Children = [
//                 Node.File { Name = "level2.txt"; Size = 20 }
//                 Node.File { Name = "anotherLevel2.txt"; Size = 4 }
//                 Node.Dir { 
//                     Name = "B"
//                     Children = [
//                         File { Name = "level3.txt"; Size = 100 }
//                     ]
//                 }
//             ]
//         }
//     ]
// }


// printfn "%A" testTree

// let sizeRecord, totalSize = nodeSize [] testTree
// printfn "all sizes: %A" sizeRecord 

// sizeRecord 
// |> List.filter (fun s -> s <= 100000)
// |> List.sum 
// |> printfn "Sum of sizes > 100000: %i"

parseLine "$ cd /" |> printfn "%A"
parseLine "$ ls" |> printfn "%A"
parseLine "dir a" |> printfn "%A"
parseLine "14848514 b.txt" |> printfn "%A"

