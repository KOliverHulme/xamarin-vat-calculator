using System;
using Xamarin.Forms;


namespace Calculators
{
	public class CorporationTaxPage : ContentPage
	{
		public Entry corpTaxEntry { get; set; }

		public Label taxYearPicker { get; set; }

		public Label profitsText { get; set; }

		public Label afterTaxProfitText { get; set; }

		public Label taxPayableText { get; set; }

		public string currencySymbol = "£";

		public CorporationTaxPage()
		{
			var instructionLabel = new Label()
			{
				HorizontalTextAlignment = TextAlignment.Center,
				Text = "\nPlease enter the amount you would like to calculate",
				FontSize = 14,
				WidthRequest = 200
			};

			corpTaxEntry = new Entry
			{
				Placeholder = "Enter your amount"
			};

			var taxYearLabel = new Label
			{
				Text = "Tax Year: "
			};

			taxYearPicker = new Label
			{
				Text = "2017/2018"
			};

			profitsText = new Label
			{
				HorizontalOptions = LayoutOptions.Start,
				FontSize = 24
			};

			taxPayableText = new Label
			{
				HorizontalOptions = LayoutOptions.Start,
				FontSize = 24
			};

			afterTaxProfitText = new Label
			{
				HorizontalOptions = LayoutOptions.Start,
				FontSize = 24
			};

			var taxCalculateButton = new Button
			{
				Text = "Calculate",
				HorizontalOptions = LayoutOptions.Center
			};

			taxCalculateButton.Clicked += this.taxCalculatorButton_Clicked;

			var resetButton = new Button
			{
				Text = "Clear",
				HorizontalOptions = LayoutOptions.Center
			};

			resetButton.Clicked += this.resetButton_Clicked;

			Content = new StackLayout
			{
				Padding = 40,
				Children =
				{
					instructionLabel,
					new StackLayout
					{
						Orientation = StackOrientation.Horizontal,
						Children =
						{
							taxYearLabel,
							taxYearPicker
						}
					},
					corpTaxEntry,
					taxCalculateButton,
					resetButton,
					profitsText,
					taxPayableText,
					afterTaxProfitText
				}
			};
		}

		void taxCalculatorButton_Clicked(object sender, EventArgs e)
		{
			// corporation tax
			profitsText.Text = $"Profits: {currencySymbol}{corpTaxEntry.Text}";

			// tax payable
			taxPayableText.Text = $"Tax Payable: {currencySymbol}{(Convert.ToInt32(corpTaxEntry.Text) * 0.19).ToString()}";

			// after tax profit
			afterTaxProfitText.Text = $"Tax After Profit: {currencySymbol}{(Convert.ToInt32(corpTaxEntry.Text) * 0.81).ToString()}";                  
		}

		void resetButton_Clicked(object sender, EventArgs e)
		{
			corpTaxEntry.Text = string.Empty;
			profitsText.Text = string.Empty;
			taxPayableText.Text = string.Empty;
			afterTaxProfitText.Text = string.Empty;
		}
	}
}
