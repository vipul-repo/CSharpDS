using System;
using System.Collections.Generic;

namespace CSharpDS
{
    class PromotionWinnerProblem
    {
        public int IsWinner(List<List<string>> codeList, List<string> shoppingCart)
        {
            if (codeList == null || codeList.Count == 0)
                return 0;

            if (shoppingCart == null || shoppingCart.Count == 0)
                return 0;

            int i = 0, j = 0;

            for (int cIndex = 0; cIndex < shoppingCart.Count; cIndex++)
            {
                if (codeList[i] == null || codeList[i].Count == 0)
                {
                    return 0;
                }

                if (codeList[i][j] == shoppingCart[cIndex] || codeList[i][j].Equals("anything", StringComparison.OrdinalIgnoreCase))
                {
                    j++;

                    if (j == codeList[i].Count)
                    {
                        i++;
                        j = 0;
                    }

                    if (i == codeList.Count)
                    {
                        return 1;
                    }
                }
                else
                {
                    cIndex -= j;
                    j = 0;
                }

            }

            return 0;
        }
    }
}