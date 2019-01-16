using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SibIntek
{
	/// <summary>
	/// Кольцевой связный список
	/// </summary>
	/// <typeparam name="T">Тип элементов списка</typeparam>
	public class UniqueCircularList<T> : IEnumerable<T>
	{
		Dictionary<T, Node<T>> dictionary { get; set; } =
			new Dictionary<T, Node<T>>();

		public Node<T> First { get; set; }
		public Node<T> Last { get; set; }
		int count;

		public Node<T> this[T item]
		{
			get
			{
				return dictionary[item];
			}
		}

		public void Add(T item)
		{
			var node = new Node<T>(item);

			if (!dictionary.TryAdd(item, node))
				return;

			if (First == null)
			{
				First = node;
				Last = node;
				Last.Next = First;
			}
			else
			{
				node.Next = First;
				Last.Next = node;
				Last = node;
			}

			count++;
		}
		public bool Remove(T item)
		{
			if (!dictionary.Remove(item))
				return false;

			var current = First;
			var previous = default(Node<T>);

			if (IsEmpty) return false;

			do
			{
				if (current.Item.Equals(item))
				{
					if (previous != null)
					{
						previous.Next = current.Next;

						if (current == Last)
							Last = previous;
					}
					else
					{
						if (count == 1)
						{
							First = Last = null;
						}
						else
						{
							First = current.Next;
							Last.Next = current.Next;
						}
					}
					count--;
					
					return true;
				}

				previous = current;
				current = current.Next;
			} while (current != First);

			return false;
		}

		public int Count { get { return count; } }
		public bool IsEmpty { get { return count == 0; } }

		public void Clear()
		{
			dictionary.Clear();
			First = null;
			Last = null;
			count = 0;
		}

		public bool Contains(T data)
		{
			var current = First;
			if (current == null) return false;
			do
			{
				if (current.Item.Equals(data))
					return true;
				current = current.Next;
			}
			while (current != First);
			return false;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)this).GetEnumerator();
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			var current = First;
			do
			{
				if (current != null)
				{
					yield return current.Item;
					current = current.Next;
				}
			}
			while (current != First);
		}
	}
}
