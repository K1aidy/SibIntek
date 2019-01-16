using System;
using System.Linq;

namespace SibIntek
{
	public class Changer
	{
		public string ChangeFirstNumber(string input)
		{
			//проверка
			if (input == null)
				throw new ArgumentNullException(nameof(input));

			if (string.IsNullOrWhiteSpace(input))
				throw new ArgumentException(nameof(input));

			//подготовка данных
			var str_numbers = "0123456789";
			var numbers = new UniqueCircularList<char>();
			var output = new char[input.Count()];

			foreach (var item in str_numbers)
			{
				numbers.Add(item);
			}


			var beginIndex = default(int?);
			var endIndex = default(int?);
			var findIndex = false;

			//вычленение первого вхождения числа 
			//и копирование данных в выходной массив
			for (int i = 0; i < input.Length; i++)
			{
				output[i] = input[i];

				if (numbers.Contains(input[i])
					&& !findIndex)
				{
					if (!beginIndex.HasValue)
						beginIndex = i;
					if (beginIndex.HasValue)
						endIndex = i;
					continue;
				}
				if (i > 0
					&& !numbers.Contains(input[i])
					&& numbers.Contains(input[i - 1]))
						findIndex = true;
			}

			//обработка числа в выходном массиве
			if (beginIndex.HasValue || endIndex.HasValue)
			{
				var isChange = false;

				output[endIndex.Value] =
							numbers[output[endIndex.Value]].Next.Item;

				if (input[endIndex.Value] == numbers.Last.Item)
				{
					for (int i = endIndex.Value - 1; i >= beginIndex.Value; i--)
					{
						if (!isChange)
						{
							if (input[i] == numbers.Last.Item)
							{
								output[i] = numbers[input[i]].Next.Item;
							}
							else
								isChange = true;

							if (i == beginIndex.Value && i > 0)
								output[i - 1] = numbers.First.Next.Item;
						}
					}
				}
			}

			//возвращение результатов
			return new string(output);
		}
	}
}
