open System

let recursiveFibSeq n = 
    let rec fibOperation n =
        if n = 0 || n = 1 then
            n
        else
            fibOperation (n - 2) + fibOperation (n - 1)

    Seq.init n fibOperation


let iterativeFibSeq n =
    let fibOperation (grandParent, parent) items =
        if grandParent = 0 && parent = 0 then // To have f(0)=0 this is how we make the induction-case
            (0, 1)
        else
            (parent, grandParent + parent)
    
    let n' = n - 1 // Quick hack to fix off-by-one error
    Seq.init n' id 
    |> Seq.scan fibOperation (0, 0)
    |> Seq.map snd

let printFibSeq fibFunc n =
    let fibNumbers = fibFunc n
    Seq.iter (fun i -> printf "%i " i) fibNumbers
    printf "\n"

[<EntryPoint>]
let main argv =
    let fibFactor = 40
    
    printf "First %i numbers by the recursive function are: \n" fibFactor
    let recursiveStopWatch = System.Diagnostics.Stopwatch.StartNew()
    printFibSeq recursiveFibSeq fibFactor
    recursiveStopWatch.Stop()
    printfn "time elapsed %f" recursiveStopWatch.Elapsed.TotalMilliseconds
    printf "\n"
    
    printf "First %i numbers by the iterative function are: \n" fibFactor
    let iterativeStopWatch = System.Diagnostics.Stopwatch.StartNew()
    printFibSeq iterativeFibSeq fibFactor
    iterativeStopWatch.Stop()
    printfn "time elapsed %f" iterativeStopWatch.Elapsed.TotalMilliseconds
    
    Console.ReadKey() |> ignore
    0 // return an integer exit code
