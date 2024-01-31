using System.Security.Cryptography.X509Certificates;

class MyProg
{

    public interface ProductIF
    {

    }

    public abstract class ProductABS() : ProductIF, IComparable<ProductABS>
    {
        private int ID;
        private double Price;
        private string Name;

        public int CompareTo(ProductABS? other)
        {
           if (other == null) return 1;
           return Price.CompareTo(other.Price);
        }

        public static bool operator >(ProductABS operand1, ProductABS operand2)
        {
            return operand1.CompareTo(operand2) > 0;
        }

        public static bool operator <(ProductABS operand1, ProductABS operand2)
        {
            return operand1.CompareTo(operand2) < 0;
        }

        public void setName(string name) 
        {
            Name = name;
        }

        public void setPrice(double price)
        { 
            Price = price;
        }

        public double getPrice()
        {
            return Price;
        }
    }

    public class Company
    {
        public SortUtility<ProductIF> sortUtility;
    }

    public class SortUtility<T> where T : ProductIF
    {
        string sortName;
        public SortUtility() { sortName = "bubblesort"; }
        public SortUtility(string sortName) 
        {   this.sortName = sortName;
        
        }

        public string getName() { return sortName; }
        public virtual List<T> sort(List<T> data)
        {
            Console.WriteLine("wrong function");
           return data;
        }
    }

    public class BubbleSort<T>: SortUtility<T> where T : ProductABS
    {
        public override List<T> sort(List<T> data)
        {
            
            T[] dataArray = data.ToArray();
            int listCount = dataArray.Length;
            for(int i = 0; i < listCount - 1; i++) 
            {
                for(int j = 0; j < listCount - 1; j++)
                {
                    if (dataArray[j] > dataArray[j+1])
                    {
                        var temp = dataArray[j];
                        dataArray[j] = dataArray[j+1];
                        dataArray[j+1] = temp;
                    }
                }
            }
            List<T> finalList = dataArray.ToList();
            Console.WriteLine("right funtion");
            return finalList;
        }
    }

    public class Desk: ProductABS
    {
        
    }



        public static void Main(string[] args)
    {
       SortUtility<Desk> newSort = new BubbleSort<Desk>();

       Desk desk1 = new Desk();
        desk1.setName("d1");
        desk1.setPrice(100);

        Desk desk2 = new Desk();
        desk2.setPrice(200);
        desk2.setName("d2");

        List<Desk> list = new List<Desk>();
        
      
        list.Add(desk1);
        list.Add(desk2);

        newSort.sort(list);

        foreach (Desk desk in list)
        {
            Console.WriteLine(desk.getPrice().ToString());
        }
    }
}
