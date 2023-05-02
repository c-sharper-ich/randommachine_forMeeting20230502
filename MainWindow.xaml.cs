using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        const int START = 10, END = 30;

        private List<string> names;
        private bool[] used;
        private Random random = new Random();

        private void Next_Clicked(object sender, RoutedEventArgs e)
        {
            int n = 0;
            for (int i = 0; i < used.Length; i++)
            {
                if (used[i]) n++;
            }
            if (n == used.Length)
            {
                used = new bool[names.Count];
            }
            int x;
            do
            {
                x = random.Next(used.Length);
            } while (used[x]);
            used[x] = true;
            tx.Text = names[x];
        }

        private void Save_Clicked(object sender, RoutedEventArgs e)
        {
            string[] st = txbox.Text.Split('\n');
            names = new List<string>();
            for (int i = 0; i < st.Length; i++)
            {

                if (!string.IsNullOrEmpty(st[i]))
                {
                    if (st[i].EndsWith("\n") || st[i].EndsWith("\r"))
                    {
                        st[i] = st[i].TrimEnd();
                    }
                    names.Add(st[i]);
                }
            }
            used = new bool[names.Count];
        }

        bool _showintop = false;
        private void Top_Clicked(object sender, RoutedEventArgs e)
        {
            _showintop = !_showintop;
            Topmost = _showintop;
            bt_intop.Content = _showintop ? "Normal" : "Top";
        }

        public MainWindow()
        {
            InitializeComponent();

            names = new List<string>();
            for (int i = 0; i < Math.Abs(END - START); i++)
            {
                txbox.Text += Convert.ToString(START + i) + "\n";
                names.Add(Convert.ToString(START + i));
            }
            used = new bool[names.Count];

        }

    }
}
