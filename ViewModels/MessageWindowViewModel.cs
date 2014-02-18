using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LagDaemon.WWB.ViewModels
{
    public enum MessageWindowResults { Yes, No, Cancel, Ok }

    public class MessageWindowViewModel : ViewModelBase
    {
        public Window window;

        public MessageWindowViewModel(Window window, string message)
        {
            this.window = window;
            this.Message = message;
        }


        public string Message { get; set; }
        public bool CanOk() { return true; }
        public bool CanCancel() { return true; }
        public bool CanYes() { return true; }
        public bool CanNo() { return true; }

        public Visibility OkVisibility { get; set; }
        public Visibility YesVisibility { get; set; }
        public Visibility NoVisibilty { get; set; }
        public Visibility CancelVisibility { get; set; }

        public MessageWindowResults Result { get; private set; }

        public void Yes()
        {
            Result = MessageWindowResults.Yes;
            Close();
        }

        public void No()
        {
            Result = MessageWindowResults.No;
            Close();
        }

        public void Ok()
        {
            Result = MessageWindowResults.Ok;
            Close();
        }

        public void Cancel()
        {
            Result = MessageWindowResults.Cancel;
            Close();
        }

        private void Close()
        {
            window.Close();
        }


        protected override void Initialize()
        {
            
        }
    }
}
