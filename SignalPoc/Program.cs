using SignalPoc;

List<Tuple<int, int>> customerAccounts = new List<Tuple<int, int>>()
{
    Tuple.Create(1, 10),
    Tuple.Create(1, 11),
    Tuple.Create(2, 13),
    Tuple.Create(3, 11),
    Tuple.Create(4, 14),
    Tuple.Create(3, 10),
    Tuple.Create(4, 13)
};

List<List<int>> matchingCustomers = FindMatchingCustomers(customerAccounts);

Console.WriteLine("Matching Customers:");
foreach (List<int> match in matchingCustomers)
{
    Console.WriteLine($"Customer(s) {string.Join(", ", match)}");
}
List<List<int>> FindMatchingCustomers(List<Tuple<int, int>> customerAccounts)
{
    Dictionary<int, HashSet<int>> accountOwners = new Dictionary<int, HashSet<int>>();

    // Populate the dictionary
    foreach (var pair in customerAccounts)
    {
        int customerId = pair.Item1;
        int accountId = pair.Item2;

        if (!accountOwners.ContainsKey(accountId))
        {
            accountOwners[accountId] = new HashSet<int>();
        }

        accountOwners[accountId].Add(customerId);
    }

    // Find customers who share all the same accounts
    List<List<int>> matchingCustomers = new List<List<int>>();
    foreach (var pair1 in accountOwners)
    {
        foreach (var pair2 in accountOwners)
        {
            if (pair1.Key != pair2.Key && pair1.Value.SetEquals(pair2.Value))
            {
                List<int> matchingCustomer = new List<int> { pair1.Value.First(), pair2.Value.First() };
                matchingCustomers.Add(matchingCustomer);
            }
        }
    }

    return matchingCustomers;
}
Console.WriteLine("Hello, World!");

var a = Signal.CreateSignal(1);
Console.WriteLine("a is " + a.Get());//1
var b = Signal.CreateSignal(2);
Console.WriteLine("b is " + b.Get());//2
var effect = Signal.CreateEffect(() =>
{
    Console.WriteLine("Sum is " + (a.Get() + b.Get()));//Sum is 3
});

a.Update(val => val + 1); //Sum is 4

b.Update(val => val + 1); //Sum is 5

var c = Signal.ComputeSignal(() => a.Get() + b.Get());
Console.WriteLine("c is " + c.Get());//5
a.Update(val => val + 1);//Sum is 6
Console.WriteLine("a is " + a.Get());//3
b.Update(val => val + 1);//Sum is 7
Console.WriteLine("b is " + b.Get());//4
Console.WriteLine("c is " + c.Get());//7

var d = Signal.ComputeSignal(() => c.Get() * 2);
Console.WriteLine("d is " + d.Get());//14
Console.WriteLine("a is " + a.Get());//3
Console.WriteLine("b is " + b.Get());//4
Console.WriteLine("c is " + c.Get());//7

a.Update(val => val + 1);//Sum is 8
Console.WriteLine("c is " + c.Get());//8
Console.WriteLine("d is " + d.Get());//16

Console.WriteLine("----------------------------");
Console.WriteLine("Unsubscribe effect and c");
effect.Unsubscribe();
c.Unsubscribe();
Console.WriteLine("No sum shown");
a.Update(val => val + 1);
b.Update(val => val + 1);
Console.WriteLine("a is " + a.Get());//5
Console.WriteLine("b is " + b.Get());//5
Console.WriteLine("c is " + c.Get());//8
Console.WriteLine("d is " + d.Get());//16

Console.WriteLine("----------------------------");
Console.WriteLine("Conditional signal");
var e = Signal.CreateSignal(true);
Console.WriteLine("e is " + e.Get());//true
var f = Signal.ComputeSignal(() =>
{
    if (e.Get())
    {
        return a.Get();
    }
    return b.Get();
});
Console.WriteLine("f is " + f.Get());//5
a.Update(v => v + 1);
Console.WriteLine("f is " + f.Get());//6
e.Update(v => !v);
Console.WriteLine("e is " + e.Get());//false
Console.WriteLine("f is " + f.Get());//5
b.Update(v => v + 1);
Console.WriteLine("f is " + f.Get());//6
a.Update(v => v + 1);
Console.WriteLine("f is " + f.Get());//6

Console.WriteLine("----------------------------");
Console.WriteLine("Effect on computed signal");
var effect2 = Signal.CreateEffect(() =>
{
    Console.WriteLine("EffectF is " + f.Get());//EffectF is 6
});
b.Update(v => v + 1);
Console.WriteLine("b is " + b.Get());//7 

Console.WriteLine("f is " + f.Get());//EffectF is 7
                                     //7

Console.WriteLine("----------------------------");
Console.WriteLine("Unsubscribe effectF and f");
f.Unsubscribe();
effect2.Unsubscribe();
b.Update(v => v + 1);
Console.WriteLine("No EffectF shown");
Console.WriteLine("b is " + b.Get());//8
Console.WriteLine("f is " + f.Get());//7

Console.ReadKey();