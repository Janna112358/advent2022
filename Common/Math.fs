module Math 

let fixedMod b = fun x -> 
    let maybeNegative = x % b
    if maybeNegative < 0 then 
        maybeNegative + b
    else 
        maybeNegative
