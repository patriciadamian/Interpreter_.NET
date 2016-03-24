namespace GUI_Interpreter
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabInputProgram = new System.Windows.Forms.TabPage();
            this.btnInputPrg = new System.Windows.Forms.Button();
            this.rtxtInput = new System.Windows.Forms.RichTextBox();
            this.tabOneStep = new System.Windows.Forms.TabPage();
            this.btnOneStep = new System.Windows.Forms.Button();
            this.rtxtOneStep = new System.Windows.Forms.RichTextBox();
            this.tabAllStep = new System.Windows.Forms.TabPage();
            this.btnAllStep = new System.Windows.Forms.Button();
            this.rtxtAllStep = new System.Windows.Forms.RichTextBox();
            this.tabSerDeser = new System.Windows.Forms.TabPage();
            this.btnDeserialize = new System.Windows.Forms.Button();
            this.btnSerialize = new System.Windows.Forms.Button();
            this.rtxtSerDes = new System.Windows.Forms.RichTextBox();
            this.checkBoxLogFlagS = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabInputProgram.SuspendLayout();
            this.tabOneStep.SuspendLayout();
            this.tabAllStep.SuspendLayout();
            this.tabSerDeser.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabInputProgram);
            this.tabControl1.Controls.Add(this.tabOneStep);
            this.tabControl1.Controls.Add(this.tabAllStep);
            this.tabControl1.Controls.Add(this.tabSerDeser);
            this.tabControl1.Location = new System.Drawing.Point(25, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(683, 497);
            this.tabControl1.TabIndex = 0;
            // 
            // tabInputProgram
            // 
            this.tabInputProgram.Controls.Add(this.btnInputPrg);
            this.tabInputProgram.Controls.Add(this.rtxtInput);
            this.tabInputProgram.Location = new System.Drawing.Point(4, 25);
            this.tabInputProgram.Name = "tabInputProgram";
            this.tabInputProgram.Padding = new System.Windows.Forms.Padding(3);
            this.tabInputProgram.Size = new System.Drawing.Size(675, 468);
            this.tabInputProgram.TabIndex = 0;
            this.tabInputProgram.Text = "Input Program";
            this.tabInputProgram.UseVisualStyleBackColor = true;
            // 
            // btnInputPrg
            // 
            this.btnInputPrg.Location = new System.Drawing.Point(549, 415);
            this.btnInputPrg.Name = "btnInputPrg";
            this.btnInputPrg.Size = new System.Drawing.Size(120, 33);
            this.btnInputPrg.TabIndex = 1;
            this.btnInputPrg.Text = "Input Program";
            this.btnInputPrg.UseVisualStyleBackColor = true;
            this.btnInputPrg.Click += new System.EventHandler(this.btnClickInputPrg);
            // 
            // rtxtInput
            // 
            this.rtxtInput.Location = new System.Drawing.Point(6, 6);
            this.rtxtInput.Name = "rtxtInput";
            this.rtxtInput.Size = new System.Drawing.Size(663, 381);
            this.rtxtInput.TabIndex = 0;
            this.rtxtInput.Text = "";
            // 
            // tabOneStep
            // 
            this.tabOneStep.Controls.Add(this.btnOneStep);
            this.tabOneStep.Controls.Add(this.rtxtOneStep);
            this.tabOneStep.Location = new System.Drawing.Point(4, 25);
            this.tabOneStep.Name = "tabOneStep";
            this.tabOneStep.Padding = new System.Windows.Forms.Padding(3);
            this.tabOneStep.Size = new System.Drawing.Size(675, 468);
            this.tabOneStep.TabIndex = 1;
            this.tabOneStep.Text = "One Step Execution";
            this.tabOneStep.UseVisualStyleBackColor = true;
            // 
            // btnOneStep
            // 
            this.btnOneStep.Location = new System.Drawing.Point(552, 422);
            this.btnOneStep.Name = "btnOneStep";
            this.btnOneStep.Size = new System.Drawing.Size(117, 29);
            this.btnOneStep.TabIndex = 2;
            this.btnOneStep.Text = "One Step";
            this.btnOneStep.UseVisualStyleBackColor = true;
            this.btnOneStep.Click += new System.EventHandler(this.btnClickOneStep);
            // 
            // rtxtOneStep
            // 
            this.rtxtOneStep.Location = new System.Drawing.Point(6, 6);
            this.rtxtOneStep.Name = "rtxtOneStep";
            this.rtxtOneStep.Size = new System.Drawing.Size(663, 393);
            this.rtxtOneStep.TabIndex = 0;
            this.rtxtOneStep.Text = "";
            // 
            // tabAllStep
            // 
            this.tabAllStep.Controls.Add(this.btnAllStep);
            this.tabAllStep.Controls.Add(this.rtxtAllStep);
            this.tabAllStep.Location = new System.Drawing.Point(4, 25);
            this.tabAllStep.Name = "tabAllStep";
            this.tabAllStep.Padding = new System.Windows.Forms.Padding(3);
            this.tabAllStep.Size = new System.Drawing.Size(675, 468);
            this.tabAllStep.TabIndex = 2;
            this.tabAllStep.Text = "All Step Execution";
            this.tabAllStep.UseVisualStyleBackColor = true;
            // 
            // btnAllStep
            // 
            this.btnAllStep.Location = new System.Drawing.Point(560, 409);
            this.btnAllStep.Name = "btnAllStep";
            this.btnAllStep.Size = new System.Drawing.Size(112, 31);
            this.btnAllStep.TabIndex = 1;
            this.btnAllStep.Text = "All Step";
            this.btnAllStep.UseVisualStyleBackColor = true;
            this.btnAllStep.Click += new System.EventHandler(this.btnClickAllStep);
            // 
            // rtxtAllStep
            // 
            this.rtxtAllStep.Location = new System.Drawing.Point(6, 6);
            this.rtxtAllStep.Name = "rtxtAllStep";
            this.rtxtAllStep.Size = new System.Drawing.Size(666, 382);
            this.rtxtAllStep.TabIndex = 0;
            this.rtxtAllStep.Text = "";
            // 
            // tabSerDeser
            // 
            this.tabSerDeser.Controls.Add(this.btnDeserialize);
            this.tabSerDeser.Controls.Add(this.btnSerialize);
            this.tabSerDeser.Controls.Add(this.rtxtSerDes);
            this.tabSerDeser.Location = new System.Drawing.Point(4, 25);
            this.tabSerDeser.Name = "tabSerDeser";
            this.tabSerDeser.Padding = new System.Windows.Forms.Padding(3);
            this.tabSerDeser.Size = new System.Drawing.Size(675, 468);
            this.tabSerDeser.TabIndex = 3;
            this.tabSerDeser.Text = "Serialize/Deserialize";
            this.tabSerDeser.UseVisualStyleBackColor = true;
            // 
            // btnDeserialize
            // 
            this.btnDeserialize.Location = new System.Drawing.Point(570, 407);
            this.btnDeserialize.Name = "btnDeserialize";
            this.btnDeserialize.Size = new System.Drawing.Size(105, 30);
            this.btnDeserialize.TabIndex = 2;
            this.btnDeserialize.Text = "Deserialize";
            this.btnDeserialize.UseVisualStyleBackColor = true;
            this.btnDeserialize.Click += new System.EventHandler(this.btnClickDeserialize);
            // 
            // btnSerialize
            // 
            this.btnSerialize.Location = new System.Drawing.Point(0, 407);
            this.btnSerialize.Name = "btnSerialize";
            this.btnSerialize.Size = new System.Drawing.Size(105, 30);
            this.btnSerialize.TabIndex = 1;
            this.btnSerialize.Text = "Serialize";
            this.btnSerialize.UseVisualStyleBackColor = true;
            this.btnSerialize.Click += new System.EventHandler(this.btnClickSerialize);
            // 
            // rtxtSerDes
            // 
            this.rtxtSerDes.Location = new System.Drawing.Point(3, 6);
            this.rtxtSerDes.Name = "rtxtSerDes";
            this.rtxtSerDes.Size = new System.Drawing.Size(666, 381);
            this.rtxtSerDes.TabIndex = 0;
            this.rtxtSerDes.Text = "";
            // 
            // checkBoxLogFlagS
            // 
            this.checkBoxLogFlagS.AutoSize = true;
            this.checkBoxLogFlagS.Location = new System.Drawing.Point(593, 13);
            this.checkBoxLogFlagS.Name = "checkBoxLogFlagS";
            this.checkBoxLogFlagS.Size = new System.Drawing.Size(85, 21);
            this.checkBoxLogFlagS.TabIndex = 1;
            this.checkBoxLogFlagS.Text = "Log Flag";
            this.checkBoxLogFlagS.UseVisualStyleBackColor = true;
            this.checkBoxLogFlagS.CheckedChanged += new System.EventHandler(this.checkClickLog);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 559);
            this.Controls.Add(this.checkBoxLogFlagS);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainWindow";
            this.Text = "Toy Language Interpreter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabInputProgram.ResumeLayout(false);
            this.tabOneStep.ResumeLayout(false);
            this.tabAllStep.ResumeLayout(false);
            this.tabSerDeser.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabInputProgram;
        private System.Windows.Forms.TabPage tabOneStep;
        private System.Windows.Forms.TabPage tabAllStep;
        private System.Windows.Forms.TabPage tabSerDeser;
        private System.Windows.Forms.RichTextBox rtxtInput;
        private System.Windows.Forms.Button btnInputPrg;
        private System.Windows.Forms.RichTextBox rtxtOneStep;
        private System.Windows.Forms.Button btnOneStep;
        private System.Windows.Forms.Button btnAllStep;
        private System.Windows.Forms.RichTextBox rtxtAllStep;
        private System.Windows.Forms.Button btnDeserialize;
        private System.Windows.Forms.Button btnSerialize;
        private System.Windows.Forms.RichTextBox rtxtSerDes;
        private System.Windows.Forms.CheckBox checkBoxLogFlagS;
    }
}

