﻿
namespace WSI
{
    partial class Form1
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.boardPictureBox = new System.Windows.Forms.PictureBox();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.shuffleButton = new System.Windows.Forms.Button();
            this.BoardSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.boardSizeLabel = new System.Windows.Forms.Label();
            this.maxNumberOfIterationsLabel = new System.Windows.Forms.Label();
            this.maxNumberOfIterationsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.algorithmComboBox = new System.Windows.Forms.GroupBox();
            this.bothAlgorithmsRadioButton = new System.Windows.Forms.RadioButton();
            this.evolutionAlgorithmRadioButton = new System.Windows.Forms.RadioButton();
            this.geneticAlgorithmRadioButton = new System.Windows.Forms.RadioButton();
            this.rightButton = new System.Windows.Forms.Button();
            this.leftButton = new System.Windows.Forms.Button();
            this.upButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boardPictureBox)).BeginInit();
            this.optionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoardSizeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxNumberOfIterationsNumericUpDown)).BeginInit();
            this.algorithmComboBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.boardPictureBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.optionsPanel);
            this.splitContainer1.Size = new System.Drawing.Size(1150, 702);
            this.splitContainer1.SplitterDistance = 642;
            this.splitContainer1.TabIndex = 0;
            // 
            // boardPictureBox
            // 
            this.boardPictureBox.BackColor = System.Drawing.Color.White;
            this.boardPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boardPictureBox.Location = new System.Drawing.Point(0, 0);
            this.boardPictureBox.Name = "boardPictureBox";
            this.boardPictureBox.Size = new System.Drawing.Size(642, 702);
            this.boardPictureBox.TabIndex = 0;
            this.boardPictureBox.TabStop = false;
            this.boardPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.boardPictureBox_Paint);
            // 
            // optionsPanel
            // 
            this.optionsPanel.Controls.Add(this.downButton);
            this.optionsPanel.Controls.Add(this.upButton);
            this.optionsPanel.Controls.Add(this.leftButton);
            this.optionsPanel.Controls.Add(this.rightButton);
            this.optionsPanel.Controls.Add(this.shuffleButton);
            this.optionsPanel.Controls.Add(this.BoardSizeNumericUpDown);
            this.optionsPanel.Controls.Add(this.boardSizeLabel);
            this.optionsPanel.Controls.Add(this.maxNumberOfIterationsLabel);
            this.optionsPanel.Controls.Add(this.maxNumberOfIterationsNumericUpDown);
            this.optionsPanel.Controls.Add(this.algorithmComboBox);
            this.optionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsPanel.Location = new System.Drawing.Point(0, 0);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(504, 702);
            this.optionsPanel.TabIndex = 0;
            // 
            // shuffleButton
            // 
            this.shuffleButton.Location = new System.Drawing.Point(10, 209);
            this.shuffleButton.Name = "shuffleButton";
            this.shuffleButton.Size = new System.Drawing.Size(75, 23);
            this.shuffleButton.TabIndex = 6;
            this.shuffleButton.Text = "Shuffle";
            this.shuffleButton.UseVisualStyleBackColor = true;
            this.shuffleButton.Click += new System.EventHandler(this.shuffleButton_Click);
            // 
            // BoardSizeNumericUpDown
            // 
            this.BoardSizeNumericUpDown.Location = new System.Drawing.Point(10, 179);
            this.BoardSizeNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.BoardSizeNumericUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.BoardSizeNumericUpDown.Name = "BoardSizeNumericUpDown";
            this.BoardSizeNumericUpDown.Size = new System.Drawing.Size(60, 23);
            this.BoardSizeNumericUpDown.TabIndex = 5;
            this.BoardSizeNumericUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.BoardSizeNumericUpDown.ValueChanged += new System.EventHandler(this.BoardSizeNumericUpDown_ValueChanged);
            // 
            // boardSizeLabel
            // 
            this.boardSizeLabel.AutoSize = true;
            this.boardSizeLabel.Location = new System.Drawing.Point(10, 161);
            this.boardSizeLabel.Name = "boardSizeLabel";
            this.boardSizeLabel.Size = new System.Drawing.Size(60, 15);
            this.boardSizeLabel.TabIndex = 3;
            this.boardSizeLabel.Text = "Board size";
            // 
            // maxNumberOfIterationsLabel
            // 
            this.maxNumberOfIterationsLabel.AutoSize = true;
            this.maxNumberOfIterationsLabel.Location = new System.Drawing.Point(10, 113);
            this.maxNumberOfIterationsLabel.Name = "maxNumberOfIterationsLabel";
            this.maxNumberOfIterationsLabel.Size = new System.Drawing.Size(173, 15);
            this.maxNumberOfIterationsLabel.TabIndex = 2;
            this.maxNumberOfIterationsLabel.Text = "Maximum number of iterations";
            // 
            // maxNumberOfIterationsNumericUpDown
            // 
            this.maxNumberOfIterationsNumericUpDown.Location = new System.Drawing.Point(10, 131);
            this.maxNumberOfIterationsNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.maxNumberOfIterationsNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxNumberOfIterationsNumericUpDown.Name = "maxNumberOfIterationsNumericUpDown";
            this.maxNumberOfIterationsNumericUpDown.Size = new System.Drawing.Size(120, 23);
            this.maxNumberOfIterationsNumericUpDown.TabIndex = 1;
            this.maxNumberOfIterationsNumericUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // algorithmComboBox
            // 
            this.algorithmComboBox.Controls.Add(this.bothAlgorithmsRadioButton);
            this.algorithmComboBox.Controls.Add(this.evolutionAlgorithmRadioButton);
            this.algorithmComboBox.Controls.Add(this.geneticAlgorithmRadioButton);
            this.algorithmComboBox.Location = new System.Drawing.Point(3, 12);
            this.algorithmComboBox.Name = "algorithmComboBox";
            this.algorithmComboBox.Size = new System.Drawing.Size(144, 100);
            this.algorithmComboBox.TabIndex = 0;
            this.algorithmComboBox.TabStop = false;
            this.algorithmComboBox.Text = "Choose algorithm";
            // 
            // bothAlgorithmsRadioButton
            // 
            this.bothAlgorithmsRadioButton.AutoSize = true;
            this.bothAlgorithmsRadioButton.Location = new System.Drawing.Point(7, 75);
            this.bothAlgorithmsRadioButton.Name = "bothAlgorithmsRadioButton";
            this.bothAlgorithmsRadioButton.Size = new System.Drawing.Size(50, 19);
            this.bothAlgorithmsRadioButton.TabIndex = 2;
            this.bothAlgorithmsRadioButton.TabStop = true;
            this.bothAlgorithmsRadioButton.Text = "Both";
            this.bothAlgorithmsRadioButton.UseVisualStyleBackColor = true;
            // 
            // evolutionAlgorithmRadioButton
            // 
            this.evolutionAlgorithmRadioButton.AutoSize = true;
            this.evolutionAlgorithmRadioButton.Location = new System.Drawing.Point(7, 49);
            this.evolutionAlgorithmRadioButton.Name = "evolutionAlgorithmRadioButton";
            this.evolutionAlgorithmRadioButton.Size = new System.Drawing.Size(75, 19);
            this.evolutionAlgorithmRadioButton.TabIndex = 1;
            this.evolutionAlgorithmRadioButton.Text = "Evolution";
            this.evolutionAlgorithmRadioButton.UseVisualStyleBackColor = true;
            // 
            // geneticAlgorithmRadioButton
            // 
            this.geneticAlgorithmRadioButton.AutoSize = true;
            this.geneticAlgorithmRadioButton.Checked = true;
            this.geneticAlgorithmRadioButton.Location = new System.Drawing.Point(7, 23);
            this.geneticAlgorithmRadioButton.Name = "geneticAlgorithmRadioButton";
            this.geneticAlgorithmRadioButton.Size = new System.Drawing.Size(64, 22);
            this.geneticAlgorithmRadioButton.TabIndex = 0;
            this.geneticAlgorithmRadioButton.TabStop = true;
            this.geneticAlgorithmRadioButton.Text = "Genetic";
            this.geneticAlgorithmRadioButton.UseCompatibleTextRendering = true;
            this.geneticAlgorithmRadioButton.UseVisualStyleBackColor = true;
            // 
            // rightButton
            // 
            this.rightButton.Location = new System.Drawing.Point(122, 294);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(50, 50);
            this.rightButton.TabIndex = 7;
            this.rightButton.Text = "Right";
            this.rightButton.UseVisualStyleBackColor = true;
            this.rightButton.Click += new System.EventHandler(this.rightButton_Click);
            // 
            // leftButton
            // 
            this.leftButton.Location = new System.Drawing.Point(10, 294);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(50, 50);
            this.leftButton.TabIndex = 8;
            this.leftButton.Text = "Left";
            this.leftButton.UseVisualStyleBackColor = true;
            this.leftButton.Click += new System.EventHandler(this.leftButton_Click);
            // 
            // upButton
            // 
            this.upButton.Location = new System.Drawing.Point(66, 238);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(50, 50);
            this.upButton.TabIndex = 9;
            this.upButton.Text = "Up";
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // downButton
            // 
            this.downButton.Location = new System.Drawing.Point(66, 294);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(50, 50);
            this.downButton.TabIndex = 10;
            this.downButton.Text = "Down";
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 702);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.boardPictureBox)).EndInit();
            this.optionsPanel.ResumeLayout(false);
            this.optionsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoardSizeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxNumberOfIterationsNumericUpDown)).EndInit();
            this.algorithmComboBox.ResumeLayout(false);
            this.algorithmComboBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox boardPictureBox;
        private System.Windows.Forms.Panel optionsPanel;
        private System.Windows.Forms.NumericUpDown BoardSizeNumericUpDown;
        private System.Windows.Forms.Label boardSizeLabel;
        private System.Windows.Forms.Label maxNumberOfIterationsLabel;
        private System.Windows.Forms.NumericUpDown maxNumberOfIterationsNumericUpDown;
        private System.Windows.Forms.GroupBox algorithmComboBox;
        private System.Windows.Forms.RadioButton bothAlgorithmsRadioButton;
        private System.Windows.Forms.RadioButton evolutionAlgorithmRadioButton;
        private System.Windows.Forms.RadioButton geneticAlgorithmRadioButton;
        private System.Windows.Forms.Button shuffleButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button rightButton;
    }
}

