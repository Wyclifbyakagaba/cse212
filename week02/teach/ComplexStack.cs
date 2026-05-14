using System.Diagnostics;

public interface IComplexStack
{
    static abstract bool DoSomethingComplicated(string line);
}

public class ComplexStack : IComplexStack
{
    public static bool DoSomethingComplicated(string line)
    {
        if (line == "A")
            return true;// true equivalent

        if (line == "B")
            return false; // false equivalent
        return true; // default fallback (must return bool)
    }
}