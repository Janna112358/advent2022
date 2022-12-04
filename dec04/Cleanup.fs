module Cleanup

type Assignment = 
    {
        Low: int 
        Up: int
    }

let parseRange (range: string) = 
    let bounds = range.Split [|'-'|]
    match bounds with 
    | [|lower; upper|] -> 
        { Low = lower |> int; Up = upper |> int }
    | _ -> 
        failwith "Unexpected assignment range format"

let parseLine (line: string) = 
    let assignments = line.Split [|','|]
    match assignments with 
    | [| left; right |] -> 
        let leftRange = parseRange left 
        let rightRange = parseRange right 
        (leftRange, rightRange)
    | _ -> 
        failwith "Unexpected line format"

let isLeftInRight (left: Assignment) (right: Assignment) = 
    (right.Low <= left.Low)
    && 
    (right.Up >= left.Up) 

let hasCompleteOverlap (left, right) = 
    (isLeftInRight left right)
    ||
    (isLeftInRight right left)

let hasNoOverlap (left, right) = 
    (left.Up < right.Low) 
    || 
    (right.Up < left.Low)