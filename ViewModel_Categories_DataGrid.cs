using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LocalMall
{
    //Step3:
    public class ViewModel_Categories_DataGrid
    {
        public BindingList<ViewModel_Categories_DataGrid_Row> vmDatagrid = new BindingList<ViewModel_Categories_DataGrid_Row>();
    }

    public class ViewModel_Categories_DataGrid_Row
    {
        #region  1.   Copy all the Model class properties here, edit if necessary to fit the display on GridView
        public string CatCode { get; set; }
        public string Name { get; set; }
        #endregion

        #region  2. Create an object (oModel) of the model class to store the values to update Database
        private StoreCategory oModel = new StoreCategory(); //This store the format to update Database
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
        public ViewModel_Categories_DataGrid_Row(IEnumerable<XElement> elements)
        {
            Console.WriteLine($"initial Error count = {errorCount} ");
            if (elements.Count() == 2)
            {
                List<XElement> elementsList = elements.ToList();

                CatCode = NullOrWhiteSpaceCheck(elementsList[0].Value.ToString(), "CatCode") ? "" : elementsList[0].Value.ToString();
                oModel.CatCode = CatCode;

                Name = NullOrWhiteSpaceCheck(elementsList[1].Value.ToString(), "Name") ? "" : elementsList[1].Value.ToString();
                oModel.Name = Name;

                Console.WriteLine($"Final Error count ={errorCount}, error = {strErrorDetails}");
            }
            else
            {
                errorCount++;
                strErrorDetails += $"Total Elements not equals to 2";
                Console.WriteLine($" elements length wrong , len = {elements.Count()}");
                if (elements.Count() > 0)
                {
                    foreach (var f in elements.Elements())
                    {
                        Console.WriteLine(f.ToString());
                    }
                }
            }
        }
        #endregion

        #region 4. Create XXX getDBData() method to return the oModel object to add new record into database
        public StoreCategory getDBData()
        {
            Console.WriteLine($"error count for CatCode:{CatCode} = {errorCount}\n");
            return (errorCount > 0) ? null : oModel;
        }
        #endregion


        #region 5. Create updateExistingDBRecord (XXX oModelUpdate) to update the current GridView Row data
        public void updateExistingDBRecord(StoreCategory oModelUpdate)
        {
            oModelUpdate.CatCode = oModel.CatCode;
            oModelUpdate.Name = oModel.Name;
        }
        #endregion
    }
}
