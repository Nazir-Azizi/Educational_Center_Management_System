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

namespace Educational_Center_Management_System.Views
{
    /// <summary>
    /// Interaction logic for InfoUserControl.xaml
    /// </summary>
    public partial class InfoUserControl : UserControl
    {
        public InfoUserControl()
        {
            InitializeComponent();
        }
        public string Text
        {
            get => (string)GetValue(LabelTextProperty);
            set => SetValue(LabelTextProperty, value);
        }

        public static readonly DependencyProperty LabelTextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(InfoUserControl), new PropertyMetadata(""));

        public string Value
        {
            get => (string)GetValue(TextContentProperty);
            set => SetValue(TextContentProperty, value);
        }

        public static readonly DependencyProperty TextContentProperty =
            DependencyProperty.Register(nameof(Value), typeof(string), typeof(InfoUserControl), new PropertyMetadata(""));
    }
}
