namespace BlackjackProject

module Definitions = 

    open System.Text.RegularExpressions

    // wraps user turn input in single case union and constrains it
    module TurnInput = 
        type TurnInput = TurnInput of string
        let pattern = Regex "^(draw|hold|fold)$" // Regex
        let create s = // string -> TurnInput option
            if pattern.IsMatch s
            then Some (TurnInput s)
            else None

        // unwraps user input into string
        let value (TurnInput t) = t // TurnInput -> string

    // wraps user's number of players input and constrains it
    module NumOfOpponents = 
        type NumOfOpponents = NumOfOpponents of int
        let create (i:int) = // int -> NumOfOpponents option
            if (i >= 0 && i <= 3)
            then Some (NumOfOpponents i)
            else None

        // unwraps number of players into int
        let value (NumOfOpponents i) = i // NumOfOpponents -> int

    // Suits type
    type Suit = 
        |Spades
        |Clubs
        |Diamonds
        |Hearts

    // Ranks type
    type Rank = 
        |Ace = 1
        |King = 10
        |Queen = 10
        |Jack = 10
        |Ten = 10
        |Nine = 9
        |Eight = 8
        |Seven = 7
        |Six = 6
        |Five = 5
        |Four = 4
        |Three = 3
        |Two = 2

    // Card type
    type Card = Rank * Suit

    // Deck type
    type Deck = Card list
    
    // Hand type
    type Hand = Card array  

    // TurnAction type
    type TurnAction = Draw | Hold | Fold

    // State type
    type State = 
        |Bust
        |Playing
        |Held
        |Out

    // Player type
    type Player = 
        {Id: int; State: State; Hand: Hand; HandValue: int}

    // Dealer type
    type Dealer = 
        {State: State; Hand: Hand; HandValue: int}
    