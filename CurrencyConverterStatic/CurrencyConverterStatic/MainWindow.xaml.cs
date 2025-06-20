using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CurrencyConverterStatic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CurrencyBind(); //calls the function
            

            //labelCurrency.Content = "Hello World!";
        }

        private void CurrencyBind()
        {
            DataTable dataCurrency = new DataTable();

            //columns of datatable
            dataCurrency.Columns.Add("Text");
            dataCurrency.Columns.Add("Value");

            //rows of datatable
            dataCurrency.Rows.Add("--SELECT--", 0);
            dataCurrency.Rows.Add("BDT", 1);
            dataCurrency.Rows.Add("EUR", 140);
            dataCurrency.Rows.Add("USD", 122);
            dataCurrency.Rows.Add("POUND", 165);

            fromCurrency.ItemsSource = dataCurrency.DefaultView;
            fromCurrency.DisplayMemberPath = "Text"; //displays in the combo box
            fromCurrency.SelectedValuePath = "Value";
            fromCurrency.SelectedIndex = 0;  //starts from 0

            toCurrency.ItemsSource = dataCurrency.DefaultView;
            toCurrency.DisplayMemberPath = "Text"; //displays in the combo box
            toCurrency.SelectedValuePath = "Value";
            toCurrency.SelectedIndex = 0;  //starts from 0
        }



        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            //labelCurrency.Content = "Converted!";

            double ConvertedCurrency;

            if (textCurrency.Text == null || textCurrency.Text.Length == 0 || textCurrency.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Currency", Title = "Information", 
                    MessageBoxButton.OK, MessageBoxImage.Information);

                //this will activate the textCurrency box, and the user can start typing after pressing "OK" in the messageBox
                textCurrency.Focus();
                return;

            }

            else if(fromCurrency.SelectedValue == null || fromCurrency.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Currency", Title = "Information",
                    MessageBoxButton.OK, MessageBoxImage.Information);

                fromCurrency.Focus(); return;
            }

            else if (toCurrency.SelectedValue == null || toCurrency.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Currency", Title = "Information",
                    MessageBoxButton.OK, MessageBoxImage.Information);

                toCurrency.Focus(); return;
            }

            else if (fromCurrency.SelectedValue == toCurrency.SelectedValue)
            {
                ConvertedCurrency = double.Parse(textCurrency.Text);

                labelCurrency.Content = toCurrency.Text + " " + ConvertedCurrency.ToString("N3");
            }

            else
            {
                //Calculation for currency converter is From Currency value multiply(*) 
                // with amount textbox value and then the total is divided(/) with To Currency value
                ConvertedCurrency = (double.Parse(fromCurrency.SelectedValue.ToString()) * double.Parse(textCurrency.Text)) / double.Parse(toCurrency.SelectedValue.ToString());

                labelCurrency.Content = toCurrency.Text + " " + ConvertedCurrency.ToString("N3");
            }
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Clear clicked");
            labelCurrency.Content = "";
            fromCurrency.SelectedIndex = 0;
            toCurrency.SelectedIndex = 0;
            textCurrency.Text = string.Empty;
            textCurrency.Focus();
        }
        public void NumberValidation(object sender, TextCompositionEventArgs e)
        {

            //checks whether the input is a number with a regular expression
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

        }
    }
}
