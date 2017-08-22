using System;
using Xamarin.Forms;

namespace Calculators
{
	public class HomePage : ContentPage
	{
		public HomePage()
		{ 
			Content = CreateHomePage();
		}

		public View CreateHomePage()
		{
			ToolbarItems.Add(new ToolbarItem
			{
				Text = "Menu",
				Icon = "",
				Order = ToolbarItemOrder.Default,
				Command = new Command(() => Navigation.PushAsync(new MenuPage()))
			});

			// Buttons
			var vatCalculatorButton = new Button
			{
				Text = "VAT",
				FontSize = 24,
				HorizontalOptions = LayoutOptions.Center
			};

			vatCalculatorButton.Clicked += vatCalculatorButton_Clicked;

			var corporationTaxCalculatorButton = new Button
			{
				Text = "Corporation Tax",
				FontSize = 24,
				HorizontalOptions = LayoutOptions.Center
			};

			corporationTaxCalculatorButton.Clicked += corporationTaxCalculatorButton_Clicked;

			var loanCalculatorButton = new Button
			{
				Text = "Loans",
				FontSize = 24,
				HorizontalOptions = LayoutOptions.Center
			};

			loanCalculatorButton.Clicked += loanCalculatorButton_Clicked;

			var dividendCalculatorButton = new Button
			{
				Text = "Dividend",
				FontSize = 24,
				HorizontalOptions = LayoutOptions.Center,
				IsEnabled = false
			};

			Content = new StackLayout
			{
				VerticalOptions = LayoutOptions.Center,
				Children =
				{
					vatCalculatorButton,
					corporationTaxCalculatorButton,
					loanCalculatorButton,
					dividendCalculatorButton
				}
			};

			return Content;
		}

		void vatCalculatorButton_Clicked(object sender, EventArgs e)
		{
			this.Navigation.PushAsync(new VatCalculatorPage { Title = "VAT"});
		}

		void corporationTaxCalculatorButton_Clicked(object sender, EventArgs e)
		{
			this.Navigation.PushAsync(new CorporationTaxPage { Title = "Corporation Tax"});
		}

		void loanCalculatorButton_Clicked(object sender, EventArgs e)
		{
			this.Navigation.PushAsync(new LoanCalculatorPage { Title = "Loans" });
		}
	}
}
