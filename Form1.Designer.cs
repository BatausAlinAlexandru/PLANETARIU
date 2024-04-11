namespace LAB2
{
    partial class Form1
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
            this.dataGridViewParent = new System.Windows.Forms.DataGridView();
            this.dataGridViewChild = new System.Windows.Forms.DataGridView();
            this.labelParentName = new System.Windows.Forms.Label();
            this.labelChildName = new System.Windows.Forms.Label();
            this.panelFlowLayoutPanelParent = new System.Windows.Forms.Panel();
            this.flowLayoutPanelParent = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelChild = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonAddParent = new System.Windows.Forms.Button();
            this.buttonUpdateParent = new System.Windows.Forms.Button();
            this.buttonDeleteParent = new System.Windows.Forms.Button();
            this.buttonDeleteChild = new System.Windows.Forms.Button();
            this.buttonUpdateChild = new System.Windows.Forms.Button();
            this.buttonAddChild = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewChild)).BeginInit();
            this.panelFlowLayoutPanelParent.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewParent
            // 
            this.dataGridViewParent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewParent.Location = new System.Drawing.Point(12, 42);
            this.dataGridViewParent.Name = "dataGridViewParent";
            this.dataGridViewParent.Size = new System.Drawing.Size(478, 195);
            this.dataGridViewParent.TabIndex = 0;
            this.dataGridViewParent.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewParent_CellClick);
            // 
            // dataGridViewChild
            // 
            this.dataGridViewChild.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewChild.Location = new System.Drawing.Point(696, 42);
            this.dataGridViewChild.Name = "dataGridViewChild";
            this.dataGridViewChild.Size = new System.Drawing.Size(478, 195);
            this.dataGridViewChild.TabIndex = 1;
            this.dataGridViewChild.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewChild_CellClick);
            // 
            // labelParentName
            // 
            this.labelParentName.AutoSize = true;
            this.labelParentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelParentName.Location = new System.Drawing.Point(192, 8);
            this.labelParentName.Name = "labelParentName";
            this.labelParentName.Size = new System.Drawing.Size(0, 31);
            this.labelParentName.TabIndex = 2;
            // 
            // labelChildName
            // 
            this.labelChildName.AutoSize = true;
            this.labelChildName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChildName.Location = new System.Drawing.Point(894, 8);
            this.labelChildName.Name = "labelChildName";
            this.labelChildName.Size = new System.Drawing.Size(0, 31);
            this.labelChildName.TabIndex = 3;
            // 
            // panelFlowLayoutPanelParent
            // 
            this.panelFlowLayoutPanelParent.Controls.Add(this.flowLayoutPanelParent);
            this.panelFlowLayoutPanelParent.Location = new System.Drawing.Point(13, 269);
            this.panelFlowLayoutPanelParent.Name = "panelFlowLayoutPanelParent";
            this.panelFlowLayoutPanelParent.Size = new System.Drawing.Size(477, 326);
            this.panelFlowLayoutPanelParent.TabIndex = 4;
            // 
            // flowLayoutPanelParent
            // 
            this.flowLayoutPanelParent.AutoScroll = true;
            this.flowLayoutPanelParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelParent.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelParent.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelParent.Name = "flowLayoutPanelParent";
            this.flowLayoutPanelParent.Size = new System.Drawing.Size(477, 326);
            this.flowLayoutPanelParent.TabIndex = 0;
            this.flowLayoutPanelParent.WrapContents = false;
            // 
            // flowLayoutPanelChild
            // 
            this.flowLayoutPanelChild.AutoScroll = true;
            this.flowLayoutPanelChild.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelChild.Location = new System.Drawing.Point(696, 269);
            this.flowLayoutPanelChild.Name = "flowLayoutPanelChild";
            this.flowLayoutPanelChild.Size = new System.Drawing.Size(478, 326);
            this.flowLayoutPanelChild.TabIndex = 5;
            this.flowLayoutPanelChild.WrapContents = false;
            // 
            // buttonAddParent
            // 
            this.buttonAddParent.Location = new System.Drawing.Point(13, 627);
            this.buttonAddParent.Name = "buttonAddParent";
            this.buttonAddParent.Size = new System.Drawing.Size(136, 55);
            this.buttonAddParent.TabIndex = 6;
            this.buttonAddParent.Text = "ADAUGA";
            this.buttonAddParent.UseVisualStyleBackColor = true;
            this.buttonAddParent.Click += new System.EventHandler(this.buttonAddParent_Click);
            // 
            // buttonUpdateParent
            // 
            this.buttonUpdateParent.Location = new System.Drawing.Point(155, 627);
            this.buttonUpdateParent.Name = "buttonUpdateParent";
            this.buttonUpdateParent.Size = new System.Drawing.Size(136, 55);
            this.buttonUpdateParent.TabIndex = 7;
            this.buttonUpdateParent.Text = "UPDATE";
            this.buttonUpdateParent.UseVisualStyleBackColor = true;
            this.buttonUpdateParent.Click += new System.EventHandler(this.buttonUpdateParent_Click);
            // 
            // buttonDeleteParent
            // 
            this.buttonDeleteParent.Location = new System.Drawing.Point(297, 627);
            this.buttonDeleteParent.Name = "buttonDeleteParent";
            this.buttonDeleteParent.Size = new System.Drawing.Size(136, 55);
            this.buttonDeleteParent.TabIndex = 8;
            this.buttonDeleteParent.Text = "DELETE";
            this.buttonDeleteParent.UseVisualStyleBackColor = true;
            this.buttonDeleteParent.Click += new System.EventHandler(this.buttonDeleteParent_Click);
            // 
            // buttonDeleteChild
            // 
            this.buttonDeleteChild.Location = new System.Drawing.Point(980, 627);
            this.buttonDeleteChild.Name = "buttonDeleteChild";
            this.buttonDeleteChild.Size = new System.Drawing.Size(136, 55);
            this.buttonDeleteChild.TabIndex = 11;
            this.buttonDeleteChild.Text = "DELETE";
            this.buttonDeleteChild.UseVisualStyleBackColor = true;
            this.buttonDeleteChild.Click += new System.EventHandler(this.buttonDeleteChild_Click);
            // 
            // buttonUpdateChild
            // 
            this.buttonUpdateChild.Location = new System.Drawing.Point(838, 627);
            this.buttonUpdateChild.Name = "buttonUpdateChild";
            this.buttonUpdateChild.Size = new System.Drawing.Size(136, 55);
            this.buttonUpdateChild.TabIndex = 10;
            this.buttonUpdateChild.Text = "UPDATE";
            this.buttonUpdateChild.UseVisualStyleBackColor = true;
            this.buttonUpdateChild.Click += new System.EventHandler(this.buttonUpdateChild_Click);
            // 
            // buttonAddChild
            // 
            this.buttonAddChild.Location = new System.Drawing.Point(696, 627);
            this.buttonAddChild.Name = "buttonAddChild";
            this.buttonAddChild.Size = new System.Drawing.Size(136, 55);
            this.buttonAddChild.TabIndex = 9;
            this.buttonAddChild.Text = "ADAUGA";
            this.buttonAddChild.UseVisualStyleBackColor = true;
            this.buttonAddChild.Click += new System.EventHandler(this.buttonAddChild_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 694);
            this.Controls.Add(this.buttonDeleteChild);
            this.Controls.Add(this.buttonUpdateChild);
            this.Controls.Add(this.buttonAddChild);
            this.Controls.Add(this.buttonDeleteParent);
            this.Controls.Add(this.buttonUpdateParent);
            this.Controls.Add(this.buttonAddParent);
            this.Controls.Add(this.flowLayoutPanelChild);
            this.Controls.Add(this.panelFlowLayoutPanelParent);
            this.Controls.Add(this.labelChildName);
            this.Controls.Add(this.labelParentName);
            this.Controls.Add(this.dataGridViewChild);
            this.Controls.Add(this.dataGridViewParent);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewChild)).EndInit();
            this.panelFlowLayoutPanelParent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewParent;
        private System.Windows.Forms.DataGridView dataGridViewChild;
        private System.Windows.Forms.Label labelParentName;
        private System.Windows.Forms.Label labelChildName;
        private System.Windows.Forms.Panel panelFlowLayoutPanelParent;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelParent;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelChild;
        private System.Windows.Forms.Button buttonAddParent;
        private System.Windows.Forms.Button buttonUpdateParent;
        private System.Windows.Forms.Button buttonDeleteParent;
        private System.Windows.Forms.Button buttonDeleteChild;
        private System.Windows.Forms.Button buttonUpdateChild;
        private System.Windows.Forms.Button buttonAddChild;
    }
}

