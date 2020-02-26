
using ConceptArchitect.Furnitures; //get all names from this namespace with needing a context
using ConceptArchitect.Data;
using PrabhatCorps.Data;
using System;

//RECOMMENDED. SPECIFY WHICH TABLE IS DEFAULT
using Table=ConceptArchitect.Data.Table; //Table by default means ConceptArchitectData.Table

//NOT RECOMMENDED. CREATES A NEW NAME THAT MAY CAUSE CONFUSION
using FTable=ConceptArchitect.Furnitures.Table; //FTable is an alias now

class FurnitureApp
{
    static void Main()
    {
        Chair chair1=new Chair();
        chair1.price=1000;
        Console.WriteLine("chair1:"+chair1+"\tprice is "+chair1.price);

        Chair chair2=new Chair();
        chair2.price=5000;
        Console.WriteLine("chair2:{0}\tprice is:{1}",chair2,chair2.price);

        List list1=new List();
        Console.WriteLine("list1 is {0}",list1);

        Table table1=new Table();
        Console.WriteLine("table is {0}",table1);

        FTable table2=new FTable(); //what is this class? I dont know
        Console.WriteLine("table2 is {0}",table2);

        Set set1=new Set();
        Console.WriteLine("set1 is {0}",set1);

        PrabhatCorps.Data.Table table3=new PrabhatCorps.Data.Table();
        Console.WriteLine("table3 is {0}",table3);

    }
}