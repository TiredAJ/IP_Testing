using Avalonia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MapDragTest.Models
{
    public class Marker : INotifyPropertyChanged
    {
        private Point _Location = new Point(0,0);

        public Point Location 
        {
            get => _Location;
            set
            {
                if (value.Equals(_Location))
                {return;}
                _Location = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string PropertyName = "")
        {PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));}
    }
}
