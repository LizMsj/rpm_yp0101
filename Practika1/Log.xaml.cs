using ClassLibrary2;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;


namespace Practika1
{
    /// <summary>
    /// Логика взаимодействия для Log.xaml
    /// </summary>
    public partial class Log : Window
    {
        public ObservableCollection<ClassLibrary2.Group> Groups;

        public Log()
        {
            InitializeComponent();
            using (var db = new DBContext())
            {
                db.Groups.ToList().ForEach(i => groups.Items.Add(i));
            }
        }

        private void filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            groups.Items.Clear();

            using (var db = new DBContext())
            {
                db.Groups.ToList().ForEach(group => 
                {
                    if (group.Scp.Contains(filter.Text))
                        groups.Items.Add(group);
                    
                } );
            }
        }
    }
}
