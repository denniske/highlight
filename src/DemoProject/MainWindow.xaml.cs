using Highlight;
using Highlight.Engines;
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

namespace DemoProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Highlighter _highlighter;
        public MainWindow()
        {
            InitializeComponent();
            _highlighter = new Highlighter(new HtmlEngine() { UseCss = false } );
           

        }

        private void TextBoxInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            var highlightedCode = _highlighter.Highlight("C#", ((TextBox)sender).Text);
            this.HtmlView.NavigateToString(highlightedCode);
        }
    }
}
