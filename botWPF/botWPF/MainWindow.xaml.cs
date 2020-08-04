using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
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
using Telegram.Bot;

namespace botWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<TelegramUser> Users;
        TelegramBotClient bot;
        public MainWindow()
        {
            InitializeComponent();
            Users = new ObservableCollection<TelegramUser>();
            userList.ItemsSource = Users;

            string token = "1234567:4TT8bAc8GHUspu3ERYn-KGcvsvGB9u_n4ddy";
            bot = new TelegramBotClient(token);

            bot.OnMessage += delegate (object sender, Telegram.Bot.Args.MessageEventArgs e)
              {
                  string msg = $"{DateTime.Now}: {e.Message.Chat.FirstName} {e.Message.Chat.Id} {e.Message.Text}";

                  File.AppendAllText("data.log", $"{msg}\n");

                  Debug.WriteLine(msg);

                  this.Dispatcher.Invoke(() =>
                  {
                      var person = new TelegramUser(e.Message.Chat.FirstName, e.Message.Chat.Id);
                      if (!Users.Contains(person))
                          Users.Add(person);
                      Users[Users.IndexOf(person)].AddMessage($"{person.Nick}: {e.Message.Text}");
                  }
                      );

              };
            bot.StartReceiving();

            //btnSendMsg.Click += delegate { SendMsg(); };

        }
    }
}
