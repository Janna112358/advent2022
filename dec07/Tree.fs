module Tree

type Node = 
| File of File
| Dir of Dir  
and File = {
    Name: string 
    Size: int
}
and Dir = {
    Name: string 
    Children: Node list
}

let rec nodeSize (record: int list) (node: Node) = 
    let record, size = 
        match node with 
        | File file -> 
            file.Size :: record, file.Size 
        | Dir dir ->
            let r = 
                dir.Children 
                |> List.collect (fun child -> 
                    nodeSize record child |> fst)
            let s = 
                dir.Children 
                |> List.sumBy (fun child -> 
                    nodeSize record child |> snd)
            r, s
    record, size 

type Line =    
    | Cd of string 
    | Ls
    | Dir of string 
    | File of int * string 

let parseLine (line: string) = 
    if line.[0..4] = "$ cd " then 
        Cd line.[5..]
    else if line = "$ ls" then 
        Ls
    else if line.[0..3] = "dir " then 
        Dir line.[4..]
    else 
        let parts = line.Split [|' '|]
        let size = parts.[0] |> int 
        let fileName = parts.[1]
        File (size, fileName)

type tracker = {
    Tree: Node 
    Status: Status 
}
and Status = 
    | GatheringChildren of Node list 
    | WaitingForCommand

let parseInput (input: Seq<string>) = 
    input 
    |> Seq.fold (fun tracker rawLine -> 
        parseLine rawLine 
        |> function
        | Cd dirName when dirName = "/" -> 
            tracker
        | Cd dirname -> 
            { tracker with Status = WaitingForCommand }
             
    ) {Tree = initialNode; Status = WaitingForCommand}