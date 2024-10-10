namespace E06.GenericCountMethodDouble
{

	public class Box<T> where T : IComparable
    {
        private Type type = typeof(T);

        private List<T> boxValue;

        public T BoxValue
        {
            set { boxValue.Add(value); }
        }

        public Box()
        {
            boxValue = new List<T>();
        }

        //method to add new elements
        public void Add(T value)
        {
            BoxValue = value;
        }

        //method to swap two elements
        public void Swap(int index1, int index2)
        {
            if (CheckIndex(index1) && CheckIndex(index2))
            {
                //get the value for both elements
                T firstElement = boxValue.ElementAt(index1);
                T secondElement = boxValue.ElementAt(index2);

                //insert the second element on the position of the firt
                //and remove the first element
                boxValue.Insert(index1, secondElement);
                boxValue.RemoveAt(index1 + 1);

                //insert the first element on the position of the second
                //and remove the second element
                boxValue.Insert(index2, firstElement);
                boxValue.RemoveAt(index2 + 1);
            }
        }

        //method to check if indexes are valide
        private bool CheckIndex(int index)
        {
            if (index >= 0 || index < boxValue.Count)
            {
                return true;
            }

            return false;
        }

        //method to compare elements
        public int Compare(T compareElement)
        {
            int count = 0;

            foreach (var element in boxValue)
            {
                if (element.CompareTo(compareElement) > 0)
                {
                    count++;
                }
            }

            return count;
        }

        //method to print all elements in the lits
        public void PrintAll()
        {
            foreach (var element in boxValue)
            {
                Console.WriteLine($"{type.FullName}: {element}");
            }
        }
    }
}