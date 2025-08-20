namespace Calculator;

partial class CalculatorForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
        txtDisplay = new System.Windows.Forms.TextBox();
        lblOperation = new System.Windows.Forms.Label();
        btnOne = new System.Windows.Forms.Button();
        btnTwo = new System.Windows.Forms.Button();
        btnThree = new System.Windows.Forms.Button();
        btnFour = new System.Windows.Forms.Button();
        btnFive = new System.Windows.Forms.Button();
        btnSix = new System.Windows.Forms.Button();
        btnSeven = new System.Windows.Forms.Button();
        btnEight = new System.Windows.Forms.Button();
        btnNine = new System.Windows.Forms.Button();
        btnZero = new System.Windows.Forms.Button();
        btnClear = new System.Windows.Forms.Button();
        btnEquals = new System.Windows.Forms.Button();
        btnPlus = new System.Windows.Forms.Button();
        btnMinus = new System.Windows.Forms.Button();
        btnMult = new System.Windows.Forms.Button();
        btnDiv = new System.Windows.Forms.Button();
        btnDecimal = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // txtDisplay
        // 
        txtDisplay.Location = new System.Drawing.Point(6, 31);
        txtDisplay.Name = "txtDisplay";
        txtDisplay.Size = new System.Drawing.Size(153, 23);
        txtDisplay.TabIndex = 0;
        txtDisplay.Text = "0";
        // 
        // lblOperation
        // 
        lblOperation.Location = new System.Drawing.Point(6, 14);
        lblOperation.Name = "lblOperation";
        lblOperation.Size = new System.Drawing.Size(153, 14);
        lblOperation.TabIndex = 1;
        lblOperation.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // btnOne
        // 
        btnOne.Location = new System.Drawing.Point(6, 60);
        btnOne.Name = "btnOne";
        btnOne.Size = new System.Drawing.Size(47, 40);
        btnOne.TabIndex = 2;
        btnOne.Text = "1";
        btnOne.UseVisualStyleBackColor = true;
        btnOne.Click += btnNumber_Click;
        // 
        // btnTwo
        // 
        btnTwo.Location = new System.Drawing.Point(59, 60);
        btnTwo.Name = "btnTwo";
        btnTwo.Size = new System.Drawing.Size(47, 40);
        btnTwo.TabIndex = 3;
        btnTwo.Text = "2";
        btnTwo.UseVisualStyleBackColor = true;
        btnTwo.Click += btnNumber_Click;
        // 
        // btnThree
        // 
        btnThree.Location = new System.Drawing.Point(112, 60);
        btnThree.Name = "btnThree";
        btnThree.Size = new System.Drawing.Size(47, 40);
        btnThree.TabIndex = 4;
        btnThree.Text = "3";
        btnThree.UseVisualStyleBackColor = true;
        btnThree.Click += btnNumber_Click;
        // 
        // btnFour
        // 
        btnFour.Location = new System.Drawing.Point(6, 106);
        btnFour.Name = "btnFour";
        btnFour.Size = new System.Drawing.Size(47, 40);
        btnFour.TabIndex = 5;
        btnFour.Text = "4";
        btnFour.UseVisualStyleBackColor = true;
        btnFour.Click += btnNumber_Click;
        // 
        // btnFive
        // 
        btnFive.Location = new System.Drawing.Point(59, 106);
        btnFive.Name = "btnFive";
        btnFive.Size = new System.Drawing.Size(47, 40);
        btnFive.TabIndex = 6;
        btnFive.Text = "5";
        btnFive.UseVisualStyleBackColor = true;
        btnFive.Click += btnNumber_Click;
        // 
        // btnSix
        // 
        btnSix.Location = new System.Drawing.Point(112, 106);
        btnSix.Name = "btnSix";
        btnSix.Size = new System.Drawing.Size(47, 40);
        btnSix.TabIndex = 7;
        btnSix.Text = "6";
        btnSix.UseVisualStyleBackColor = true;
        btnSix.Click += btnNumber_Click;
        // 
        // btnSeven
        // 
        btnSeven.Location = new System.Drawing.Point(6, 152);
        btnSeven.Name = "btnSeven";
        btnSeven.Size = new System.Drawing.Size(47, 40);
        btnSeven.TabIndex = 8;
        btnSeven.Text = "7";
        btnSeven.UseVisualStyleBackColor = true;
        btnSeven.Click += btnNumber_Click;
        // 
        // btnEight
        // 
        btnEight.Location = new System.Drawing.Point(59, 152);
        btnEight.Name = "btnEight";
        btnEight.Size = new System.Drawing.Size(47, 40);
        btnEight.TabIndex = 9;
        btnEight.Text = "8";
        btnEight.UseVisualStyleBackColor = true;
        btnEight.Click += btnNumber_Click;
        // 
        // btnNine
        // 
        btnNine.Location = new System.Drawing.Point(112, 152);
        btnNine.Name = "btnNine";
        btnNine.Size = new System.Drawing.Size(47, 40);
        btnNine.TabIndex = 10;
        btnNine.Text = "9";
        btnNine.UseVisualStyleBackColor = true;
        btnNine.Click += btnNumber_Click;
        // 
        // btnZero
        // 
        btnZero.Location = new System.Drawing.Point(59, 198);
        btnZero.Name = "btnZero";
        btnZero.Size = new System.Drawing.Size(47, 40);
        btnZero.TabIndex = 11;
        btnZero.Text = "0";
        btnZero.UseVisualStyleBackColor = true;
        btnZero.Click += btnNumber_Click;
        // 
        // btnClear
        // 
        btnClear.Location = new System.Drawing.Point(6, 198);
        btnClear.Name = "btnClear";
        btnClear.Size = new System.Drawing.Size(47, 40);
        btnClear.TabIndex = 12;
        btnClear.Text = "C";
        btnClear.UseVisualStyleBackColor = true;
        btnClear.Click += btnClear_Click;
        // 
        // btnEquals
        // 
        btnEquals.Location = new System.Drawing.Point(165, 14);
        btnEquals.Name = "btnEquals";
        btnEquals.Size = new System.Drawing.Size(47, 40);
        btnEquals.TabIndex = 13;
        btnEquals.Text = "=";
        btnEquals.UseVisualStyleBackColor = true;
        btnEquals.Click += btnEquals_Click;
        // 
        // btnPlus
        // 
        btnPlus.Location = new System.Drawing.Point(165, 60);
        btnPlus.Name = "btnPlus";
        btnPlus.Size = new System.Drawing.Size(47, 40);
        btnPlus.TabIndex = 14;
        btnPlus.Text = "+";
        btnPlus.UseVisualStyleBackColor = true;
        btnPlus.Click += btnOperator_Click;
        // 
        // btnMinus
        // 
        btnMinus.Location = new System.Drawing.Point(165, 106);
        btnMinus.Name = "btnMinus";
        btnMinus.Size = new System.Drawing.Size(47, 40);
        btnMinus.TabIndex = 15;
        btnMinus.Text = "-";
        btnMinus.UseVisualStyleBackColor = true;
        btnMinus.Click += btnOperator_Click;
        // 
        // btnMult
        // 
        btnMult.Location = new System.Drawing.Point(165, 152);
        btnMult.Name = "btnMult";
        btnMult.Size = new System.Drawing.Size(47, 40);
        btnMult.TabIndex = 16;
        btnMult.Text = "×";
        btnMult.UseVisualStyleBackColor = true;
        btnMult.Click += btnOperator_Click;
        // 
        // btnDiv
        // 
        btnDiv.Location = new System.Drawing.Point(165, 198);
        btnDiv.Name = "btnDiv";
        btnDiv.Size = new System.Drawing.Size(47, 40);
        btnDiv.TabIndex = 17;
        btnDiv.Text = "÷";
        btnDiv.UseVisualStyleBackColor = true;
        btnDiv.Click += btnOperator_Click;
        // 
        // btnDecimal
        // 
        btnDecimal.Location = new System.Drawing.Point(112, 198);
        btnDecimal.Name = "btnDecimal";
        btnDecimal.Size = new System.Drawing.Size(47, 40);
        btnDecimal.TabIndex = 18;
        btnDecimal.Text = ".";
        btnDecimal.UseVisualStyleBackColor = true;
        btnDecimal.Click += btnDecimal_Click;
        // 
        // CalculatorForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(218, 250);
        Controls.Add(btnDecimal);
        Controls.Add(btnDiv);
        Controls.Add(btnMult);
        Controls.Add(btnMinus);
        Controls.Add(btnPlus);
        Controls.Add(btnEquals);
        Controls.Add(btnClear);
        Controls.Add(btnZero);
        Controls.Add(btnNine);
        Controls.Add(btnEight);
        Controls.Add(btnSeven);
        Controls.Add(btnSix);
        Controls.Add(btnFive);
        Controls.Add(btnFour);
        Controls.Add(btnThree);
        Controls.Add(btnTwo);
        Controls.Add(btnOne);
        Controls.Add(lblOperation);
        Controls.Add(txtDisplay);
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button btnTwo;
    private System.Windows.Forms.Button btnThree;
    private System.Windows.Forms.Button btnFour;
    private System.Windows.Forms.Button btnFive;
    private System.Windows.Forms.Button btnSix;

    private System.Windows.Forms.Button btnPlus;
    private System.Windows.Forms.Button btnMinus;
    private System.Windows.Forms.Button btnMult;
    private System.Windows.Forms.Button btnDiv;
    private System.Windows.Forms.Button btnDecimal;
    private System.Windows.Forms.Button btnSeven;
    private System.Windows.Forms.Button btnEight;
    private System.Windows.Forms.Button btnNine;
    private System.Windows.Forms.Button btnZero;
    private System.Windows.Forms.Button btnClear;
    private System.Windows.Forms.Button btnEquals;

    private System.Windows.Forms.TextBox txtDisplay;
    private System.Windows.Forms.Label lblOperation;
    private System.Windows.Forms.Button btnOne;

    #endregion
}