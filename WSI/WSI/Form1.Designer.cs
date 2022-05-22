
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
            this.endCheckingSolutionButton = new System.Windows.Forms.Button();
            this.evolutionUsedIterationsLabel = new System.Windows.Forms.Label();
            this.geneticUsedIterationsLabel = new System.Windows.Forms.Label();
            this.stepLabel = new System.Windows.Forms.Label();
            this.rightStepButton = new System.Windows.Forms.Button();
            this.leftStepButton = new System.Windows.Forms.Button();
            this.selectedSolutionLabel = new System.Windows.Forms.Label();
            this.evolutionResultSelectionButton = new System.Windows.Forms.Button();
            this.geneticResultSelectButton = new System.Windows.Forms.Button();
            this.iterationLabel = new System.Windows.Forms.Label();
            this.simulationLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.upButton = new System.Windows.Forms.Button();
            this.leftButton = new System.Windows.Forms.Button();
            this.rightButton = new System.Windows.Forms.Button();
            this.shuffleButton = new System.Windows.Forms.Button();
            this.BoardSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.boardSizeLabel = new System.Windows.Forms.Label();
            this.maxNumberOfIterationsLabel = new System.Windows.Forms.Label();
            this.maxNumberOfIterationsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.algorithmComboBox = new System.Windows.Forms.GroupBox();
            this.bothAlgorithmsRadioButton = new System.Windows.Forms.RadioButton();
            this.evolutionAlgorithmRadioButton = new System.Windows.Forms.RadioButton();
            this.geneticAlgorithmRadioButton = new System.Windows.Forms.RadioButton();
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
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
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
            this.splitContainer1.Size = new System.Drawing.Size(1142, 702);
            this.splitContainer1.SplitterDistance = 747;
            this.splitContainer1.TabIndex = 0;
            // 
            // boardPictureBox
            // 
            this.boardPictureBox.BackColor = System.Drawing.Color.White;
            this.boardPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boardPictureBox.Location = new System.Drawing.Point(0, 0);
            this.boardPictureBox.Name = "boardPictureBox";
            this.boardPictureBox.Size = new System.Drawing.Size(747, 702);
            this.boardPictureBox.TabIndex = 0;
            this.boardPictureBox.TabStop = false;
            this.boardPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.boardPictureBox_Paint);
            // 
            // optionsPanel
            // 
            this.optionsPanel.Controls.Add(this.endCheckingSolutionButton);
            this.optionsPanel.Controls.Add(this.evolutionUsedIterationsLabel);
            this.optionsPanel.Controls.Add(this.geneticUsedIterationsLabel);
            this.optionsPanel.Controls.Add(this.stepLabel);
            this.optionsPanel.Controls.Add(this.rightStepButton);
            this.optionsPanel.Controls.Add(this.leftStepButton);
            this.optionsPanel.Controls.Add(this.selectedSolutionLabel);
            this.optionsPanel.Controls.Add(this.evolutionResultSelectionButton);
            this.optionsPanel.Controls.Add(this.geneticResultSelectButton);
            this.optionsPanel.Controls.Add(this.iterationLabel);
            this.optionsPanel.Controls.Add(this.simulationLabel);
            this.optionsPanel.Controls.Add(this.startButton);
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
            this.optionsPanel.Size = new System.Drawing.Size(391, 702);
            this.optionsPanel.TabIndex = 0;
            // 
            // endCheckingSolutionButton
            // 
            this.endCheckingSolutionButton.Enabled = false;
            this.endCheckingSolutionButton.Location = new System.Drawing.Point(10, 427);
            this.endCheckingSolutionButton.Name = "endCheckingSolutionButton";
            this.endCheckingSolutionButton.Size = new System.Drawing.Size(187, 23);
            this.endCheckingSolutionButton.TabIndex = 23;
            this.endCheckingSolutionButton.Text = "End checking solution";
            this.endCheckingSolutionButton.UseVisualStyleBackColor = true;
            this.endCheckingSolutionButton.Click += new System.EventHandler(this.endCheckingSolutionButton_Click);
            // 
            // evolutionUsedIterationsLabel
            // 
            this.evolutionUsedIterationsLabel.AutoSize = true;
            this.evolutionUsedIterationsLabel.Location = new System.Drawing.Point(162, 515);
            this.evolutionUsedIterationsLabel.Name = "evolutionUsedIterationsLabel";
            this.evolutionUsedIterationsLabel.Size = new System.Drawing.Size(88, 15);
            this.evolutionUsedIterationsLabel.TabIndex = 22;
            this.evolutionUsedIterationsLabel.Text = "Used iterations:";
            // 
            // geneticUsedIterationsLabel
            // 
            this.geneticUsedIterationsLabel.AutoSize = true;
            this.geneticUsedIterationsLabel.Location = new System.Drawing.Point(10, 515);
            this.geneticUsedIterationsLabel.Name = "geneticUsedIterationsLabel";
            this.geneticUsedIterationsLabel.Size = new System.Drawing.Size(88, 15);
            this.geneticUsedIterationsLabel.TabIndex = 21;
            this.geneticUsedIterationsLabel.Text = "Used iterations:";
            // 
            // stepLabel
            // 
            this.stepLabel.AutoSize = true;
            this.stepLabel.Location = new System.Drawing.Point(63, 618);
            this.stepLabel.Name = "stepLabel";
            this.stepLabel.Size = new System.Drawing.Size(50, 15);
            this.stepLabel.TabIndex = 20;
            this.stepLabel.Text = "Step 0/0";
            // 
            // rightStepButton
            // 
            this.rightStepButton.Enabled = false;
            this.rightStepButton.Location = new System.Drawing.Point(140, 648);
            this.rightStepButton.Name = "rightStepButton";
            this.rightStepButton.Size = new System.Drawing.Size(32, 30);
            this.rightStepButton.TabIndex = 19;
            this.rightStepButton.Text = ">";
            this.rightStepButton.UseVisualStyleBackColor = true;
            this.rightStepButton.Click += new System.EventHandler(this.rightStepButton_Click);
            // 
            // leftStepButton
            // 
            this.leftStepButton.Enabled = false;
            this.leftStepButton.Location = new System.Drawing.Point(10, 648);
            this.leftStepButton.Name = "leftStepButton";
            this.leftStepButton.Size = new System.Drawing.Size(30, 30);
            this.leftStepButton.TabIndex = 18;
            this.leftStepButton.Text = "<";
            this.leftStepButton.UseVisualStyleBackColor = true;
            this.leftStepButton.Click += new System.EventHandler(this.leftStepButton_Click);
            // 
            // selectedSolutionLabel
            // 
            this.selectedSolutionLabel.AutoSize = true;
            this.selectedSolutionLabel.Location = new System.Drawing.Point(10, 458);
            this.selectedSolutionLabel.Name = "selectedSolutionLabel";
            this.selectedSolutionLabel.Size = new System.Drawing.Size(103, 15);
            this.selectedSolutionLabel.TabIndex = 17;
            this.selectedSolutionLabel.Text = "Selected solution: ";
            // 
            // evolutionResultSelectionButton
            // 
            this.evolutionResultSelectionButton.Enabled = false;
            this.evolutionResultSelectionButton.Location = new System.Drawing.Point(162, 485);
            this.evolutionResultSelectionButton.Name = "evolutionResultSelectionButton";
            this.evolutionResultSelectionButton.Size = new System.Drawing.Size(75, 23);
            this.evolutionResultSelectionButton.TabIndex = 16;
            this.evolutionResultSelectionButton.Text = "Evolution";
            this.evolutionResultSelectionButton.UseVisualStyleBackColor = true;
            this.evolutionResultSelectionButton.Click += new System.EventHandler(this.evolutionResultSelectionButton_Click);
            // 
            // geneticResultSelectButton
            // 
            this.geneticResultSelectButton.Enabled = false;
            this.geneticResultSelectButton.Location = new System.Drawing.Point(10, 485);
            this.geneticResultSelectButton.Name = "geneticResultSelectButton";
            this.geneticResultSelectButton.Size = new System.Drawing.Size(75, 23);
            this.geneticResultSelectButton.TabIndex = 15;
            this.geneticResultSelectButton.Text = "Genetic";
            this.geneticResultSelectButton.UseVisualStyleBackColor = true;
            this.geneticResultSelectButton.Click += new System.EventHandler(this.geneticResultSelectButton_Click);
            // 
            // iterationLabel
            // 
            this.iterationLabel.AutoSize = true;
            this.iterationLabel.Location = new System.Drawing.Point(10, 399);
            this.iterationLabel.Name = "iterationLabel";
            this.iterationLabel.Size = new System.Drawing.Size(97, 15);
            this.iterationLabel.TabIndex = 13;
            this.iterationLabel.Text = "Iterations: 0/100";
            // 
            // simulationLabel
            // 
            this.simulationLabel.AutoSize = true;
            this.simulationLabel.Location = new System.Drawing.Point(10, 351);
            this.simulationLabel.Name = "simulationLabel";
            this.simulationLabel.Size = new System.Drawing.Size(64, 15);
            this.simulationLabel.TabIndex = 12;
            this.simulationLabel.Text = "Simulation";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(10, 369);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(187, 23);
            this.startButton.TabIndex = 11;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
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
            100,
            0,
            0,
            0});
            this.maxNumberOfIterationsNumericUpDown.ValueChanged += new System.EventHandler(this.maxNumberOfIterationsNumericUpDown_ValueChanged);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 702);
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
        private System.Windows.Forms.Label iterationLabel;
        private System.Windows.Forms.Label simulationLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button evolutionResultSelectionButton;
        private System.Windows.Forms.Button geneticResultSelectButton;
        private System.Windows.Forms.Label selectedSolutionLabel;
        private System.Windows.Forms.Label stepLabel;
        private System.Windows.Forms.Button rightStepButton;
        private System.Windows.Forms.Button leftStepButton;
        private System.Windows.Forms.Label evolutionUsedIterationsLabel;
        private System.Windows.Forms.Label geneticUsedIterationsLabel;
        private System.Windows.Forms.Button endCheckingSolutionButton;
    }
}

