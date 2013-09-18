using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;

namespace demoncodemonkey.LittleHelpers
{
	[TestClass]
	public class EnsureTests
	{
		#region IsNull - Int

		[TestMethod]
		public void IsNull_ShouldSucceed_UsingInt()
		{
			int? nullableObject = null;
			Ensure.That(nullableObject).IsNull();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsNull_ShouldFailWhenNotNull_UsingInt()
		{
			int? nullableObject = 1;
			Ensure.That(nullableObject).IsNull();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsNull_ShouldFailWhenNotNullAndZero_UsingInt()
		{
			int? nullableObject = 0;
			Ensure.That(nullableObject).IsNull();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsNull_ShouldFailWhenNotNullAndNegative_UsingInt()
		{
			int? nullableObject = -999;
			Ensure.That(nullableObject).IsNull();
		}

		#endregion

		#region IsNull - String

		[TestMethod]
		public void IsNull_ShouldSucceed_UsingString()
		{
			string nullableObject = null;
			Ensure.That(nullableObject).IsNull();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsNull_ShouldFailWhenNotNullAndEmpty_UsingString()
		{
			string nullableObject = "";
			Ensure.That(nullableObject).IsNull();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsNull_ShouldFailWhenNotNullAndValidString_UsingString()
		{
			string nullableObject = "abc";
			Ensure.That(nullableObject).IsNull();
		}

		#endregion


		#region IsNotNull - Int

		[TestMethod]
		public void IsNotNull_ShouldSucceed_UsingInt()
		{
			int? nullableObject = 0;
			Ensure.That(nullableObject).IsNotNull();
			nullableObject = 1;
			Ensure.That(nullableObject).IsNotNull();
			nullableObject = 999;
			Ensure.That(nullableObject).IsNotNull();
			nullableObject = -999;
			Ensure.That(nullableObject).IsNotNull();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsNotNull_ShouldFailWhenNotNull_UsingInt()
		{
			int? nullableObject = null;
			Ensure.That(nullableObject).IsNotNull();
		}

		#endregion

		#region IsNotNull - String

		[TestMethod]
		public void IsNotNull_ShouldSucceed_UsingString()
		{
			string nullableObject = "";
			Ensure.That(nullableObject).IsNotNull();
			nullableObject = "abc";
			Ensure.That(nullableObject).IsNotNull();
			nullableObject = "ABC";
			Ensure.That(nullableObject).IsNotNull();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsNotNull_ShouldFailWhenNotNull_UsingString()
		{
			string nullableObject = null;
			Ensure.That(nullableObject).IsNotNull();
		}

		#endregion


		#region IsEmpty - String

		[TestMethod]
		public void IsEmpty_ShouldSucceed_UsingString()
		{
			string input = "";
			Ensure.That(input).IsEmpty();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsEmpty_ShouldFailWhenNotEmpty_UsingString()
		{
			string input = "abc";
			Ensure.That(input).IsEmpty();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsEmpty_ShouldThrow_WhenGivenNullString()
		{
			string input = null;
			Ensure.That(input).IsEmpty();
		}

		#endregion

		#region IsEmpty - List<string>

		[TestMethod]
		public void IsEmpty_ShouldSucceed_UsingStringList()
		{
			var input = new List<string>();
			Ensure.That(input).IsEmpty();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsEmpty_ShouldFailWhenNotEmpty_UsingStringList()
		{
			var input = new List<string> { "abc" };
			Ensure.That(input).IsEmpty();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsEmpty_ShouldThrow_WhenGivenNullStringList()
		{
			List<string> input = null;
			Ensure.That(input).IsEmpty();
		}

		#endregion

		#region IsEmpty - IEnumerable<string>

		[TestMethod]
		public void IsEmpty_ShouldSucceed_UsingStringEnumerable()
		{
			var input = new List<string>().AsEnumerable();
			Ensure.That(input).IsEmpty();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsEmpty_ShouldFailWhenEmpty_UsingStringEnumerable()
		{
			var input = new List<string> { "abc" }.AsEnumerable();
			Ensure.That(input).IsEmpty();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsEmpty_ShouldThrow_WhenGivenNullStringEnumerable()
		{
			List<string> input = null;
			IEnumerable<string> inputEnumerable = input.AsEnumerable();
			Ensure.That(inputEnumerable).IsEmpty();
		}

		#endregion

		#region IsNotEmpty - String

		[TestMethod]
		public void IsNotEmpty_ShouldSucceed_UsingString()
		{
			string input = "abc";
			Ensure.That(input).IsNotEmpty();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsNotEmpty_ShouldFailWhenEmpty_UsingString()
		{
			string input = "";
			Ensure.That(input).IsNotEmpty();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsNotEmpty_ShouldThrow_WhenGivenNullString()
		{
			string input = null;
			Ensure.That(input).IsNotEmpty();
		}

		#endregion

		#region IsNotEmpty - List<string>

		[TestMethod]
		public void IsNotEmpty_ShouldSucceed_UsingStringList()
		{
			var input = new List<string> { "abc" };
			Ensure.That(input).IsNotEmpty();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsNotEmpty_ShouldFailWhenEmpty_UsingStringList()
		{
			var input = new List<string>();
			Ensure.That(input).IsNotEmpty();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsNotEmpty_ShouldThrow_WhenGivenNullStringList()
		{
			List<string> input = null;
			Ensure.That(input).IsNotEmpty();
		}

		#endregion

		#region IsNotEmpty - IEnumerable<string>

		[TestMethod]
		public void IsNotEmpty_ShouldSucceed_UsingStringEnumerable()
		{
			var input = new List<string> { "abc" }.AsEnumerable();
			Ensure.That(input).IsNotEmpty();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsNotEmpty_ShouldFailWhenEmpty_UsingStringEnumerable()
		{
			var input = new List<string>().AsEnumerable();
			Ensure.That(input).IsNotEmpty();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsNotEmpty_ShouldThrow_WhenGivenNullStringEnumerable()
		{
			List<string> input = null;
			IEnumerable<string> inputEnumerable = input.AsEnumerable();
			Ensure.That(inputEnumerable).IsNotEmpty();
		}

		#endregion


		#region IsEqualTo - Int

		[TestMethod]
		public void IsEqualTo_ShouldSucceed_UsingInt()
		{
			Ensure.That(0).IsEqualTo(0);
			Ensure.That(1).IsEqualTo(1);
			Ensure.That(999).IsEqualTo(999);
			Ensure.That(-999).IsEqualTo(-999);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsEqualTo_ShouldFailWhenGreater_UsingInt()
		{
			Ensure.That(0).IsEqualTo(1);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsEqualTo_ShouldFailWhenLess_UsingInt()
		{
			Ensure.That(1).IsEqualTo(0);
		}

		#endregion

		#region IsEqualTo - String

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsEqualTo_ShouldThrow_WithNullSourceUsingString()
		{
			string input = null;
			string testString = "def";
			Ensure.That(input).IsEqualTo(testString);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsEqualTo_ShouldThrow_WithNullTargetUsingString()
		{
			string input = "abc";
			string testString = null;
			Ensure.That(input).IsEqualTo(testString);
		}

		[TestMethod]
		public void IsEqualTo_ShouldSucceed_UsingString()
		{
			Ensure.That("").IsEqualTo("");
			Ensure.That("a").IsEqualTo("a");
			Ensure.That("abcdef").IsEqualTo("abcdef");
			Ensure.That("ABCDEF").IsEqualTo("ABCDEF");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsEqualTo_ShouldFailWhenGreater_UsingString()
		{
			Ensure.That("b").IsEqualTo("d");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsEqualTo_ShouldFailWhenLess_UsingString()
		{
			Ensure.That("d").IsEqualTo("b");
		}

		#endregion


		#region IsNotEqualTo - Int

		[TestMethod]
		public void IsNotEqualTo_ShouldSucceed_UsingInt()
		{
			Ensure.That(0).IsNotEqualTo(1);
			Ensure.That(1).IsNotEqualTo(999);
			Ensure.That(999).IsNotEqualTo(-999);
			Ensure.That(-999).IsNotEqualTo(0);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsNotEqualTo_ShouldFailWhenEqual_UsingInt()
		{
			Ensure.That(0).IsNotEqualTo(0);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsNotEqualTo_ShouldFailWhenEqualAndNegative_UsingInt()
		{
			Ensure.That(-999).IsNotEqualTo(-999);
		}

		#endregion

		#region IsNotEqualTo - String

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsNotEqualTo_ShouldThrow_WithNullSourceUsingString()
		{
			string input = null;
			string testString = "def";
			Ensure.That(input).IsNotEqualTo(testString);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsNotEqualTo_ShouldThrow_WithNullTargetUsingString()
		{
			string input = "abc";
			string testString = null;
			Ensure.That(input).IsNotEqualTo(testString);
		}

		[TestMethod]
		public void IsNotEqualTo_ShouldSucceed_UsingString()
		{
			Ensure.That("").IsNotEqualTo("a");
			Ensure.That("a").IsNotEqualTo("");
			Ensure.That("a").IsNotEqualTo("abc");
			Ensure.That("abcdef").IsNotEqualTo("ABCDEF");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsNotEqualTo_ShouldFailWhenEqual_UsingString()
		{
			Ensure.That("abc").IsNotEqualTo("abc");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsNotEqualTo_ShouldFailWhenEqualAndEmpty_UsingString()
		{
			Ensure.That("").IsNotEqualTo("");
		}

		#endregion


		#region IsLessThan - Int

		[TestMethod]
		public void IsLessThan_ShouldSucceed_UsingInt()
		{
			Ensure.That(2).IsLessThan(999);
			Ensure.That(1).IsLessThan(2);
			Ensure.That(0).IsLessThan(2);
			Ensure.That(-1).IsLessThan(2);
			Ensure.That(-999).IsLessThan(2);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsLessThan_ShouldFailWhenGreater_UsingInt()
		{
			Ensure.That(1).IsLessThan(0);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsLessThan_ShouldFailWhenEqual_UsingInt()
		{
			Ensure.That(1).IsLessThan(1);
		}

		#endregion

		#region IsLessThan - String

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsLessThan_ShouldThrow_WithNullSourceUsingString()
		{
			string input = null;
			string testString = "ccc";
			Ensure.That(input).IsLessThan(testString);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsLessThan_ShouldThrow_WithNullTargetUsingString()
		{
			string input = "aaa";
			string testString = null;
			Ensure.That(input).IsLessThan(testString);
		}

		[TestMethod]
		public void IsLessThan_ShouldSucceed_UsingString()
		{
			Ensure.That("b").IsLessThan("d");
			Ensure.That("abc").IsLessThan("abcdef");
			Ensure.That("abc").IsLessThan("z");
			Ensure.That("B").IsLessThan("D");
			Ensure.That("ABC").IsLessThan("ABCDEF");
			Ensure.That("ABC").IsLessThan("Z");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsLessThan_ShouldFailWhenGreater_UsingString()
		{
			Ensure.That("d").IsLessThan("b");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsLessThan_ShouldFailWhenEqual_UsingString()
		{
			Ensure.That("abc").IsLessThan("abc");
		}

		#endregion


		#region IsGreaterThan - Int

		[TestMethod]
		public void IsGreaterThan_ShouldSucceed_UsingInt()
		{
			Ensure.That(999).IsGreaterThan(2);
			Ensure.That(2).IsGreaterThan(1);
			Ensure.That(2).IsGreaterThan(0);
			Ensure.That(2).IsGreaterThan(-1);
			Ensure.That(2).IsGreaterThan(-999);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsGreaterThan_ShouldFailWhenGreater_UsingInt()
		{
			Ensure.That(0).IsGreaterThan(1);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsGreaterThan_ShouldFailWhenEqual_UsingInt()
		{
			Ensure.That(1).IsGreaterThan(1);
		}

		#endregion

		#region IsGreaterThan - String

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsGreaterThan_ShouldThrow_WithNullSourceUsingString()
		{
			string input = null;
			string testString = "ccc";
			Ensure.That(input).IsGreaterThan(testString);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsGreaterThan_ShouldThrow_WithNullTargetUsingString()
		{
			string input = "aaa";
			string testString = null;
			Ensure.That(input).IsGreaterThan(testString);
		}

		[TestMethod]
		public void IsGreaterThan_ShouldSucceed_UsingString()
		{
			Ensure.That("d").IsGreaterThan("b");
			Ensure.That("abcdef").IsGreaterThan("abc");
			Ensure.That("z").IsGreaterThan("abc");
			Ensure.That("D").IsGreaterThan("B");
			Ensure.That("ABCDEF").IsGreaterThan("ABC");
			Ensure.That("Z").IsGreaterThan("ABC");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsGreaterThan_ShouldFailWhenGreater_UsingString()
		{
			Ensure.That("b").IsGreaterThan("d");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsGreaterThan_ShouldFailWhenEqual_UsingString()
		{
			Ensure.That("abc").IsGreaterThan("abc");
		}

		#endregion


		#region IsLessThanOrEqualTo - Int

		[TestMethod]
		public void IsLessThanOrEqualTo_ShouldSucceed_UsingInt()
		{
			Ensure.That(2).IsLessThanOrEqualTo(999);
			Ensure.That(1).IsLessThanOrEqualTo(2);
			Ensure.That(0).IsLessThanOrEqualTo(2);
			Ensure.That(-1).IsLessThanOrEqualTo(2);
			Ensure.That(-999).IsLessThanOrEqualTo(2);
			Ensure.That(1).IsLessThanOrEqualTo(1);
			Ensure.That(-999).IsLessThanOrEqualTo(-999);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsLessThanOrEqualTo_ShouldFailWhenGreater_UsingInt()
		{
			Ensure.That(1).IsLessThanOrEqualTo(0);
		}

		#endregion

		#region IsLessThanOrEqualTo - String

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsLessThanOrEqualTo_ShouldThrow_WithNullSourceUsingString()
		{
			string input = null;
			string testString = "ccc";
			Ensure.That(input).IsLessThanOrEqualTo(testString);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsLessThanOrEqualTo_ShouldThrow_WithNullTargetUsingString()
		{
			string input = "aaa";
			string testString = null;
			Ensure.That(input).IsLessThanOrEqualTo(testString);
		}

		[TestMethod]
		public void IsLessThanOrEqualTo_ShouldSucceed_UsingString()
		{
			Ensure.That("b").IsLessThanOrEqualTo("d");
			Ensure.That("abc").IsLessThanOrEqualTo("abcdef");
			Ensure.That("abc").IsLessThanOrEqualTo("z");
			Ensure.That("B").IsLessThanOrEqualTo("D");
			Ensure.That("ABC").IsLessThanOrEqualTo("ABCDEF");
			Ensure.That("ABC").IsLessThanOrEqualTo("Z");
			Ensure.That("abc").IsLessThanOrEqualTo("abc");
			Ensure.That("ABC").IsLessThanOrEqualTo("ABC");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsLessThanOrEqualTo_ShouldFailWhenGreater_UsingString()
		{
			Ensure.That("d").IsLessThanOrEqualTo("b");
		}

		#endregion


		#region IsGreaterThanOrEqualTo - Int

		[TestMethod]
		public void IsGreaterThanOrEqualTo_ShouldSucceed_UsingInt()
		{
			Ensure.That(999).IsGreaterThanOrEqualTo(2);
			Ensure.That(2).IsGreaterThanOrEqualTo(1);
			Ensure.That(2).IsGreaterThanOrEqualTo(0);
			Ensure.That(2).IsGreaterThanOrEqualTo(-1);
			Ensure.That(2).IsGreaterThanOrEqualTo(-999);
			Ensure.That(1).IsGreaterThanOrEqualTo(1);
			Ensure.That(-999).IsGreaterThanOrEqualTo(-999);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsGreaterThanOrEqualTo_ShouldFailWhenGreater_UsingInt()
		{
			Ensure.That(0).IsGreaterThanOrEqualTo(1);
		}

		#endregion

		#region IsGreaterThanOrEqualTo - String

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsGreaterThanOrEqualTo_ShouldThrow_WithNullSourceUsingString()
		{
			string input = null;
			string testString = "ccc";
			Ensure.That(input).IsGreaterThanOrEqualTo(testString);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsGreaterThanOrEqualTo_ShouldThrow_WithNullTargetUsingString()
		{
			string input = "aaa";
			string testString = null;
			Ensure.That(input).IsGreaterThanOrEqualTo(testString);
		}

		[TestMethod]
		public void IsGreaterThanOrEqualTo_ShouldSucceed_UsingString()
		{
			Ensure.That("d").IsGreaterThanOrEqualTo("b");
			Ensure.That("abcdef").IsGreaterThanOrEqualTo("abc");
			Ensure.That("z").IsGreaterThanOrEqualTo("abc");
			Ensure.That("D").IsGreaterThanOrEqualTo("B");
			Ensure.That("ABCDEF").IsGreaterThanOrEqualTo("ABC");
			Ensure.That("Z").IsGreaterThanOrEqualTo("ABC");
			Ensure.That("abc").IsGreaterThanOrEqualTo("abc");
			Ensure.That("ABC").IsGreaterThanOrEqualTo("ABC");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsGreaterThanOrEqualTo_ShouldFailWhenGreater_UsingString()
		{
			Ensure.That("b").IsGreaterThanOrEqualTo("d");
		}

		#endregion


		#region IsBetween - Int

		[TestMethod]
		public void IsBetween_ShouldSucceed_UsingInt()
		{
			Ensure.That(1).IsBetween(0, 1);
			Ensure.That(1).IsBetween(0, 2);
			Ensure.That(1).IsBetween(1, 2);
			Ensure.That(1).IsBetween(2, 1);
			Ensure.That(-1).IsBetween(-1, -3);
			Ensure.That(-2).IsBetween(-1, -3);
			Ensure.That(-3).IsBetween(-1, -3);
			Ensure.That(-1).IsBetween(-1, -1);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsBetween_ShouldFailWhenLess_UsingInt()
		{
			Ensure.That(0).IsBetween(1, 2);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsBetween_ShouldFailWhenGreater_UsingInt()
		{
			Ensure.That(3).IsBetween(1, 2);
		}

		#endregion

		#region IsBetween - String

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsBetween_ShouldThrow_WithNullInputUsingString()
		{
			string input = null;
			string testStringMin = "aaa";
			string testStringMax = "ccc";
			Ensure.That(input).IsBetween(testStringMin, testStringMax);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsBetween_ShouldThrow_WithNullMinUsingString()
		{
			string input = "bbb";
			string testStringMin = null;
			string testStringMax = "ccc";
			Ensure.That(input).IsBetween(testStringMin, testStringMax);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsBetween_ShouldThrow_WithNullMaxUsingString()
		{
			string input = "bbb";
			string testStringMin = "aaa";
			string testStringMax = null;
			Ensure.That(input).IsBetween(testStringMin, testStringMax);
		}

		[TestMethod]
		public void IsBetween_ShouldSucceed_UsingString()
		{
			Ensure.That("").IsBetween("", "");
			Ensure.That("bbb").IsBetween("aaa", "bbb");
			Ensure.That("bbb").IsBetween("aaa", "ccc");
			Ensure.That("bbb").IsBetween("", "ccc");
			Ensure.That("BBB").IsBetween("AAA", "CCC");
			Ensure.That("BBB").IsBetween("", "CCC");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsBetween_ShouldFailWhenLess_UsingString()
		{
			Ensure.That("aaa").IsBetween("bbb", "ccc");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsBetween_ShouldFailWhenGreater_UsingString()
		{
			Ensure.That("ddd").IsBetween("bbb", "ccc");
		}

		#endregion


		#region IsNotBetween - Int

		[TestMethod]
		public void IsNotBetween_ShouldSucceed_UsingInt()
		{
			Ensure.That(0).IsNotBetween(1, 2);
			Ensure.That(3).IsNotBetween(1, 2);
			Ensure.That(3).IsNotBetween(2, 1);
			Ensure.That(-1).IsNotBetween(-2, -3);
			Ensure.That(-4).IsNotBetween(-2, -3);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsNotBetween_ShouldFailWhenBetween_UsingInt1()
		{
			Ensure.That(1).IsNotBetween(1, 3);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsNotBetween_ShouldFailWhenBetween_UsingInt2()
		{
			Ensure.That(2).IsNotBetween(1, 3);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsNotBetween_ShouldFailWhenBetween_UsingUpsideDownInts3()
		{
			Ensure.That(2).IsNotBetween(3, 1);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsNotBetween_ShouldFailWhenBetween_UsingInt4()
		{
			Ensure.That(3).IsNotBetween(1, 3);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsNotBetween_ShouldFailWhenBetween_UsingNegativeInt1()
		{
			Ensure.That(-1).IsNotBetween(-1, -1);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsNotBetween_ShouldFailWhenBetween_UsingInt()
		{
			Ensure.That(0).IsNotBetween(0, 1);
		}

		#endregion

		#region IsNotBetween - String

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsNotBetween_ShouldThrow_WithNullInputUsingString()
		{
			string input = null;
			string testStringMin = "aaa";
			string testStringMax = "ccc";
			Ensure.That(input).IsNotBetween(testStringMin, testStringMax);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsNotBetween_ShouldThrow_WithNullMinUsingString()
		{
			string input = "bbb";
			string testStringMin = null;
			string testStringMax = "ccc";
			Ensure.That(input).IsNotBetween(testStringMin, testStringMax);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsNotBetween_ShouldThrow_WithNullMaxUsingString()
		{
			string input = "bbb";
			string testStringMin = "aaa";
			string testStringMax = null;
			Ensure.That(input).IsNotBetween(testStringMin, testStringMax);
		}

		[TestMethod]
		public void IsNotBetween_ShouldSucceed_UsingString()
		{
			Ensure.That("").IsNotBetween("a", "c");
			Ensure.That("aaa").IsNotBetween("bbb", "ccc");
			Ensure.That("ddd").IsNotBetween("bbb", "ccc");
			Ensure.That("").IsNotBetween("A", "C");
			Ensure.That("AAA").IsNotBetween("BBB", "CCC");
			Ensure.That("DDD").IsNotBetween("BBB", "CCC");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsNotBetween_ShouldFailWhenBetween_UsingString1()
		{
			Ensure.That("aaa").IsNotBetween("aaa", "ccc");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsNotBetween_ShouldFailWhenBetween_UsingString2()
		{
			Ensure.That("bbb").IsNotBetween("aaa", "ccc");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsNotBetween_ShouldFailWhenBetween_UsingString3()
		{
			Ensure.That("ccc").IsNotBetween("aaa", "ccc");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsNotBetween_ShouldFailWhenBetween_UsingEmptyString4()
		{
			Ensure.That("").IsNotBetween("", "");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsNotBetween_ShouldFailWhenBetween_UsingString5()
		{
			Ensure.That("").IsNotBetween("", "");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsNotBetween_ShouldFailWhenBetween_UsingString6()
		{
			Ensure.That("BBB").IsNotBetween("AAA", "CCC");
		}

		#endregion


		#region IsIn - Int

		[TestMethod]
		public void IsIn_ShouldSucceedWhenIncluded_UsingInt()
		{
			Ensure.That(-1).IsIn(-1);
			Ensure.That(-1).IsIn(-1, -2);
			Ensure.That(-2).IsIn(-1, -2);
			Ensure.That(0).IsIn(0);
			Ensure.That(0).IsIn(0, 1);
			Ensure.That(1).IsIn(0, 1);
			Ensure.That(0).IsIn(0, 0, 1);
			Ensure.That(1).IsIn(0, 0, 1);
			Ensure.That(0).IsIn(new List<int> { 0 });
			Ensure.That(0).IsIn(new List<int> { 0, 1 });
			Ensure.That(1).IsIn(new List<int> { 0, 1 });
			Ensure.That(0).IsIn(new List<int> { 0, 1, 2 });
			Ensure.That(1).IsIn(new List<int> { 0, 1, 2 });
			Ensure.That(2).IsIn(new List<int> { 0, 1, 2 });
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsIn_ShouldThrow_WhenNullList_UsingInt()
		{
			List<int> testList = null;
			Ensure.That(2).IsIn(testList);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsIn_ShouldThrow_WhenEmptyList_UsingInt()
		{
			Ensure.That(2).IsIn();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsIn_ShouldThrow_WhenNotIncluded_UsingInt1()
		{
			Ensure.That(2).IsIn(0);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsIn_ShouldThrow_WhenNotIncluded_UsingInt2()
		{
			Ensure.That(2).IsIn(0, 1);
		}

		#endregion

		#region IsIn - String

		[TestMethod]
		public void IsIn_ShouldSucceedWhenIncluded_UsingString()
		{
			Ensure.That("-1").IsIn("-1");
			Ensure.That("-1").IsIn("-1", "-2");
			Ensure.That("-2").IsIn("-1", "-2");
			Ensure.That("0").IsIn("0");
			Ensure.That("0").IsIn("0", "1");
			Ensure.That("1").IsIn("0", "1");
			Ensure.That("0").IsIn("0", "0", "1");
			Ensure.That("1").IsIn("0", "0", "1");
			Ensure.That("0").IsIn(new List<string> { "0" });
			Ensure.That("0").IsIn(new List<string> { "0", "1" });
			Ensure.That("1").IsIn(new List<string> { "0", "1" });
			Ensure.That("0").IsIn(new List<string> { "0", "1", "2" });
			Ensure.That("1").IsIn(new List<string> { "0", "1", "2" });
			Ensure.That("2").IsIn(new List<string> { "0", "1", "2" });
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsIn_ShouldThrow_WhenNullSource_UsingString()
		{
			var testList = new List<string> { "abc" };
			string input = null;
			Ensure.That(input).IsIn(testList);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsIn_ShouldThrow_WhenNullList_UsingString()
		{
			List<string> testList = null;
			Ensure.That("2").IsIn(testList);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsIn_ShouldThrow_WhenNullItemInList_UsingString()
		{
			string nullString = null;
			var testList = new List<string> { "abc", nullString, "def" };
			Ensure.That("2").IsIn(testList);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsIn_ShouldThrow_WhenEmptyList_UsingString()
		{
			Ensure.That("2").IsIn();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsIn_ShouldThrow_WhenNotIncluded_UsingString1()
		{
			Ensure.That("2").IsIn("0");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsIn_ShouldThrow_WhenNotIncluded_UsingString2()
		{
			Ensure.That("2").IsIn("0", "1");
		}

		#endregion


		#region IsNotIn - Int

		[TestMethod]
		public void IsNotIn_ShouldSucceedWhenNotIncluded_UsingInt()
		{
			Ensure.That(-1).IsNotIn(0);
			Ensure.That(-1).IsNotIn(0, 1);
			Ensure.That(0).IsNotIn(1);
			Ensure.That(0).IsNotIn(1, 2);
			Ensure.That(3).IsNotIn(1, 2);
			Ensure.That(-1).IsNotIn(new List<int> { 0 });
			Ensure.That(-1).IsNotIn(new List<int> { 0, 1 });
			Ensure.That(0).IsNotIn(new List<int> { 1 });
			Ensure.That(0).IsNotIn(new List<int> { 1, 2 });
			Ensure.That(3).IsNotIn(new List<int> { 1, 2 });
		}

		[TestMethod]
		public void IsNotIn_ShouldSucceed_WhenEmptyList_UsingInt()
		{
			Ensure.That(2).IsNotIn();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsNotIn_ShouldThrow_WhenNullList_UsingInt()
		{
			List<int> testList = null;
			Ensure.That(2).IsNotIn(testList);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsNotIn_ShouldThrow_WhenIncluded_UsingInt1()
		{
			Ensure.That(0).IsNotIn(0);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsNotIn_ShouldThrow_WhenIncluded_UsingInt2()
		{
			Ensure.That(0).IsNotIn(0, 1);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsNotIn_ShouldThrow_WhenIncluded_UsingInt3()
		{
			Ensure.That(1).IsNotIn(0, 1);
		}

		#endregion

		#region IsNotIn - String

		[TestMethod]
		public void IsNotIn_ShouldSucceedWhenIncluded_UsingString()
		{
			Ensure.That("-1").IsNotIn("0");
			Ensure.That("-1").IsNotIn("0", "1");
			Ensure.That("0").IsNotIn("1");
			Ensure.That("0").IsNotIn("1", "2");
			Ensure.That("3").IsNotIn("1", "2");
			Ensure.That("-1").IsNotIn(new List<string> { "0" });
			Ensure.That("-1").IsNotIn(new List<string> { "0", "1" });
			Ensure.That("0").IsNotIn(new List<string> { "1" });
			Ensure.That("0").IsNotIn(new List<string> { "1", "2" });
			Ensure.That("3").IsNotIn(new List<string> { "1", "2" });
		}

		[TestMethod]
		public void IsNotIn_ShouldSucceed_WhenEmptyList_UsingString()
		{
			Ensure.That("2").IsNotIn();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsNotIn_ShouldThrow_WhenNullSource_UsingString()
		{
			var testList = new List<string> { "abc" };
			string input = null;
			Ensure.That(input).IsNotIn(testList);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsNotIn_ShouldThrow_WhenNullList_UsingString()
		{
			List<string> testList = null;
			Ensure.That("2").IsNotIn(testList);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsNotIn_ShouldThrow_WhenNullItemInList_UsingString()
		{
			string nullString = null;
			var testList = new List<string> { "abc", nullString, "def" };
			Ensure.That("2").IsNotIn(testList);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsNotIn_ShouldThrow_WhenNotIncluded_UsingString1()
		{
			Ensure.That("0").IsNotIn("0");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsNotIn_ShouldThrow_WhenNotIncluded_UsingString2()
		{
			Ensure.That("0").IsNotIn("0", "1");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsNotIn_ShouldThrow_WhenNotIncluded_UsingString3()
		{
			Ensure.That("1").IsNotIn("0", "1");
		}

		#endregion


		#region Chaining

		[TestMethod]
		public void TestChaining()
		{
			const string testString = "abc";
			const int testInt = 3;
			var testList = new List<string> { "abc", "def" };

			Ensure.That(testString).IsNotNull().IsNotEqualTo("blahblah").IsEqualTo("abc").IsLessThan("ddd");
			Ensure.That(testInt).IsNotEqualTo(5).IsEqualTo(3).IsLessThan(8).IsGreaterThan(1).IsGreaterThanOrEqualTo(3).IsIn(1, 2, 3, 4).IsNotIn(4, 5, 6, 7);
			Ensure.That(testList).IsNotNull();
		}

		#endregion
	}
}
