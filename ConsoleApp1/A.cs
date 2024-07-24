using System.Reflection;

public class A : IA
{
    public IEnumerable<T> Test<T>(IEnumerable<T> c)
    {
        return c;
    }
}

public static class Test
{
    public static void RunTest()
    {
        IA a = new A();
        var method = a.GetType().GetMethod(nameof(A.Test)).MakeGenericMethod(typeof(char));
        // First fetch the generic form
        //Func<object, object, object> ret = (Func<object, object, object>)typeof(B)
        //    .GetMethod(
        //        nameof(B.MagicMethodHelperOld),
        //        BindingFlags.Public | BindingFlags.Static)
        //    .MakeGenericMethod(
        //        a.GetType(),
        //        method.GetParameters()[0].ParameterType,
        //        method.ReturnType)
        //    .Invoke(null, [method]);

        Func<object, object, object> ret = (Func<object, object, object>)typeof(MagicMethodHelpers)
            .GetMethod(
                nameof(MagicMethodHelpers.MagicMethodHelperNew),
                BindingFlags.Public | BindingFlags.Static)
            .Invoke(null, [method, a.GetType()]);
        IA b = new A();
        var res = (IEnumerable<char>)ret(b, new List<char> { 'e' });
        Console.WriteLine(res.ToList()[0]);
    }
}