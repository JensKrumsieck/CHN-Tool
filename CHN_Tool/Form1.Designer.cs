namespace CHN_Tool
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ResLbl = new System.Windows.Forms.Label();
            this.formulaTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.deltaLbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.FValue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.NValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.HValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CValue = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Imp2Step = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.Imp2Upper = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.Imp2Lower = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.Imp2Formula = new System.Windows.Forms.TextBox();
            this.Imp2CB = new System.Windows.Forms.CheckBox();
            this.Sub3Btn = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.Imp1Step = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Imp1Upper = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Imp1Lower = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Imp1Formula = new System.Windows.Forms.TextBox();
            this.Imp1CB = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.outputRTB = new System.Windows.Forms.RichTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ResLbl);
            this.groupBox1.Controls.Add(this.formulaTB);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(198, 336);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Theoretical";
            // 
            // ResLbl
            // 
            this.ResLbl.AutoSize = true;
            this.ResLbl.Location = new System.Drawing.Point(4, 67);
            this.ResLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ResLbl.Name = "ResLbl";
            this.ResLbl.Size = new System.Drawing.Size(10, 13);
            this.ResLbl.TabIndex = 7;
            this.ResLbl.Text = ".";
            // 
            // formulaTB
            // 
            this.formulaTB.Location = new System.Drawing.Point(6, 41);
            this.formulaTB.Margin = new System.Windows.Forms.Padding(2);
            this.formulaTB.Name = "formulaTB";
            this.formulaTB.Size = new System.Drawing.Size(161, 20);
            this.formulaTB.TabIndex = 5;
            this.formulaTB.TextChanged += new System.EventHandler(this.formulaTB_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enter Formula (without brackets)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.deltaLbl);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.FValue);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.SValue);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.NValue);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.HValue);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.CValue);
            this.groupBox2.Location = new System.Drawing.Point(212, 6);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(145, 336);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Experimental";
            // 
            // deltaLbl
            // 
            this.deltaLbl.AutoSize = true;
            this.deltaLbl.Location = new System.Drawing.Point(3, 143);
            this.deltaLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.deltaLbl.Name = "deltaLbl";
            this.deltaLbl.Size = new System.Drawing.Size(10, 13);
            this.deltaLbl.TabIndex = 8;
            this.deltaLbl.Text = ".";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 118);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "F [%]";
            // 
            // FValue
            // 
            this.FValue.Enabled = false;
            this.FValue.Location = new System.Drawing.Point(38, 116);
            this.FValue.Margin = new System.Windows.Forms.Padding(2);
            this.FValue.Name = "FValue";
            this.FValue.Size = new System.Drawing.Size(104, 20);
            this.FValue.TabIndex = 11;
            this.FValue.TextChanged += new System.EventHandler(this.ExpChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 98);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "S [%]";
            // 
            // SValue
            // 
            this.SValue.Enabled = false;
            this.SValue.Location = new System.Drawing.Point(38, 97);
            this.SValue.Margin = new System.Windows.Forms.Padding(2);
            this.SValue.Name = "SValue";
            this.SValue.Size = new System.Drawing.Size(104, 20);
            this.SValue.TabIndex = 10;
            this.SValue.TextChanged += new System.EventHandler(this.ExpChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 79);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "N [%]";
            // 
            // NValue
            // 
            this.NValue.Enabled = false;
            this.NValue.Location = new System.Drawing.Point(38, 77);
            this.NValue.Margin = new System.Windows.Forms.Padding(2);
            this.NValue.Name = "NValue";
            this.NValue.Size = new System.Drawing.Size(104, 20);
            this.NValue.TabIndex = 9;
            this.NValue.TextChanged += new System.EventHandler(this.ExpChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 60);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "H [%]";
            // 
            // HValue
            // 
            this.HValue.Enabled = false;
            this.HValue.Location = new System.Drawing.Point(38, 58);
            this.HValue.Margin = new System.Windows.Forms.Padding(2);
            this.HValue.Name = "HValue";
            this.HValue.Size = new System.Drawing.Size(104, 20);
            this.HValue.TabIndex = 8;
            this.HValue.TextChanged += new System.EventHandler(this.ExpChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "C [%]";
            // 
            // CValue
            // 
            this.CValue.Enabled = false;
            this.CValue.Location = new System.Drawing.Point(38, 39);
            this.CValue.Margin = new System.Windows.Forms.Padding(2);
            this.CValue.Name = "CValue";
            this.CValue.Size = new System.Drawing.Size(104, 20);
            this.CValue.TabIndex = 6;
            this.CValue.TextChanged += new System.EventHandler(this.ExpChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.Imp2Step);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.Imp2Upper);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.Imp2Lower);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.Imp2Formula);
            this.groupBox3.Controls.Add(this.Imp2CB);
            this.groupBox3.Controls.Add(this.Sub3Btn);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.Imp1Step);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.Imp1Upper);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.Imp1Lower);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.Imp1Formula);
            this.groupBox3.Controls.Add(this.Imp1CB);
            this.groupBox3.Location = new System.Drawing.Point(360, 6);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(165, 336);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Impurities/Solvents";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 222);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 13);
            this.label12.TabIndex = 33;
            this.label12.Text = "Stepsize";
            // 
            // Imp2Step
            // 
            this.Imp2Step.Enabled = false;
            this.Imp2Step.Location = new System.Drawing.Point(68, 220);
            this.Imp2Step.Margin = new System.Windows.Forms.Padding(2);
            this.Imp2Step.Name = "Imp2Step";
            this.Imp2Step.Size = new System.Drawing.Size(47, 20);
            this.Imp2Step.TabIndex = 32;
            this.Imp2Step.Text = "0,5";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(116, 202);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 13);
            this.label13.TabIndex = 31;
            this.label13.Text = "Eq.";
            // 
            // Imp2Upper
            // 
            this.Imp2Upper.Enabled = false;
            this.Imp2Upper.Location = new System.Drawing.Point(68, 200);
            this.Imp2Upper.Margin = new System.Windows.Forms.Padding(2);
            this.Imp2Upper.Name = "Imp2Upper";
            this.Imp2Upper.Size = new System.Drawing.Size(47, 20);
            this.Imp2Upper.TabIndex = 30;
            this.Imp2Upper.Text = "1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(55, 202);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(10, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "-";
            // 
            // Imp2Lower
            // 
            this.Imp2Lower.Enabled = false;
            this.Imp2Lower.Location = new System.Drawing.Point(7, 200);
            this.Imp2Lower.Margin = new System.Windows.Forms.Padding(2);
            this.Imp2Lower.Name = "Imp2Lower";
            this.Imp2Lower.Size = new System.Drawing.Size(47, 20);
            this.Imp2Lower.TabIndex = 28;
            this.Imp2Lower.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 159);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(44, 13);
            this.label15.TabIndex = 27;
            this.label15.Text = "Formula";
            // 
            // Imp2Formula
            // 
            this.Imp2Formula.Enabled = false;
            this.Imp2Formula.Location = new System.Drawing.Point(6, 175);
            this.Imp2Formula.Margin = new System.Windows.Forms.Padding(2);
            this.Imp2Formula.Name = "Imp2Formula";
            this.Imp2Formula.Size = new System.Drawing.Size(118, 20);
            this.Imp2Formula.TabIndex = 26;
            // 
            // Imp2CB
            // 
            this.Imp2CB.AutoSize = true;
            this.Imp2CB.Enabled = false;
            this.Imp2CB.Location = new System.Drawing.Point(6, 139);
            this.Imp2CB.Margin = new System.Windows.Forms.Padding(2);
            this.Imp2CB.Name = "Imp2CB";
            this.Imp2CB.Size = new System.Drawing.Size(119, 17);
            this.Imp2CB.TabIndex = 25;
            this.Imp2CB.Text = "Impurity/Solvent #2";
            this.Imp2CB.UseVisualStyleBackColor = true;
            this.Imp2CB.CheckedChanged += new System.EventHandler(this.Imp2CB_CheckedChanged);
            // 
            // Sub3Btn
            // 
            this.Sub3Btn.Enabled = false;
            this.Sub3Btn.Location = new System.Drawing.Point(6, 310);
            this.Sub3Btn.Margin = new System.Windows.Forms.Padding(2);
            this.Sub3Btn.Name = "Sub3Btn";
            this.Sub3Btn.Size = new System.Drawing.Size(156, 22);
            this.Sub3Btn.TabIndex = 39;
            this.Sub3Btn.Text = "Recalculate";
            this.Sub3Btn.UseVisualStyleBackColor = true;
            this.Sub3Btn.Click += new System.EventHandler(this.Sub3Btn_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 107);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Stepsize";
            // 
            // Imp1Step
            // 
            this.Imp1Step.Enabled = false;
            this.Imp1Step.Location = new System.Drawing.Point(64, 105);
            this.Imp1Step.Margin = new System.Windows.Forms.Padding(2);
            this.Imp1Step.Name = "Imp1Step";
            this.Imp1Step.Size = new System.Drawing.Size(47, 20);
            this.Imp1Step.TabIndex = 23;
            this.Imp1Step.Text = "0,5";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(112, 86);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Eq.";
            // 
            // Imp1Upper
            // 
            this.Imp1Upper.Enabled = false;
            this.Imp1Upper.Location = new System.Drawing.Point(64, 85);
            this.Imp1Upper.Margin = new System.Windows.Forms.Padding(2);
            this.Imp1Upper.Name = "Imp1Upper";
            this.Imp1Upper.Size = new System.Drawing.Size(47, 20);
            this.Imp1Upper.TabIndex = 21;
            this.Imp1Upper.Text = "1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(52, 86);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(10, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "-";
            // 
            // Imp1Lower
            // 
            this.Imp1Lower.Enabled = false;
            this.Imp1Lower.Location = new System.Drawing.Point(4, 85);
            this.Imp1Lower.Margin = new System.Windows.Forms.Padding(2);
            this.Imp1Lower.Name = "Imp1Lower";
            this.Imp1Lower.Size = new System.Drawing.Size(47, 20);
            this.Imp1Lower.TabIndex = 19;
            this.Imp1Lower.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 43);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Formula";
            // 
            // Imp1Formula
            // 
            this.Imp1Formula.Enabled = false;
            this.Imp1Formula.Location = new System.Drawing.Point(3, 60);
            this.Imp1Formula.Margin = new System.Windows.Forms.Padding(2);
            this.Imp1Formula.Name = "Imp1Formula";
            this.Imp1Formula.Size = new System.Drawing.Size(118, 20);
            this.Imp1Formula.TabIndex = 17;
            // 
            // Imp1CB
            // 
            this.Imp1CB.AutoSize = true;
            this.Imp1CB.Enabled = false;
            this.Imp1CB.Location = new System.Drawing.Point(3, 24);
            this.Imp1CB.Margin = new System.Windows.Forms.Padding(2);
            this.Imp1CB.Name = "Imp1CB";
            this.Imp1CB.Size = new System.Drawing.Size(119, 17);
            this.Imp1CB.TabIndex = 0;
            this.Imp1CB.Text = "Impurity/Solvent #1";
            this.Imp1CB.UseVisualStyleBackColor = true;
            this.Imp1CB.CheckedChanged += new System.EventHandler(this.Imp1CB_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 352);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Output";
            // 
            // outputRTB
            // 
            this.outputRTB.Location = new System.Drawing.Point(6, 366);
            this.outputRTB.Margin = new System.Windows.Forms.Padding(2);
            this.outputRTB.Name = "outputRTB";
            this.outputRTB.ReadOnly = true;
            this.outputRTB.Size = new System.Drawing.Size(520, 183);
            this.outputRTB.TabIndex = 40;
            this.outputRTB.Text = "";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(398, 348);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(125, 13);
            this.label16.TabIndex = 41;
            this.label16.Text = "Made by Jens Krumsieck";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(538, 552);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.outputRTB);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = Resources.chn_icon;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "CHN-Tool";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label ResLbl;
        private System.Windows.Forms.TextBox formulaTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label deltaLbl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox FValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox NValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox HValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CValue;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox Imp1Step;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Imp1Upper;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Imp1Lower;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Imp1Formula;
        private System.Windows.Forms.CheckBox Imp1CB;
        private System.Windows.Forms.Button Sub3Btn;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox outputRTB;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox Imp2Step;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox Imp2Upper;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox Imp2Lower;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox Imp2Formula;
        private System.Windows.Forms.CheckBox Imp2CB;
        private System.Windows.Forms.Label label16;
    }
}

