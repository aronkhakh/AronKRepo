namespace BlackjackProject
module BuildPlayers = 

    open Definitions
    open DrawCard


    module BuildPlayers = 
        // takes number of players as input
        let buildPlayers num = 
            
            let list = 
                // pattern match - checks if num is equal to a certain value
                match num with
                |1 -> 
                    // create array of player records
                    let playersList = [|
                        {Id = 0; State = State.Out; Hand = [||]; HandValue = 0};
                        {Id = 1; State = State.Out; Hand = [||]; HandValue = 0}|]
                    // return player array
                    playersList
                |2 -> 
                    let playersList = [|
                        {Id = 0; State = State.Out; Hand = [||]; HandValue = 0};
                        {Id = 1; State = State.Out; Hand = [||]; HandValue = 0}; 
                        {Id = 2; State = State.Out; Hand = [||]; HandValue = 0}|] 
                    playersList
                |3 -> 
                    let playersList = [|
                        {Id = 0; State = State.Out; Hand = [||]; HandValue = 0};
                        {Id = 1; State = State.Out; Hand = [||]; HandValue = 0}; 
                        {Id = 2; State = State.Out; Hand = [||]; HandValue = 0}; 
                        {Id = 3; State = State.Out; Hand = [||]; HandValue = 0}|] 
                    playersList
                |_ -> 
                    // creates array of 1 player and returns it
                    let playersList = [|
                        {Id = 0; State = State.Out; Hand = [||]; HandValue = 0}|]
                    playersList
                
            list
            
        

        
        

        

