// A class that contains static functions
// that check what the current game state is

public static class GameStateCheckers
{
    // Is the game Starting?
    public static bool isGameStarting(PossibleGameStates currentGameState)
    {
        return currentGameState == PossibleGameStates.Starting;
    }

    // Is the game active?
    public static bool isGameActive(PossibleGameStates currentGameState)
    {
        return currentGameState == PossibleGameStates.Active;
    }

    // Is the game finished?
    public static bool isGameFinished(PossibleGameStates currentGameState)
    {
        return currentGameState == PossibleGameStates.Finished;
    }

    // Is the game paused?
    public static bool isGamePaused(PossibleGameStates currentGameState)
    {
        return currentGameState == PossibleGameStates.Paused;
    }
}