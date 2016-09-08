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

namespace WpfApplication17
{
    /// <summary>
    /// Interaction logic for SearchControl.xaml
    /// </summary>
    public partial class SearchControl : UserControl
    {
        public SearchControl()
        {
            InitializeComponent();
        }

        public event EventHandler<SearchEventArgs> OnSearch; 
        private void BtnSearch_OnClick(object sender, RoutedEventArgs e)
        {
            ExeccuteSearch(TbxInput.Text);
        }

        private void TbxInput_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Enter)
            {
                var textBox = sender as TextBox;
                ExeccuteSearch(textBox.Text);
            }
        }

        private void ExeccuteSearch(string text)
        {
            if (OnSearch != null)
            {
                var args=new SearchEventArgs();
                args.SearchText = text;
                OnSearch(this, args);
            }
        }
    }
    public class SearchEventArgs : EventArgs
    {
        public string SearchText { get; set; }
    }
}
