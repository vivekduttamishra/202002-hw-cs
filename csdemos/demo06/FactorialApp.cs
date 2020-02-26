class FactorialApp
{
	static void Main()
	{
		int x=5;
		Calculator myCalculator= new Calculator(); //you need an object
		int fx=myCalculator.Factorial(x);          //to do the calculation

		System.Console.WriteLine("Factorial of "+x+" is "+fx);
	}
}

