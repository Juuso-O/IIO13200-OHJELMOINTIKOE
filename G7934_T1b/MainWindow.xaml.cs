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

namespace G7934_T1b
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AlphabetCounter counter;

        public MainWindow()
        {
            InitializeComponent();
            counter = new AlphabetCounter();
        }

        private void btnCount_Click(object sender, RoutedEventArgs e)
        {
            if (counter.checkForContent(textBox.Text))
            {
                txtResult.Text = "";

                int[] c = counter.countAlphabets(textBox.Text);

                int total = 0;
                int differents = 0;

                for (int i = 0; i < (int)char.MaxValue; i++)
                {
                    if (c[i] > 0 && char.IsLetterOrDigit((char)i))
                    {
                        String newChar = (char)i + " = " + c[i] + "\n";
                        txtResult.Text = txtResult.Text + newChar;
                        total = total + c[i];
                        differents++;
                    }
                }

                txtResult.Text = txtResult.Text + "Yhteensä " + total + " merkkiä ja " + differents + " eri kirjainta.";
            } else
            {
                txtResult.Text = "Syöte ei saa olla tyhjä eikä sisältää numeroita!";
            }
        }
    }
}
