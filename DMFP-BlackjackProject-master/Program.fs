namespace BlackjackProject

module Main = 

    open Definitions
    open PlayerTurn
    open GetNumOpps
    open BuildDeck
    open BuildPlayers
    open DrawCard

    // function to run the game
    let playGame () = // unit -> unit
        // get number of opponents from user
        let numOpps = NumOfOpps.noOfOpps

        // build and shuffle new deck
        let deck = buildDeck.build

        // create dealer
        let dealer = {State = State.Out; Hand = [||]; HandValue = 0}

        // create players
        let players = numOpps |> BuildPlayers.buildPlayers 

        // deal first hand to players and dealer
        let players, deck = DealFirstHand.dealFirst players deck
        let dealer, deck = DealFirstHand.dealFirstDealer dealer deck

        // get turn action from user
        let playerTurnAction = TakeTurn.takeTurn players dealer
        
        // to test that playerTurnAction contains a string
        printfn "Your action: %s" playerTurnAction

    [<EntryPoint>]
        let main argv = 
            playGame ()
            0
          // return an integer exit code