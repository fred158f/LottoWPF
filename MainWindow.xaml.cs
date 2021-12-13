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
using LottoWPF.LottoKupon;

namespace LottoWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Kupon[] kuponer;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void cmd_CreateCoupon(object sender, RoutedEventArgs e)
        {

            kuponer = new Kupon[ComboCoupon.SelectedIndex + 1];

            for (int i = 0; i < kuponer.Length; i++)
            {
                kuponer[i] = new Kupon(CheckJoker.IsChecked == true);

            }

            ViewCoupon(kuponer);
        }

        private void ViewCoupon(Kupon[] kupons)
        {
            txtOne.Clear();
            txtTwo.Clear();
            txtThree.Clear();
            string sep = "\n________________________________\n";

            for (int i = 0; i < kupons.Length; i++)
            {
                TextBox current;

                if ((i + 1) % 3 == 0)
                {
                    txtThree.Text += $"\n{kuponer[i].Coupon}";
                    current = txtThree;
                }
                else if ((i + 1) % 2 == 0 && i + 1 != 4 && i + 1 != 10 || i + 1 == 5)
                {
                    txtTwo.Text += $"\n{kuponer[i].Coupon}";
                    current = txtTwo;
                }
                else
                {
                    txtOne.Text += $"\n{kuponer[i].Coupon}";
                    current = txtOne;
                }
                current.Text += sep;
            }
        }

        private void cmd_SaveTicket(object sender, RoutedEventArgs e)
        {
            try
            {
                    FileSaver.Save(kuponer);   
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}","Error in save", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
