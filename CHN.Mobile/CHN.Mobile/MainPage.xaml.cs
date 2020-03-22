using CHN.Shared;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace CHN.Mobile
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public Dictionary<string, double> Theoretical { get; set; }
        public Dictionary<string, double> Deviation { get; set; }


        public MainPage()
        {
            InitializeComponent();
        }

        private void SumFormula_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SumFormula.Text) && SumFormula.Text.Length > 2)
            {
                SumFormulaParsed.Text = $" Parsed Sum Formula: {SumFormula.Text.Parse()} - Molecular Weight: {SumFormula.Text.MolWeight()}";
                Theoretical = SumFormula.Text.Deviation();
                BindableLayout.SetItemsSource(theoreticalView, Theoretical);
            }
        }

        private void Exp_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SumFormula.Text) && SumFormula.Text.Length > 2)
            {
                Deviation = Theoretical.Deviation(Experimental);
                BindableLayout.SetItemsSource(deviationView, Deviation);
            }
        }

        private Dictionary<string, double> Experimental => new Dictionary<string, double>
        {
            ["C"] = expC.Text.ToDouble(),
            ["H"] = expH.Text.ToDouble(),
            ["N"] = expN.Text.ToDouble(),
            ["F"] = expS.Text.ToDouble(),
            ["S"] = expF.Text.ToDouble()
        };
    }
}
