namespace BlackjackProject

module GetHandValue = 
    open Definitions

    module GetCardValue = 
        // takes a Card as input
        let getCardValue card = // Rank * 'a -> int
            // splits Card, binding the first element (Rank) to cardRank
            let cardRank = fst card

            // pattern match - return value of Card
            match cardRank with
            |Rank.Ace -> 11
            |Rank.Two -> 2
            |Rank.Three -> 3
            |Rank.Four -> 4
            |Rank.Five -> 5
            |Rank.Six -> 6
            |Rank.Seven -> 7
            |Rank.Eight -> 8
            |Rank.Nine -> 9
            |Rank.Ten |Rank.Jack |Rank.Queen |Rank.King -> 10
            |_ -> failwith "Error"


    module GetHandValue = 
        // runs getCardValue across all Cards in Hand
        let getHandValue (hand:array<_>) = // Rank * 'a array -> int
            Array.fold (fun acc elem -> acc + GetCardValue.getCardValue elem) 0 hand

            



            
