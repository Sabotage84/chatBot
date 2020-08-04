using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace botWPF
{
    class TelegramUser : INotifyPropertyChanged, IEquatable<TelegramUser>
    {
        public TelegramUser(string NickName, long ChatId)
        {
            Nick = NickName;
            Id = ChatId;
            Messages = new ObservableCollection<string>();
        }
        private string nick;

        public string Nick { 
            get => nick;
            set {
                this.nick = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.nick)));
            
            } 
        }

        public long Id { get => id;
            set 
            {
                this.id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.id)));


            }
        }

        public ObservableCollection<string> Messages { get => messages; set => messages = value; }

        private long id;


        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<string> messages; 

        public bool Equals(TelegramUser other)
        {
            return other.Id == this.Id;
        }
        public void AddMessage(string text)
        {
            Messages.Add(text);
        }
    }
}
