namespace Life
{
    partial class LifeUI
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
            this.components = new System.ComponentModel.Container();
            this.controlsUI = new System.Windows.Forms.GroupBox();
            this.generationUI = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.clearUI = new System.Windows.Forms.Button();
            this.stopUI = new System.Windows.Forms.Button();
            this.startUI = new System.Windows.Forms.Button();
            this.gridUI = new System.Windows.Forms.GroupBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.controlsUI.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlsUI
            // 
            this.controlsUI.Controls.Add(this.generationUI);
            this.controlsUI.Controls.Add(this.label1);
            this.controlsUI.Controls.Add(this.clearUI);
            this.controlsUI.Controls.Add(this.stopUI);
            this.controlsUI.Controls.Add(this.startUI);
            this.controlsUI.Location = new System.Drawing.Point(12, 12);
            this.controlsUI.Name = "controlsUI";
            this.controlsUI.Size = new System.Drawing.Size(450, 50);
            this.controlsUI.TabIndex = 0;
            this.controlsUI.TabStop = false;
            // 
            // generationUI
            // 
            this.generationUI.Location = new System.Drawing.Point(348, 24);
            this.generationUI.Name = "generationUI";
            this.generationUI.ReadOnly = true;
            this.generationUI.Size = new System.Drawing.Size(96, 20);
            this.generationUI.TabIndex = 4;
            this.generationUI.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(345, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Current Generation:";
            // 
            // clearUI
            // 
            this.clearUI.Location = new System.Drawing.Point(218, 10);
            this.clearUI.Name = "clearUI";
            this.clearUI.Size = new System.Drawing.Size(100, 34);
            this.clearUI.TabIndex = 2;
            this.clearUI.Text = "Clear";
            this.clearUI.UseVisualStyleBackColor = true;
            this.clearUI.Click += new System.EventHandler(this.clearUI_Click);
            // 
            // stopUI
            // 
            this.stopUI.Location = new System.Drawing.Point(112, 10);
            this.stopUI.Name = "stopUI";
            this.stopUI.Size = new System.Drawing.Size(100, 34);
            this.stopUI.TabIndex = 1;
            this.stopUI.Text = "Stop";
            this.stopUI.UseVisualStyleBackColor = true;
            this.stopUI.Click += new System.EventHandler(this.stopUI_Click);
            // 
            // startUI
            // 
            this.startUI.Location = new System.Drawing.Point(6, 10);
            this.startUI.Name = "startUI";
            this.startUI.Size = new System.Drawing.Size(100, 34);
            this.startUI.TabIndex = 0;
            this.startUI.Text = "Start";
            this.startUI.UseVisualStyleBackColor = true;
            this.startUI.Click += new System.EventHandler(this.startUI_Click);
            // 
            // gridUI
            // 
            this.gridUI.Location = new System.Drawing.Point(12, 68);
            this.gridUI.Name = "gridUI";
            this.gridUI.Size = new System.Drawing.Size(450, 450);
            this.gridUI.TabIndex = 1;
            this.gridUI.TabStop = false;
            // 
            // timer
            // 
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // LifeUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(474, 531);
            this.Controls.Add(this.gridUI);
            this.Controls.Add(this.controlsUI);
            this.MaximumSize = new System.Drawing.Size(490, 570);
            this.MinimumSize = new System.Drawing.Size(490, 570);
            this.Name = "LifeUI";
            this.Text = "Conway\'s Game of Life";
            this.Load += new System.EventHandler(this.LifeUI_Load);
            this.controlsUI.ResumeLayout(false);
            this.controlsUI.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox controlsUI;
        private System.Windows.Forms.GroupBox gridUI;
        private System.Windows.Forms.Button clearUI;
        private System.Windows.Forms.Button stopUI;
        private System.Windows.Forms.Button startUI;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox generationUI;
        private System.Windows.Forms.Label label1;
    }
}

