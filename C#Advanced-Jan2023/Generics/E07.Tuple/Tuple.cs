namespace E07.Tuple
{
	public class CustomTuple<T1, T2>
    {
        //define properties for both values
        public T1 FirstItem { get; set; }
        public T2 SecondItem { get; set; }

        //create a constructor
        public CustomTuple(T1 firstItem, T2 secondItem)
        {
            FirstItem = firstItem;
            SecondItem = secondItem;
        }

        public void Print()
        {
            Console.WriteLine($"{FirstItem} -> {SecondItem}");
        }
    }
}
