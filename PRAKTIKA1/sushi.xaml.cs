using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace PRAKTIKA1
{
    /// <summary>
    /// Логика взаимодействия для sushi.xaml
    /// </summary>
    public partial class sushi : Page
    {
        private PRAKT3Entities context = new PRAKT3Entities();
        public sushi()
        {
            InitializeComponent();
            sushik.ItemsSource = context.SUSHI.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (sushik.ItemsSource != null)
            {
                try
                {
                    context.SUSHI.Remove(sushik.SelectedItem as SUSHI);
                    context.SaveChanges();
                    sushik.ItemsSource = context.SUSHI.ToList();
                }
                catch
                {
                    MessageBox.Show("Нельзя!!!! Вы хотите удалить данный, использующиеся в БД", "кринж");
                }
            }
        }


        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SUSHI c = new SUSHI();
            c.NANE_SUSHI = text1.Text;
            decimal ff = Convert.ToDecimal(text2.Text);
            c.PRICE_SUSHI = ff;
            c.DESCRIPTION_SUSHI = text3.Text;
            context.SUSHI.Add(c);

            context.SaveChanges();
            sushik.ItemsSource = context.SUSHI.ToList();
            text1.Text = null;
            text2.Text = null;
            text3.Text = null;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (sushik.SelectedItem != null)
            {
                var selected = sushik.SelectedItem as SUSHI;
                selected.NANE_SUSHI = text1.Text;
                selected.PRICE_SUSHI = Convert.ToDecimal(text2.Text);
                selected.DESCRIPTION_SUSHI = text3.Text;
                context.SaveChanges();
                sushik.ItemsSource = context.SUSHI.ToList();
            }
            text1.Text = null;
            text2.Text = null;
            text3.Text = null;

        }

        private void sushik_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sushik.SelectedItem != null)
            {
                var selected = sushik.SelectedItem as SUSHI;
                text1.Text = selected.NANE_SUSHI;
                text2.Text = Convert.ToString(selected.PRICE_SUSHI);
                text3.Text = selected.DESCRIPTION_SUSHI;
            }
        }
    }
}

