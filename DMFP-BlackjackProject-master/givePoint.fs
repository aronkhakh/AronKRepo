namespace BlackjackProject
  open System
  open Program
  module givePointToWinner = 
    let mutable p1count = 0
    let mutable p2count = 0
    let mutable p3count = 0
    let mutable p4count = 0
    let mutable p5count = 0
    let mutable dealer = 0
    let mutable value = 0
    let mutable Winner = ""
     
    module givePoint = 
        
        let givepoint winner = 
          let Winner = winner
          if (Winner = "player1") then
            p1count <- p1count + 1
            value <- p1count
          elif (Winner = "player2") then
            p2count <- p2count + 1
            value <- p2count
          elif (Winner = "player3") then
            p3count <- p3count + 1
            value <- p3count
          elif (Winner = "player4") then
            p4count <- p4count + 1
            value <- p4count
          elif (Winner = "player5") then
            p5count <- p5count + 1
            value <- p5count
          elif (Winner = "dealer") then
            dealer <- dealer + 1   
            value <- dealer
          elif (Winner = "push") then
            printfn "Push, no one gets points" 
            value <- 0
          else
            printfn "Invalid Point Input"
            value <- 0
        
    
    //Handle Result
    //Input Winner, pcount of Winner
    
    module handleResult =
      if (value <= 2) then
        printfn "%s has won that round! Get ready for the next one..." Winner
        //Call main game function 
      elif (value > 2) then
        printfn "%s has won with %i points!" Winner value
        printfn "Game Over!" //Game Over
        