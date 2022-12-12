using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Work007.Models
{
    class Todo: INotifyPropertyChanged
    {
        private bool id;
        public bool Id
        {

            get { return id; }
            set
            {
                if (id == value)
                    return;
                id = value;
                OnPropertyChanged("IsDone");
            }
        }

        
        public DateTime CreationDate { get; set; }

        private bool isDone;
        public bool IsDone
        {
            get { return isDone; }
            set 
            {
                if (isDone == value)
                    return;
                isDone = value;
                OnPropertyChanged("IsDone");
            }
        }
        private string text;
        public string Text
        {
            get { return text; }
            set 
            {
                if (text==value)
                    return;
                text = value;
                OnPropertyChanged("Text");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
