using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace Calculators
{
	public class VatCalculatorPage : ContentPage
	{
		public Entry vatCalcEntry { get; set; }
		public Picker vatPicker { get; set; }
		public Picker vatPercentagePicker { get; set; }
		public List<int> vatPercentage { get; set; }
		public Label calculation { get; set; }

		public VatCalculatorPage()
		{
			// Labels
			var instructionLabel = new Label()
			{
				HorizontalTextAlignment = TextAlignment.Center,
				Text = "\nPlease enter the amount you would like to calculate",
				FontSize = 14,
				WidthRequest = 200
			};

			calculation = new Label
			{
				Text = "",
				FontSize = 24,
				HorizontalOptions = LayoutOptions.Center
			};

			// Entries

			vatCalcEntry = new Entry
			{
				Placeholder = "Enter your amount",
				Keyboard = Keyboard.Numeric,
				WidthRequest = 500
			};

			// Pickers

			// VAT Pickers

			List<string> vatOptions = new List<string> { "Add VAT", "Remove the VAT" };

			vatPicker = new Picker
			{
				Title = "Pick your VAT option",
				VerticalOptions = LayoutOptions.Center
			};

			foreach (string option in vatOptions)
			{
				vatPicker.Items.Add(option);
			}

			vatPercentage = new List<int> { 15, 20, 25, 30 };

			vatPercentagePicker = new Picker
			{
				Title = "Pick your VAT percentage",
				VerticalOptions = LayoutOptions.Center
			};

			foreach (int option in vatPercentage)
			{
				vatPercentagePicker.Items.Add(option.ToString());
			}

			// Buttons

			var vatCalculateButton = new Button
			{
				Text = "Calculate",
				HorizontalOptions = LayoutOptions.Center
			};

			vatCalculateButton.Clicked += this.vatCalculatorButton_Clicked;

			var vatResetButton = new Button
			{
				Text = "Clear",
				HorizontalOptions = LayoutOptions.Center
			};

			vatResetButton.Clicked += this.vatResetButton_Clicked;

			Content = new StackLayout
			{
				Padding = 40,
				Children =
				{
					new StackLayout
					{
						VerticalOptions = LayoutOptions.End,
						Children =
						{
							instructionLabel,
							vatCalcEntry,
							vatPicker,
							vatPercentagePicker,
							vatCalculateButton,
							vatResetButton,
							calculation
						}
					},
				}
			};
		}

		void vatCalculatorButton_Clicked(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(vatCalcEntry.ToString()))
			{
				// output "please fill out this field"
				DisplayAlert("Error", "Please fill out this field", "Cancel");
			}

			var percent = (100 + Convert.ToInt32(vatPercentagePicker.Items[vatPercentagePicker.SelectedIndex])) / 100;

			var removePercent = 1.00 - Convert.ToInt32(vatPercentagePicker.Items[vatPercentagePicker.SelectedIndex]);

			// if vat picker is add
			if (vatPicker.Items[vatPicker.SelectedIndex] == "Add VAT")
			{
				// take entry and * 1.20%
				calculation.Text = "You should pay £" + (Convert.ToInt32(vatCalcEntry.Text) * percent).ToString() + " VAT";
			}
			else
			{
				// if vat picker is remove
				calculation.Text = "You should pay £" + (Convert.ToInt32(vatCalcEntry.Text) * removePercent).ToString() + " VAT";
			}
		}

		void vatResetButton_Clicked(object sender, EventArgs e)
		{
			// wipe the entry field	
			vatCalcEntry.Text = string.Empty;
			calculation.Text = string.Empty;
		}
	}
}
