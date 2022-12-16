namespace BlackjackProject

module PlayerAction =
    open Definitions
    open GetHandValue
    open DrawCard
    open PlayerParse
    open PrintCards
    open PlayerTurn
    open BuildDeck
    open AITurn
type Action = draw | hold | fold

module PlayerMakesAction = PlayerTurn (userInput)
    //Player draws random card from deck, if deck is empty they receive no cards

    type DrawCard = {Card:Deck}
        let CardDraw Deck =
            match Deck with
            | [] -> 
                printfn "The deck is empty"
                None

    //If player holds, skip to opponent
    let hold () = 
        printf "You draw no cards. Going to next player"
        (AIturn)
     
    //If player folds, end the game and player can restart
    let rec fold () = 
        printf "You have folded, you have lost this round to start a new round say start: "
        let userInput = Console.ReadLine () 
       
        match TurnInput.create userInput with
        |Some s -> 
            TurnInput.value s
        |None -> 
            // error and recursion call
            printf "ERROR: Invalid input please type in start '%s'" userInput 
            printfn " Error! Are you trying to restart the game? "
            fold ()
            playGame ()
        

