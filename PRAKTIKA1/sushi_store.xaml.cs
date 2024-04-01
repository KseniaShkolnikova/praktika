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

namespace PRAKTIKA1
{
    /// <summary>
    /// Логика взаимодействия для sushi_store.xaml
    /// </summary>
    public partial class sushi_store : Page
    {
        private PRAKT3Entities context = new PRAKT3Entities();
        public sushi_store()
        {
            InitializeComponent();
            sushik_store.ItemsSource = context.SUSHI_STORE.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (sushik_store.ItemsSource != null)
            {
                try
                {
                    context.SUSHI_STORE.Remove(sushik_store.SelectedItem as SUSHI_STORE);
                    context.SaveChanges();
                    sushik_store.ItemsSource = context.SUSHI_STORE.ToList();
                }
                catch
                {
                    MessageBox.Show("Нельзя!!!! Вы хотите удалить данный, использующиеся в БД", "кринж");
                }
            }
        }


        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SUSHI_STORE c = new SUSHI_STORE();
            c.SUSHI_ID =Convert.ToInt32(text1.Text);
            c.INGREDIENT_ID = Convert.ToInt32(text2.Text);
            c.COLVO_SUSHI = Convert.ToInt32(text3.Text);
            c.GRADE_SUSHI = text4.Text;
            c.NAME_POVARA = text5.Text;
            context.SUSHI_STORE.Add(c);

            context.SaveChanges();
            sushik_store.ItemsSource = context.INGREDIENTS.ToList();
            text1.Text = null;
            text2.Text = null;
            text3.Text = null;
            text4.Text = null;
            text5.Text = null;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (sushik_store.SelectedItem != null)
            {
                var selected = sushik_store.SelectedItem as SUSHI_STORE;
                selected.SUSHI_ID =Convert.ToInt32(text1.Text);
                selected.INGREDIENT_ID = Convert.ToInt32(text2.Text);
                selected.COLVO_SUSHI = Convert.ToInt32(text3.Text);
                selected.GRADE_SUSHI = text4.Text;
                selected.NAME_POVARA = text5.Text;
                context.SaveChanges();
                sushik_store.ItemsSource = context.SUSHI_STORE.ToList();
            }

        }
        private void sushik_store_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sushik_store.SelectedItem != null)
            {
                var selected = sushik_store.SelectedItem as SUSHI_STORE;
                text1.Text = Convert.ToString(selected.SUSHI_ID);
                text2.Text = Convert.ToString(selected.INGREDIENT_ID);
                text3.Text = Convert.ToString(selected.COLVO_SUSHI);
                text4.Text = selected.GRADE_SUSHI;
                text5.Text = selected.NAME_POVARA;
            }
        }
    }
}
