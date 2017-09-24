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
            AbsoluteLayout layout = new AbsoluteLayout();

            this.Content = layout;

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
        }

    }
}