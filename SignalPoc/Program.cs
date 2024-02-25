using SignalPoc;

Console.WriteLine("Hello, World!");

var a = SignalOop.CreateSignal(1);
Console.WriteLine("a is " + a.Get());
var b = SignalOop.CreateSignal(2);
Console.WriteLine("b is " + b.Get());
var effect = SignalOop.CreateEffect(() =>
{
    Console.WriteLine("Sum is " + (a.Get() + b.Get()));
});

a.Update(val => val + 1); //2

b.Update(val => val + 1); //3

var (c, subscriptionC) = SignalOop.ComputeSignal(() => a.Get() + b.Get());
Console.WriteLine("c is " + c.Get());
a.Update(val => val + 1);
Console.WriteLine("a is " + a.Get());
b.Update(val => val + 1);
Console.WriteLine("b is " + b.Get());
Console.WriteLine("c is " + c.Get());

var (d, subscriptionD) = SignalOop.ComputeSignal(() => c.Get() * 2);
Console.WriteLine("d is " + d.Get());

c.Update(val => val + 1);
Console.WriteLine("a is " + a.Get());
Console.WriteLine("b is " + b.Get());
Console.WriteLine("c is " + c.Get());
Console.WriteLine("d is " + d.Get());

Console.WriteLine("Unsubscribe effect and c");
effect.Unsubscribe();
subscriptionC.Unsubscribe();
a.Update(val => val + 1);
b.Update(val => val + 1);
Console.WriteLine("a is " + a.Get());
Console.WriteLine("b is " + b.Get());
Console.WriteLine("No sum shown");
Console.WriteLine("c is " + c.Get());
Console.WriteLine("d is " + d.Get());

Console.WriteLine("Unsubscribe d");
subscriptionD.Unsubscribe();
c.Update(val => val + 1);
Console.WriteLine("c is " + c.Get());
Console.WriteLine("d is " + d.Get());

Console.ReadKey();