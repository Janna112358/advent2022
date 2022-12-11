module Queue

type Queue<'T> = {
    Size: int 
    Items: list<'T>
}
with 
    static member fromList (size: int) (inputList: list<'T>) = 
        let sizedItems = 
            match inputList with 
            | input when (List.length inputList <= size) -> 
                input 
            | longInput -> 
                let items, rest = List.splitAt size longInput 
                items 
        {
            Size = size 
            Items = sizedItems
        }
    static member fromSizedList (inputList: list<'T>) = 
        {
            Size = List.length inputList 
            Items = inputList
        }

let addToQueue (queue: Queue<'T>) (item: 'T) = 
        List.append queue.Items [item]
        |> function 
        | [] -> queue, None 
        | items when (List.length items <= queue.Size) -> 
            { queue with Items = items }, None 
        | poppedItem :: rest -> 
            { queue with Items = rest }, Some poppedItem


let isFull (queue: Queue<'T>) = 
    List.length queue.Items = queue.Size

let hasDuplicates (queue: Queue<'T>) = 
    let uniqueCount = 
        queue.Items 
        |> Set.ofList 
        |> Set.count
    uniqueCount < List.length queue.Items 
