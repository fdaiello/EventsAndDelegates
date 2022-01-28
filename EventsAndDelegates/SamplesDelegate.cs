namespace EventsAndDelegates
{ 
    // Defines some methods to which the delegate can point.
    public class mySampleClass
    {

        // Defines an instance method.
        public string myStringMethod(int myInt)
        {
            if (myInt > 0)
                return ("positive");
            if (myInt < 0)
                return ("negative");
            return ("zero");
        }

        // Defines a static method.
        public static string mySignMethod(int myInt)
        {
            if (myInt > 0)
                return ("+");
            if (myInt < 0)
                return ("-");
            return ("");
        }
    }

}
