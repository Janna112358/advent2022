module Calories 

type CalorieLine = 
    | Break 
    | Int of int 
    | Invalid

let toCalorieLine (s: string) = 
    match s with 
    | "" -> Break 
    | something -> 
        match System.Int32.TryParse(something) with 
        | true, number -> Int number 
        | false, _ -> Invalid
