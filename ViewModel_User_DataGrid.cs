using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LocalMall
{
    //Step3:
    public class ViewModel_User_DataGrid
    {
        public BindingList<ViewModel_User_DataGrid_Row> vmDatagrid = new BindingList<ViewModel_User_DataGrid_Row>();
    }

    public class ViewModel_User_DataGrid_Row
    {
        #region  1.   Copy all the Model class properties here, edit if necessary to fit the display on GridView
        public string UserId { get; set; }
        public string Pwd { get; set; }
        public string Role { get; set; }
        #endregion

        #region  2. Create an object (oModel) of the model class to store the values to update Database
        private User oModel = new User(); //This store the format to update Database
        #endregion

        #region   2a. Any other supporting methods/variables required
        private int errorCount { get; set; } = 0;
        private string strErrorDetails { get; set; } = "";
        public string getErrorDetails()
        {
            return strErrorDetails;
        }
        private bool NullOrWhiteSpaceCheck(string strValue, string name)
        {
            if (String.IsNullOrWhiteSpace(strValue) || strValue.ToLower().Equals("null"))
            {
                errorCount++;
                strErrorDetails += $"{name} is empty or null\n";
                return true;
            }
            return false;
        }
        #endregion


        #region 3. Create constructor to inject data to both Gridview as well as it's internal model object
        Dictionary<string, int> roles = new Dictionary<string, int>
        {
            { "Member", 0 },
            { "Admin", 1 }
        };
        public ViewModel_User_DataGrid_Row(string[] fields)
        {
            Console.WriteLine($"initial Error count = {errorCount} ");
            if (fields.Length == 3)
            {
                UserId = NullOrWhiteSpaceCheck(fields[0], "UserId") ? "" : fields[0];
                oModel.UserId = UserId;

                Pwd = NullOrWhiteSpaceCheck(fields[1], "Password") ? "" : fields[1];
                oModel.Pwd = Pwd;

                Role = NullOrWhiteSpaceCheck(fields[2], "Role") ? "" : fields[2];
                if (roles.ContainsKey(Role))
                {
                    oModel.Role = roles[Role];
                }
                else
                {
                    errorCount++;
                    strErrorDetails += $"Role is invalid : {fields[2]}\n";
                }

                Console.WriteLine($"Final Error count ={errorCount}, error = {strErrorDetails}");
            }
            else
            {
                errorCount++;
                strErrorDetails += $"Total Fields not equals to 3";
                Console.WriteLine($" fields length wrong , len = {fields.Length}");
                if (fields.Length > 0)
                {
                    foreach (var f in fields)
                    {
                        Console.WriteLine(f.ToString());
                    }
                }
            }
        }
        #endregion

        #region 4. Create XXX getDBData() method to return the oModel object to add new record into database
        public User getDBData()
        {
            Console.WriteLine($"error count for UserId:{UserId} = {errorCount}\n");
            return (errorCount > 0) ? null : oModel;
        }
        #endregion


        #region 5. Create updateExistingDBRecord (XXX oModelUpdate) to update the current GridView Row data
        public void updateExistingDBRecord(User oModelUpdate)
        {
            oModelUpdate.UserId = oModel.UserId;
            oModelUpdate.Pwd = oModel.Pwd;
            oModelUpdate.Role = oModel.Role;
        }
        #endregion
    }
}
