using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {

        public CalculatorForm()
        {
            InitializeComponent();
        }

        //Graphing
        int graphXlimit = (50 + 1);
        private void graphToggle_Click(object sender, EventArgs e)
        {
            if(graph1.Visible == true)
            {
                graph1.Visible = false;
            }
            else
            {
                graph1.Visible = true;
            }
        }
        private void plot1_Click(object sender, EventArgs e)
        {
            if (graph1.Visible == false)
            {
                graph1.Visible = true;
            }
            try
            {
                graphingCalc1stDeg(Convert.ToDouble(textBoxK.Text), Convert.ToDouble(textBoxM.Text), graphXlimit);
            }
            catch (Exception)
            {
                textBoxXAns.Text = "Error";
            }
        }
        private void plot2_Click(object sender, EventArgs e)
        {
            if (graph1.Visible == false)
            {
                graph1.Visible = true;
            }
            try
            {
                graphingCalc2ndDeg(Convert.ToDouble(textBoxA.Text), Convert.ToDouble(textBoxB.Text), Convert.ToDouble(textBoxC.Text), graphXlimit);
            }
            catch (Exception)
            {
                textBoxXAns.Text = "Error";
            }
        }
        private void graphingCalc1stDeg(double k, double m, int limit)
        {
            List<double> valuesX = new List<double>();
            List<double> valuesY = new List<double>();

            for (int x = -limit + 2; x < limit; x++)
            {
                valuesX.Add(x);
                valuesY.Add(k * x + m);
            }

            graph1.Series["Equation"].Points.DataBindXY(valuesX, valuesY);
        }
        private void graphingCalc2ndDeg(double a, double b, double c, int limit)
        {
            List<double> valuesX = new List<double>();
            List<double> valuesY = new List<double>();

            for (int x = -limit + 2; x < limit; x++)
            {
                valuesX.Add(x);
                valuesY.Add((a * x * x) + (b * x) + c);
            }
            
            graph1.Series["Equation"].Points.DataBindXY(valuesX, valuesY);
        }

        //Calculator
        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button.Text == "C")
            {
                textBoxResult.Text = "";
            }
            else if(button.Text == "<----")
            {
                if (textBoxResult.Text.Length > 0)
                {
                    textBoxResult.Text = textBoxResult.Text.Remove(textBoxResult.Text.Length - 1, 1);
                }
            }
            else if (button.Text == "=")
            {
                try
                {

                    textBoxResult.Text = new DataTable().Compute(textBoxResult.Text, null).ToString();
                }
                catch (Exception)
                {
                    textBoxResult.Text = "Error";
                }
            }
            else
            {
                textBoxResult.Text += button.Text;
            }
        }

        //1st Degree solver
        private void solver1stDeg_Click(object sender, EventArgs e)
        {
            if (title1stDeg.Visible == true)
            {
                title1stDeg.Visible = false;
                explain1stDeg.Visible = false;
                textBoxK.Visible = false;
                textBoxM.Visible = false;
                textBoxY.Visible = false;
                k.Visible = false;
                m.Visible = false;
                y.Visible = false;
                plusX1.Visible = false;
                xAns.Visible = false;
                textBoxXAns.Visible = false;
                button1_0.Visible = false;
                button1_1.Visible = false;
                button1_2.Visible = false;
                button1_3.Visible = false;
                button1_4.Visible = false;
                button1_5.Visible = false;
                button1_6.Visible = false;
                button1_7.Visible = false;
                button1_8.Visible = false;
                button1_9.Visible = false;
                button1_Comma.Visible = false;
                button1_Backspace.Visible = false;
                button1_C.Visible = false;
                button1_Equals.Visible = false;
                button1_Negative.Visible = false;
                radioK.Visible = false;
                radioM.Visible = false;
                radioY.Visible = false;
                plot1.Visible = false;
            }
            else
            {
                title1stDeg.Visible = true;
                explain1stDeg.Visible = true;
                textBoxK.Visible = true;
                textBoxM.Visible = true;
                textBoxY.Visible = true;
                k.Visible = true;
                m.Visible = true;
                y.Visible = true;
                plusX1.Visible = true;
                xAns.Visible = true;
                textBoxXAns.Visible = true;
                button1_0.Visible = true;
                button1_1.Visible = true;
                button1_2.Visible = true;
                button1_3.Visible = true;
                button1_4.Visible = true;
                button1_5.Visible = true;
                button1_6.Visible = true;
                button1_7.Visible = true;
                button1_8.Visible = true;
                button1_9.Visible = true;
                button1_Comma.Visible = true;
                button1_Backspace.Visible = true;
                button1_C.Visible = true;
                button1_Equals.Visible = true;
                button1_Negative.Visible = true;
                radioK.Visible = true;
                radioM.Visible = true;
                radioY.Visible = true;
                plot1.Visible = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioK.Checked == true)
            {
                Button button = (Button)sender;
                if (button.Text == "C")
                {
                    textBoxK.Text = "";
                }
                else if (button.Text == "=")
                {
                    try
                    {
                        textBoxXAns.Text = firstDegCalculations(Convert.ToDouble(textBoxK.Text), Convert.ToDouble(textBoxM.Text), Convert.ToDouble(textBoxY.Text));
                    }
                    catch (Exception)
                    {
                        textBoxXAns.Text = "Error";
                    }
                }
                else if (button.Text == "<----")
                {
                    if (textBoxK.Text.Length > 0)
                    {
                        textBoxK.Text = textBoxK.Text.Remove(textBoxK.Text.Length - 1, 1);
                    }
                }
                else
                {
                    textBoxK.Text += button.Text;
                }
            }
            else if (radioM.Checked == true)
            {
                Button button = (Button)sender;
                if (button.Text == "C")
                {
                    textBoxM.Text = "";
                }
                else if (button.Text == "=")
                {
                    try
                    {
                        textBoxXAns.Text = firstDegCalculations(Convert.ToDouble(textBoxK.Text), Convert.ToDouble(textBoxM.Text), Convert.ToDouble(textBoxY.Text));
                    }
                    catch (Exception)
                    {
                        textBoxXAns.Text = "Error";
                    }
                }
                else if (button.Text == "<----")
                {
                    if (textBoxM.Text.Length > 0)
                    {
                        textBoxM.Text = textBoxM.Text.Remove(textBoxM.Text.Length - 1, 1);
                    }
                }
                else
                {
                    textBoxM.Text += button.Text;
                }
            }
            else if (radioY.Checked == true)
            {
                Button button = (Button)sender;
                if (button.Text == "C")
                {
                    textBoxY.Text = "";
                }
                else if (button.Text == "=")
                {
                    try
                    {
                        textBoxXAns.Text = firstDegCalculations(Convert.ToDouble(textBoxK.Text), Convert.ToDouble(textBoxM.Text), Convert.ToDouble(textBoxY.Text));
                    }
                    catch (Exception)
                    {
                        textBoxXAns.Text = "Error";
                    }
                }
                else if (button.Text == "<----")
                {
                    if (textBoxY.Text.Length > 0)
                    {
                        textBoxY.Text = textBoxY.Text.Remove(textBoxY.Text.Length - 1, 1);
                    }
                }
                else
                {
                    textBoxY.Text += button.Text;
                }
            }
        }
        static string firstDegCalculations(double k, double m, double y)
        {
            string result = "Error";
            try
            {
                result = $"{(y - m) / k}";
            }
            catch
            {
                return result; ;
            }
            return result;
        }

        //2nd Degree solver
        private void solver2ndDeg_Click(object sender, EventArgs e)
        {
            if (title2ndDeg.Visible == true)
            {
                title2ndDeg.Visible = false;
                explain2ndDeg.Visible = false;
                textBoxA.Visible = false;
                textBoxB.Visible = false;
                textBoxC.Visible = false;
                x2.Visible = false;
                plusX1.Visible = false;
                x1.Visible = false;
                x0.Visible = false;
                x1Ans.Visible = false;
                x2Ans.Visible = false;
                textBoxX1Ans.Visible = false;
                textBoxX2Ans.Visible = false;
                button2_0.Visible = false;
                button2_1.Visible = false;
                button2_2.Visible = false;
                button2_3.Visible = false;
                button2_4.Visible = false;
                button2_5.Visible = false;
                button2_6.Visible = false;
                button2_7.Visible = false;
                button2_8.Visible = false;
                button2_9.Visible = false;
                button2_Comma.Visible = false;
                button2_backspace.Visible = false;
                button2_C.Visible = false;
                button2_Equals.Visible = false;
                button2_Negative.Visible = false;
                radioA.Visible = false;
                radioB.Visible = false;
                radioC.Visible = false;
                plot2.Visible = false;
            }
            else
            {
                title2ndDeg.Visible = true;
                explain2ndDeg.Visible = true;
                textBoxA.Visible = true;
                textBoxB.Visible = true;
                textBoxC.Visible = true;
                x2.Visible = true;
                plusX1.Visible = false;
                x1.Visible = true;
                x0.Visible = true;
                x1Ans.Visible = true;
                x2Ans.Visible = true;
                textBoxX1Ans.Visible = true;
                textBoxX2Ans.Visible = true;
                button2_0.Visible = true;
                button2_1.Visible = true;
                button2_2.Visible = true;
                button2_3.Visible = true;
                button2_4.Visible = true;
                button2_5.Visible = true;
                button2_6.Visible = true;
                button2_7.Visible = true;
                button2_8.Visible = true;
                button2_9.Visible = true;
                button2_Comma.Visible = true;
                button2_backspace.Visible = true;
                button2_C.Visible = true;
                button2_Equals.Visible = true;
                button2_Negative.Visible = true;
                radioA.Visible = true;
                radioB.Visible = true;
                radioC.Visible = true;
                plot2.Visible = true;
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (radioA.Checked == true)
            {
                Button button = (Button)sender;
                if (button.Text == "C")
                {
                    textBoxA.Text = "";
                }
                else if (button.Text == "=")
                {
                    try
                    {
                        textBoxX1Ans.Text = secondDegCalculations(Convert.ToDouble(textBoxA.Text), Convert.ToDouble(textBoxB.Text), Convert.ToDouble(textBoxC.Text), 1);
                    }
                    catch (Exception)
                    {
                        textBoxX1Ans.Text = "Error";
                    }
                    try
                    {
                        textBoxX2Ans.Text = secondDegCalculations(Convert.ToDouble(textBoxA.Text), Convert.ToDouble(textBoxB.Text), Convert.ToDouble(textBoxC.Text), 2);
                    }
                    catch
                    {
                        textBoxX2Ans.Text = "Error";
                    }
                }
                else if(button.Text == "<----")
                {
                    if (textBoxA.Text.Length > 0)
                    {
                        textBoxA.Text = textBoxA.Text.Remove(textBoxA.Text.Length - 1, 1);
                    }
                }
                else
                {
                    textBoxA.Text += button.Text;
                }
            }
            else if (radioB.Checked == true)
            {
                Button button = (Button)sender;
                if (button.Text == "C")
                {
                    textBoxB.Text = "";
                }
                else if (button.Text == "=")
                {
                    try
                    {
                        textBoxX1Ans.Text = secondDegCalculations(Convert.ToDouble(textBoxA.Text), Convert.ToDouble(textBoxB.Text), Convert.ToDouble(textBoxC.Text), 1);
                    }
                    catch (Exception)
                    {
                        textBoxX1Ans.Text = "Error";
                    }
                    try
                    {
                        textBoxX2Ans.Text = secondDegCalculations(Convert.ToDouble(textBoxA.Text), Convert.ToDouble(textBoxB.Text), Convert.ToDouble(textBoxC.Text), 2);
                    }
                    catch
                    {
                        textBoxX2Ans.Text = "Error";
                    }
                }
                else if (button.Text == "<----")
                {
                    if (textBoxB.Text.Length > 0)
                    {
                        textBoxB.Text = textBoxB.Text.Remove(textBoxB.Text.Length - 1, 1);
                    }
                }
                else
                {
                    textBoxB.Text += button.Text;
                }
            }
            else if (radioC.Checked == true)
            {
                Button button = (Button)sender;
                if (button.Text == "C")
                {
                    textBoxC.Text = "";
                }
                else if (button.Text == "=")
                {
                    try
                    {
                        textBoxX1Ans.Text = secondDegCalculations(Convert.ToDouble(textBoxA.Text), Convert.ToDouble(textBoxB.Text), Convert.ToDouble(textBoxC.Text), 1);
                    }
                    catch (Exception)
                    {
                        textBoxX1Ans.Text = "Error";
                    }
                    try
                    {
                        textBoxX2Ans.Text = secondDegCalculations(Convert.ToDouble(textBoxA.Text), Convert.ToDouble(textBoxB.Text), Convert.ToDouble(textBoxC.Text), 2);
                    }
                    catch
                    {
                        textBoxX2Ans.Text = "Error";
                    }
                }
                else if (button.Text == "<----")
                {
                    if (textBoxC.Text.Length > 0)
                    {
                        textBoxC.Text = textBoxC.Text.Remove(textBoxC.Text.Length - 1, 1);
                    }
                }
                else
                {
                    textBoxC.Text += button.Text;
                }
            }
        }
        static string secondDegCalculations(double a, double b, double c, int num)
        {
            string result = "Error";
            if(num == 1)
            {
                if ((b*b-4*a*c > 0 && a != 0)) 
                {
                    try
                    {
                        result = Convert.ToString(((-b / (2 * a)) + (Math.Sqrt((b * b) - 4 * a * c) / (2 * a))));
                    }
                    catch
                    {
                        return result;
                    }
                }
                else
                {
                    try
                    {
                        result = $"{(-b / (2 * a))} + {Math.Sqrt(-((b * b) - 4 * a * c)) / (2 * a)} * i";
                    }
                    catch
                    {
                        return result;
                    }
                }
            }
            else if(num == 2)
            {
                if ((b * b - 4 * a * c > 0 && a != 0))
                {
                    try
                    {
                        result = Convert.ToString(((-b / (2 * a)) - (Math.Sqrt((b * b) - 4 * a * c) / (2 * a))));
                    }
                    catch
                    {
                        return result;
                    }
                }
                else
                {
                    try
                    {
                        result = $"{(-b / (2 * a))} - {Math.Sqrt(-((b * b) - 4 * a * c)) / (2 * a)} * i";
                    }
                    catch
                    {
                        return result;
                    }
                }
            }

            return result;
        }
    }
}