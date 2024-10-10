namespace E02.GenericBoxofInteger
{
	public class Box<T>
    {
        T boxValue = default;
        public T MyProperty { get; set; }

        public Box(T value)
        {
            boxValue = value;
        }

        public override string ToString()
        {
            Type type = typeof(T);

            return ($"{type.FullName}: {boxValue}");
        }
    }
}
