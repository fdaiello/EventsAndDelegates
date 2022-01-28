using EventsAndDelegates;

class Program
{
    static void Main()
    {
        TestCounter();

    }

    static void TestCounter()
    {
        var c = new Counter(5) { Value = 0};

        // Sign to the event - when event c.ThresholdReached is fired, it will also fire c_ThresholdReached
        c.ThresholdReached += c_ThresholdReached;

        for ( int x =0; x < 20; x++)
        {
            c.Increment();
            Console.WriteLine(c.Value);
        }

        static void c_ThresholdReached(object sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine($"The threshold was reached: {e.Threshold} at {e.TimeReached}");

        }
    }

    // Declares a delegate for a method that takes in an int and returns a string.
    public delegate string myMethodDelegate(int myInt);

    static void DelegateExemple()
    {

        // Creates one delegate for each method. For the instance method, an
        // instance (mySC) must be supplied. For the static method, use the
        // class name.
        mySampleClass mySC = new mySampleClass();
        myMethodDelegate myD1 = new myMethodDelegate(mySC.myStringMethod);
        myMethodDelegate myD2 = new myMethodDelegate(mySampleClass.mySignMethod);

        // Invokes the delegates.
        Console.WriteLine("{0} is {1}; use the sign \"{2}\".", 5, myD1(5), myD2(5));
        Console.WriteLine("{0} is {1}; use the sign \"{2}\".", -3, myD1(-3), myD2(-3));
        Console.WriteLine("{0} is {1}; use the sign \"{2}\".", 0, myD1(0), myD2(0));
    }

    // Declares a Delegate
    public delegate int myAdditionDelegate(int x, int y);

    /*
     * Test Addition Delegate
     */
    static void TestAdditionDelegate()
    {
        myAdditionDelegate md = new myAdditionDelegate(Operation.Addition);

        Console.WriteLine($" 1 + 1 = {md(1,1)}");
    }
}
