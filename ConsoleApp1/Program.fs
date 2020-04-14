// Learn more about F# at http://fsharp.org

open System

let fibOperation (grandParent, parent) items =
    (parent, grandParent + parent)

let calcFibNumber n =
    Seq.init n id 
    |> Seq.scan (fibOperation) (0, 1) 
    |> Seq.map snd

[<EntryPoint>]
let main argv =
    let fibCount = 20
    let fibNumbers = calcFibNumber fibCount
    printf "First %i numbers are: \n" fibCount
    Seq.iter (fun i -> printf "%i " i) fibNumbers 
    Console.ReadKey() |> ignore
    0 // return an integer exit code
