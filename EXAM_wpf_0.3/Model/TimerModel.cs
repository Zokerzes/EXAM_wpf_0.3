using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAM_wpf_0._3.Model
{
    public class TimerModel : INotifyPropertyChanged
    {
        private DateTime _startTime;

        public DateTime StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        private bool _isStarted;

        public bool IsStarted
        {
            get { return _isStarted; }
            set { _isStarted = value; }
        }

        private DateTime _stopTime;

        public DateTime StopTime
        {
            get { return _stopTime; }
            set { _stopTime = value; }
        }

        private DateTime _allTime;

        public DateTime AllTime
        {
            get { return _allTime; }
            set 
            {
                
                _allTime = value; 
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropretyChanget(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));  // подписка на событие и проверка на null

        }
    }
}
