namespace E01.ListyIterator
{
	public class ListyIterator<T>
    {
        private List<T> list;
        private int index = 0;

        public ListyIterator(List<T> list)
        {
            if (list.Any())
            {
                this.list = list;
            }
            else
            {
                this.list = new List<T>();
            }             
        }

        public bool Move()
        {
            if (++index < list.Count)
            {
                Console.WriteLine("True");
                return true;
            }

            index--;
            Console.WriteLine("False");
            return false;
        }

        public bool HasNext()
        {
            if ((index + 1) < list.Count)
            {
                Console.WriteLine("True");
                return true;
            }

            Console.WriteLine("False");
            return false;
        }

        public void Print()
        {
            if (list.Any())
            {
                Console.WriteLine(list[index]);
            }
            else
            {
                Console.WriteLine("Invalid Operation!");
            }
        }
    }
}
