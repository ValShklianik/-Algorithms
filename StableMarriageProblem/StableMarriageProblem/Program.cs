using System;
using System.Collections.Generic;

namespace StableMarriageProblem
{
    public class Program
    {
        static void Main(string[] args)
        {
            int N = 4;
            var man = new Man[N];
            var woman = new Woman[N];
            int[][] womansPrefs =
            {
                new[]{3, 2, 0, 1},
                new[]{1, 0, 2, 3},
                new[]{0, 2, 3, 1},
                new[]{3, 2, 0, 1},
            };

            int[][] mansPrefs =
            {
                new[]{2, 1, 3, 0},
                new[]{3, 2, 0, 1},
                new[]{2, 0, 1, 3},
                new[]{2, 1, 3, 0},
            };

            for (int i = 0; i < N; i++)
            {
                woman[i] = new Woman(womansPrefs[i]);
            }
            List<int> unmarried = new List<int>();
            for (int i = 0; i < N; i++)
            {
                man[i] = new Man(mansPrefs[i]);
                unmarried.Add(i);
            }

            var templist = new List<int>(unmarried);

            while (unmarried.Count > 0)
            {
                foreach (var current in templist)
                {

                    for (int w = 0; w < N; w++)
                    {
                        var tempSpouse = woman[man[current].Pref[w]].Spouse;
                        var result = woman[man[current].Pref[w]].NewMatch(current);
                        if (result == 0)
                        {
                            man[current].Engage(man[current].Pref[w]);
                            unmarried.Remove(current);
                            break;

                        }
                        if (result == 1)
                        {
                            man[tempSpouse].DisEngage();
                            man[current].Engage(man[current].Pref[w]);
                            unmarried.Remove(current);
                            unmarried.Add(tempSpouse);
                            break;
                        }
                    }
                }
                templist = new List<int>(unmarried);
            }



           
            for (int o = 0; o < N; o++)
            {
                Console.Write($"women: {o}");
                Console.Write(" ");
                Console.WriteLine($"man: {man[o].Spouse}");

            }

        }
    }
}