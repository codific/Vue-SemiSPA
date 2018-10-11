using System;
using System.Collections.Generic;

namespace VueDemo.Functions
{
    public static class GameFunctions
    {
        public static GameResult GetGameResult(string[] playground)
        {
            List<int[]> winnerCombination = new List<int[]>()
            {
                new int[3] { 0, 1, 2 },
                new int[3] { 3, 4, 5 },
                new int[3] { 6, 7, 8 },
                new int[3] { 0, 3, 6 },
                new int[3] { 1, 4, 7 },
                new int[3] { 2, 5, 8 },
                new int[3] { 0, 4, 8 },
                new int[3] { 2, 4, 6 }
            };

            foreach (var combination in winnerCombination)
            {
                if (playground[combination[0]] == playground[combination[1]] && playground[combination[1]] == playground[combination[2]] && playground[combination[0]] != null)
                {
                    GameResult result = new GameResult
                    {
                        WinnerCombination = new int[3] { combination[0], combination[1], combination[2] },
                        WinnerSign = playground[combination[0]]
                    };
                    return result;
                }
            }

            return null;
        }
    }

    public class GameResult
    {
        public int[] WinnerCombination { get; set; }

        public string WinnerSign { get; set; }
    }
}
