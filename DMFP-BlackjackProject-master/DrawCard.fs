namespace BlackjackProject
module DrawCard = 

    open Definitions
    open GetHandValue

    module Draw = 
        // takes Deck as input
        let drawCard deck = // 'a list -> 'a * 'a list
            // pattern match - checks if Deck has at least 1 Card
            match deck with 
            |card :: rest -> card, rest // returns a Card and a new Deck
            |_ -> failwith "Deck needs at least 1 card"

    module Deal = 
        // takes Deck as input
        let deal deck = // 'a list -> 'a * 'a * 'a list
            // pattern match - checks if Deck has at least 2 Cards
            match deck with 
            |card1 :: card2 :: rest -> card1, card2, rest // returns 2 Cards and a new Deck
            |_ -> failwith "Deck needs at least 2 cards"

            
    
    module DealFirstHand = 
        // takes Players array and Deck as input
        let dealFirst players deck = // 'a [] -> Deck -> Player [] * Deck
            // pattern match - checks the length of the Players array
            match Array.length players with
            |1 -> 
                // creates new Hand using 2 Cards and gets the HandValue
                let card1, card2, newDeck = deck |> Deal.deal
                let hand1 = [|card1; card2|] |> GetHandValue.getHandValue 

                // updates the Players array
                let players = [|
                    {Id = 0; State = State.Playing; Hand = [|card1; card2|]; HandValue = hand1}|]

                // returns the Players array and a new Deck
                players, newDeck
               
            |2 -> 
                let card1, card2, newDeck = deck |> Deal.deal 
                let card3, card4, newDeck = newDeck |> Deal.deal 
                let hand1 = [|card1; card2|] |> GetHandValue.getHandValue 
                let hand2 = [|card3; card4|] |> GetHandValue.getHandValue 

                let players = [|
                    {Id = 0; State = State.Playing; Hand = [|card1; card2|]; HandValue = hand1}; 
                    {Id = 1; State = State.Playing; Hand = [|card3; card4|]; HandValue = hand2}|]
                players, newDeck

            |3 -> 
                let card1, card2, newDeck = deck |> Deal.deal 
                let card3, card4, newDeck = newDeck |> Deal.deal
                let card5, card6, newDeck = newDeck |> Deal.deal
                let hand1 = [|card1; card2|] |> GetHandValue.getHandValue 
                let hand2 = [|card3; card4|] |> GetHandValue.getHandValue 
                let hand3 = [|card5; card6|] |> GetHandValue.getHandValue 

                let players = [|
                    {Id = 0; State = State.Playing; Hand = [|card1; card2|]; HandValue = hand1}; 
                    {Id = 1; State = State.Playing; Hand = [|card3; card4|]; HandValue = hand2}; 
                    {Id = 2; State = State.Playing; Hand = [|card5; card6|]; HandValue = hand3}|]
                players, newDeck

            |4 -> 
                let card1, card2, newDeck = deck |> Deal.deal
                let card3, card4, newDeck = newDeck |> Deal.deal
                let card5, card6, newDeck = newDeck |> Deal.deal
                let card7, card8, newDeck = newDeck |> Deal.deal
                let hand1 = [|card1; card2|] |> GetHandValue.getHandValue 
                let hand2 = [|card3; card4|] |> GetHandValue.getHandValue 
                let hand3 = [|card5; card6|] |> GetHandValue.getHandValue
                let hand4 = [|card7; card8|] |> GetHandValue.getHandValue

                let players = [|
                    {Id = 0; State = State.Playing; Hand = [|card1; card2|]; HandValue = hand1}; 
                    {Id = 1; State = State.Playing; Hand = [|card3; card4|]; HandValue = hand2}; 
                    {Id = 2; State = State.Playing; Hand = [|card5; card6|]; HandValue = hand3};
                    {Id = 3; State = State.Playing; Hand = [|card7; card8|]; HandValue = hand4}|]
                players, newDeck

            |_ -> failwith "Error"

        let dealFirstDealer dealer deck = // 'a -> Deck -> Dealer * Deck
            // creates new Hand for Dealer and gets the HandValue
            let card, newDeck = deck |> Draw.drawCard
            let hand1 = [|card|] |> GetHandValue.getHandValue

            // updates the Dealer with new Hand
            let dealer = {State = State.Playing; Hand = [|card|]; HandValue = hand1}

            // returns Dealer and new Deck
            dealer, newDeck

            
            

    
            