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

    Seq.init n id 
    |> Seq.scan fibOperation (0, 0)
    |> Seq.map snd

let printFibSeq fibFunc n =
    let fibNumbers = fibFunc n
    Seq.iter (fun i -> printf "%i " i) fibNumbers 

[<EntryPoint>]
let main argv =
    let fibFactor = 20
    printf "First %i numbers by the recursive function are: \n" fibFactor
    printFibSeq recursiveFibSeq fibFactor
    printf "\n"
    printf "First %i numbers by the iterative function are: \n" fibFactor
    printFibSeq recursiveFibSeq fibFactor
    Console.ReadKey() |> ignore
    0 // return an integer exit code
