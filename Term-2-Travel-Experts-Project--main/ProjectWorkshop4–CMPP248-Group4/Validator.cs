using Products_SuppliersData;
using SuppliersData;
using System;
using System.Collections.Generic;
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
        /// <returns>bool</returns>
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
        /// <returns>bool</returns>
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
        /// test if a text box contains numeric values or special characters
        /// </summary>
        /// <param name="tb">text box to test</param>
        /// <param name="name">name for error message</param>
        /// <returns>bool</returns>
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

        /// <summary>
        /// tests to see if commision is less than base
        /// </summary>
        /// <param name="commission">commission</param>
        /// <param name="price">price</param>
        /// <param name="name"></param>
        /// <returns>bool</returns>
        public static bool IsLessThanBase(TextBox commission, TextBox price, string name)
        {
            bool isValid = true;
            decimal com = Convert.ToDecimal(commission.Text);
            decimal pr = Convert.ToDecimal(price.Text);
            if (com >= pr)
            {
                isValid = false;
                MessageBox.Show(name + " should be less than the base price", "Input Error");
                commission.SelectAll();
                commission.Focus();
            }
            return isValid;
        }

        /// <summary>
        /// tests to see if end date is after start date
        /// </summary>
        /// <param name="end"></param>
        /// <param name="start"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsAfterStartDate(DateTimePicker end, DateTimePicker start, string name)
        {
            bool isValid = true;

            if (end.Value <= start.Value)
            {
                isValid = false;
                MessageBox.Show(name + " should be after start date.", "Input Error");
                end.Focus();
            }
            return isValid;
        }


        public static bool SupplierNameExists(Suppliers supplier, string name)
        {
            bool isValid = true;

            if (supplier== null)
            {
                isValid = false;
                MessageBox.Show(name + " already exists in the database.", "Duplication Error");

            }
            return isValid;
        }




    }
}
