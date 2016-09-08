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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<TreeViewModel> itemSoure;
        public MainWindow()
        {
            InitializeComponent();

        }

      

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState==MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void BtnClose_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public event EventHandler<SelectEventArgs> OnConfirm;
        private void BtnConfirm_OnClick(object sender, RoutedEventArgs e)
        {
            if (OnConfirm!=null)
            {
                var selectItems=SelectControl.RightListBox.Items;
                var args = new SelectEventArgs();
                args.SelectItems = selectItems;
                OnConfirm(sender, args);
            }
            this.Close();
        }
    }

    public class SelectEventArgs : EventArgs
    {
        public object SelectItems { get; set; }
    }
}
