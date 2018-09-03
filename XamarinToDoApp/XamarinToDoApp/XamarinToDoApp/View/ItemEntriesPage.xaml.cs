using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinToDoApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemEntriesPage : ContentPage
    {

        public ItemEntriesPage()
        {
            InitializeComponent();
        }
        void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
        }
        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;
        }
    }
}