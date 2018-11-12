using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingScoreProject
{
    enum BonusRollType
    {
        None,
        AddRollAfter,
        AddTwoRollsAfter
    }

    class BowlingScoreCounter
    {
        private int _score;
        private string[] _frameRolls;
        private BonusRollType[] _bonusRollType;

        public BowlingScoreCounter()
        {
            _score = 0;
            _bonusRollType = new BonusRollType[] {
                BonusRollType.None,
                BonusRollType.None,
                BonusRollType.None
            };
        }

        public void ComputeFromInput()
        {
            Console.WriteLine("Enter pins knocked down per roll per frame separated by space");
            for (int frame = 0; frame < 10; frame++)
            {
                Console.WriteLine("Pins knocked down for frame " + (frame+1).ToString());
                var frameInput = Console.ReadLine();
                _frameRolls = frameInput.Split(' ');

                switch (_frameRolls.Length)
                {
                    case 1:
                        // Assume correct input (10). TODO: Input checking
                        ProcessStrike();
                        break;
                    case 2:
                        ProcessSpareOrOther();
                        break;
                    default:
                        break;
                }
            }

            AddBonusFramesIfNeeded();
        }

        private void ProcessStrike()
        {
            _score += 10;
            _bonusRollType[2] = BonusRollType.AddTwoRollsAfter;

            ProcessRollTypeFlags();
        }

        private void ProcessSpareOrOther()
        {
            int firstRoll = Convert.ToInt32(_frameRolls[0]);
            int secondRoll = Convert.ToInt32(_frameRolls[1]);

            _score = _score + firstRoll + secondRoll;

            if (firstRoll + secondRoll == 10)
                _bonusRollType[2] = BonusRollType.AddRollAfter;
            else
                _bonusRollType[2] = BonusRollType.None;

            ProcessRollTypeFlags();
        }

        private void ProcessRollTypeFlags()
        {
            int firstRoll;
            int secondRoll;

            if (_bonusRollType[0] == BonusRollType.AddTwoRollsAfter)
            {
                firstRoll = Convert.ToInt32(_frameRolls[0]);
                _score += firstRoll;
                _bonusRollType[0] = BonusRollType.None;
            }

            if (_bonusRollType[1] == BonusRollType.AddRollAfter)
            {
                firstRoll = Convert.ToInt32(_frameRolls[0]);
                _score += firstRoll;
                _bonusRollType[1] = BonusRollType.None;
            }
            else if (_bonusRollType[1] == BonusRollType.AddTwoRollsAfter)
            {
                firstRoll = Convert.ToInt32(_frameRolls[0]);
                _score += firstRoll;

                if (_frameRolls.Length == 2)
                {
                    secondRoll = Convert.ToInt32(_frameRolls[1]);
                    _score += secondRoll;
                    _bonusRollType[1] = BonusRollType.None;
                }
            }

            // Shift _bonusRollType flags to the left. Next flag will be
            // placed in index 2
            _bonusRollType[0] = _bonusRollType[1];
            _bonusRollType[1] = _bonusRollType[2];
            _bonusRollType[2] = BonusRollType.None;
        }

        private void AddBonusFramesIfNeeded()
        {
            var bonusRollInput = "";

            if (_bonusRollType[1] == BonusRollType.AddRollAfter)
            {
                Console.WriteLine("1 Bonus Roll");
                Console.WriteLine("Pins knocked down for bonus roll 1:");
                bonusRollInput = Console.ReadLine();
                //TODO: Add input checking
                _score += Convert.ToInt32(bonusRollInput);
            }
            else if (_bonusRollType[1] == BonusRollType.AddTwoRollsAfter)
            {
                Console.WriteLine("2 Bonus Rolls");
                Console.WriteLine("Pins knocked down for bonus roll 1:");
                bonusRollInput = Console.ReadLine();
                //TODO: Add input checking
                _score += Convert.ToInt32(bonusRollInput);

                if (_bonusRollType[0] == BonusRollType.AddTwoRollsAfter)
                    _score += Convert.ToInt32(bonusRollInput);

                Console.WriteLine("Pins knocked down for bonus roll 2:");
                bonusRollInput = Console.ReadLine();
                //TODO: Add input checking
                _score += Convert.ToInt32(bonusRollInput);
            }
        }

        public void PrintTotal()
        {
            Console.WriteLine("Total score is " + _score.ToString());
            Console.ReadLine();
        }
    }
}
