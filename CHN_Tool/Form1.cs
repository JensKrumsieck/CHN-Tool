using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChemSharp.Extensions;
using ChemSharp.Molecules.ElementalAnalysis;
using ChemSharp.Molecules.Extensions;

namespace CHN_Tool;

public partial class Form1 : Form
{
    public Analysis Analysis = new();

    public Form1()
    {
        InitializeComponent();
        CValue.Text = HValue.Text = NValue.Text = SValue.Text = FValue.Text = 0.ToString();
        ResLbl.Text = deltaLbl.Text = default;
    }

    /// <summary>
    /// Fires whenever an experimental value changes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ExpChanged(object sender, EventArgs e)
    {
        Analysis.ExperimentalAnalysis = ReadExperimental();
        deltaLbl.Text = "";
        if (Analysis.Deviation == null) return;
        foreach (var (key, value) in Analysis.Deviation)
            deltaLbl.Text += $"{key}: {value.ToString("N3", CultureInfo.InvariantCulture)} \n";
    }

    /// <summary>
    /// reads current experimental values
    /// </summary>
    /// <returns></returns>
    private Dictionary<string, double> ReadExperimental() =>
        new()
        {
            ["C"] = !string.IsNullOrEmpty(CValue.Text) ? CValue.Text.ToDouble() : 0,
            ["H"] = !string.IsNullOrEmpty(HValue.Text) ? HValue.Text.ToDouble() : 0,
            ["N"] = !string.IsNullOrEmpty(NValue.Text) ? NValue.Text.ToDouble() : 0,
            ["F"] = !string.IsNullOrEmpty(FValue.Text) ? FValue.Text.ToDouble() : 0,
            ["S"] = !string.IsNullOrEmpty(SValue.Text) ? SValue.Text.ToDouble() : 0,
        };

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
        var items = Analysis.Impurities.ToList();
        foreach (var item in items) Analysis.Impurities.Remove(item);
        //read impurities 
        if (Imp1CB.Checked) Analysis.Impurities.Add(new Impurity(Imp1Formula.Text, Imp1Lower.Text.ToDouble(), Imp1Upper.Text.ToDouble(), Imp1Step.Text.ToDouble()));
        if (Imp2CB.Checked) Analysis.Impurities.Add(new Impurity(Imp2Formula.Text, Imp2Lower.Text.ToDouble(), Imp2Upper.Text.ToDouble(), Imp2Step.Text.ToDouble()));

        if (Analysis.Impurities.Count == 0 || Analysis.Deviation == null) return;

        var best = await Task.Run(() => Analysis.Solve());
        ////gets the sum formula of best composition
        var sumFormula = Analysis.Formula.SumFormula(Analysis.Impurities, best);
        var composition = sumFormula.ElementalAnalysis();
        ////output everything.
        var analysis = Analysis.TheoreticalAnalysis;
        outputRTB.Text = $"Analysis completed for {formulaTB.Text} with Error: {ElementalAnalysisUtil.Error(ref composition, ref analysis)}.\nBest Values found: {String.Join(", ", best)}\n" +
            $"Formula therefore is:\n{formulaTB.Text} x ";
        for (var i = 0; i < Analysis.Impurities.Count; i++) outputRTB.Text += $"{best[i]} {Analysis.Impurities[i].Formula} ";
        outputRTB.Text += $"\nFormula after parsing: {sumFormula}\n";
        //print analysis
        outputRTB.Text += $"#########################################\n";
        foreach (var (key, value) in composition)
            outputRTB.Text += $"{key} [%]: {value.ToString("N3", CultureInfo.InvariantCulture)}\n";
        outputRTB.Text += $"#########################################\n";

        foreach (var (key, value) in ElementalAnalysisUtil.Deviation(composition, Analysis.ExperimentalAnalysis))
            outputRTB.Text += $"{key} [%]: {value.ToString("N3", CultureInfo.InvariantCulture)} \n";
        outputRTB.Text += $"#########################################\n";

        //reactivate button
        Sub3Btn.Enabled = true;
    }

    /// <summary>
    /// Checks Impurity 1
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Imp1CB_CheckedChanged(object sender, EventArgs e)
    {
        Imp1Formula.Enabled = Imp1CB.Checked
            ? Imp1Lower.Enabled = Imp1Upper.Enabled = Imp1Step.Enabled = Imp2CB.Enabled = true
            : Imp1Lower.Enabled = Imp1Upper.Enabled = Imp1Step.Enabled = Imp2CB.Enabled = false;
    }

    /// <summary>
    /// Checks Impurity 2
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Imp2CB_CheckedChanged(object sender, EventArgs e)
    {
        Imp2Formula.Enabled = Imp2CB.Checked
            ? Imp2Lower.Enabled = Imp2Upper.Enabled = Imp2Step.Enabled = true
            : Imp2Lower.Enabled = Imp2Upper.Enabled = Imp2Step.Enabled = false;
    }


    /// <summary>
    /// Recalculates when Formula has Changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void formulaTB_TextChanged(object sender, EventArgs e)
    {
        //test = C64H49ClN6O5Zn
        try
        {
            Analysis.Formula = formulaTB.Text.Parse();
            ResLbl.Text = Analysis.Formula + "\n\n" + "MW: " + Analysis.Formula.MolecularWeight() + "\n\n";
            foreach (var (key, value) in Analysis.TheoreticalAnalysis)
                ResLbl.Text += $"{key} [%] : {value.ToString("N3", CultureInfo.InvariantCulture)}\n";
            CValue.Enabled = HValue.Enabled = SValue.Enabled = NValue.Enabled = FValue.Enabled = true;
        }
        catch { ResLbl.Text = "Parse Error"; }
    }
}

