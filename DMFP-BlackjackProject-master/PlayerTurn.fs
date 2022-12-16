namespace BlackjackProject

module PlayerTurn = 

    open System
    open Definitions
    open PrintCards
    open GetHandValue

    module TakeTurn = 
        // takes Players array and Dealer as input
        let takeTurn players dealer = // Player [] -> Dealer -> string
            
            printfn "Your turn!"
            printfn ""

            // outputs all opponent data that the user is allowed to see
            for i = 1 to Array.length players - 1 do
                printfn "Player %i's hand: " players.[i].Id

                let card1 = players.[i].Hand.[0]
                let card2 = players.[i].Hand.[1]
                let card1Rank = PrintCards.printCard card1 |> fst
                let card1Suit = PrintCards.printCard card1 |> snd
                let card2Rank = PrintCards.printCard card2 |> fst
                let card2Suit = PrintCards.printCard card2 |> snd
                printfn "%s of %s" card1Rank card1Suit
                printfn "%s of %s" card2Rank card2Suit

                let oppHand = [|card1; card2|] |> GetHandValue.getHandValue 
                printfn "Hand value: %i" oppHand
                printfn ""

            // outputs dealer data that the player is allowed to see
            printfn "Dealer's card: "
            let dealerCard = dealer.Hand.[0]
            let cardRank = PrintCards.printCard dealerCard |> fst
            let cardSuit = PrintCards.printCard dealerCard |> snd
            printfn "%s of %s" cardRank cardSuit

            let dealerHand = [|dealerCard|] |> GetHandValue.getHandValue 
            printfn "Hand value: %i" dealerHand
            printfn ""

            // outputs player data
            printfn "Your hand: "
            for i = 0 to Array.length players.[0].Hand - 1 do
                let card = players.[0].Hand.[i]
                let printedCard = card |> PrintCards.printCard
                let cardRank = printedCard |> fst
                let cardSuit = printedCard |> snd
                printfn "%s of %s" cardRank cardSuit

            let handValue = players.[0].Hand |> GetHandValue.getHandValue 
            printfn "Total hand value: %i" handValue
            printfn ""

            // gets user action
            let rec choice () = // unit -> string
                
                printf "Please input draw, hold or fold: "
                let userInput = Console.ReadLine () // stores user input

                // match user input
                match TurnInput.create userInput with
                |Some s -> 
                    TurnInput.value s
                |None -> 
                    // error and recursion call
                    printf "ERROR: Invalid input '%s' -" userInput 
                    printfn " Expecting a single valid command as input"
                    printfn ""
                    choice ()

            choice ()