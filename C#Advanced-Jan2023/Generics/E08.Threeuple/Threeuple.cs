namespace E08.Threeuple
{
	public class CustomTuple<T1, T2, T3>
    {
        //define properties for both values
        public T1 FirstItem { get; set; }
        public T2 SecondItem { get; set; }
        public T3 ThirdItem { get; set; }

        //create a constructor
        public CustomTuple(T1 firstItem, T2 secondItem, T3 thirdItem)
        {
            FirstItem = firstItem;
            SecondItem = secondItem;
            ThirdItem = thirdItem;
        }

        public void Print()
        {
            Console.WriteLine($"{FirstItem} -> {SecondItem} -> {ThirdItem}");
        }
    }
}

