namespace Froggy
{
    using System.Collections;
    using System.Collections.Generic;

    public class Lake : IEnumerable<int>
    {
        private int[] stones;

        public Lake(int[] stones)
        {
            this.stones = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.stones.Length; i+=2)
            {
                yield return this.stones[i];
            }


            int lastOfIndex = (this.stones.Length - 1) % 2 == 0 ? this.stones.Length - 2 : this.stones.Length - 1; 

            for (int i = lastOfIndex; i > 0; i-=2)
            {
                yield return this.stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}