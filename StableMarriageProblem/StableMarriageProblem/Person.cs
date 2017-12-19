using System;

namespace StableMarriageProblem
{
    public class Man
    {
        public bool married;
        public int[] Pref;
        public int Spouse { get; set; }

        public Man(int[] P)
        {
            Pref = new int[500];
            for (int i = 0; i < P.Length; i++)
            {
                Pref[i] = P[i];
            }
            married = false;
            Spouse = 0;
        }

        public void Engage(int w)
        {
            Spouse = w;

        }

        public void DisEngage()
        {
            Spouse = 0;

        }


    }

    public class Woman
    {
        public bool married;
        public int[] Pref;
        int Status;
        public int Spouse { get; set; }

        public Woman(int[] P)
        {
            Pref = new int[500];
            for (int i = 0; i < P.Length; i++)
            {
                Pref[i] = P[i];
            }
            married = false;
            Spouse = 0;
        }

        public int NewMatch(int m)
        {
            if (Status == 0)
            {
                Status = 1;
                Spouse = m;
                return 0;
            }
            if (Status == 1)
            {
                if (Array.IndexOf(Pref, m) < Array.IndexOf(Pref, Spouse))
                {
                    Spouse = m;
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
                return -1;
        }
    }
}
