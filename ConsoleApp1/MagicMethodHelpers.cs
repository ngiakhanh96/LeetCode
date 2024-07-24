using System.Linq.Expressions;
using System.Reflection;

internal class MagicMethodHelpers
{
    //Not support to create open delegate for generic method of class that extends interface 
    public static Func<TTarget, object, object> MagicMethodHelperOld<TTarget, TParam, TReturn>(MethodInfo method)
        where TTarget : class
    {
        // Convert the slow MethodInfo into a fast, strongly typed, open delegate
        Func<TTarget, TParam, TReturn> func = (Func<TTarget, TParam, TReturn>)Delegate.CreateDelegate
            (typeof(Func<TTarget, TParam, TReturn>), method);
        Func<TTarget, object, object> ret = (target, param) => func(target, (TParam)param);
        return ret;
    }

    public static Func<object, object, object> MagicMethodHelperNew(MethodInfo method, Type targetType)
    {
        var instance = Expression.Parameter(typeof(object), "instance");
        var argument = Expression.Parameter(typeof(object), "argument");
        var methodCall = Expression.Call(
            Expression.Convert(instance, targetType),
            method,
            Expression.Convert(argument, method.GetParameters()[0].ParameterType)
        );

        return Expression.Lambda<Func<object, object, object>>(
            methodCall,
            instance,
            argument
        ).Compile();
    }
}