/* Purpose: Manage the attributes of an issue with 
 *          city infrastructure for Happyville, Nova Scotia
 * Author : Joseph Davidson
 * Date   : February, 2016
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace IssueTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test the initial constructor.
            Tracker tracker1 = new Tracker(2, 3, 3, "It's Bad", "Some", "Body", Convert.ToDateTime("2016-02-02"));
            Console.Write("Returned: ");
            Console.WriteLine(tracker1.GetIssueDetails(true));
            Console.WriteLine("Expected: 1, {X=2,Y=3}, road, It's Bad, Some Body, 2/2/2016");

            //Print a blank line for formatting.
            Console.WriteLine();

            // Test the second constructor.
            Tracker tracker2 = new Tracker(2, 2, 2, "Broken");
            Console.Write("Returned: ");
            Console.WriteLine(tracker2.GetIssueDetails(true));
            Console.WriteLine("Expected: 2, {X=2,Y=2}, signage, Broken, Not Known, 2/7/2016");

            //Print a blank line for formatting.
            Console.WriteLine();

            // Test the Issue Date for dates in the future.
            Tracker tracker3 = new Tracker(0, 0, 0, "", "", "", Convert.ToDateTime("2016-03-01"));
            Console.Write("Returned: ");
            Console.WriteLine(tracker3.IssueDate);
            Console.WriteLine("Expected: 2/7/2016 12:00:00 AM");

            //Print a blank line for formatting.
            Console.WriteLine();

            // Test the Issue Date for dates > than 1 year ago.
            Tracker tracker4 = new Tracker(0, 0, 0, "", "", "", Convert.ToDateTime("2015-02-01"));
            Console.Write("Returned: ");
            Console.WriteLine(tracker4.IssueDate);
            Console.WriteLine("Expected: 2/7/2016 12:00:00 AM");

            //Print a blank line for formatting.
            Console.WriteLine();

            // Test the Issue Type method for the 'facility' Issue Type.
            Tracker tracker5 = new Tracker(0, 0, 1, "");
            Console.Write("Returned: ");
            Console.WriteLine(tracker5.GetIssueType());
            Console.WriteLine("Expected: facility");

            //Print a blank line for formatting.
            Console.WriteLine();

            // Test the Issue Type method for the 'facility' Issue Type.
            Tracker tracker6 = new Tracker(0, 0, 2, "");
            Console.Write("Returned: ");
            Console.WriteLine(tracker6.GetIssueType());
            Console.WriteLine("Expected: signage");

            //Print a blank line for formatting.
            Console.WriteLine();

            // Test the Issue Type method for the 'facility' Issue Type.
            Tracker tracker7 = new Tracker(0, 0, 3, "");
            Console.Write("Returned: ");
            Console.WriteLine(tracker7.GetIssueType());
            Console.WriteLine("Expected: road");

            //Print a blank line for formatting.
            Console.WriteLine();

            // Test the Issue Type method for numbers outside of 1, 2, or 3.
            Tracker tracker8 = new Tracker(0, 0, 5, "");
            Console.Write("Returned: ");
            Console.WriteLine(tracker8.GetIssueType());
            Console.WriteLine("Expected: unknown");

            // Pause the program
            Console.ReadKey();
        }
    }
}
