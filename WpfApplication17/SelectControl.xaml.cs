using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using WpfApplication17.Annotations;

namespace WpfApplication17
{
    /// <summary>
    /// Interaction logic for TreeListControl.xaml
    /// </summary>
    public partial class SelectControl : UserControl
    {
        private List<TreeViewModel> ItemSoure { get; set; }
        public SelectControl()
        {
            InitializeComponent();
            ItemSoure = new List<TreeViewModel>() { new TreeViewModel()
                {
                    Name = "前端设计",
                    TreeViewItems = new List<TreeViewModel>()
                    {
                        new TreeViewModel(){Name = "Html/Css/Js"},
                        new TreeViewModel(){Name = "WPF"},
                        new TreeViewModel(){Name = "Winform"},
                        new TreeViewModel(){Name = "Webform"},
                        new TreeViewModel(){Name = "U3D"},
                    }
                },
                new TreeViewModel()
                {
                    Name = "后台语言",
                    TreeViewItems = new List<TreeViewModel>()
                    {
                        new TreeViewModel(){Name = "C#"},
                         new TreeViewModel(){Name = "VB.Net"},
                        new TreeViewModel(){Name = "Java"},
                        new TreeViewModel(){Name = "PHP"},
                        new TreeViewModel(){Name = "C"},
                        new TreeViewModel(){Name = "Python"},
                        new TreeViewModel(){Name = "C++"},
                        new TreeViewModel(){Name = "Ruby"},
                    }
                },new TreeViewModel()
                {
                    Name = "数据库",
                    TreeViewItems = new List<TreeViewModel>()
                    {
                        new TreeViewModel(){Name = "SqlServer"},
                         new TreeViewModel(){Name = "MySql"},
                        new TreeViewModel(){Name = "Oracle"},
                        new TreeViewModel(){Name = "SqlLite"},
                        new TreeViewModel(){Name = "MongoDB"},
                        new TreeViewModel(){Name = "PLSql"},
                    }
                }
            };
            MyTreeView.ItemsSource = ItemSoure;
            RightListBox.ItemsSource = null;
            RightListBox.ItemsSource = new List<TreeViewModel>();
        }

        /// <summary>
        /// 选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var viewModel = button.DataContext as TreeViewModel;
            if (!viewModel.IsChecked)
            {
                viewModel.IsChecked = true;
                var selectList = RightListBox.ItemsSource as List<TreeViewModel>;
                selectList.Add(viewModel);
                RightListBox.ItemsSource = null;
                RightListBox.ItemsSource = selectList;
            }
        }
        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRemove_OnClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var viewModel = button.DataContext as TreeViewModel;
            viewModel.IsChecked = false;
            var selectList = RightListBox.ItemsSource as List<TreeViewModel>;
            selectList.Remove(viewModel);
            RightListBox.ItemsSource = null;
            RightListBox.ItemsSource = selectList;
        }
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSearch_OnOnSearch(object sender, SearchEventArgs e)
        {
            string serachText=e.SearchText;
            var items=new List<TreeViewModel>();
            if (string.IsNullOrWhiteSpace(serachText))
            {
                MyTreeView.ItemsSource = ItemSoure;
                return;
            }
            foreach (var item in ItemSoure)
            {
                var childrenItems=item.TreeViewItems.Where(o => o.Name.Contains(serachText)).ToList();
                if (childrenItems.Count>0)
                {
                    var parentItem=new TreeViewModel(){Name = item.Name};
                    parentItem.TreeViewItems = childrenItems;
                    items.Add(parentItem);
                }
            }
            MyTreeView.ItemsSource = items;
        }
    }

    public class TreeViewModel : INotifyPropertyChanged
    {
        public string Name { get; set; }

        private bool _isChecked = false;
        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("IsChecked"));
                }
            }
        }

        public List<TreeViewModel> TreeViewItems { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
