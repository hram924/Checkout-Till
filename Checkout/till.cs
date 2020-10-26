using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkout
{
    public class Till
    {

        private Dictionary<char, int> _items = new Dictionary<char, int>{
            {'A', 0},
            {'B', 0},
            {'C', 0},
			{'D', 0} // added d in dictionary 
        };

        public double Total() 
        { 
            double total = 0;
            foreach(var item in _items)
            {
                if(item.Key.Equals('A'))
                {
                    total += AddA(item.Value.ToString()); //added function to implement discount
                }
                else if(item.Key.Equals('B'))
                {
                    total += AddB(item.Value.ToString());
                } 
                else if(item.Key.Equals('C'))
                {
                    total = AddItemC(total, item);
                }
                else total = AddItemD(total, item);
            } 
           return total;
        }

static double AddItemD(double total, KeyValuePair<char, int> item)
{
    if (item.Key.Equals('D'))
    {
        total += 15 * item.Value;
    }

    return total;
}


        private static double AddItemC(double total, KeyValuePair<char, int> item)
        {
            if (item.Key.Equals('C'))
            {
                total += 15 * item.Value;
            }

            return total;
        }
		
		
        public double AddA(string numberItems)
        {
            int items = Int32.Parse(numberItems); //changed double to int so the number of pairs does not have any decimals

            if(items == 0) return 0;

            var cost = items * 50;
                var numberOfGroups =  items / 3; 

            // discount is 20 on each group
            var discount = numberOfGroups * 20;
            return cost - discount;
        }

        public double AddB(string numberItems)
        {
            int items = Int32.Parse(numberItems); //changed double to int so the number of pairs does not have any decimals

            if(items == 0) return 0;

            var cost = items * 30; 
                var numberOfPairs =  items / 2; 

            // discount is 15 on each pair
            var discount = numberOfPairs * 15;
            return cost - discount;
        }

        public void Scan(string items)
        {
            foreach(var item in items)
            {
                _items[item]++;  
            }
            //Adding function to limit the scans of C to 6 with a warning message
            if(_items['C'] > 6)
            {
                _items['C'] = 6;
                Console.WriteLine("There is a limit of 6 for item C");
            }
        }
    }
}