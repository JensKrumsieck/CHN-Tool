using System;
using System.Collections.Generic;
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
            Dictionary<string, double> exp = new Dictionary<string, double>();

            exp["C"] = CValue.Text.ToDouble();
            exp["H"] = HValue.Text.ToDouble();
            exp["N"] = NValue.Text.ToDouble();
            exp["F"] = SValue.Text.ToDouble();
            exp["S"] = FValue.Text.ToDouble();

            return exp;
        }

        /// <summary>
        /// Click Submit #Rework required
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sub3Btn_Click(object sender, EventArgs e)
        {
            var impurities = new List<Impurity>();
            //read impurities 
            if (Imp1CB.Checked) impurities.Add(new Impurity(Imp1Formula.Text, Imp1Lower.Text.ToDouble(), Imp1Upper.Text.ToDouble(), Imp1Step.Text.ToDouble()));
            if (Imp2CB.Checked) impurities.Add(new Impurity(Imp2Formula.Text, Imp1Lower.Text.ToDouble(), Imp2Upper.Text.ToDouble(), Imp2Step.Text.ToDouble()));

            double[] best = formulaTB.Text.Solve(ReadExperimental(), impurities);
            string bestForm = $"{formulaTB.Text}({impurities[0].formula}){best[0]}({impurities[1].formula}){best[1]}".Parse();
            outputRTB.Text = $"Best Result: \n{best[0]} {impurities[0].formula} and {best[1]} {impurities[1].formula}\nTherefore the new formula is:\n{bestForm}\nWith Composition:";
            foreach (var item in bestForm.Deviation()) outputRTB.Text += $"{item.Key} [%] : {Math.Round(item.Value, 2)}";
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

