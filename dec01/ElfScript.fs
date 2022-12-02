module ElfScript

type ElfLine = 
    | Break 
    | Int of int 
    | Invalid

let toElfline (s: string) = 
    match s with 
    | "" -> Break 
    | something -> 
        match System.Int32.TryParse(something) with 
        | true, number -> Int number 
        | false, _ -> Invalid

