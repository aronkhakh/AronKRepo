namespace BlackjackProject

module PlayerParse =

    open Definitions
    open GetHandValue
    open DrawCard
    open PlayerTurn
    open PrintCards

    let parsePlayerMove (TakeTurn) =
        if String.IsNullOrEmpty(str) then
            let ReadCard = "No move played"
            (ReadCard,"")
        else 
            if first = charToMatch then
                let ReadCard = sprintf "Player played %c" charToMatch
                (ReadCard)

