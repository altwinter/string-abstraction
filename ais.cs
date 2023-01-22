namespace Abstract
{
    public class AIS
    {
        private AIS()
        {
        }

        private static string bottom = "𐤀";
        private static string top = "𐤕";

        // Return one of the best string abstraction
        private static string Max(HashSet<string> values)
        {
            if (values.Count == 0)
                return bottom;

            var gauge = values.First();

            foreach (var val in values)
            {
                if (isBetter(gauge, val)) gauge = val;
            }

            return gauge;
        }

        private static Boolean isBetter(string value1, string value2)
        {
            var value1Len = value1.Count();
            var value2Len = value2.Count();

            int nbrTop1 = value1.Where(x => (x == '*')).Count();
            int nbrTop2 = value2.Where(x => (x == '*')).Count();

            int nbrLetter1 = value1Len - nbrTop1;
            int nbrLetter2 = value2Len - nbrTop2;

            if (nbrLetter2 > nbrLetter1) return true;
            if (nbrTop2 > nbrTop1) return true;

            return false;
        }

        private static string AddTop(string value)
        {
            if (value == "")
                return top;

            if (value.EndsWith(top))
                return value;

            return value + top;
        }

        public static string computation(string value1, string value2)
        {


            if (value1 == "") return bottom;
            if (value2 == "") return bottom;



            int i, j;
            int s1Len = value1.Length;
            int s2Len = value2.Length;

            int[] z = new int[(s1Len + 1) * (s2Len + 1)];

            // Create two dimension table of string list
            List<List<HashSet<string>>> c = new List<List<HashSet<string>>>();
            for (i = 0; i <= s1Len; ++i)
                c.Add(new List<HashSet<string>>());

            for (i = 0; i <= s1Len; ++i)
            {
                for (j = 0; j <= s2Len; ++j)
                {
                    c[i].Add(new HashSet<string>());
                }
            }

            // Init two dimensional table
            c[0][0].Add("");
            for (i = 1; i <= s1Len; ++i)
                c[i][0].Add(top);

            for (j = 1; j <= s2Len; ++j)
                c[0][j].Add(top);

            // Compute all string values possible
            for (i = 1; i <= s1Len; ++i)
            {
                for (j = 1; j <= s2Len; ++j)
                {
                    if (value1[i - 1] == value2[j - 1])
                    {
                        foreach (var val in c[i - 1][j - 1])
                        {
                            c[i][j].Add(val + value1[i - 1]);
                        }

                        foreach (var valTop in c[i - 1][j])
                        {
                            c[i][j].Add(AddTop(valTop));
                        }

                        foreach (var valLeft in c[i][j - 1])
                        {
                            c[i][j].Add(AddTop(valLeft));
                        }
                    }
                    else
                    {
                        foreach (var valTop in c[i - 1][j])
                        {
                            c[i][j].Add(AddTop(valTop));
                        }

                        foreach (var valLeft in c[i][j - 1])
                        {
                            c[i][j].Add(AddTop(valLeft));

                        }

                    }


                }
            }

            return Max(c[s1Len][s2Len]);
        }

    }
}