using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SibIntek.Test
{
	[TestClass]
	public class ChangerTest
	{
		[TestMethod]
		public void NullString_Exception()
		{
			//arrange
			var input = default(string);
			var changer = new Changer();

			//act
			try
			{
				var output = changer.ChangeFirstNumber(input);
			}
			catch (Exception ex)
			{
				//assert
				Assert.IsNull(input);
				Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
			}
		}

		[TestMethod]
		public void EmptyString_Exception()
		{
			//arrange
			var input = String.Empty;
			var changer = new Changer();

			//act
			try
			{
				var output = changer.ChangeFirstNumber(input);
			}
			catch (Exception ex)
			{
				//assert
				Assert.IsInstanceOfType(ex, typeof(ArgumentException));
			}
		}

		[TestMethod]
		public void WhiteSpaceString_Exception()
		{
			//arrange
			var input = "  ";
			var changer = new Changer();

			//act
			try
			{
				var output = changer.ChangeFirstNumber(input);
			}
			catch (Exception ex)
			{
				//assert
				Assert.IsInstanceOfType(ex, typeof(ArgumentException));
			}
		}

		[TestMethod]
		public void BeginWithManyNineNumber_TrancateStr()
		{
			//arrange
			var input = "999999999fgdg";
			var changer = new Changer();

			//act
			var output = changer.ChangeFirstNumber(input);

			//assert
			Assert.AreEqual(output, "000000000fgdg");
		}

		[TestMethod]
		public void MiddleWithManyNineNumber_TrancateStr()
		{
			//arrange
			var input = "aa99fg";
			var changer = new Changer();

			//act
			var output = changer.ChangeFirstNumber(input);

			//assert
			Assert.AreEqual(output, "a100fg");
		}

		[TestMethod]
		public void NotNumber_NotReplace()
		{
			//arrange
			var input = "sadasd&)&(^#$";
			var changer = new Changer();

			//act
			var output = changer.ChangeFirstNumber(input);

			//assert
			Assert.AreEqual(output, input);
		}

		[TestMethod]
		public void GrateThenLongMax_IsAccess()
		{
			//arrange
			var input = $"aaa{long.MaxValue}111fgdg";
			var changer = new Changer();

			//act
			var output = changer.ChangeFirstNumber(input);

			//assert
			Assert.AreEqual(output, $"aaa{long.MaxValue}112fgdg");
		}

		[TestMethod]
		public void EmptyInMiddle_IncrementLeftNumber()
		{
			//arrange
			var input = $"aaa999 111fgdg";
			var changer = new Changer();

			//act
			var output = changer.ChangeFirstNumber(input);

			//assert
			Assert.AreEqual(output, $"aa1000 111fgdg");
		}
	}
}
