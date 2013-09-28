using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

#if LITTLEHELPERS_NEEDS_EXPLICIT_USING_DIRECTIVES
namespace demoncodemonkey.LittleHelpers
{
#endif

	public static class Utils
	{
		public static void Swap<T>(ref T valueA, ref T valueB)
		{
			T temp = valueA;
			valueA = valueB;
			valueB = temp;
		}

		public static object GetPropertyValue(object obj, string propName)
		{
			PropertyInfo propInfo = obj.GetType().GetProperty(propName);
			return propInfo.GetValue(obj, null);
		}
	}

#if LITTLEHELPERS_NEEDS_EXPLICIT_USING_DIRECTIVES
}
#endif
