using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    public class Sum : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged == null)
            {
                return;
            }
            PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        private string _num1;
        private string _num2;
        private string _result;

        public string Num1
        {
            get
            {
                return _num1;
            }
            set
            {
                int number;
                bool result = int.TryParse(value, out number);
                if(result)
                {
                    _num1 = value;
                    OnPropertyChanged("Num1");
                    OnPropertyChanged("Result");
                }
            }
        }

        public string Num2
        {
            get
            {
                return _num2;
            }
            set
            {
                int number;
                bool result = int.TryParse(value, out number);
                if (result)
                {
                    _num2 = value;
                    OnPropertyChanged("Num2");
                    OnPropertyChanged("Result");
                }
            }
        }

        public string Result
        {
            get
            {
                int result = int.Parse(_num1) + int.Parse(_num2);
                return result.ToString();
            }
            set
            {
                int result = int.Parse(_num1) + int.Parse(_num2);
                _result = result.ToString();
                OnPropertyChanged("Result");
            }
        }
    }
}
