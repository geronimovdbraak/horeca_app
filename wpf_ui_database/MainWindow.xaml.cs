using System.Windows;
using System.Linq;
using System.Windows.Controls;
using System.Text;
using System.Data;
using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace wpf_ui_database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


   
    public partial class MainWindow : Window
    {

        dbPizzaCornerEntities db = new wpf_ui_database.dbPizzaCornerEntities();

        ObservableCollection<menuItem> obsCollection = new ObservableCollection<menuItem>();

        public MainWindow()     
        {
            InitializeComponent();
            LoadPage();

        }

        public void LoadPage()
        {

            List<menuItem> menu_items = db.menuItems.ToList();

            ObservableCollection<menuItem> obsCollection = new ObservableCollection<menuItem>(menu_items);

            dgMenuItemstable.ItemsSource = obsCollection;

            db.SaveChanges();
           
            

        }




        /* Order Grid by Name */
        public void OrderByName()
        {

            List<menuItem> menu_items = db.menuItems.ToList();

            menu_items = menu_items.OrderBy(x => x.name).ToList();

            ObservableCollection<menuItem> obsCollection = new ObservableCollection<menuItem>(menu_items);

            dgMenuItemstable.ItemsSource = obsCollection;

        }

        /* Order Grid by Catagory */
        public void OrderByCatagory()
        {

            List<menuItem> menu_items = db.menuItems.ToList();
            menu_items = menu_items.OrderBy(x => x.catagory).ToList();
            dgMenuItemstable.ItemsSource = menu_items;

        }

        /* Order Grid by Price */
        public void OrderByPrice()
        {

            List<menuItem> menu_items = db.menuItems.ToList();
            menu_items = menu_items.OrderBy(x => x.price).ToList();
            dgMenuItemstable.ItemsSource = menu_items;

        }

        /* Order Grid by ID */
        public void OrderById()
        {

            List<menuItem> menu_items = db.menuItems.ToList();
            menu_items = menu_items.OrderBy(x => x.id).ToList();
            dgMenuItemstable.ItemsSource = menu_items;

        }


        /* Sorting DataGrid by Combobox */
        private bool handle = true;
        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (handle) Handle();
            handle = true;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            handle = !cmb.IsDropDownOpen;
            Handle();
        }

        private void Handle()
        {
            switch (cmbSortItems.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last())
            {
                case "Name":
                    OrderByName();
                    break;
                case "Catagory":
                    OrderByCatagory();
                    break;
                case "Price":
                    OrderByPrice();
                    break;
                case "Id":
                    OrderById();
                    break;
            }
        }


        /* Insert database entry */
        private void add_button_Click(object sender, RoutedEventArgs e)
        {

            addItem Iitem = new addItem();
            Iitem.DataBaseChanged = new DataBaseChangedDelegate(OnDataBaseChanged);
            Iitem.ShowDialog();
        }

        /* Edit database entry */
        private void edit_button_Click(object sender, RoutedEventArgs e)
        {


            int CurrentID = (dgMenuItemstable.SelectedItem as menuItem).id;

            updateItem Uitem = new updateItem(CurrentID);

            Uitem.DataBaseChanged = new DataBaseChangedDelegate(OnDataBaseChanged);
            Uitem.ShowDialog();

            // MessageBox.Show("hello world");

            // addItem Iitem = new addItem();
            // Iitem.DataBaseChanged = new DataBaseChangedDelegate(OnDataBaseChanged);
            // Iitem.ShowDialog();
        }


        /* Insert update gatagrid after submission */
        public void OnDataBaseChanged(bool reloadingGrid)
        {
            LoadPage();
           
        }


        /* Delete database entry */
        private void delete_button_Click(object sender, RoutedEventArgs e)
        {

            List<int> itemstoremove = new List<int>();

            foreach (menuItem item in dgMenuItemstable.SelectedItems)
            {
                 itemstoremove.Add(item.id);
            }

            foreach (int id in itemstoremove)
            {
                int currentID = id;
                string currentID_string = currentID.ToString();
                delete_item(currentID);
            }

            LoadPage();
        }


        private void delete_item(int currentID)
        {
            menuItem itemtoDelete = db.menuItems.Where(a => a.id == currentID).FirstOrDefault();
            db.menuItems.Remove(itemtoDelete);
            db.SaveChanges();
        }





        /* Pagination Buttons */
        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            OrderByName();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            OrderByCatagory();
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            OrderByPrice();
        }

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            OrderById();
        }

        private void btnReload_Click(object sender, RoutedEventArgs e)
        {
            LoadPage();
        }


        /* Check boxes when sellected */
        private void dgMenuItemstable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            List<int> itemselection = new List<int>();

            foreach (menuItem item in dgMenuItemstable.Items)
            {
                if (dgMenuItemstable.SelectedItems.Contains(item))
                {
                    itemselection.Add(item.id);
                    item.Checkbox = true;
                }
                else
                {
                    itemselection.Remove(item.id);
                    item.Checkbox = false;
                }

            }
            LoadPage();
            
         

        }


    }
}

