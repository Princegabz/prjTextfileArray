using System;
using System.IO;
using Xceed.Wpf.Toolkit;

namespace prjTextfileArray
{
    internal class Program
    {
        private static StreamReader filein;
        private static StreamWriter fileout;
        private static string[] id = new string[3];
        private static string[] name = new string[3];
        private static string[] price = new string[3];

        static void Main(string[] args)
        {
            fillArray();
            int choice = 1;
            while (choice==1)
            {
                printArray();
                Console.WriteLine("would you like to update a products price Enter (1) for YES:");//
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    enterNewValues();
                }
            }
        }
       
        private static void fillArray()
        {
            try
            {
                int x = 0;
                string proj = "";
                if (File.Exists("Products.txt"))
                {
                    filein = new StreamReader("Products.txt");
                    while ((proj = filein.ReadLine()) !=null)
                    {
                        id[x] = proj;
                        proj = filein.ReadLine();
                        name[x] = proj;
                        proj = filein.ReadLine();
                        price[x] = proj;
                        x += 1;
                    }
                    filein.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The following error has occured: " + ex.ToString());
            }
        }
       
        private static void printArray()
        {
            Console.Clear();
            Console.WriteLine("PRINTOUT FROM THE PRODUCTS TEXT FILE");
            Console.WriteLine("********************************************");
            for (int y = 0; y < 3; y++)
            {
                Console.WriteLine("ID: " + id[y]);
                Console.WriteLine("PRODUCT: " + name[y]);
                Console.WriteLine("PRICE: " + price[y]);
                Console.WriteLine("********************************************");
            }
        }
        private static void enterNewValues()
        {
            Console.Clear();
            Console.WriteLine("Enter the product ID to edit: ");
            string strID = Console.ReadLine();
            Boolean change = false;
            Boolean productFound = false;

            for (int y = 0; y < 3; y++)
            {
                if (strID.Equals(id[y]))
                {
                    Console.WriteLine("Enter the new product price: ");
                    price[y] = Console.ReadLine();
                    change = true;
                    productFound = true;
                }              
            }
            if (productFound == false)
            {
                Console.WriteLine("The productID yoou entered cannot be located! Update Failed");
            }
            if (change == true)
            {
                writeBackToFile();
            }
        }

        private static void writeBackToFile()
        {
            try
            {
                File.Delete("Products.txt");
                fileout = new StreamWriter("Products.txt", true);
                for (int y = 0; y < 3; y++)
                {
                    fileout.WriteLine(id[y]);
                    fileout.WriteLine(name[y]);
                    fileout.WriteLine(price[y]);
                }
                fileout.Close();
                Console.WriteLine("Product file updated succesfully!", "update");

            }
            catch (Exception ex)
            {
                Console.WriteLine("The following error has occured: " + ex.ToString());
            }
            printArray();
        }
    }
}
