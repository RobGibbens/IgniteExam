using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace eXam
{
    public class HomePage : ContentPage
    {
        public HomePage()
        {
            NavigationPage.SetHasNavigationBar(page: this, value: false);
            AbsoluteLayout layout = new AbsoluteLayout();

            this.Content = layout;

            Image image = new Image
            {
                Source = ImageSource.FromResource("eXam.Images.background.jpg"),
                Aspect = Aspect.AspectFill
            };

            layout.Children.Add(
                view: image,
                bounds: new Rectangle(x: 0, y: 0, width: 1, height: 1),
                flags: AbsoluteLayoutFlags.SizeProportional);

            Button button = new Button
            {
                Text = "Start eXam!",
                BackgroundColor = Color.LightCoral,
                Font = Font.SystemFontOfSize(20)
            };

            layout.Children.Add(
                view: button,
                bounds: new Rectangle(x: 0.5, y: 0.5, width: 150, height: 60),
                flags: AbsoluteLayoutFlags.PositionProportional);

            button.Clicked += async (sender, args) =>
            {
                await this.Navigation.PushAsync(new QuestionPage(App.CurrentGame.CurrentQuestion));
            };


        }

    }
}