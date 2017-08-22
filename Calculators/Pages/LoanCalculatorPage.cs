using Xamarin.Forms;
using System;

namespace Calculators
{
	public class LoanCalculatorPage : ContentPage
	{
		public Entry loanAmount { get; set; }
		public Entry aprPercentage { get; set; }
		public Entry years { get; set; }
		public Label totalsToPayBack { get; set; }
		public Label totalInterest { get; set; }
		public Label monthlyPayment { get; set; }

		public LoanCalculatorPage()
		{
			loanAmount = new Entry
			{
				Placeholder = "Loan Amount"
			};

			aprPercentage = new Entry
			{
				Placeholder = "APR %"
			};

			years = new Entry
			{
				Placeholder = "Years"
			};

			totalInterest = new Label
			{
			};

			totalsToPayBack = new Label
			{ 
				FontSize = 24
			};

			monthlyPayment = new Label
			{
			};

			var loanCalculateButton = new Button
			{
				Text = "Calculate"
			};
			loanCalculateButton.Clicked += this.loanCalculateButton_Clicked;

			var resetButton = new Button
			{
				Text = "Clear"
			};
			resetButton.Clicked += this.resetButton_Clicked;

			Content = new StackLayout
			{
				Padding = 40,
				Children =
				{
					loanAmount,
					aprPercentage,
					years,
					loanCalculateButton,
					resetButton,
					totalsToPayBack
				}
			};
		}

		void loanCalculateButton_Clicked(object sender, EventArgs e)
		{
			var totalInterestInPounds = (Convert.ToInt32(loanAmount.Text)/100) * Convert.ToInt32(aprPercentage.Text);
			var payBack = Convert.ToInt32(loanAmount.Text) + totalInterestInPounds;
			monthlyPayment.Text = (payBack / 12).ToString();

			totalsToPayBack.Text = $"Total Interest: £{totalInterestInPounds.ToString()}\nTotal to pay back: £{payBack.ToString()}\nMonthly Payment: £{monthlyPayment.Text}";
		}

		void resetButton_Clicked(object sender, EventArgs e)
		{
			loanAmount.Text = string.Empty;
			aprPercentage.Text = string.Empty;
			years.Text = string.Empty;
			totalsToPayBack.Text = string.Empty;
		}
	}
}
