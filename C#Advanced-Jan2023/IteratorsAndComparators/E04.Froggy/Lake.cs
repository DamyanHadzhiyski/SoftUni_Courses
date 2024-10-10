using System.Collections;

namespace E04.Froggy
{
	internal class Lake : IEnumerable<int>
    {
        private List<int> stones;

        public Lake(List<int> stones)
        {
            Stones = stones;
        }
        public List<int> Stones { get; set; }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < Stones.Count; i++)
            {
                if (i % 2 == 0)
                { 
                    yield return Stones[i];
                }
            }

            for (int i = Stones.Count - 1; i >= 0; i--)
            {

                if (i % 2 != 0)
                {
                    yield return Stones[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
