

class FurnitureApp
{
    static void Main()
    {
        Chair chair1=new Chair();
        chair1.price=1000;
        System.Console.WriteLine("chair1:"+chair1+"\tprice is "+chair1.price);

        Chair chair2=new Chair();
        chair2.price=5000;
        System.Console.WriteLine("chair2:{0}\tprice is:{1}",chair2,chair2.price);

        List list1=new List();
        System.Console.WriteLine("list1 is {0}",list1);

        Table table1=new Table();
        System.Console.WriteLine("table is {0}",table1);

    }
}