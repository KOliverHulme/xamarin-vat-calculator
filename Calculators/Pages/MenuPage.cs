using System;
using Xamarin.Forms;

namespace Calculators
{
	public class MenuPage : ContentPage
	{
		public MenuPage()
		{
			Content = CreateMenuPage();
		}

		public View CreateMenuPage()
		{
			var helpButton = new Button
			{
				Text = "Help",
				FontSize = 24,
				Font = Font.SystemFontOfSize(NamedSize.Medium),
				HorizontalOptions = LayoutOptions.Center
			};
			helpButton.Clicked += OnHelpButtonClicked;

			var settingsButton = new Button
			{
				Text = "Settings",
				FontSize = 24,
				Font = Font.SystemFontOfSize(NamedSize.Medium),
				HorizontalOptions = LayoutOptions.Center
			};
			//settingsButton.Clicked += OnSettingsButtonClicked;

			var outerScrollView = new ScrollView
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				Content = new StackLayout
				{
					Padding = 15,
					Spacing = 15,
					Children =
					{
						helpButton,
						settingsButton
					}
				}
			};

			return outerScrollView;
		}

		public void OnHelpButtonClicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new HelpPage { Title = "Help" });
		}
	}
}
