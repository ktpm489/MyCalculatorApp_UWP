using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MyCalculatorApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Button button;
        object Operator;
        int value { get; set; }
        string Result { get; set; }
        //private ObservableCollection<string> listData = new ObservableCollection<string>();
        //public ObservableCollection<string> ListData
        //{
        //    set { value = listData; }
        //    get { return listData; }

        //}

        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size { Width = 100, Height = 200 });
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void Value_Click(object sender, RoutedEventArgs e)
        {
            button = (Button)sender;
            if (DisplayBlock.Text == "0")
                DisplayBlock.Text = "";
            DisplayBlock.Text += button.Content.ToString();
            //string data += button.Content.ToString();
            //DisplayBlock.Text = String.Format(CultureInfo.InvariantCulture,
            //                    "{0:#,###,,}", data);
        }

        private void Ope_Click(object sender, RoutedEventArgs e)
        {
            button = (Button)sender;
            
            value = int.Parse(DisplayBlock.Text);

            Operator = button.Content;
            tempBlock.Text += DisplayBlock.Text + button.Content;
            DisplayBlock.Text = "0";
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            //int value = (int)tempBlock.Text;
            WorkOperations();
            historyblock1.Text = tempBlock.Text + " " + DisplayBlock.Text;
            historyblock2.Text = Result;
            DisplayBlock.Text = Result;

            deletetBtn.Visibility = Visibility.Visible;
            tempBlock.Text = "";
            this.InitializeComponent();
        }

        private void ClearData_Click(object sender, RoutedEventArgs e)
        {
            DisplayBlock.Text = "0";
        }

        private void ClearValue_Click(object sender, RoutedEventArgs e)
        {
            DisplayBlock.Text = DisplayBlock.Text.Remove(DisplayBlock.Text.Length - 1);
            if (DisplayBlock.Text.Length <= 0)
                DisplayBlock.Text = "0";
        }

        private void TotClear_Click(object sender, RoutedEventArgs e)
        {
            DisplayBlock.Text = "0";
            tempBlock.Text = "";
        }

        private void WorkOperations()
        {
            switch (Operator.ToString())
            {
                case "+":
                    Result = ((double)value + int.Parse(DisplayBlock.Text)).ToString();
                    break;
                case "-":
                    Result = ((double)value - int.Parse(DisplayBlock.Text)).ToString();
                    break;
                case "*":
                    Result = (value * int.Parse(DisplayBlock.Text)).ToString();
                    break;
                case "/":
                    Result = ((double)value / int.Parse(DisplayBlock.Text)).ToString();
                    break;
                default:
                    Result = "0";
                    break;
            }
        }

        //Storing in the memory
        private void MS_Click(object sender, RoutedEventArgs e)
        {
            btnPanel.Visibility = Visibility.Visible;
            memoryBlock.Text = DisplayBlock.Text;
            MrBtn.IsEnabled = true;
            McBtn.IsEnabled = true;
            if (DisplayBlock.Text == "")
                memoryBlock.Text = "No history items";
        }

        //Clear the memory list
        private void MC_Click(object sender, RoutedEventArgs e)
        {
            memoryBlock.Text = "No memory items";
            btnPanel.Visibility = Visibility.Collapsed;
            MrBtn.IsEnabled = false;
            McBtn.IsEnabled = false;
        }

        //Getting memory list into display block
        private void MR_Click(object sender, RoutedEventArgs e)
        {
            DisplayBlock.Text = memoryBlock.Text;
            btnPanel.Visibility = Visibility.Visible;
            if (memoryBlock.Text == "No memory items")
            {
                DisplayBlock.Text = "0";
                btnPanel.Visibility = Visibility.Collapsed;
            }
        }

        //add values to memory value
        private void MPlus_click(object sender, RoutedEventArgs e)
        {
            if (memoryBlock.Text == "No memory items")
            {
                memoryBlock.Text = "No memory items";
                btnPanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                btnPanel.Visibility = Visibility.Visible;
                int val = int.Parse(DisplayBlock.Text);
                int sum = int.Parse(memoryBlock.Text);
                sum += val;
                memoryBlock.Text = sum.ToString();
            }
        }

        //substract values from memory value
        private void MMinus_click(object sender, RoutedEventArgs e)
        {
            if (memoryBlock.Text == "No memory items")
            {
                memoryBlock.Text = "No memory items";
                btnPanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                btnPanel.Visibility = Visibility.Visible;
                int val = int.Parse(DisplayBlock.Text);
                int sum = int.Parse(memoryBlock.Text);
                sum -= val;
                memoryBlock.Text = sum.ToString();
            }
        }

        private void DeleteHistory(object sender, RoutedEventArgs e)
        {
            historyblock1.Text = "No History items";
            historyblock2.Text = "";
            deletetBtn.Visibility = Visibility.Collapsed;
        }
    }
}