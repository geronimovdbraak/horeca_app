//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wpf_ui_database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows;

    public partial class menuItem // : INotifyPropertyChanged
    {
        public menuItem()
        {

        }

        // public event PropertyChangedEventHandler PropertyChanged;
        // 
        // private void OnPropertyChanged(string propertyName)
        // {
        //    
        //    if (PropertyChanged != null)
        //     {
        //         PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //        MessageBox.Show("not null");
        //    }
        // }

        public bool checkingbox { get; set; } /* Check if this is the correct way */

        private bool checkbox;
        public bool Checkbox
        {
            get { return checkbox; }
            set
            {

                checkbox = value;
            }
        }

        public int id { get; set; }

        private string nameP;
        public string name
        {
            get
            {
                return nameP;
            }
            set
            {
                nameP = value;
                // OnPropertyChanged("name");

            }
        }

        public string catagory { get; set; }
        public Nullable<decimal> price { get; set; }
        public string salesDay { get; set; }
        public Nullable<decimal> salesPrice { get; set; }
    }
}
