namespace BlackjackProject

module BuildDeck = 

    open Definitions
    open System

    module buildDeck = 
        let build = 
            // create list of suits
            let suits = [Diamonds; Hearts; Clubs; Spades]
            
            // create list of ranks
            let ranks = [Rank.Ace; Rank.King; Rank.Queen; Rank.Jack; Rank.Ten; Rank.Nine; Rank.Eight; Rank.Seven;
                        Rank.Six; Rank.Five; Rank.Four; Rank.Three; Rank.Two]
            
            // combine two lists into list of tuples (rank * suit)
            let newDeck:Deck = 
                [for s in suits do
                    for r in ranks do 
                        yield Card (r, s)]

            // shuffle deck into random order
            let shuffleDeck () = // Deck -> Deck
                
                // create new random generator
                let rand = Random ()
                
                // create list of randomly generated ints of the same size as newDeck
                let random = List.init newDeck.Length (fun _ -> rand.Next ())

                // zip newDeck and random lists into list of tuples (Card * int)
                let shuffleList = List.zip newDeck random

                // sort new list by second element in tuple - random ints
                // map to a new list in shuffled order
                shuffleList
                |> List.sortBy snd
                |> List.map fst

            // return shuffled Deck
            shuffleDeck ()