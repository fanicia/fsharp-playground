// Learn more about F# at http://fsharp.org

open System

let fibOperation (grandParent, parent) items =
    (parent, grandParent + parent)

let calcFibSeq n =
    Seq.init n id 
    |> Seq.scan (fibOperation) (0, 1) 
    |> Seq.map snd

let printFibSeq n =
    let fibNumbers = calcFibSeq n
    printf "First %i numbers are: \n" n
    Seq.iter (fun i -> printf "%i " i) fibNumbers 

[<EntryPoint>]
let main argv =
    printFibSeq 20
    Console.ReadKey() |> ignore
    0 // return an integer exit code
