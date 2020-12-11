using System;
using System.Linq;

namespace CandidateTesting.AndersonSilvaGarcia
{
    public class Adjacent
    {
        private int[] Values { get; }
        private int Initial { get; }
        private int Final { get; }

        public Adjacent(int[] values, int initial, int final)
        {
            Values = values;
            Initial = initial;
            Final = final;
        }
        public Adjacent(int[] values)
        {
            Values = values;
        }
     

        public bool IsEqualValue() => Values[Initial] == Values[Final];
        public bool IsSequential() => Values[Initial..Final].SequenceEqual(new int[] { Values[Initial], Values[Initial] + 1 });
        public bool ExistValueBetweenSequence() => Values.Any(c => c > Values[Initial] && c < Values[Final]);
        public bool IsAdjacentValue()
        {
            if (IsEqualValue()) return true;

            if (IsSequential()) return true;

            if (!ExistValueBetweenSequence()) return true;

            return false;
        }
        public int ShortestDistance() => Math.Abs(Values[Initial] - Values[Final]);
        public string MaxAdjacentDistance()
        {
            if (IsAdjacentValue() && !IsEqualValue())
                return string.Format(Constant.MaxDistanceAdjacent, ShortestDistance());

            return Constant.Nothing;
        }
        public string MaxDistanceAllValues()
        {
            int maxDistance = 0;
            for (int start = 0; start < Values.Length; start++)
            {
                for (int end = start + 1; end < Values.Length; end++)
                {
                    if (IsAdjacentValue())
                    {
                        int distance = ShortestDistance();
                        maxDistance = distance > maxDistance ? distance : maxDistance;
                    }
                }
            }

            return maxDistance == 0 ? Constant.Nothing : string.Format(Constant.MaxDistanceAdjacentMatriz, maxDistance);
        }
    }
}
