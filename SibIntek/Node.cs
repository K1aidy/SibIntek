namespace SibIntek
{
	public class Node<T>
	{
		public Node(T data)
		{
			Item = data;
		}
		public T Item { get; set; }
		public Node<T> Next { get; set; }
	}
}
