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
    class Tracker
    {
        #region Fields
        /// <summary>
        /// Fields
        /// </summary>
        public static int CurrentID = 1;
        private Point issueLocation;
        private DateTime issueDate;
        private int issueID;
        private int issueType;
        private string firstName, lastName;
        private string issueDescription;
        #endregion

        #region Properties
        /// <summary>
        /// Properties
        /// </summary>
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public DateTime IssueDate 
        { 
            get { return issueDate; } 
            set 
            { 
                int diffYear = (int)(DateTime.Today - value).TotalDays;
                if ((diffYear < 0 || diffYear > 365))
                    issueDate = DateTime.Today;
                else issueDate = value; 
            } 
        }
        public int IssueType 
        { 
            get { return issueType; } 
            set 
            { 
                if (!(value == 1 || value == 2 || value == 3)) 
                    issueType = 0;
                else issueType = value;
            } 
        }
        #endregion

        #region Initial Constructor
        /// <summary>
        /// Initial Constructor -- All values declared
        /// </summary>
        /// <param name="coordinateX">Point Value X</param>
        /// <param name="coordinateY">Point Value Y</param>
        /// <param name="it">Issue Type</param>
        /// <param name="id">Issue Description</param>
        /// <param name="fn">First Name</param>
        /// <param name="ln">Last Name</param>
        /// <param name="idate">Issue Date</param>
        public Tracker(int coordinateX, int coordinateY, int it, string id, string fn, string ln, DateTime iDate)
        {
            issueLocation = new Point(coordinateX, coordinateY);
            FirstName = fn;
            LastName = ln;
            IssueDate = iDate;
            IssueType = it;
            issueDescription = id;
            issueID = incrementID();
        }
        #endregion
        #region Second Constructor
        /// <summary>
        /// Constructor - Point Coordinates, issue type passed as integers and issue description passed as string.
        /// </summary>
        /// <param name="coordinateX">Point Value X</param>
        /// <param name="coordinateY">Point Value Y</param>
        /// <param name="it">Issue Type</param>
        /// <param name="id">Issue Description</param>
        public Tracker(int coordinateX, int coordinateY, int it, string id)
            : this(coordinateX, coordinateY, it, id, "Not", "Known", 
                DateTime.Today) { }
        #endregion

        #region Method - Issue Type
        /// <summary>
        /// Determine the issue's type
        /// </summary>
        /// <returns>A numeric value representing the issue type</returns>
        public string GetIssueType()
        {
            string typeOutput = "unknown";
            if (issueType == 1) 
            { 
                typeOutput = "facility"; 
            }
            if (issueType == 2) 
            { 
                typeOutput = "signage"; 
            }
            if (issueType == 3) 
            { 
                typeOutput = "road"; 
            }
            return typeOutput;
        }
        #endregion
        #region Method - Issue details
        /// <summary>
        /// Concatenate the issue details.
        /// </summary>
        /// <returns>The issue's ID, location, type and description passed as strings</returns>
        public string GetIssueDetails()
        {
            return issueID + ", " + issueLocation + ", "
                + GetIssueType() + ", " + issueDescription;
        }
        /// <summary>
        /// Concatenate remaining issue fields if the issue date is set.
        /// </summary>
        /// <param name="dDate">Include Issue Date</param>
        /// <returns>All issue details as a string</returns>
        public string GetIssueDetails(bool iDate)
        {
            if (iDate)
                return GetIssueDetails() + ", " + firstName + " " + lastName 
                    + ", " + issueDate.ToShortDateString();
            else
                return GetIssueDetails();
        }
        #endregion
        #region Method - IncrementID
        /// <summary>
        /// Increment the automatically assigned issue ID number.
        /// </summary>
        /// <returns>The ID number of the issue.</returns>
        private static int incrementID()
        {
            return CurrentID++;
        }
        #endregion
    }
}