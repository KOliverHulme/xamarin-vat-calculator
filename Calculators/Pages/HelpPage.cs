using System;
using Xamarin.Forms;

namespace Calculators
{
	public class HelpPage : ContentPage
	{
		public Label helpText { get; set; }

		public HelpPage()
		{
			helpText = new Label
			{
				Text = "Junction 5 Studios Ltd is neither a professional legal or accounting company.\n\nBefore you take any action on information you have gathered from this product we reccommend that you consult professional accounting services and legal support."
			};

			Content = new StackLayout
			{
				Padding = 40,
				VerticalOptions = LayoutOptions.Start,
				Children =
				{
					helpText
				}
			};
		}
	}
}
