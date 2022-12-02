module RPS 

module Math = 
    let fixedMod b = fun x -> 
        let maybeNegative = x % b
        if maybeNegative < 0 then 
            maybeNegative + b
        else 
            maybeNegative

type RPS = 
    | Rock 
    | Paper
    | Scissors
with 
    static member fromOrder (o: int) = 
        match o with 
        | 0 -> Rock 
        | 1 -> Paper 
        | _ 
        | 2 -> Scissors
    member this.toOrder = 
        match this with 
        | Rock -> 0 
        | Paper -> 1 
        | Scissors -> 2
    member this.toItemScore = 
        match this with 
        | Rock -> 1
        | Paper -> 2
        | Scissors -> 3

type MatchOutcome = 
    | Win 
    | Loss 
    | Draw
with 
    static member fromOrder (o: int) = 
        match o with 
        | 1 -> Win 
        | 2 -> Loss 
        | 0 
        | _ -> Draw 
    member this.toOrder = 
        match this with 
        | Win -> 1 
        | Loss -> 2 
        | Draw -> 0
    member this.toScore = 
        match this with 
        | Win -> 6 
        | Loss -> 0 
        | Draw -> 3

let outcome (opponent: RPS) (me: RPS) = 
    me.toOrder - opponent.toOrder
    |> Math.fixedMod 3 
    |> MatchOutcome.fromOrder 

let score (opponent: RPS) (me: RPS) = 
    let out = outcome opponent me 
    out.toScore + me.toItemScore

let playFromOutcome (opponent: RPS) (outcome: MatchOutcome) = 
    outcome.toOrder + opponent.toOrder
    |> Math.fixedMod 3 
    |> RPS.fromOrder 
    
let scoreFromOutcome (opponent: RPS) (outcome: MatchOutcome) = 
    let me = playFromOutcome opponent outcome 
    outcome.toScore + me.toItemScore 