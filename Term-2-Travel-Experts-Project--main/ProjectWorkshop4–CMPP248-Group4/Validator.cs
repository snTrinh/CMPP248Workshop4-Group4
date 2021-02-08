using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ProjectWorkshop4_CMPP248_Group4
{
    public static class Validator
    {
        /// <summary>
        /// tests if textbox is not empty
        /// </summary>
        /// <param name="tb">text box to test</param>
        /// <param name="name">name for error message</param>
        /// <returns></returns>
        public static bool IsPresent(TextBox tb, string name)
        {
            bool isValid = true; // "innocent until proven guilty"
            if (tb.Text == "")// empty
            {
                isValid = false;
                MessageBox.Show(name + " is required", "Input Error");
                tb.Focus();
            }
            return isValid;
        }
        /// <summary>
        /// test if a text box contains nonnegative decimal
        /// </summary>
        /// <param name="tb">text box to test</param>
        /// <param name="name">name for error message</param>
        /// <returns></returns>
        public static bool IsNonNegativeDecimal(TextBox tb, string name)
        {
            bool isValid = true;
            decimal value;
            if (!Decimal.TryParse(tb.Text, out value))// not a double number
            {
                isValid = false;
                MessageBox.Show(name + " should be a number", "Input Error");
                tb.SelectAll(); // select all text box content to ease replacing
                tb.Focus();
            }
            else if (value < 0)// negative number
            {
                isValid = false;
                MessageBox.Show(name + " should be positive or zero", "Input Error");
                tb.SelectAll(); // select all text box content to ease replacing
                tb.Focus();
            }
            return isValid;
        }

        /// <summary>
        /// test if a text box contains nonnegative integer
        /// </summary>
        /// <param name="tb">text box to test</param>
        /// <param name="name">name for error message</param>
        /// <returns></returns>
        public static bool IsNonNegativeInt32(TextBox tb, string name)
        {
            bool isValid = true;
            int value;
            if (!Int32.TryParse(tb.Text, out value))// not an integer
            {
                isValid = false;
                MessageBox.Show(name + " should be a whole number", "Input Error");
                tb.SelectAll(); // select all text box content to ease replacing
                tb.Focus();
            }
            else if (value < 0)// integer, but negative
            {
                isValid = false;
                MessageBox.Show(name + " should be positive or zero", "Input Error");
                tb.SelectAll(); // select all text box content to ease replacing
                tb.Focus();
            }
            return isValid;
        }

        /// <summary>
        /// test if a text box contains numeric values or special characters
        /// </summary>
        /// <param name="tb">text box to test</param>
        /// <param name="name">name for error message</param>
        /// <returns></returns>
        public static bool IsNonNumeric(TextBox tb, string name)
        {
            bool isValid = true;
            bool value = Regex.IsMatch(tb.Text, @"^[A-Za-z\-\ ']+$"); // regular expression accepting letters, dashes, spaces and apostrophes
            if (value == false) // if text in text box doesn't match
            {
                isValid = false;
                MessageBox.Show(name + " should be non-numeric and should not contain special characters", "Input Error");
                tb.SelectAll(); // select all text box content to ease replacing
                tb.Focus();
            }
            return isValid;
        }

        public static bool IsLessThanBase(TextBox commission, TextBox price, string name)
        {
            bool isValid = true;
            decimal com = Convert.ToDecimal(commission.Text);
            decimal pr = Convert.ToDecimal(price.Text);
            if (com > pr)
            {
                isValid = false;
                MessageBox.Show(name + " should be less than the base price", "Input Error");
                commission.SelectAll();
                commission.Focus();
            }
            return isValid;
        }

        public static bool IsAfterStartDate(DateTimePicker end, DateTimePicker start, string name)
        {
            bool isValid = true;

            if (end.Value < start.Value)
            {
                isValid = false;
                MessageBox.Show(name + " should be less than the base price", "Input Error");
                end.Focus();
            }
            return isValid;
        }

        //public static bool IsUniqueSupplierId(TextBox tb, string name)
        //{
        //    //bool isValid = true;
        //    //// check if value exists in Suppliers.SupplierId
        //    //if ( < )
        //    //{
        //    //    isValid = false;
        //    //    MessageBox.Show(name + " already exists in the database. Please try again.", "Input Error");
        //    //    tb.SelectAll();
        //    //    tb.Focus();
        //    //}
        //    //return isValid;
        //}
    }
}
