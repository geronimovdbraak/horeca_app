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
    /// <summary>
    /// Interaction logic for updateItem.xaml
    /// </summary>
    public partial class updateItem : Window 
    {

        dbPizzaCornerEntities db = new dbPizzaCornerEntities();
        int Id;

        /* Only allow numeric input */
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public updateItem(int itemId)
        {
            // this.DataContext = this;
            // nametextBox.DataContext = this;
            InitializeComponent();
            Id = itemId;
        }

        /* Submit form to database (not complete yet)*/
        private void updateWindowSubmit_Click(object sender, RoutedEventArgs e)
        {


            menuItem updateItem = (from m in db.menuItems where m.id == Id select m).Single();
             {
                updateItem.name = nametextBox.Text;
                updateItem.catagory = categorycomboBox.Text;
                updateItem.price = Decimal.Parse(priceBox.Text);
                updateItem.salesDay = salesdayBox.Text;
                updateItem.salesPrice = Decimal.Parse(salespriceBox.Text); 

            };


            db.SaveChanges();
            this.Hide();
            DataBaseChanged(true);
        }

        public DataBaseChangedDelegate DataBaseChanged;
    }
}
