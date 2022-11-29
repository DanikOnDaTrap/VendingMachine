using Microsoft.Win32;
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

namespace LABA5
{
    public class Coffee
    {
        public string _type = "Амеркано";
        public bool _sugar = false;
        public bool _milk = false;
        

        public Coffee()
        {

        }
        public Coffee(string type, bool sugar, bool milk)
        {
            this._type = type;
            this._milk = milk;
            this._sugar = sugar;
        }

        public void SetMilk()
        {
            this._milk = !this._milk;
        }

        public void SetSugar()
        {
            this._sugar = !this._sugar;
        }

        public void SetType(string type)
        {
            this._type = type;
        }
    }
    public partial class MainWindow : Window
    {
        Coffee obj = new Coffee();
        public int _balance = 0;
        public string _currentType = "Американо";
        public int _curTypePrice = 50;
        public int _curDopPriceMilk = 0;
        public int _curDopPriceSugar = 0;
        public int _cost = 0;

        public MainWindow()
        {
            InitializeComponent();
            labelCurrentMoney.Content = 0;
            labelCost.Content = _cost;
            cbAddMilk.IsEnabled = false;
            cbAddSugar.IsEnabled = false;
            SetUnvisible();
        }

        public void AddBalance(int sum)
        {
            this._balance += sum;
        }

        public void RemoveBalance(int sum)
        {
            this._balance -= sum;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (textboxMoney.Text != "")
            {
                try
                {
                    AddBalance(Int32.Parse(textboxMoney.Text));
                }
                catch
                {
                    textboxMoney.Text = "";
                }
            }
            labelCurrentMoney.Content = _balance;

        }

        private void CbAddMilk_Checked(object sender, RoutedEventArgs e)
        {
            obj.SetMilk();
            _curDopPriceMilk = 20;
            labelCost.Content = _curTypePrice + _curDopPriceMilk + _curDopPriceSugar;
        }

        private void CbAddSugar_Checked(object sender, RoutedEventArgs e)
        {
            obj.SetSugar();
            _curDopPriceSugar = 15;
            labelCost.Content = _curTypePrice + _curDopPriceMilk + _curDopPriceSugar;
        }

        public void SetUnvisible()
        {
            ImageBoxAmericano.Visibility = Visibility.Hidden;
            ImageBoxEspresso.Visibility = Visibility.Hidden;
            ImageBoxChocolate.Visibility = Visibility.Hidden;
            ImageBoxCapuccino.Visibility = Visibility.Hidden;
        }

        private void RbAmericano_Checked(object sender, RoutedEventArgs e)
        {

            if (sender is RadioButton radio)
            {
                SetUnvisible();
                switch (radio.Content)
                {
                    case "Американо":
                        _curTypePrice = 50;
                        ImageBoxAmericano.Visibility = Visibility.Visible;
                        break;
                    case "Эспрeссо":
                        _curTypePrice = 60;
                        ImageBoxEspresso.Visibility = Visibility.Visible;
                        break;
                    case "Капуччино":
                        _curTypePrice = 65;
                        ImageBoxCapuccino.Visibility= Visibility.Visible; ;
                        break;
                    case "Горячий шоколад":
                        _curTypePrice = 45;
                        ImageBoxChocolate.Visibility = Visibility.Visible;
                        break;
                }
            }
            
            cbAddMilk.IsEnabled = true;
            cbAddSugar.IsEnabled = true;
            labelCost.Content = _curTypePrice + _curDopPriceMilk + _curDopPriceSugar;
        }

        private void cbAddMilk_Unchecked(object sender, RoutedEventArgs e)
        {
            obj.SetMilk();
            _curDopPriceMilk = 0;
            labelCost.Content = _curTypePrice + _curDopPriceMilk + _curDopPriceSugar;
        }

        private void cbAddSugar_Unchecked(object sender, RoutedEventArgs e)
        {
            obj.SetSugar();
            _curDopPriceSugar = 0;
            labelCost.Content = _curTypePrice + _curDopPriceMilk + _curDopPriceSugar;
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            if ((int)labelCurrentMoney.Content >= (int)labelCost.Content)
            {
                MessageBox.Show("Приятного аппетита!", "Ваш напиток готов!");
                labelCashBack.Content = ((int)labelCurrentMoney.Content - (int)labelCost.Content);
                _balance = (int)labelCurrentMoney.Content - (int)labelCost.Content;
                labelCurrentMoney.Content = _balance;
                if ((int)labelCashBack.Content <= 0)
                {
                    labelCashBack.Content = "";
                }
            }
            else
            {
                MessageBox.Show("На счете не хватает средств!", "Ошибка!");
            }
        }
    }
}
