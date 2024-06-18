using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LocalMall
{
    //Step3:
    public class ViewModel_Mall_DataGrid
    {
        // This is the view for DataGrid
        // Need to use BindingList, do not use ObservableCollection as BindlingList is specially used with DataGridView
        public BindingList<ViewModel_Mall_DataGrid_Row> vmDatagrid = new BindingList<ViewModel_Mall_DataGrid_Row>();
    }

    public class ViewModel_Mall_DataGrid_Row
    {
        // This class is used to
        //      - store variables to be displayed on Gridview, also determine seq and headerText to store in Gridview
        //      - store a model object of the value to be stored in EF database model class format
        //      - perform any business rules checking of the row of data
        //      - return model object to be used to add to Database
        //      - Helps to update existing DBContext object with latest value to be updated to database

        #region  1.   Copy all the Model class properties here, edit if necessary to fit the display on GridView
        //      Model may store as a double value but in Gridview it is displayed as a String
        //      public properties are displayed on Gridview
        //      private properties are hidden from GridView
        //      Other methods are used for supporting any requirements and processing
        public string MallId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public string Tel { get; set; }
        public string NumOfLikes { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public string Description { get; set; }
        #endregion

        #region  2. Create an object (oModel) of the model class to store the values to update Database
        private Mall oModel = new Mall(); //This store the format to update Database
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
        // Use constructor to pass in csv string and perform all error checking
        // populate the values into oModel which will used for updates to DB if there is no error
        // csv format
        // mallId    name    street    postalCode    website    lat    lng    tel    description    numOfLikes
        public ViewModel_Mall_DataGrid_Row(string[] fields) // pass in csv delimited String []
        {
            Console.WriteLine($"initial Error count = {errorCount} ");
            if (fields.Length == 10)
            {
                MallId = NullOrWhiteSpaceCheck(fields[0], "MallId") ? "" : fields[0];
                oModel.MallId = MallId;

                Name = NullOrWhiteSpaceCheck(fields[1], "Name") ? "" : fields[1];
                oModel.Name = Name;

                string Street = NullOrWhiteSpaceCheck(fields[2], "Street") ? "" : fields[2];
                string PostalCode = NullOrWhiteSpaceCheck(fields[3], "PostalCode") ? "" : fields[3];
                if ("" != PostalCode)
                {
                    string pattern = @"^\d{6}$";
                    if (!Regex.IsMatch(PostalCode.Replace(" ", ""), pattern))
                    {
                        errorCount++;
                        strErrorDetails += $"PostalCode must be exactly 6 digits : {PostalCode}\n";
                        //Console.WriteLine($"Error count ={errorCount}, error = {strErrorDetails}");
                    }
                }
                Address = $"{Street} , Singapore {PostalCode}";

                //update model
                oModel.Street = Street;
                oModel.PostalCode = PostalCode;

                // Website,lat,lng are optional
                // We do not consider them error but still need correct to "" for storage
                Website = (String.IsNullOrWhiteSpace(fields[4]) || fields[4].ToLower().Equals("null")) ? "" : fields[4];
                oModel.Website = Website;

                Lat = (String.IsNullOrWhiteSpace(fields[5]) || fields[5].ToLower().Equals("null")) ? "" : fields[5];
                oModel.Lat = Double.TryParse(Lat, out double parsedLat) ? parsedLat : -1;
                if (oModel.Lat == -1) // error
                {
                    oModel.Lat = 0;
                    errorCount++;
                    strErrorDetails += $"Lat is not a double value : {fields[5]}\n";
                }

                Lng = (String.IsNullOrWhiteSpace(fields[6]) || fields[6].ToLower().Equals("null")) ? "" : fields[6];
                oModel.Lng = Double.TryParse(Lng, out double parsedLng) ? parsedLng : -1;
                if (oModel.Lng == -1) // error
                {
                    oModel.Lng = 0;
                    errorCount++;
                    strErrorDetails += $"Lng is not a double value : {fields[6]}\n";
                }

                // Specs mention Tel is optional. Database allow null. but it has some requirement.
                // Thus I accept empty tel but don't accept invalid tel
                Tel = fields[7];
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
                            strErrorDetails += $"Tel is not 8 digits or +65 with 8 digits : {fields[7]} \n";
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

                // We do not consider desc as error but still need correct to "" for storage
                Description = (String.IsNullOrWhiteSpace(fields[8]) || fields[8].ToLower().Equals("null")) ? "" : fields[8];
                oModel.Description = Description;

                NumOfLikes = NullOrWhiteSpaceCheck(fields[9], "NumOfLikes") ? "" : fields[9];
                oModel.NumOfLikes = int.TryParse(NumOfLikes, out int parsedNumOfLikes) ? parsedNumOfLikes : -1;
                if (oModel.NumOfLikes == -1) // error
                {
                    oModel.NumOfLikes = 0;
                    errorCount++;
                    strErrorDetails += $"NumOfLikes is not a Integer value : {fields[9]}\n";
                }

                Console.WriteLine($"Final Error count ={errorCount}, error = {strErrorDetails}");
            }
            else
            {
                errorCount++;
                strErrorDetails += $"Total Fields not equals to 10";
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
        // This is getting the converted data from view Model to EF model object
        // returns null when there is error, which should not be updated to database
        public Mall getDBData()
        {
            Console.WriteLine($"error count for name:{Name} = {errorCount}\n");
            return (errorCount > 0) ? null : oModel;
        }
        #endregion


        #region 5. Create updateExistingDBRecord (XXX oModelUpdate) to update the current GridView Row data
        // to existing database row using it's internal oModel which is in sync with the EF object 
        public void updateExistingDBRecord(Mall oModelUpdate)
        {
            // need to get from oModel as that is the format required for database
            oModelUpdate.MallId = oModel.MallId;
            oModelUpdate.Name = oModel.Name;
            oModelUpdate.Street = oModel.Street;
            oModelUpdate.PostalCode = oModel.PostalCode;
            oModelUpdate.Website = oModel.Website;
            oModelUpdate.Lat = oModel.Lat;
            oModelUpdate.Lng = oModel.Lng;
            oModelUpdate.Description = oModel.Description;
            oModelUpdate.NumOfLikes = oModel.NumOfLikes;
            oModelUpdate.Tel = oModel.Tel;
        }
        #endregion
    }
}
