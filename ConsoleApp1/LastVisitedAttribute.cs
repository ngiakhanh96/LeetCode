namespace ConsoleApp1;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
internal class LastVisitedAttribute : Attribute
{
    public DateOnly LastVisitedDate;

    public LastVisitedAttribute(int year, int month, int day)
    {
        LastVisitedDate = new DateOnly(year, month, day);
    }
}