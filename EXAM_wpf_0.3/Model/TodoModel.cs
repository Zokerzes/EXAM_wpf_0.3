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

        private DateTime _startTime;

        public DateTime StartTime
        {
            get { return _startTime; }
            set 
            {
                //if (_startTime==null)
                //{
                //    _startTime = CreationData;
                //}
                _startTime = value; 
            }
        }

        private bool _isStarted;

        public bool IsStarted
        {
            get { return _isStarted; }
            set
            {
                if (_isStarted == value) return;

                _isStarted = value;
                OnPropretyChanget("IsStarted");
            }
        }

        private DateTime _stopTime;

        public DateTime StopTime
        {
            get { return _stopTime; }
            set { _stopTime = value; }
        }

        private string _allTime;

        public string AllTime
        {
            get { return _allTime; }
            set
            {
                //if (StopTime == null)
                //{
                //    _allTime = DateTime.Now - StartTime;
                //}
                _allTime = (StopTime - StartTime).ToString();
            }
        }





        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropretyChanget(string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));  // подписка на событие и проверка на null
           
        }


    }
}
