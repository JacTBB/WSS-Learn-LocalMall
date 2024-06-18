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
    public class ViewModel_Stores_DataGrid
    {
        public BindingList<ViewModel_Stores_DataGrid_Row> vmDatagrid = new BindingList<ViewModel_Stores_DataGrid_Row>();
    }

    public class ViewModel_Stores_DataGrid_Row
    {
        #region  1.   Copy all the Model class properties here, edit if necessary to fit the display on GridView
        public string StoreId { get; set; }
        public string MallId { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public string Unit { get; set; }
        public string Website { get; set; }
        public string Tel { get; set; }
        #endregion

        #region  2. Create an object (oModel) of the model class to store the values to update Database
        private Store oModel = new Store(); //This store the format to update Database
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
        public ViewModel_Stores_DataGrid_Row(IEnumerable<XElement> elements)
        {
            Console.WriteLine($"initial Error count = {errorCount} ");
            if (elements.Count() == 8)
            {
                List<XElement> elementsList = elements.ToList();

                StoreId = NullOrWhiteSpaceCheck(elementsList[0].Value.ToString(), "StoreId") ? "" : elementsList[0].Value.ToString();
                oModel.StoreId = int.TryParse(StoreId, out int pasedStoreId) ? pasedStoreId : -1;
                if (oModel.StoreId == -1) // error
                {
                    oModel.StoreId = 0;
                    errorCount++;
                    strErrorDetails += $"StoreId is not a Integer value : {elementsList[0].Value.ToString()}\n";
                }
                //oModel.StoreId = StoreId;

                MallId = NullOrWhiteSpaceCheck(elementsList[1].Value.ToString(), "MallId") ? "" : elementsList[1].Value.ToString();
                oModel.MallId = MallId;
                
                Name = NullOrWhiteSpaceCheck(elementsList[2].Value.ToString(), "Name") ? "" : elementsList[2].Value.ToString();
                oModel.Name = Name;
                
                Level = NullOrWhiteSpaceCheck(elementsList[3].Value.ToString(), "Level") ? "" : elementsList[3].Value.ToString();
                oModel.Level = Level;
                if (Level.Length > 4)
                {
                    errorCount++;
                    strErrorDetails += $"Invalid Level : {elementsList[3].Value.ToString()}\n";
                }

                Unit = NullOrWhiteSpaceCheck(elementsList[4].Value.ToString(), "Unit") ? "" : elementsList[4].Value.ToString();
                oModel.Unit = Unit;
                if (Unit.Length > 16)
                {
                    errorCount++;
                    strErrorDetails += $"Invalid Unit : {elementsList[4].Value.ToString()}\n";
                }

                Website = (String.IsNullOrWhiteSpace(elementsList[5].Value.ToString()) || elementsList[5].Value.ToString().ToLower().Equals("null")) ? "" : elementsList[5].Value.ToString();
                oModel.Website = Website;

                Tel = elementsList[6].Value.ToString();
                Tel = Tel.Replace(" ", "");
                if (String.IsNullOrWhiteSpace(Tel) || Tel.ToLower().Equals("null"))
                    Tel = "";

                if ("" != Tel)
                {
                    //Remove empty spaces from tel number before processing e.g. “6555 0123” will be
                    // converted to “65550123” . Tel numbers must have exactly 8 characters if do not include
                    // Singapore code(does not include +65). Otherwise, Tel numbers must have exactly 11
                    //characters(include + 65). 
                    // so only accept 8 digit or +65 with 8 digits, other format need to reject
                    string pattern1 = @"^\d{8}$";
                    string pattern2 = @"^\+65\d{8}$";
                    if (!Regex.IsMatch(Tel.Replace(" ", ""), pattern1)) // not SG 8 digit
                    {
                        if (!Regex.IsMatch(Tel.Replace(" ", ""), pattern2)) // also not +65 SG 8 digit
                        {
                            //declare error, will not save to DB later
                            errorCount++;
                            strErrorDetails += $"Tel is not 8 digits or +65 with 8 digits : {elementsList[6].Value.ToString()} \n";
                            //Console.WriteLine($"Error count ={errorCount}, error = {strErrorDetails}");
                        }
                    }
                }
                // valid +65 Tel.
                // Database length is only 8, so although display +65 at gridview, need to remove before save to DB
                if (Tel.Length == 11 && Tel.StartsWith("+65"))
                {
                    oModel.Tel = Tel.Substring(3);
                    Console.WriteLine($"Remove Tel +65 : {Tel} becomes {oModel.Tel}");
                }
                else
                    oModel.Tel = Tel;

                Console.WriteLine($"Final Error count ={errorCount}, error = {strErrorDetails}");
            }
            else
            {
                errorCount++;
                strErrorDetails += $"Total Elements not equals to 8";
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
        public Store getDBData()
        {
            Console.WriteLine($"error count for Name:{Name} = {errorCount}\n");
            return (errorCount > 0) ? null : oModel;
        }
        #endregion


        #region 5. Create updateExistingDBRecord (XXX oModelUpdate) to update the current GridView Row data
        public void updateExistingDBRecord(Store oModelUpdate)
        {
            oModelUpdate.StoreId = oModel.StoreId;
            oModelUpdate.MallId = oModel.MallId;
            oModelUpdate.Name = oModel.Name;
            oModelUpdate.Level = oModel.Level;
            oModelUpdate.Unit = oModel.Unit;
            oModelUpdate.Website = oModel.Website;
            oModelUpdate.Tel = oModel.Tel;
        }
        #endregion
    }
}
