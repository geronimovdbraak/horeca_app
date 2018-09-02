using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace wpf_ui_database
{




    public partial class addItem : Window
    {

        dbPizzaCornerEntities db = new dbPizzaCornerEntities();


        /* Only allow numeric input */
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public addItem()
        {
            InitializeComponent();

        }



        /* Submit form to database (not complete yet)*/
        private void addWindowSubmit_Click(object sender, RoutedEventArgs e)
        {


            menuItem newItem = new menuItem()
            {
                name = nametextBox.Text,
                catagory = categorycomboBox.Text,
                price = Decimal.Parse(priceBox.Text),
                salesDay = salesdayBox.Text,
                salesPrice = Decimal.Parse(salespriceBox.Text)

            };

            db.menuItems.Add(newItem);
            db.SaveChanges();
            this.Hide();
            DataBaseChanged(true);


        }
        public DataBaseChangedDelegate DataBaseChanged;

    }
}
