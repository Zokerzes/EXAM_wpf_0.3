using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAM_wpf_0._3.Model
{

    public class TodoModel: INotifyPropertyChanged
    {

        public DateTime CreationData { get; set; } = DateTime.Now;

        private bool _isDone;
        private string _text;
        public bool IsDone
        {
            get { return _isDone; }
            set 
            {
                if (_isDone == value) return;

                _isDone = value;
                OnPropretyChanget("IsDone");
            }
        }
        
        public string Text
        {
            get { return _text; }
            set 
            {
                if (_text == value) return;
                
                _text = value;
                OnPropretyChanget("Text");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropretyChanget(string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));  // подписка на событие и проверка на null
           
        }

    }
}
