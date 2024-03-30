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
        private PRAKT2Entities context = new PRAKT2Entities();
        public sushi()
        {
            InitializeComponent();
            sushik.ItemsSource = context.SUSHI.ToList();
        }

    }
}
