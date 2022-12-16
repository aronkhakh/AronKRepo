namespace BlackjackProject

module GetNumOpps = 

    open System
    open Definitions

    module NumOfOpps = 
        let noOfOpps = 
            
            // recursive function - runs until a correct input is provided
            let rec parseStr () = // unit -> int

                // get input from user
                printf "Please input the number of opponents you wish to face: "
                let str = Console.ReadLine ()

                // match parsed input 
                match Int32.TryParse (str:string) with
                |(true, num:int) ->  
                    // nested match - if NumOfOpponents.create returns a Some
                    match NumOfOpponents.create num with
                    |Some i -> NumOfOpponents.value i 
                    |None -> 
                        // error and recursion call
                        printf "ERROR: Invalid input '%A' -" num
                        printfn " Expecting a single valid integer as input"
                        printfn ""
                        parseStr ()

                |_ -> 
                    printf "ERROR: Invalid input '%A' -" str
                    printfn " Expecting a single valid integer as input"
                    printfn ""
                    parseStr ()

            parseStr ()