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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace PRAKTIKA1
{
    /// <summary>
    /// Логика взаимодействия для ihgrid.xaml
    /// </summary>
    public partial class ihgrid : Page
    {
        private PRAKT3Entities context = new PRAKT3Entities();
        public ihgrid()
        {
            InitializeComponent();
            ihgr.ItemsSource = context.INGREDIENTS.ToList();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ihgr.ItemsSource != null)
            {
                try
                {
                    context.INGREDIENTS.Remove(ihgr.SelectedItem as INGREDIENTS);
                    context.SaveChanges();
                    ihgr.ItemsSource = context.INGREDIENTS.ToList();
                }
                catch 
                {
                    MessageBox.Show("Нельзя!!!! Вы хотите удалить данный, использующиеся в БД", "кринж");
                }
            }
        }


        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            INGREDIENTS c = new INGREDIENTS();
            c.NAME_INGREDIENT = text1.Text;
            decimal ff = Convert.ToDecimal(text2.Text);
            c.GRAMMOVKA = ff;
            c.DESCRIPTION_INGREDIENT = text3.Text;
            context.INGREDIENTS.Add(c);

            context.SaveChanges();
            ihgr.ItemsSource = context.INGREDIENTS.ToList();
            text1.Text = null;
            text2.Text = null;
            text3.Text = null;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ihgr.SelectedItem != null)
            {
                var selected = ihgr.SelectedItem as INGREDIENTS;
                selected.NAME_INGREDIENT = text1.Text;
                selected.GRAMMOVKA = Convert.ToDecimal(text2.Text);
                selected.DESCRIPTION_INGREDIENT= text3.Text;
                context.SaveChanges();
                ihgr.ItemsSource = context.INGREDIENTS.ToList();
            }

        }

        private void ihgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ihgr.SelectedItem != null)
            {
                var selected = ihgr.SelectedItem as INGREDIENTS;
                text1.Text = selected.NAME_INGREDIENT;
                text2.Text = Convert.ToString(selected.GRAMMOVKA);
                text3.Text = selected.DESCRIPTION_INGREDIENT;
            }
        }
    }
}
