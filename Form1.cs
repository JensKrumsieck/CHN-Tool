using System;
using System.Collections.Generic;
using System.Linq;
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


        private void ExpChanged (object sender, EventArgs e)
        {
            if (formulaTB.Text == "") return;
            Dictionary<string, double> exp = new Dictionary<string, double>();

            exp["C"] = Convert.ToDouble(CValue.Text);
            exp["H"] = Convert.ToDouble(HValue.Text);
            exp["N"] = Convert.ToDouble(NValue.Text);
            exp["F"] = Convert.ToDouble(FValue.Text);
            exp["S"] = Convert.ToDouble(SValue.Text);

            deltaLbl.Text = "Deltas:\n";
            foreach (string element in new string[] { "C", "H", "N", "S", "F" })
            {
                if (exp[element] != 0 && lastAnalysis.Keys.Contains(element))
                    deltaLbl.Text += element + " [%]: " + Math.Round(Math.Abs(exp[element] - (lastAnalysis[element] / MolForm.MolWeight(MolForm.ExtractElements(formula))) * 100), 3) + "\n";
            }

            Imp1CB.Enabled = Imp2CB.Enabled = true;
            Sub3Btn.Enabled = true;
        }

        private void Sub3Btn_Click(object sender, EventArgs e)
        {
            outputRTB.Text = "";

            /**
             * lastAnalysis is analysis of current formula and contains all weights. 
             * So Calculation of different weights is needed...
             * save in ixj Matrix
             **/

            //get exp Data
            Dictionary<string, double> exp = new Dictionary<string, double>();
            exp["C"] = Convert.ToDouble(CValue.Text);
            exp["H"] = Convert.ToDouble(HValue.Text);
            exp["N"] = Convert.ToDouble(NValue.Text);
            exp["F"] = Convert.ToDouble(FValue.Text);
            exp["S"] = Convert.ToDouble(SValue.Text);

            //so get dimensions...
            outputRTB.Text += "Building Matrix with Dimension ";

            //i dimension
            double x = Convert.ToDouble(Imp1Upper.Text) - Convert.ToDouble(Imp1Lower.Text);
            x = x / Convert.ToDouble(Imp1Step.Text);
            if (!Imp1CB.Checked) x = 0;
            int ix = Convert.ToInt32(x) + 1;

            //j dimension
            double y = Convert.ToDouble(Imp2Upper.Text) - Convert.ToDouble(Imp2Lower.Text);
            y = y / Convert.ToDouble(Imp2Step.Text);
            if (!Imp2CB.Checked) y = 0;
            int jy = Convert.ToInt32(y) + 1;

            outputRTB.Text += ix + "x" + jy + "\n";

            //building matrices
            string[,] formulas = new string[ix, jy];
            double[,] lsq = new double[ix, jy];

            //storing impurity formulas
            Dictionary<string, double> iForm = MolForm.ExtractElements(Imp1Formula.Text);
            Dictionary<string, double> jForm = MolForm.ExtractElements(Imp2Formula.Text);

            //store lastAnalysis
            Dictionary<string, double> ijAnalysis = new Dictionary<string, double>();

            //looping matrices
            for (int i = 0; i <= ix-1; i++)
            {
                for (int j = 0; j <= jy-1; j++)
                {
                    double iEq = (i * Convert.ToDouble(Imp1Step.Text)) + Convert.ToDouble(Imp1Lower.Text);
                    double jEq = (j * Convert.ToDouble(Imp2Step.Text)) + Convert.ToDouble(Imp2Lower.Text);

                    outputRTB.Text += "\nEntry #" + i + "x" + j + "\n" + "#####################\n";
                    outputRTB.Text += "Using: " + iEq + " Eq. of " + Imp1Formula.Text + " and " + jEq + " Eq. of " + Imp2Formula.Text + "\n";

                    string iSum = "";
                    string jSum = "";

                    foreach (KeyValuePair<string, double> iElements in iForm)
                    {
                        iSum += iElements.Key + (iElements.Value * iEq);
                    }
                    foreach (KeyValuePair<string, double> jElements in jForm)
                    {
                       jSum += jElements.Key + (jElements.Value * jEq);
                    }
                    formulas[i,j] = iSum + jSum + formula;
                    outputRTB.Text += "Formula is " + formulas[i,j] + " with MW = " + MolForm.MolWeight(MolForm.ExtractElements(formulas[i,j])) + "\n";

                    //calculate analysis
                    ijAnalysis = MolForm.Calculate(formulas[i,j]);

                    foreach (string element in new string[] { "C", "H", "N", "S", "F" })
                    {
                        if (exp[element] != 0 && lastAnalysis.Keys.Contains(element))
                        {
                            double ijAn = (ijAnalysis[element] / MolForm.MolWeight(MolForm.ExtractElements(formulas[i, j]))) * 100;
                            outputRTB.Text += element + " [%]: " + Math.Round(ijAn, 3) + " => d= " + Math.Round(Math.Abs(exp[element] - ijAn), 3) + "\n";
                            lsq[i, j] = lsq[i, j] + Math.Pow(exp[element] - ijAn, 2);
                        }
                    }

                    outputRTB.Text += "lsq is " + lsq[i, j] + "\n";

                }
            }
            string result = "########################################\n" + "RESULT\n" + "########################################\n";

            int ii = 0;
            int ij = 0;
            double min  = double.PositiveInfinity;
            for (int i = 0; i <= ix - 1; i++)
            {
                for (int j = 0; j <= jy - 1; j++)
                {
                    if (lsq[i, j]  <= min)
                    {
                        min = lsq[i, j];
                        ii = i;
                        ij = j;
                    }
                }
            }
            result += "Lowest lsq is " + min + " at " + "position: " + ii + "x" + ij + "\n";
            result += "The best possible composition with given impurities is: ";

            //get equivalents:
            double iiEq = (ii * Convert.ToDouble(Imp1Step.Text)) + Convert.ToDouble(Imp1Lower.Text);
            double ijEq = (ij * Convert.ToDouble(Imp2Step.Text)) + Convert.ToDouble(Imp2Lower.Text);

            result += formula + " x " + iiEq + " " + Imp1Formula.Text + " x " + ijEq + " " + Imp2Formula.Text + "\n";

            //recalculate best analysis
            ijAnalysis = MolForm.Calculate(formulas[ii, ij]);
            foreach (string element in new string[] { "C", "H", "N", "S", "F" })
            {
                if (exp[element] != 0 && lastAnalysis.Keys.Contains(element))
                {
                    double ijAn = (ijAnalysis[element] / MolForm.MolWeight(MolForm.ExtractElements(formulas[ii, ij]))) * 100;
                    result += element + " [%]: " + Math.Round(ijAn, 3) + " => d= " + Math.Round(Math.Abs(exp[element] - ijAn), 3) + "\n";
                }
            }
            result += "\n########################################\n";
            outputRTB.Text = result + "\n" + outputRTB.Text;

        }

        private void Imp1CB_CheckedChanged(object sender, EventArgs e)
        {
            if (Imp1CB.Checked)
            {
                Imp1Formula.Enabled = Imp1Lower.Enabled = Imp1Upper.Enabled = Imp1Step.Enabled = Imp2CB.Enabled = true;
            }
            else Imp1Formula.Enabled = Imp1Lower.Enabled = Imp1Upper.Enabled = Imp1Step.Enabled = Imp2CB.Enabled = false;
        }

        private void Imp2CB_CheckedChanged(object sender, EventArgs e)
        {
            if (Imp2CB.Checked)
            {
                Imp2Formula.Enabled = Imp2Lower.Enabled = Imp2Upper.Enabled = Imp2Step.Enabled = true;
            }
            else Imp2Formula.Enabled = Imp2Lower.Enabled = Imp2Upper.Enabled = Imp2Step.Enabled = false;
        }


        private void formulaTB_TextChanged(object sender, EventArgs e)
        {
            //test = C64H49ClN6O5Zn
            formula = MolForm.Parse(formulaTB.Text);
            ResLbl.Text = formula + "\n\n" + "MW: " + MolForm.MolWeight(MolForm.ExtractElements(formula)) + "\n\n";

            lastAnalysis = MolForm.Calculate(formula);
            foreach (KeyValuePair<string, double> element in lastAnalysis)
            {
                ResLbl.Text += element.Key + ": " + Math.Round(element.Value / MolForm.MolWeight(MolForm.ExtractElements(formula)) * 100, 3) + "\n";
            }
            CValue.Enabled = HValue.Enabled = SValue.Enabled = NValue.Enabled = FValue.Enabled = true;
        }
    }
}

