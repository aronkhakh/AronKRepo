namespace BlackjackTesting

module BlackjackTesting =
    open BlackjackProject.Definitions
    open BlackjackProject.GetHandValue
    open BlackjackProject.PrintCards
    open BlackjackProject.BuildPlayers
    open BlackjackProject.DrawCard
    open NUnit.Framework
    open FsUnit

    [<Test>]
    let ``Check get hand value for integer`` () = 
        Assert.AreEqual (
            19, 
            [|Rank.Queen, Hearts; Rank.Two, Hearts; Rank.Three, Spades; Rank.Four, Clubs|] |> GetHandValue.getHandValue
        )

    [<Test>]
    let ``Check get card value for integer`` () = 
        Assert.AreEqual (
            10, 
            (Rank.Queen, Hearts) |> GetCardValue.getCardValue
        )

    [<Test>]
    let ``Check print card for tuple of strings`` () = 
        Assert.AreEqual (
            ("Ace", "Spades"), 
            (Rank.Ace, Spades) |> PrintCards.printCard
        )

    [<Test>]
    let ``Check build players for an array of player records when input is 0`` () = 
        Assert.AreEqual (
            [|
                {Id = 0; State = State.Out; Hand = [||]; HandValue = 0}|],

                0 |> BuildPlayers.buildPlayers
        )

    [<Test>]
    let ``Check build players for an array of player records when input is 1`` () = 
        Assert.AreEqual (
            [|
                {Id = 0; State = State.Out; Hand = [||]; HandValue = 0};
                {Id = 1; State = State.Out; Hand = [||]; HandValue = 0}|],

                1 |> BuildPlayers.buildPlayers
        )

    [<Test>]
    let ``Check build players for an array of player records when input is 2`` () = 
        Assert.AreEqual (
            [|
                {Id = 0; State = State.Out; Hand = [||]; HandValue = 0};
                {Id = 1; State = State.Out; Hand = [||]; HandValue = 0};
                {Id = 2; State = State.Out; Hand = [||]; HandValue = 0}|],

                2 |> BuildPlayers.buildPlayers
        )

    [<Test>]
    let ``Check build players for an array of player records when input is 3`` () = 
        Assert.AreEqual (
            [|
                {Id = 0; State = State.Out; Hand = [||]; HandValue = 0};
                {Id = 1; State = State.Out; Hand = [||]; HandValue = 0};
                {Id = 2; State = State.Out; Hand = [||]; HandValue = 0};
                {Id = 3; State = State.Out; Hand = [||]; HandValue = 0}|],

                3 |> BuildPlayers.buildPlayers
        )

    [<Test>]
    let ``Check draw card for a tuple of card * deck `` () = 
        Assert.AreEqual (
            ((Rank.Ace, Spades), [Rank.Queen, Hearts; Rank.Two, Hearts; Rank.Three, Spades; Rank.Four, Clubs]),
            [Rank.Ace, Spades; Rank.Queen, Hearts; Rank.Two, Hearts; Rank.Three, Spades; Rank.Four, Clubs] |> Draw.drawCard
        )

    [<Test>]
    let ``Check deal for a tuple of card * card * deck`` () = 
        Assert.AreEqual (
            ((Rank.Ace, Spades), (Rank.Queen, Hearts), [Rank.Two, Hearts; Rank.Three, Spades; Rank.Four, Clubs]),
            [Rank.Ace, Spades; Rank.Queen, Hearts; Rank.Two, Hearts; Rank.Three, Spades; Rank.Four, Clubs] |> Deal.deal
        )

    [<Test>]
    let ``Check deal first for a tuple of player array * deck`` () =
        let players = [|
            {Id = 0; State = Out; Hand = [||]; HandValue = 0}; 
            {Id = 1; State = Out; Hand = [||]; HandValue = 0}
        |]
        
        let deck = [Rank.Ace, Spades; Rank.Queen, Hearts; Rank.Two, Hearts; Rank.Three, Spades; Rank.Four, Clubs]

        Assert.AreEqual (
            ([|
                {Id = 0; State = Playing; Hand = [|Rank.Ace, Spades; Rank.Queen, Hearts|]; HandValue = 21}; 
                {Id = 1; State = Playing; Hand = [|Rank.Two, Hearts; Rank.Three, Spades|]; HandValue = 5}|], 
                [Rank.Four, Clubs]), 

                DealFirstHand.dealFirst players deck
        )

    [<Test>]
    let ``Check deal first dealer for tuple of dealer * deck`` () = 
        let dealer = {State = Out; Hand = [||]; HandValue = 0}

        let deck = [Rank.Ace, Spades; Rank.Queen, Hearts; Rank.Two, Hearts; Rank.Three, Spades; Rank.Four, Clubs]

        Assert.AreEqual (
            (
                {State = Playing; Hand = [|Rank.Ace, Spades|]; HandValue = 11}, 
                [Rank.Queen, Hearts; Rank.Two, Hearts; Rank.Three, Spades; Rank.Four, Clubs]),

            DealFirstHand.dealFirstDealer dealer deck
        )

    [<Test>]
    let ``Check TurnInput create returns Some`` () = 
        Assert.AreEqual (
            Some (TurnInput.TurnInput "draw"),
            "draw" |> TurnInput.create
        )

    [<Test>]
    let ``Check TurnInput value for string`` () = 
        Assert.AreEqual (
            "draw", 
            TurnInput.TurnInput "draw" |> TurnInput.value
        )

    [<Test>]
    let ``Check NumOfOpponents create returns Some`` () = 
        Assert.AreEqual (
            Some (NumOfOpponents.NumOfOpponents 1),
            1 |> NumOfOpponents.create
        )

    [<Test>]
    let ``Check NumOfOpponents value for int`` () = 
        Assert.AreEqual (
            1, 
            NumOfOpponents.NumOfOpponents 1 |> NumOfOpponents.value
        )