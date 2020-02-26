class FactorialApp
{
	static void Main()
	{
		int x=5;
		int fx=Calculator.Factorial(x);

		System.Console.WriteLine("Factorial of "+x+" is "+fx);
	}
}



class Calculator
{
	public static int Factorial(int n)
	{
		if(n<1)
			return 1;
		else
			return n * Factorial(n-1);
	}

}