namespace HighestCardGame
{
    class Program
    {
        private static UserInteraction _userInteraction;
        private static CardGame _cardGame;
        private static Player _winner;

        static void Main(string[] args)
        {
            ShowGameInstructions();
            StartGame();
            DetermineWinnerBasedOnGameRules();
            ShowResult();
        }

        private static void ShowGameInstructions()
        {
            _userInteraction = new UserInteraction();
            _userInteraction.StartUI();
        }

        private static void StartGame()
        {
            _cardGame = new CardGame();
            _cardGame.StartGame();
        }

        private static void DetermineWinnerBasedOnGameRules()
        {
            CardGameRuleController cardGameRuleController = new CardGameRuleController();
            _winner = cardGameRuleController.DetermineWinner(_cardGame.Players);
        }

        private static void ShowResult()
        {
            _userInteraction.ShowResult(_cardGame.Players, _winner);
        }
    }
}
