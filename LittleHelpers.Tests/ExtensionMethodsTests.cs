using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;

namespace demoncodemonkey.LittleHelpers
{
	public class ExtensionMethodsTests
	{
		[TestClass]
		public class Objects
		{
			[TestInitialize]
			public void Setup()
			{
			}

			#region IsNull
			[TestMethod]
			public void IsNull_ShouldReturnTrue_WithNullObject()
			{
				object input = null;
				Assert.IsTrue(input.IsNull());
			}

			[TestMethod]
			public void IsNull_ShouldReturnTrue_WithNullString()
			{
				string input = null;
				Assert.IsTrue(input.IsNull());
			}

			[TestMethod]
			public void IsNull_ShouldReturnFalse_WithEmptyString()
			{
				string input = string.Empty;
				Assert.IsFalse(input.IsNull());
			}

			[TestMethod]
			public void IsNull_ShouldReturnFalse_WithNewStringArray()
			{
				var input = new string[] { "aaa", "bbb" };
				Assert.IsFalse(input.IsNull());
			}
			#endregion

			#region IsNotNull
			[TestMethod]
			public void IsNotNull_ShouldReturnFalse_WithNullObject()
			{
				object input = null;
				Assert.IsFalse(input.IsNotNull());
			}

			[TestMethod]
			public void IsNotNull_ShouldReturnFalse_WithNullString()
			{
				string input = null;
				Assert.IsFalse(input.IsNotNull());
			}

			[TestMethod]
			public void IsNotNull_ShouldReturnTrue_WithEmptyString()
			{
				string input = string.Empty;
				Assert.IsTrue(input.IsNotNull());
			}

			[TestMethod]
			public void IsNotNull_ShouldReturnTrue_WithNewStringArray()
			{
				var input = new string[] { "aaa", "bbb" };
				Assert.IsTrue(input.IsNotNull());
			}
			#endregion

			#region IsIn
			//System.Random used for testing, as it is an easily instantiatable class
			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void IsIn_ShouldThrow_WithNullSource()
			{
				Random input = null;
				var target = new Random();
				var testList = new List<Random>() { target, };
				bool result = input.IsIn(testList);
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void IsIn_ShouldThrow_WithNullArgument()
			{
				var input = new Random();
				List<Random> testList = null;
				bool result = input.IsIn(testList);
			}

			[TestMethod]
			public void IsIn_ShouldReturnFalse_WithEmptyArgument()
			{
				var input = new Random();
				var testList = new List<Random>();
				Assert.IsFalse(input.IsIn(testList));
			}

			[TestMethod]
			public void IsIn_ShouldReturnFalse_WhenLookingForNonMatchingObject()
			{
				var input = new Random();
				var target = new Random();
				var testList = new List<Random>() { target, };
				Assert.IsFalse(input.IsIn(testList));
			}

			[TestMethod]
			public void IsIn_ShouldReturnTrue_WhenLookingForIdenticalObject()
			{
				var input = new Random();
				var target = new Random();
				var testList = new List<Random>() { target, input, };
				Assert.IsTrue(input.IsIn(testList));
			}

			#endregion

			#region IsNotIn
			//System.Random used for testing, as it is an easily instantiatable class
			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void IsNotIn_ShouldThrow_WithNullSource()
			{
				Random input = null;
				var target = new Random();
				var testList = new List<Random>() { target, };
				bool result = input.IsNotIn(testList);
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void IsNotIn_ShouldThrow_WithNullArgument()
			{
				var input = new Random();
				List<Random> testList = null;
				bool result = input.IsNotIn(testList);
			}

			[TestMethod]
			public void IsNotIn_ShouldReturnTrue_WithEmptyArgument()
			{
				var input = new Random();
				var testList = new List<Random>();
				Assert.IsTrue(input.IsNotIn(testList));
			}

			[TestMethod]
			public void IsNotIn_ShouldReturnTrue_WhenLookingForNonMatchingObject()
			{
				var input = new Random();
				var target = new Random();
				var testList = new List<Random>() { target, };
				Assert.IsTrue(input.IsNotIn(testList));
			}

			[TestMethod]
			public void IsNotIn_ShouldReturnFalse_WhenLookingForIdenticalObject()
			{
				var input = new Random();
				var target = new Random();
				var testList = new List<Random>() { target, input, };
				Assert.IsFalse(input.IsNotIn(testList));
			}

			#endregion
		}

		[TestClass]
		public class Strings
		{
			[TestInitialize]
			public void Setup()
			{
			}

			#region IsEmpty
			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void IsEmpty_ShouldThrow_WithNullString()
			{
				string input = null;
				bool result = input.IsEmpty();
			}

			[TestMethod]
			public void IsEmpty_ShouldReturnTrue_WithEmptyString()
			{
				string input = string.Empty;
				Assert.IsTrue(input.IsEmpty());
			}

			public void IsEmpty_ShouldReturnFalse_WithNormalString()
			{
				string input = "abcdef";
				Assert.IsFalse(input.IsEmpty());
			}
			#endregion

			#region IsNotEmpty
			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void IsNotEmpty_ShouldThrow_WithNullString()
			{
				string input = null;
				bool result = input.IsNotEmpty();
			}

			[TestMethod]
			public void IsNotEmpty_ShouldReturnFalse_WithEmptyString()
			{
				string input = string.Empty;
				Assert.IsFalse(input.IsNotEmpty());
			}

			public void IsNotEmpty_ShouldReturnTrue_WithNormalString()
			{
				string input = "abcdef";
				Assert.IsTrue(input.IsNotEmpty());
			}
			#endregion

			#region IsNullOrEmpty
			[TestMethod]
			public void IsNullOrEmpty_ShouldReturnTrue_WithNullString()
			{
				string input = null;
				Assert.IsTrue(input.IsNullOrEmpty());
			}

			[TestMethod]
			public void IsNullOrEmpty_ShouldReturnTrue_WithEmptyString()
			{
				string input = string.Empty;
				Assert.IsTrue(input.IsNullOrEmpty());
			}

			public void IsNullOrEmpty_ShouldReturnFalse_WithNormalString()
			{
				string input = "abcdef";
				Assert.IsFalse(input.IsNullOrEmpty());
			}
			#endregion

			#region IsNotNullAndNotEmpty
			[TestMethod]
			public void IsNotNullAndNotEmpty_ShouldReturnFalse_WithNullString()
			{
				string input = null;
				Assert.IsFalse(input.IsNotNullAndNotEmpty());
			}

			[TestMethod]
			public void IsNotNullAndNotEmpty_ShouldReturnFalse_WithEmptyString()
			{
				string input = string.Empty;
				Assert.IsFalse(input.IsNotNullAndNotEmpty());
			}

			public void IsNotNullAndNotEmpty_ShouldReturnTrue_WithNormalString()
			{
				string input = "abcdef";
				Assert.IsTrue(input.IsNotNullAndNotEmpty());
			}
			#endregion

			#region ContainsIgnoreCase
			[TestMethod]
			public void ContainsIgnoreCase_ShouldReturnTrue_WhenLookingForIdenticalMatch()
			{
				string input = "abcdefg";
				string testMatch = "abcdefg";
				Assert.IsTrue(input.ContainsIgnoreCase(testMatch));
			}

			[TestMethod]
			public void ContainsIgnoreCase_ShouldReturnTrue_WhenLookingForIdenticalCasedSubstring()
			{
				string input = "abcdefg";
				string testMatch = "def";
				Assert.IsTrue(input.ContainsIgnoreCase(testMatch));
			}

			[TestMethod]
			public void ContainsIgnoreCase_ShouldReturnTrue_WhenLookingForWrongCasedSubstring()
			{
				string input = "abcdefg";
				string testMatch = "DeF";
				Assert.IsTrue(input.ContainsIgnoreCase(testMatch));
			}

			[TestMethod]
			public void ContainsIgnoreCase_ShouldReturnFalse_WhenLookingForEmptyString()
			{
				string input = "abcdefg";
				string testMatch = "";
				Assert.IsFalse(input.ContainsIgnoreCase(testMatch));
			}

			[TestMethod]
			public void ContainsIgnoreCase_ShouldReturnFalse_WhenLookingForNonMatchingSubstring()
			{
				string input = "abcdefg";
				string testMatch = "xxyyzz";
				Assert.IsFalse(input.ContainsIgnoreCase(testMatch));
			}

			[TestMethod]
			public void ContainsIgnoreCase_ShouldReturnFalse_WhenLookingForStringWithinSubstring()
			{
				string input = "def";
				string testMatch = "abcdefg";
				Assert.IsFalse(input.ContainsIgnoreCase(testMatch));
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ContainsIgnoreCase_ShouldThrow_WhenLookingForNull()
			{
				string input = "abcdefg";
				string testMatch = null;
				bool result = input.ContainsIgnoreCase(testMatch);
			}
			#endregion

			#region EqualsIgnoreCase
			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void EqualsIgnoreCase_ShouldThrow_WithNullString()
			{
				string input = null;
				string testMatch = "asd";
				bool result = input.EqualsIgnoreCase(testMatch);
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void EqualsIgnoreCase_ShouldThrow_WithNullStringArgument()
			{
				string input = "asd";
				string testMatch = null;
				bool result = input.EqualsIgnoreCase(testMatch);
			}

			[TestMethod]
			public void EqualsIgnoreCase_ShouldReturnFalse_WithEmptyStringAndValidArgument()
			{
				string input = string.Empty;
				string testMatch = "asd";
				Assert.IsFalse(input.EqualsIgnoreCase(testMatch));
			}

			[TestMethod]
			public void EqualsIgnoreCase_ShouldReturnFalse_WithValidStringAndEmptyArgument()
			{
				string input = "asd";
				string testMatch = string.Empty;
				Assert.IsFalse(input.EqualsIgnoreCase(testMatch));
			}

			[TestMethod]
			public void EqualsIgnoreCase_ShouldReturnTrue_WithEmptyStringAndEmptyArgument()
			{
				string input = string.Empty;
				string testMatch = string.Empty;
				Assert.IsTrue(input.EqualsIgnoreCase(testMatch));
			}

			[TestMethod]
			public void EqualsIgnoreCase_ShouldReturnTrue_WithIdenticalStrings()
			{
				string input = "abcdefg";
				string testMatch = "abcdefg";
				Assert.IsTrue(input.EqualsIgnoreCase(testMatch));
			}

			[TestMethod]
			public void EqualsIgnoreCase_ShouldReturnTrue_WithWrongCaseStrings()
			{
				string input = "aBcdeFg";
				string testMatch = "abCDEfg";
				Assert.IsTrue(input.EqualsIgnoreCase(testMatch));
			}

			[TestMethod]
			public void EqualsIgnoreCase_ShouldReturnFalse_WithNonMatchingStrings()
			{
				string input = "abcdefg";
				string testMatch = "isdbfjsasdasf";
				Assert.IsFalse(input.EqualsIgnoreCase(testMatch));
			}

			[TestMethod]
			public void EqualsIgnoreCase_ShouldReturnFalse_WithNonMatchingSubstrings()
			{
				string input = "abcdefg";
				string testMatch = "isdbfjabcdefgsasdasf";
				Assert.IsFalse(input.EqualsIgnoreCase(testMatch));
			}

			#endregion

			#region IsIn (list)
			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void IsIn_StringList_ShouldThrow_WithNullString()
			{
				string input = null;
				var testList = new List<string>() { "abcdefg", };
				bool result = input.IsIn(testList);
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void IsIn_StringList_ShouldThrow_WithNullArgument()
			{
				string input = "abcdefg";
				List<string> testList = null;
				bool result = input.IsIn(testList);
			}

			[TestMethod]
			public void IsIn_StringList_ShouldReturnFalse_WithEmptyArgument()
			{
				string input = "abcdefg";
				var testList = new List<string>();
				Assert.IsFalse(input.IsIn(testList));
			}

			[TestMethod]
			public void IsIn_StringList_ShouldReturnTrue_WithEmptyStringWhenListContainsEmptyString()
			{
				string input = string.Empty;
				var testList = new List<string>() { "abcdefg", "", "hhuuuiii" };
				Assert.IsTrue(input.IsIn(testList));
			}

			[TestMethod]
			public void IsIn_StringList_ShouldReturnFalse_WithEmptyStringWhenListDoesNotContainEmptyString()
			{
				string input = string.Empty;
				var testList = new List<string>() { "abcdefg", "xyz", "qwqweqwe" };
				Assert.IsFalse(input.IsIn(testList));
			}

			[TestMethod]
			public void IsIn_StringList_ShouldReturnTrue_WhenLookingForIdenticalMatchInSingleItemList()
			{
				string input = "abcdefg";
				var testList = new List<string>() { "abcdefg", };
				Assert.IsTrue(input.IsIn(testList));
			}

			[TestMethod]
			public void IsIn_StringList_ShouldReturnTrue_WhenLookingForIdenticalMatchAtStartOfMultiItemList()
			{
				string input = "abcdefg";
				var testList = new List<string>() { "abcdefg", "hahaha", "blahblah", };
				Assert.IsTrue(input.IsIn(testList));
			}

			[TestMethod]
			public void IsIn_StringList_ShouldReturnTrue_WhenLookingForIdenticalMatchAtMiddleOfMultiItemList()
			{
				string input = "abcdefg";
				var testList = new List<string>() { "floofloo", "abcdefg", "sosososos", };
				Assert.IsTrue(input.IsIn(testList));
			}

			[TestMethod]
			public void IsIn_StringList_ShouldReturnTrue_WhenLookingForIdenticalMatchAtEndOfMultiItemList()
			{
				string input = "abcdefg";
				var testList = new List<string>() { "kakakaoskasdasd", "halominosphart", "abcdefg", };
				Assert.IsTrue(input.IsIn(testList));
			}

			[TestMethod]
			public void IsIn_StringList_ShouldReturnFalse_WhenLookingForNonMatchingStringInSingleItemList()
			{
				string input = "abcdefg";
				var testList = new List<string>() { "nsdofbgifvcgx", };
				Assert.IsFalse(input.IsIn(testList));
			}

			[TestMethod]
			public void IsIn_StringList_ShouldReturnFalse_WhenLookingForNonMatchingStringInMultiItemList()
			{
				string input = "abcdefg";
				var testList = new List<string>() { "dfndfpogdfb", "oinsdofinsdgf", "ffttdfgineiedv", };
				Assert.IsFalse(input.IsIn(testList));
			}

			[TestMethod]
			public void IsIn_StringList_ShouldReturnFalse_WhenLookingForNonMatchingStringInSubstringInSingleItemList()
			{
				string input = "abcdefg";
				var testList = new List<string>() { "xmfgiabcdefgfdgmnd", };
				Assert.IsFalse(input.IsIn(testList));
			}

			[TestMethod]
			public void IsIn_StringList_ShouldReturnFalse_WhenLookingForNonMatchingStringInSubstringInMultiItemList()
			{
				string input = "abcdefg";
				var testList = new List<string>() { "osdfunhimfgoidtg", "sdfbabcdefgsdvsd", "vdfhfghgsjjj", };
				Assert.IsFalse(input.IsIn(testList));
			}

			[TestMethod]
			public void IsIn_StringList_ShouldReturnFalse_WhenLookingForWrongCaseMatchingStringInSingleItemList()
			{
				string input = "abcdefg";
				var testList = new List<string>() { "ABCDEFG", };
				Assert.IsFalse(input.IsIn(testList));
			}

			[TestMethod]
			public void IsIn_StringList_ShouldReturnFalse_WhenLookingForWrongCaseMatchingStringInMultiItemList()
			{
				string input = "abcdefg";
				var testList = new List<string>() { "dfndfpogdfb", "ABCDEFG", "ffttdfgineiedv", };
				Assert.IsFalse(input.IsIn(testList));
			}

			#endregion

			#region IsIn (array)
			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void IsIn_StringArray_ShouldThrow_WithNullString()
			{
				string input = null;
				var testList = new string[] { "abcdefg", };
				bool result = input.IsIn(testList);
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void IsIn_StringArray_ShouldThrow_WithNullArgument()
			{
				string input = "abcdefg";
				string[] testList = null;
				bool result = input.IsIn(testList);
			}

			[TestMethod]
			public void IsIn_StringArray_ShouldReturnFalse_WithEmptyArgument()
			{
				string input = "abcdefg";
				var testList = new string[] { };
				Assert.IsFalse(input.IsIn(testList));
			}

			[TestMethod]
			public void IsIn_StringArray_ShouldReturnTrue_WithEmptyStringWhenListContainsEmptyString()
			{
				string input = string.Empty;
				var testList = new string[] { "abcdefg", "", "hhuuuiii" };
				Assert.IsTrue(input.IsIn(testList));
			}

			[TestMethod]
			public void IsIn_StringArray_ShouldReturnFalse_WithEmptyStringWhenListDoesNotContainEmptyString()
			{
				string input = string.Empty;
				var testList = new string[] { "abcdefg", "xyz", "qwqweqwe" };
				Assert.IsFalse(input.IsIn(testList));
			}

			[TestMethod]
			public void IsIn_StringArray_ShouldReturnTrue_WhenLookingForIdenticalMatchInSingleItemList()
			{
				string input = "abcdefg";
				var testList = new string[] { "abcdefg", };
				Assert.IsTrue(input.IsIn(testList));
			}

			[TestMethod]
			public void IsIn_StringArray_ShouldReturnTrue_WhenLookingForIdenticalMatchAtStartOfMultiItemList()
			{
				string input = "abcdefg";
				var testList = new string[] { "abcdefg", "hahaha", "blahblah", };
				Assert.IsTrue(input.IsIn(testList));
			}

			[TestMethod]
			public void IsIn_StringArray_ShouldReturnTrue_WhenLookingForIdenticalMatchAtMiddleOfMultiItemList()
			{
				string input = "abcdefg";
				var testList = new string[] { "floofloo", "abcdefg", "sosososos", };
				Assert.IsTrue(input.IsIn(testList));
			}

			[TestMethod]
			public void IsIn_StringArray_ShouldReturnTrue_WhenLookingForIdenticalMatchAtEndOfMultiItemList()
			{
				string input = "abcdefg";
				var testList = new string[] { "kakakaoskasdasd", "halominosphart", "abcdefg", };
				Assert.IsTrue(input.IsIn(testList));
			}

			[TestMethod]
			public void IsIn_StringArray_ShouldReturnFalse_WhenLookingForNonMatchingStringInSingleItemList()
			{
				string input = "abcdefg";
				var testList = new string[] { "nsdofbgifvcgx", };
				Assert.IsFalse(input.IsIn(testList));
			}

			[TestMethod]
			public void IsIn_StringArray_ShouldReturnFalse_WhenLookingForNonMatchingStringInMultiItemList()
			{
				string input = "abcdefg";
				var testList = new string[] { "dfndfpogdfb", "oinsdofinsdgf", "ffttdfgineiedv", };
				Assert.IsFalse(input.IsIn(testList));
			}

			[TestMethod]
			public void IsIn_StringArray_ShouldReturnFalse_WhenLookingForNonMatchingStringInSubstringInSingleItemList()
			{
				string input = "abcdefg";
				var testList = new string[] { "xmfgiabcdefgfdgmnd", };
				Assert.IsFalse(input.IsIn(testList));
			}

			[TestMethod]
			public void IsIn_StringArray_ShouldReturnFalse_WhenLookingForNonMatchingStringInSubstringInMultiItemList()
			{
				string input = "abcdefg";
				var testList = new string[] { "osdfunhimfgoidtg", "sdfbabcdefgsdvsd", "vdfhfghgsjjj", };
				Assert.IsFalse(input.IsIn(testList));
			}

			[TestMethod]
			public void IsIn_StringArray_ShouldReturnFalse_WhenLookingForWrongCaseMatchingStringInSingleItemList()
			{
				string input = "abcdefg";
				var testList = new string[] { "ABCDEFG", };
				Assert.IsFalse(input.IsIn(testList));
			}

			[TestMethod]
			public void IsIn_StringArray_ShouldReturnFalse_WhenLookingForWrongCaseMatchingStringInMultiItemList()
			{
				string input = "abcdefg";
				var testList = new string[] { "dfndfpogdfb", "ABCDEFG", "ffttdfgineiedv", };
				Assert.IsFalse(input.IsIn(testList));
			}

			#endregion

			#region IsInIgnoreCase
			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void IsInIgnoreCase_ShouldThrow_WithNullString()
			{
				string input = null;
				var testList = new List<string>() { "abcdefg", };
				bool result = input.IsInIgnoreCase(testList);
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void IsInIgnoreCase_ShouldThrow_WithNullArgument()
			{
				string input = "abcdefg";
				List<string> testList = null;
				bool result = input.IsInIgnoreCase(testList);
			}

			[TestMethod]
			public void IsInIgnoreCase_ShouldReturnFalse_WithEmptyArgument()
			{
				string input = "abcdefg";
				var testList = new List<string>();
				Assert.IsFalse(input.IsInIgnoreCase(testList));
			}

			[TestMethod]
			public void IsInIgnoreCase_ShouldReturnTrue_WithEmptyStringWhenListContainsEmptyString()
			{
				string input = string.Empty;
				var testList = new List<string>() { "abcdefg", "", "hhuuuiii" };
				Assert.IsTrue(input.IsInIgnoreCase(testList));
			}

			[TestMethod]
			public void IsInIgnoreCase_ShouldReturnFalse_WithEmptyStringWhenListDoesNotContainEmptyString()
			{
				string input = string.Empty;
				var testList = new List<string>() { "abcdefg", "xyz", "qwqweqwe" };
				Assert.IsFalse(input.IsInIgnoreCase(testList));
			}
			
			[TestMethod]
			public void IsInIgnoreCase_ShouldReturnTrue_WhenLookingForIdenticalMatchInSingleItemList()
			{
				string input = "abcdefg";
				var testList = new List<string>() { "abcdefg", };
				Assert.IsTrue(input.IsInIgnoreCase(testList));
			}

			[TestMethod]
			public void IsInIgnoreCase_ShouldReturnTrue_WhenLookingForIdenticalMatchAtStartOfMultiItemList()
			{
				string input = "abcdefg";
				var testList = new List<string>() { "abcdefg", "hahaha", "blahblah", };
				Assert.IsTrue(input.IsInIgnoreCase(testList));
			}

			[TestMethod]
			public void IsInIgnoreCase_ShouldReturnTrue_WhenLookingForIdenticalMatchAtMiddleOfMultiItemList()
			{
				string input = "abcdefg";
				var testList = new List<string>() { "floofloo", "abcdefg", "sosososos", };
				Assert.IsTrue(input.IsInIgnoreCase(testList));
			}

			[TestMethod]
			public void IsInIgnoreCase_ShouldReturnTrue_WhenLookingForIdenticalMatchAtEndOfMultiItemList()
			{
				string input = "abcdefg";
				var testList = new List<string>() { "kakakaoskasdasd", "halominosphart", "abcdefg", };
				Assert.IsTrue(input.IsInIgnoreCase(testList));
			}

			[TestMethod]
			public void IsInIgnoreCase_ShouldReturnFalse_WhenLookingForNonMatchingStringInSingleItemList()
			{
				string input = "abcdefg";
				var testList = new List<string>() { "nsdofbgifvcgx", };
				Assert.IsFalse(input.IsInIgnoreCase(testList));
			}

			[TestMethod]
			public void IsInIgnoreCase_ShouldReturnFalse_WhenLookingForNonMatchingStringInMultiItemList()
			{
				string input = "abcdefg";
				var testList = new List<string>() { "dfndfpogdfb", "oinsdofinsdgf", "ffttdfgineiedv", };
				Assert.IsFalse(input.IsInIgnoreCase(testList));
			}

			[TestMethod]
			public void IsInIgnoreCase_ShouldReturnFalse_WhenLookingForNonMatchingStringInSubstringInSingleItemList()
			{
				string input = "abcdefg";
				var testList = new List<string>() { "xmfgiabcdefgfdgmnd", };
				Assert.IsFalse(input.IsInIgnoreCase(testList));
			}

			[TestMethod]
			public void IsInIgnoreCase_ShouldReturnFalse_WhenLookingForNonMatchingStringInSubstringInMultiItemList()
			{
				string input = "abcdefg";
				var testList = new List<string>() { "osdfunhimfgoidtg", "sdfbabcdefgsdvsd", "vdfhfghgsjjj", };
				Assert.IsFalse(input.IsInIgnoreCase(testList));
			}

			[TestMethod]
			public void IsInIgnoreCase_ShouldReturnTrue_WhenLookingForWrongCaseMatchingStringInSingleItemList()
			{
				string input = "abcdefg";
				var testList = new List<string>() { "ABcdeFG", };
				Assert.IsTrue(input.IsInIgnoreCase(testList));
			}

			[TestMethod]
			public void IsInIgnoreCase_ShouldReturnTrue_WhenLookingForWrongCaseMatchingStringInMultiItemList()
			{
				string input = "abcdefg";
				var testList = new List<string>() { "dfndfpogdfb", "ABcdeFG", "ffttdfgineiedv", };
				Assert.IsTrue(input.IsInIgnoreCase(testList));
			}
			#endregion
		}

		[TestClass]
		public class IEnumerables
		{
			#region IsEmpty
			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void IsEmpty_ShouldThrow_WithNullList()
			{
				List<string> input = null;
				bool result = input.IsEmpty();
			}

			[TestMethod]
			public void IsEmpty_ShouldReturnTrue_WithEmptyList()
			{
				var input = new List<string>();
				Assert.IsTrue(input.IsEmpty());
			}

			public void IsEmpty_ShouldReturnFalse_WithSingleItemList()
			{
				var input = new List<string> { "abcdef" };
				Assert.IsFalse(input.IsEmpty());
			}

			public void IsEmpty_ShouldReturnFalse_WithMultiItemList()
			{
				var input = new List<string> { "abcdef", "ghijkl" };
				Assert.IsFalse(input.IsEmpty());
			}

			public void IsEmpty_ShouldReturnFalse_WithListOfEmptyString()
			{
				var input = new List<string> { "" };
				Assert.IsFalse(input.IsEmpty());
			}
			#endregion

			#region IsNotEmpty
			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void IsNotEmpty_ShouldThrow_WithNullList()
			{
				List<string> input = null;
				bool result = input.IsNotEmpty();
			}

			[TestMethod]
			public void IsNotEmpty_ShouldReturnFalse_WithEmptyList()
			{
				var input = new List<string>();
				Assert.IsFalse(input.IsNotEmpty());
			}

			public void IsNotEmpty_ShouldReturnTrue_WithSingleItemList()
			{
				var input = new List<string> { "abcdef" };
				Assert.IsTrue(input.IsNotEmpty());
			}

			public void IsNotEmpty_ShouldReturnTrue_WithMultiItemList()
			{
				var input = new List<string> { "abcdef", "ghijkl" };
				Assert.IsTrue(input.IsNotEmpty());
			}

			public void IsNotEmpty_ShouldReturnTrue_WithListOfEmptyString()
			{
				var input = new List<string> { "" };
				Assert.IsTrue(input.IsNotEmpty());
			}
			#endregion

			#region GetItemsContents

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void GetItemsContents_ShouldThrow_WhenGivenNull()
			{
				List<string> input = null;
				IEnumerable<string> output = input.GetItemsContents().ToList();
			}

			[TestMethod]
			public void GetItemsContents_ShouldReturnEmptyStringList_WhenGivenEmptyList()
			{
				var input = new List<string>();
				IEnumerable<string> output = input.GetItemsContents();
				Assert.AreEqual(0, output.Count());
			}

			[TestMethod]
			public void GetItemsContents_ShouldReturnValidStringList_WhenGivenListOfOneEmptyString()
			{
				var input = new List<string> { "" };
				IEnumerable<string> output = input.GetItemsContents();
				Assert.AreEqual(1, output.Count());
				Assert.AreEqual("", output.FirstOrDefault());
			}

			[TestMethod]
			public void GetItemsContents_ShouldReturnValidStringList_WhenGivenListOfOneString()
			{
				var input = new List<string> { "abcdef" };
				IEnumerable<string> output = input.GetItemsContents();
				Assert.AreEqual(1, output.Count());
				Assert.AreEqual("abcdef", output.FirstOrDefault());
			}

			[TestMethod]
			public void GetItemsContents_ShouldReturnValidStringList_WhenGivenListOfMultiStrings()
			{
				var input = new List<string> { "abc", "def", "ghi" };
				IEnumerable<string> output = input.GetItemsContents();
				Assert.AreEqual(3, output.Count());
				Assert.IsTrue("abc".IsIn(output));
				Assert.IsTrue("def".IsIn(output));
				Assert.IsTrue("ghi".IsIn(output));
			}

			#endregion
		}
	}
}
