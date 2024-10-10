using System.Collections;

namespace E03.Stack
{
	internal class CustomStack<T> : IEnumerable<T>
    {
        private List<T> stack;

        public CustomStack()
        {
            stack = new List<T>();
        }

        public void Push(List<T> value)
        {
            stack.AddRange(value);
        }

        public T Pop()
        {
            if (stack.Any())
            {
                int lastIndex = stack.Count - 1;
                T element = stack[lastIndex];
                stack.RemoveAt(lastIndex);
                return element;
            }
            
            Console.WriteLine("No elements");
            return default;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = stack.Count - 1; i >= 0; i--)
            {
                yield return stack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
