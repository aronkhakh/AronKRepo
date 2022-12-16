namespace BlackjackProject

module PrintCards = 

    module PrintCards = 

        // takes a Card as input
        let printCard card = 
            // splits Card tuple into Rank and Suit, binding them to separate variables
            let cardRank = fst card
            let cardSuit = snd card

            // convert cardRank and cardSuit to strings
            let printedRank = cardRank.ToString ()
            let printedSuit = cardSuit.ToString ()

            // return tuple of string * string
            printedRank, printedSuit

        
