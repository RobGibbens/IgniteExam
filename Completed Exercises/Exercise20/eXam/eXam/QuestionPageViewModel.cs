using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eXam
{
    public class QuestionPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly Game game;
        public Command TrueSelected { get; set; }
        public Command FalseSelected { get; set; }
        public Command NextSelected { get; set; }

        public QuestionPageViewModel(Game game)
        {
            this.game = game;
            this.game.Restart();
            TrueSelected = new Command(OnTrue);
            FalseSelected = new Command(OnFalse);
            NextSelected = new Command(OnNext, OnCanExecuteNext);

        }

        public string Question
        {
            get { return game.CurrentQuestion.Question; }
        }

        public string Response
        {
            get
            {
                if (game.CurrentResponse == null)
                {
                    return "";
                }

                return game.CurrentQuestion.Answer == game.CurrentResponse
                    ? "Correct!"
                    : "Incorrect";
            }
        }

        private void OnTrue()
        {
            game.OnTrue();
            RaiseAllPropertiesChanged();
            NextSelected.ChangeCanExecute();
        }

        private void OnFalse()
        {
            game.OnFalse();
            RaiseAllPropertiesChanged();
            NextSelected.ChangeCanExecute();
        }
        private async void OnNext()
        {
            bool result = game.NextQuestion();
            if (result)
            {
                NextSelected.ChangeCanExecute();
                RaiseAllPropertiesChanged();
            }
            else
            {
                NavigationService navigationService = DependencyService.Get<NavigationService>();
                await navigationService.GotoPageAsync(AppPage.ReviewPage);
            }
        }



        private void RaiseAllPropertiesChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
        }
        private bool OnCanExecuteNext()
        {
            return game.CurrentResponse.HasValue;
        }


    }

}
