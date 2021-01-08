namespace AoC2020
{
    public class LLNode<T>
    {
        public T Data { get; set; }
        public LLNode<T> Next { get; set; }

        public LLNode(T input)
        {
            Data = input;
        }
    }
}