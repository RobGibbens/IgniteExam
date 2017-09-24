using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eXam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReviewPage : ContentPage
    {
        public ReviewPage(ReviewPageViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
            listQuestions.ItemTapped += async (sender, args) =>
            {
                QuizQuestionViewModel qqvm = args.Item as QuizQuestionViewModel;
                if (qqvm != null)
                {
                    await this.DisplayAlert("Explanation", qqvm.Explanation, "Ok");
                }
            };

        }

    }
}