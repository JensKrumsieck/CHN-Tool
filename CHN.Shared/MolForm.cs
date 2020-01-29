using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CHN.Shared
{
    public static class MolForm
    {
        //the regex pattern for molecular formulas, can be changed
        //public static string pattern = @"([A-Z][a-z]*)(\d*)";
        //public static string pattern = @"([A-Z][a-z]*)(\d*)|(\()|(\))(\d*)";
        public static string pattern = @"([A-Z][a-z]*)(\d*[,.]?\d*)|(\()|(\))(\d*[,.]?\d*)";
        //unsupported are all radioactive elements
        public static Dictionary<string, double> weights = new Dictionary<string, double>()
        {
            ["H"] = 1.008,
            ["He"] = 4.0026,
            ["Li"] = 6.94,
            ["Be"] = 9.0122,
            ["B"] = 10.81,
            ["C"] = 12.011,
            ["N"] = 14.007,
            ["O"] = 15.999,
            ["F"] = 18.998,
            ["Ne"] = 20.180,
            ["Na"] = 22.990,
            ["Mg"] = 24.305,
            ["Al"] = 26.982,
            ["Si"] = 28.085,
            ["P"] = 30.974,
            ["S"] = 32.06,
            ["Cl"] = 35.45,
            ["Ar"] = 39.948,
            ["K"] = 39.098,
            ["Ca"] = 40.078,
            ["Sc"] = 44.956,
            ["Ti"] = 47.867,
            ["V"] = 50.942,
            ["Cr"] = 51.996,
            ["Mn"] = 54.938,
            ["Fe"] = 55.845,
            ["Co"] = 58.933,
            ["Ni"] = 58.693,
            ["Cu"] = 63.546,
            ["Zn"] = 65.38,
            ["Ga"] = 69.723,
            ["Ge"] = 72.630,
            ["As"] = 74.922,
            ["Se"] = 78.971,
            ["Br"] = 79.904,
            ["Kr"] = 83.798,
            ["Rb"] = 85.468,
            ["Sr"] = 87.62,
            ["Y"] = 88.906,
            ["Zr"] = 91.224,
            ["Nb"] = 92.906,
            ["Mo"] = 95.95,
            ["Ru"] = 101.07,
            ["Rh"] = 102.91,
            ["Pd"] = 106.42,
            ["Ag"] = 107.87,
            ["Cd"] = 112.41,
            ["In"] = 114.82,
            ["Sn"] = 118.71,
            ["Sb"] = 121.76,
            ["Te"] = 127.6,
            ["I"] = 126.9,
            ["Xe"] = 131.29,
            ["Cs"] = 132.91,
            ["Ba"] = 137.33,
            ["La"] = 138.91,
            ["Ce"] = 140.12,
            ["Pr"] = 140.91,
            ["Nd"] = 144.24,
            ["Sm"] = 150.36,
            ["Eu"] = 151.96,
            ["Gd"] = 157.25,
            ["Tb"] = 158.93,
            ["Dy"] = 162.5,
            ["Ho"] = 164.93,
            ["Er"] = 167.26,
            ["Tm"] = 168.93,
            ["Yb"] = 173.05,
            ["Lu"] = 174.97,
            ["Hf"] = 178.49,
            ["Ta"] = 180.95,
            ["W"] = 183.84,
            ["Re"] = 186.21,
            ["Os"] = 190.23,
            ["Ir"] = 193.22,
            ["Pt"] = 195.08,
            ["Au"] = 196.97,
            ["Hg"] = 200.59,
            ["Tl"] = 204.38,
            ["Pb"] = 207.2,
            ["Bi"] = 208.98,
            ["Th"] = 232.04,
            ["Pa"] = 231.04,
            ["U"] = 238.03
        };

        /// <summary>
        /// Parses the given string into a dictionary
        /// </summary>
        /// <param name="formula"></param>
        /// <returns></returns>
        public static Dictionary<string, double> ExtractElements(string formula)
        {
            List<Dictionary<string, double>> result = new List<Dictionary<string, double>>
            {
                new Dictionary<string, double>()
            };
            int i = 0;
            foreach (Match m in Regex.Matches(formula, pattern))
            {
                //Group one == Element string, Assign Group two == Factor
                if (m.Groups[1].Success)
                {
                    //does not contain key -> create
                    if (!result[i].ContainsKey(m.Groups[1].Value)) result[i][m.Groups[1].Value] = (m.Groups[2].Success && m.Groups[2].Value != "" ? Convert.ToDouble(m.Groups[2].Value) : 1d);
                    //contains key -> additon
                    else result[i][m.Groups[1].Value] += (m.Groups[2].Success && m.Groups[2].Value != "" ? Convert.ToDouble(m.Groups[2].Value) : 1d);
                }
                //group 3 == left parentheses
                if (m.Groups[3].Success)
                {
                    i++;
                    result.Add(new Dictionary<string, double>());
                }
                //group 4 == right parentheses; group 5 == multiplicator
                if (m.Groups[4].Success)
                {
                    //add multiplicator to each group element
                    double mult = 1d;
                    if (m.Groups[5].Success && m.Groups[5].Value != "") mult = Convert.ToDouble(m.Groups[5].Value);
                    for (int j = i; j < result.Count; j++) result[j].Factor(mult);
                    ////end of subformula
                    //i--;
                }
            }
            //combine dictionaries
            return result.Merge();
        }

        /// <summary>
        /// merges all dictionaries
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Dictionary<string, double> Merge(this IEnumerable<Dictionary<string, double>> input)
        {
            var dic = new Dictionary<string, double>();
            foreach (var elements in input)
            {
                foreach (var element in elements)
                {
                    if (dic.ContainsKey(element.Key)) dic[element.Key] += element.Value;
                    else dic.Add(element.Key, element.Value); 
                }
            }
            return dic;
        }

        /// <summary>
        /// multiplies each element with factor
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="mult">The factor</param>
        /// <returns></returns>
        public static Dictionary<string, double> Factor(this Dictionary<string, double> dict, double mult)
        {
            for (int j = 0; j < dict.Count; j++)
            {
                dict[dict.ElementAt(j).Key] = dict.ElementAt(j).Value * mult;
            }
            return dict;
        }

        /// <summary>
        /// Parses empricial Formula as string
        /// </summary>
        /// <param name="formula"></param>
        /// <returns></returns>
        public static string Parse(this string formula) => ExtractElements(formula).Parse();

        /// <summary>
        /// Parses dictionary as string
        /// </summary>
        /// <param name="composition"></param>
        /// <returns></returns>
        public static string Parse(this Dictionary<string, double> composition)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in composition)
            {
                sb.Append(item.Key + item.Value);
            }
            return sb.ToString();
        }


        /// <summary>
        /// gets molecular weight
        /// </summary>
        /// <param name="Elements"></param>
        /// <returns></returns>
        public static double MolWeight(Dictionary<string, double> Elements)
        {
            double MW = 0;
            foreach (var element in Elements)
            {
                MW += Weight(element.Key, element.Value);
            }
            return MW;
        }

        /// <summary>
        /// Gets Molecular Weight from string
        /// </summary>
        /// <param name="formula"></param>
        /// <returns></returns>
        public static double MolWeight(this string formula) => MolWeight(ExtractElements(formula));

        /// <summary>
        /// gets weight of single element
        /// </summary>
        /// <param name="el"></param>
        /// <param name="no"></param>
        /// <returns></returns>
        public static double Weight(string el, double no)
        {
            if(weights.ContainsKey(el)) return weights[el] * no;
            return 0;
        }

        /// <summary>
        /// calculates the CHN Analysis
        /// </summary>
        /// <param name="formula"></param>
        /// <returns></returns>
        public static Dictionary<string, double> Calculate(string formula)
        {
            var CHNElements = new Dictionary<string, double>();
            foreach (KeyValuePair<string, double> element in ExtractElements(formula)) CHNElements.Add(element.Key, Weight(element.Key, element.Value));
            return CHNElements;
        }

        /// <summary>
        /// Calculates CHN Analysis in percent
        /// </summary>
        /// <param name="formula"></param>
        /// <returns></returns>
        public static Dictionary<string, double> Deviation(this string formula)
        {
            var analysis = new Dictionary<string, double>();

            foreach (var item in Calculate(formula)) analysis.Add(item.Key, Math.Round(item.Value / MolWeight(formula) * 100, 3));
            return analysis;
        }

        /// <summary>
        /// Calculates Deviation of Exp and Th
        /// </summary>
        /// <param name="th"></param>
        /// <param name="exp"></param>
        /// <returns></returns>
        public static Dictionary<string, double> Deviation(this Dictionary<string, double> th, Dictionary<string, double> exp)
        {
            var analysis = new Dictionary<string, double>();
            foreach (var item in th) if (exp.ContainsKey(item.Key) && exp[item.Key] != 0d) analysis.Add(item.Key, Math.Round(Math.Abs(item.Value - exp[item.Key]), 3));
            return analysis;
        }

        /// <summary>
        /// calculates error between two analysis
        /// </summary>
        /// <param name="theo"></param>
        /// <param name="exp"></param>
        /// <returns></returns>
        public static double Error(this Dictionary<string, double> theo, Dictionary<string, double> exp)
        {
            HashSet<double> err = new HashSet<double>();
            foreach (var item in theo)
            {
                if (exp.ContainsKey(item.Key)) err.Add(Math.Pow(exp[item.Key] - theo[item.Key], 2));
            }
            return Math.Sqrt(err.Sum()) * err.Max();
        }

        /// <summary>
        /// gets best composition
        /// </summary>
        /// <param name="formula"></param>
        /// <param name="exp"></param>
        /// <param name="impurities"></param>
        /// <returns></returns>
        public static double[] Solve(this string formula, Dictionary<string, double> exp, List<Impurity> impurities)
        {
            HashSet<Result> calc = new HashSet<Result>();

            //get all combinations
            HashSet<List<double>> comp = new HashSet<List<double>>();
            foreach (var imp in impurities) comp.Add(imp.Range().ToList());

            foreach (var vec in comp.Cartesian())
            {
                //build testformula
                string testFormula = formula.SumFormula(impurities, vec.ToArray());
                calc.Add(new Result(testFormula, testFormula.Deviation().Error(exp), vec.ToArray()));
            }
            return calc.OrderBy(s => s.err).First().vec;          
        }

        /// <summary>
        /// Build Sumformula
        /// </summary>
        /// <param name="formula"></param>
        /// <param name="impurities"></param>
        /// <param name="vec"></param>
        /// <returns></returns>
        public static string SumFormula(this string formula, List<Impurity> impurities, double[] vec)
        {
            string testFormula = formula;
            for (int i = 0; i < vec.Count(); i++) testFormula += ExtractElements(impurities[i].formula).Factor(vec.ElementAt(i)).Parse();
            return testFormula;
        }


        /// <summary>
        /// Builds a Sequence of doubles with steps
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="step"></param>
        /// <returns></returns>
        public static IEnumerable<double> Range(this Impurity imp)
        {
            for (int i = 0; i < (imp.upper - imp.lower) / imp.step + 1; i++)
                yield return (i * imp.step) + imp.lower;
        }

        public static IEnumerable<IEnumerable<T>> Cartesian<T>(this IEnumerable<IEnumerable<T>> sequences)
        {
            IEnumerable<IEnumerable<T>> emptyProduct = new[] { Enumerable.Empty<T>() };
            return sequences.Aggregate(
                 emptyProduct,
                 (accumulator, sequence) =>
                     from accseq in accumulator
                     from item in sequence
                     select accseq.Concat(new[] { item }));
        }

        /// <summary>
        /// Converts String to Double with Check and Fallback
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static double ToDouble(this string input) => Double.TryParse(input, out double val) ? val : 0;
    }


    /// <summary>
    /// struct for impurity handling
    /// </summary>
    public struct Impurity
    {
        public string formula;
        public double lower;
        public double upper;
        public double step;

        public Impurity(string formula, double lower, double upper, double step)
        {
            this.formula = formula;
            this.lower = lower;
            this.upper = upper;
            this.step = step;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public struct Result
    {
        public string formula;
        public double err;
        public double[] vec;

        public Result(string formula, double err, double[] vec)
        {
            this.formula = formula;
            this.err = err;
            this.vec = vec;
        }
    }
}
