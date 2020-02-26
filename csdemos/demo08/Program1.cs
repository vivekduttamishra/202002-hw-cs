

class FurnitureApp
{
    static void Main()
    {
        Furnitures.Chair chair1=new Furnitures.Chair();
        chair1.price=1000;
        System.Console.WriteLine("chair1:"+chair1+"\tprice is "+chair1.price);

        Furnitures.Chair chair2=new Furnitures.Chair();
        chair2.price=5000;
        System.Console.WriteLine("chair2:{0}\tprice is:{1}",chair2,chair2.price);

        Data.List list1=new Data.List();
        System.Console.WriteLine("list1 is {0}",list1);

        Furnitures.Table table1=new Furnitures.Table();
        System.Console.WriteLine("table is {0}",table1);

        Data.Table table2=new Data.Table();
        System.Console.WriteLine("table2 is {0}",table2);

        Data.Set set1=new Data.Set();
        System.Console.WriteLine("set1 is {0}",set1);

    }
}