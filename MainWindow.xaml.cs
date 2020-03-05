using System;
using System.Windows;
using System.Windows.Controls;

namespace calc_pressure_losses_along_len
{

    public partial class MainWindow : Window
    {
        string leftOperand = "";
        string operation = "";
        string rightOperand = "";

        public MainWindow()
        {
            InitializeComponent();

            foreach (UIElement child in LayoutRoot.Children)
                if (child is Button)
                    ((Button)child).Click += Button_Click;
        }

        private void Button_Click(object sender, RoutedEventArgs ev)
        {
            string buttonText = (string)((Button)ev.OriginalSource).Content;
            textBlock.Text += buttonText;

            int num;
            bool result = int.TryParse(buttonText, out num);

            if (result == true)
                if (operation == "")
                    leftOperand += buttonText;
                else
                    rightOperand += buttonText;
            else
                if (buttonText == "=")
                {
                    UpdateRightOperand();
                    textBlock.Text += rightOperand;
                    operation = "";
                }
                else if (buttonText == "CLEAR")
                {
                    leftOperand = "";
                    rightOperand = "";
                    operation = "";
                    textBlock.Text = "";
                }
                else
                {
                    if (rightOperand != "")
                    {
                        UpdateRightOperand();
                        leftOperand = rightOperand;
                        rightOperand = "";
                    }

                    operation = buttonText;
                }
        }

        private void UpdateRightOperand()
        {
            int num1 = int.Parse(leftOperand);
            int num2 = int.Parse(rightOperand);

            switch (operation)
            {
                case "+":
                    rightOperand = (num1 + num2).ToString();
                    break;

                case "-":
                    rightOperand = (num1 - num2).ToString();
                    break;

                case "*":
                    rightOperand = (num1 * num2).ToString();
                    break;

                case "/":
                    rightOperand = (num1 / num2).ToString();
                    break;
            }
        }
    }
}
