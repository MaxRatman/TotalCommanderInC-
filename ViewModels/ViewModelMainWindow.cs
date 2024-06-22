using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows;

namespace TotalCommanderInC_.ViewModels
{
    public class ViewModelMainWindow : INotifyPropertyChanged
    {
        public bool startWorkingProgram;
        public RelayCommand commandButtonFirst;
        public RelayCommand CommandButtonFirst
        {
            get
            {
                return commandButtonFirst ?? (commandButtonFirst = new RelayCommand(obj =>
                {
                    MessageBox.Show("1");
                    if(numberToEnter==1)
                    {
                        startWorkingProgram = true;
                    }
                    else
                    {
                        startWorkingProgram= false;
                    }
                }));
            }
        }
        private Image imageFloppyDisk;
        public Image ImageFloppyDisk
        {
            get { return imageFloppyDisk; } set
            {
                imageFloppyDisk = value;
                OnPropertyChanged();
            }
        }
        public int numberToEnter=0;
        public ViewModelMainWindow() 
        {
            numberToEnter = new Random().Next(1, 3);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop="")
        {
            MemoryStream ms = new MemoryStream(Properties.Resources.floppy_disk_blue, 0, Properties.Resources.floppy_disk_blue.Length);
            ms.Write(Properties.Resources.floppy_disk_blue, 0, Properties.Resources.floppy_disk_blue.Length);
            //imageFloppyDisk =  Properties.Resources.floppy_disk_blue;  
            if(PropertyChanged != null)
                PropertyChanged(this,new PropertyChangedEventArgs(prop));
        }
    }
}
