using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CHN_Tool
{
    public partial class Form1 : Form
    {
        public Dictionary<string, double> lastAnalysis;
        public string formula;


        public Form1()
        {
            InitializeComponent();
            CValue.Text = HValue.Text = NValue.Text = SValue.Text = FValue.Text = 0.ToString();
        }

        /// <summary>
        /// Fires whenever an experimental value changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExpChanged(object sender, EventArgs e)
        {
            if (formulaTB.Text == "") return;

            deltaLbl.Text = "Deltas:\n";
            foreach (var item in MolForm.Deviation(formulaTB.Text).Deviation(ReadExperimental())) deltaLbl.Text += $"{item.Key} [%]: {item.Value} \n";

            Imp1CB.Enabled = Imp2CB.Enabled = true;
            Sub3Btn.Enabled = true;
        }

        /// <summary>
        /// reads current experimental values
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, double> ReadExperimental()
        {
            Dictionary<string, double> exp = new Dictionary<string, double>
            {
                ["C"] = CValue.Text.ToDouble(),
                ["H"] = HValue.Text.ToDouble(),
                ["N"] = NValue.Text.ToDouble(),
                ["F"] = SValue.Text.ToDouble(),
                ["S"] = FValue.Text.ToDouble()
            };

            return exp;
        }

        /// <summary>
        /// Click Submit #Rework required
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Sub3Btn_Click(object sender, EventArgs e)
        {
            outputRTB.Text = ""; //flush Text

            //deactivate button
            Sub3Btn.Enabled = false;
            Sub3Btn.Text = "Running ...";

            var impurities = new List<Impurity>();
            //read impurities 
            if (Imp1CB.Checked) impurities.Add(new Impurity(Imp1Formula.Text, Imp1Lower.Text.ToDouble(), Imp1Upper.Text.ToDouble(), Imp1Step.Text.ToDouble()));
            if (Imp2CB.Checked) impurities.Add(new Impurity(Imp2Formula.Text, Imp1Lower.Text.ToDouble(), Imp2Upper.Text.ToDouble(), Imp2Step.Text.ToDouble()));

            //solves all problems ;)
            double[] best = await Task.Run(() => formulaTB.Text.Solve(ReadExperimental(), impurities));
            //gets the sum formula of best composition
            string sumFormula = formulaTB.Text.SumFormula(impurities, best).Parse();

            //output everything.
            outputRTB.Text = $"Analysis completed for {formulaTB.Text} with Error: {sumFormula.Deviation().Error(ReadExperimental())}.\nBest Values found: {String.Join(", ", best)}\n" +
                $"Formula therefore is:\n{formulaTB.Text} x ";
            for (int i = 0; i < impurities.Count; i++) outputRTB.Text += $"{best[i]} {impurities[i].formula} ";
            outputRTB.Text += $"\nFormula after parsing: {sumFormula}\n";

            //print analysis
            outputRTB.Text += $"#########################################\n";
            foreach (var element in sumFormula.Deviation()) outputRTB.Text += $"{element.Key} [%]: {element.Value}\n";
            outputRTB.Text += $"#########################################\n";

            foreach (var item in MolForm.Deviation(sumFormula).Deviation(ReadExperimental())) outputRTB.Text += $"{item.Key} [%]: {item.Value} \n";
            outputRTB.Text += $"#########################################\n";

            //reactivate button
            Sub3Btn.Enabled = true;
            Sub3Btn.Text = "Recalculate";
        }

        /// <summary>
        /// Checks Impurity 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Imp1CB_CheckedChanged(object sender, EventArgs e)
        {
            if (Imp1CB.Checked)
            {
                Imp1Formula.Enabled = Imp1Lower.Enabled = Imp1Upper.Enabled = Imp1Step.Enabled = Imp2CB.Enabled = true;
            }
            else Imp1Formula.Enabled = Imp1Lower.Enabled = Imp1Upper.Enabled = Imp1Step.Enabled = Imp2CB.Enabled = false;
        }

        /// <summary>
        /// Checks Impurity 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Imp2CB_CheckedChanged(object sender, EventArgs e)
        {
            if (Imp2CB.Checked)
            {
                Imp2Formula.Enabled = Imp2Lower.Enabled = Imp2Upper.Enabled = Imp2Step.Enabled = true;
            }
            else Imp2Formula.Enabled = Imp2Lower.Enabled = Imp2Upper.Enabled = Imp2Step.Enabled = false;
        }


        /// <summary>
        /// Recalculates when Formula has Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void formulaTB_TextChanged(object sender, EventArgs e)
        {
            //test = C64H49ClN6O5Zn
            formula = formulaTB.Text.Parse();
            ResLbl.Text = formula + "\n\n" + "MW: " + formula.MolWeight() + "\n\n";

            lastAnalysis = MolForm.Calculate(formula);
            foreach (KeyValuePair<string, double> element in MolForm.Deviation(formula)) ResLbl.Text += element.Key + " [%] : " + element.Value + "\n";

            CValue.Enabled = HValue.Enabled = SValue.Enabled = NValue.Enabled = FValue.Enabled = true;
        }
    }
}

