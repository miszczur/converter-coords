﻿using System;
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
using System.Text.RegularExpressions;

namespace converter_coords
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Convert_Click(object sender, RoutedEventArgs e)
        {

            // string text = coords.Text.Replace("\r\n", " "); //replacing enters into spacebars
            //  var deletingCharacters = text.Where(c => (Char.IsDigit(c) || c == '|'));
            // var array = deletingCharacters.ToArray();
            string output = "";
            string pattern = "\\d+[|]\\d+";
            string villages = coords.Text.Replace(" ", string.Empty);
            Regex rg = new Regex(pattern);
            MatchCollection cordmatch = rg.Matches(villages);

            for (int count = 0; count < cordmatch.Count; count++)
            {
                output += cordmatch[count].Value + " ";
            }

            results.Text = output;

            if (CopyToClipboard.IsChecked == true)
            Clipboard.SetText(results.Text);
        }

        private void ResultsWithEnter_Click(object sender, RoutedEventArgs e)
        {

            string output = "";
            string pattern = "\\d+[|]\\d+";
            string villages = coords.Text.Replace(" ", string.Empty);
            Regex rg = new Regex(pattern);
            MatchCollection cordmatch = rg.Matches(villages);

            for (int count = 0; count < cordmatch.Count; count++)
            {
                output += cordmatch[count].Value + "\r\n";
            }

            results.Text = output;

            if(CopyToClipboard.IsChecked==true)
            Clipboard.SetText(results.Text);
        }

        private new void GotFocus(object sender, RoutedEventArgs e)
        {
            coords.Clear();
        }

    }
    }
