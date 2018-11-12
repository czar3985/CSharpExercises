using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingScoreProject
{
    enum BonusRollType
    {
        None,
        AddRollAfter,
        AddSecondRollAfter
    }

    class BowlingScoreCounter
    {
        private int _score;
        private string[] _frameRolls;
        private BonusRollType[,] _bonusRollTypePerFrame;

        public BowlingScoreCounter()
        {
            _score = 0;
            _bonusRollTypePerFrame = new BonusRollType[,] {
                { BonusRollType.None, BonusRollType.None },
                { BonusRollType.None, BonusRollType.None },
                { BonusRollType.None, BonusRollType.None },
                { BonusRollType.None, BonusRollType.None },
                { BonusRollType.None, BonusRollType.None },
                { BonusRollType.None, BonusRollType.None },
                { BonusRollType.None, BonusRollType.None },
                { BonusRollType.None, BonusRollType.None },
                { BonusRollType.None, BonusRollType.None },
                { BonusRollType.None, BonusRollType.None },
            };
        }

        public void ComputeFromInput()
        {
            Console.WriteLine("Enter pins knocked down per roll per frame separated by space");
            for (int frame = 0; frame < 10; frame++)
            {
                Console.WriteLine("Pins knocked down for frame " + frame);
                var frameInput = Console.ReadLine();
                _frameRolls = frameInput.Split(' ');

                switch (_frameRolls.Length)
                {
                    case 1:
                        // Assume correct input (10). TODO: Error checking
                        ProcessStrike(frame);
                        break;
                    case 2:
                        ProcessSpareOrOther(frame);
                        break;
                    default:
                        break;
                }
            }
        }

        private void ProcessStrike(int frame)
        {
            _score += 10;
            _bonusRollTypePerFrame[frame, 0] = BonusRollType.AddRollAfter;
            _bonusRollTypePerFrame[frame, 1] = BonusRollType.AddSecondRollAfter;

            if ((frame-1 >= 0) &&
                (_bonusRollTypePerFrame[frame-1, 0] == BonusRollType.AddRollAfter))
            {
                _score += 10;
                _bonusRollTypePerFrame[frame-1, 0] = BonusRollType.None;
            }

            if ((frame-2 >= 0) &&
                (_bonusRollTypePerFrame[frame-2, 0] == BonusRollType.AddSecondRollAfter))
            {
                _score += 10;
                _bonusRollTypePerFrame[frame-2, 0] = BonusRollType.None;
            }
        }

        private void ProcessSpareOrOther(int frame)
        {
            int firstRoll = Convert.ToInt32(_frameRolls[0]);
            int secondRoll = Convert.ToInt32(_frameRolls[1]);

            _score = _score + firstRoll + secondRoll;

            if (firstRoll + secondRoll == 10)
                _bonusRollTypePerFrame[frame, 0] = BonusRollType.AddRollAfter;

            if ((frame-1 >= 0) &&
                (_bonusRollTypePerFrame[frame-1, 0] == BonusRollType.AddRollAfter))
            {
                _score += firstRoll;
                _bonusRollTypePerFrame[frame-1, 0] = BonusRollType.None;
            }

            if ((frame-2 >= 0) &&
                (_bonusRollTypePerFrame[frame-2, 0] == BonusRollType.AddSecondRollAfter))
            {
                _score += secondRoll;
                _bonusRollTypePerFrame[frame-2, 0] = BonusRollType.None;
            }

            if ((frame-2 >= 0) &&
                (_bonusRollTypePerFrame[frame-2, 0] == BonusRollType.AddSecondRollAfter))
            {
                _score += firstRoll;
                _bonusRollTypePerFrame[frame-2, 0] = BonusRollType.None;
            }
        }

        public void PrintTotal()
        {
            Console.WriteLine("Total score is " + _score.ToString());
            Console.ReadLine();
        }
    }
}
