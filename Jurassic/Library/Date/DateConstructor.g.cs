/*
 * This file is auto-generated, do not modify directly.
 */

using System.Collections.Generic;
using Jurassic;

namespace Jurassic.Library
{

	public partial class DateConstructor
	{
		internal new List<PropertyNameAndValue> GetDeclarativeProperties()
		{
			return new List<PropertyNameAndValue>(7)
			{
				new PropertyNameAndValue("now", new ClrStubFunction(this.Engine.Function.InstancePrototype, "now", 0, __STUB__now), PropertyAttributes.NonEnumerable),
				new PropertyNameAndValue("UTC", new ClrStubFunction(this.Engine.Function.InstancePrototype, "UTC", 7, __STUB__UTC), PropertyAttributes.NonEnumerable),
				new PropertyNameAndValue("parse", new ClrStubFunction(this.Engine.Function.InstancePrototype, "parse", 1, __STUB__parse), PropertyAttributes.NonEnumerable),
			};
		}

		private static object __STUB__Call(ScriptEngine engine, object thisObj, object[] args)
		{
			thisObj = TypeConverter.ToObject(engine, thisObj);
			if (!(thisObj is DateConstructor))
				throw new JavaScriptException(engine, "TypeError", "The method 'Call' is not generic.");
			return ((DateConstructor)thisObj).Call();
		}

		private static ObjectInstance __STUB__Construct(ScriptEngine engine, object thisObj, object[] args)
		{
			thisObj = TypeConverter.ToObject(engine, thisObj);
			if (!(thisObj is DateConstructor))
				throw new JavaScriptException(engine, "TypeError", "The method 'Construct' is not generic.");
			switch (args.Length)
			{
				case 0:
					return ((DateConstructor)thisObj).Construct(new object[0]);
				default:
					return ((DateConstructor)thisObj).Construct(args);
			}
		}

		private static object __STUB__now(ScriptEngine engine, object thisObj, object[] args)
		{
			return Now();
		}

		private static object __STUB__UTC(ScriptEngine engine, object thisObj, object[] args)
		{
			switch (args.Length)
			{
				case 0:
					return UTC(0, 0, 1, 0, 0, 0, 0);
				case 1:
					return UTC(TypeConverter.ToInteger(args[0]), 0, 1, 0, 0, 0, 0);
				case 2:
					return UTC(TypeConverter.ToInteger(args[0]), TypeConverter.ToInteger(args[1]), 1, 0, 0, 0, 0);
				case 3:
					return UTC(TypeConverter.ToInteger(args[0]), TypeConverter.ToInteger(args[1]), TypeConverter.ToInteger(args[2], 1), 0, 0, 0, 0);
				case 4:
					return UTC(TypeConverter.ToInteger(args[0]), TypeConverter.ToInteger(args[1]), TypeConverter.ToInteger(args[2], 1), TypeConverter.ToInteger(args[3], 0), 0, 0, 0);
				case 5:
					return UTC(TypeConverter.ToInteger(args[0]), TypeConverter.ToInteger(args[1]), TypeConverter.ToInteger(args[2], 1), TypeConverter.ToInteger(args[3], 0), TypeConverter.ToInteger(args[4], 0), 0, 0);
				case 6:
					return UTC(TypeConverter.ToInteger(args[0]), TypeConverter.ToInteger(args[1]), TypeConverter.ToInteger(args[2], 1), TypeConverter.ToInteger(args[3], 0), TypeConverter.ToInteger(args[4], 0), TypeConverter.ToInteger(args[5], 0), 0);
				default:
					return UTC(TypeConverter.ToInteger(args[0]), TypeConverter.ToInteger(args[1]), TypeConverter.ToInteger(args[2], 1), TypeConverter.ToInteger(args[3], 0), TypeConverter.ToInteger(args[4], 0), TypeConverter.ToInteger(args[5], 0), TypeConverter.ToInteger(args[6], 0));
			}
		}

		private static object __STUB__parse(ScriptEngine engine, object thisObj, object[] args)
		{
			switch (args.Length)
			{
				case 0:
					return Parse("undefined");
				default:
					return Parse(TypeConverter.ToString(args[0]));
			}
		}
	}

}
