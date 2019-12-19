using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CHN_Tool
{
    static class MolForm
    {
        //the regex pattern for molecular formulas, can be changed
        //public static string pattern = @"([A-Z][a-z]*)(\d*)";
        public static string pattern = @"([A-Z][a-z]*)(\d*)|(\()|(\))(\d*)";
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
        //gets elements in given formula (no brackets allowed!)
        public static Dictionary<string, double> getElements(string formula)
        {
            List<Dictionary<string, double>> result = new List<Dictionary<string, double>>();
            result.Add(new Dictionary<string, double>());
            int i = 0;
            foreach(Match m in Regex.Matches(formula, pattern)){
                //Group one == Element string, Assign Group two == Factor
                if (m.Groups[1].Success)
                {
                    //does not contain key -> create
                    if (!result[i].ContainsKey(m.Groups[1].Value)) result[i][m.Groups[1].Value] = (m.Groups[2].Success && m.Groups[2].Value != "" ? Convert.ToDouble(m.Groups[2].Value) : 1d);
                    //contains key -> additon
                    else result[i][m.Groups[1].Value] += (m.Groups[2].Success ? Convert.ToDouble(m.Groups[2].Value) : 1d);
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
                    for (int j = 0; j < result[i].Count; j++)
                    {
                        result[i][result[i].ElementAt(j).Key] = result[i].ElementAt(j).Value * mult;
                    }
                    //check if there is a top dict.
                    for (int j = i + 1; j < result.Count; j++)
                    {
                        for (int k = 0; k < result[j].Count; k++)
                        {
                            result[j][result[j].ElementAt(k).Key] = result[j].ElementAt(k).Value * mult;
                        }
                    }
                    //end of subformula
                    i--;

                }
            }

            //combine dictionaries
            return result.SelectMany(d => d).ToLookup(pair => pair.Key, pair => pair.Value).ToDictionary(group => group.Key, group => group.First());
        }

        public static double getWeight(Dictionary<string, double> Elements)
        {
            double MW = 0;
            foreach(KeyValuePair<string, double> element in Elements){
                MW = MW + (element.Value * weights[element.Key]);
            }
            return MW;
        }
        public static double getWeight(string el, double no)
        {
            return weights[el] * no;
        }

        public static Dictionary<string, double> getAnalysis(string formula)
        {
            Dictionary<string, double> CHNElements = new Dictionary<string, double>();
            
            foreach(KeyValuePair<string, double> element in getElements(formula))
            {
                CHNElements.Add(element.Key, getWeight(element.Key, element.Value));
            }
            return CHNElements;
        }
    }
}
