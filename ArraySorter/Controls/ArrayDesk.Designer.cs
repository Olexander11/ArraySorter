using System;

namespace ArraySorter
{
    partial class ArrayDesk
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
            this.sortingProcessLabel = new System.Windows.Forms.Label();
            this.selectMethodLabel = new System.Windows.Forms.Label();
            this.arraySourcePanel = new System.Windows.Forms.Panel();
            this.arrayTabControl = new System.Windows.Forms.TabControl();
            this.sortingTabPage = new System.Windows.Forms.TabPage();
            this.methodGroupBox = new System.Windows.Forms.GroupBox();
            this.sortMethodComboBox = new System.Windows.Forms.ComboBox();
            this.orderComboBox = new System.Windows.Forms.ComboBox();
            this.orderArrayLabel = new System.Windows.Forms.Label();
            this.confirmMethodButton = new System.Windows.Forms.Button();
            this.createGroupBox = new System.Windows.Forms.GroupBox();
            this.fileRadioButton = new System.Windows.Forms.RadioButton();
            this.ramdomRadioButton = new System.Windows.Forms.RadioButton();
            this.processPanel = new System.Windows.Forms.Panel();
            this.processGridView = new System.Windows.Forms.DataGridView();
            this.speedDownButton = new System.Windows.Forms.Button();
            this.speedUpButton = new System.Windows.Forms.Button();
            this.startSortingButton = new System.Windows.Forms.Button();
            this.historytabPage = new System.Windows.Forms.TabPage();
            this.updateHistoryButton = new System.Windows.Forms.Button();
            this.sortButton = new System.Windows.Forms.Button();
            this.sortingProcessDataGridView = new System.Windows.Forms.DataGridView();
            this.pauseButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.arrayTabControl.SuspendLayout();
            this.sortingTabPage.SuspendLayout();
            this.methodGroupBox.SuspendLayout();
            this.createGroupBox.SuspendLayout();
            this.processPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.processGridView)).BeginInit();
            this.historytabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sortingProcessDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // sortingProcessLabel
            // 
            this.sortingProcessLabel.AutoSize = true;
            this.sortingProcessLabel.Location = new System.Drawing.Point(253, 16);
            this.sortingProcessLabel.Name = "sortingProcessLabel";
            this.sortingProcessLabel.Size = new System.Drawing.Size(102, 16);
            this.sortingProcessLabel.TabIndex = 3;
            this.sortingProcessLabel.Text = "Sorting Process";
            // 
            // selectMethodLabel
            // 
            this.selectMethodLabel.AutoSize = true;
            this.selectMethodLabel.Location = new System.Drawing.Point(15, 18);
            this.selectMethodLabel.Name = "selectMethodLabel";
            this.selectMethodLabel.Size = new System.Drawing.Size(89, 16);
            this.selectMethodLabel.TabIndex = 6;
            this.selectMethodLabel.Text = "Sort algorithm";
            // 
            // arraySourcePanel
            // 
            this.arraySourcePanel.Location = new System.Drawing.Point(6, 42);
            this.arraySourcePanel.Name = "arraySourcePanel";
            this.arraySourcePanel.Size = new System.Drawing.Size(232, 111);
            this.arraySourcePanel.TabIndex = 7;
            // 
            // arrayTabControl
            // 
            this.arrayTabControl.Controls.Add(this.sortingTabPage);
            this.arrayTabControl.Controls.Add(this.historytabPage);
            this.arrayTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.arrayTabControl.Location = new System.Drawing.Point(0, 0);
            this.arrayTabControl.Name = "arrayTabControl";
            this.arrayTabControl.SelectedIndex = 0;
            this.arrayTabControl.Size = new System.Drawing.Size(1227, 524);
            this.arrayTabControl.TabIndex = 8;
            // 
            // sortingTabPage
            // 
            this.sortingTabPage.Controls.Add(this.stopButton);
            this.sortingTabPage.Controls.Add(this.pauseButton);
            this.sortingTabPage.Controls.Add(this.methodGroupBox);
            this.sortingTabPage.Controls.Add(this.createGroupBox);
            this.sortingTabPage.Controls.Add(this.processPanel);
            this.sortingTabPage.Controls.Add(this.speedDownButton);
            this.sortingTabPage.Controls.Add(this.speedUpButton);
            this.sortingTabPage.Controls.Add(this.startSortingButton);
            this.sortingTabPage.Controls.Add(this.sortingProcessLabel);
            this.sortingTabPage.Location = new System.Drawing.Point(4, 25);
            this.sortingTabPage.Name = "sortingTabPage";
            this.sortingTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.sortingTabPage.Size = new System.Drawing.Size(1219, 495);
            this.sortingTabPage.TabIndex = 0;
            this.sortingTabPage.Text = "Sorting";
            this.sortingTabPage.UseVisualStyleBackColor = true;
            // 
            // methodGroupBox
            // 
            this.methodGroupBox.Controls.Add(this.selectMethodLabel);
            this.methodGroupBox.Controls.Add(this.sortMethodComboBox);
            this.methodGroupBox.Controls.Add(this.orderComboBox);
            this.methodGroupBox.Controls.Add(this.orderArrayLabel);
            this.methodGroupBox.Controls.Add(this.confirmMethodButton);
            this.methodGroupBox.Location = new System.Drawing.Point(6, 204);
            this.methodGroupBox.Name = "methodGroupBox";
            this.methodGroupBox.Size = new System.Drawing.Size(238, 235);
            this.methodGroupBox.TabIndex = 1;
            this.methodGroupBox.TabStop = false;
            this.methodGroupBox.Text = "Sort method";
            // 
            // sortMethodComboBox
            // 
            this.sortMethodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sortMethodComboBox.FormattingEnabled = true;
            this.sortMethodComboBox.Location = new System.Drawing.Point(18, 52);
            this.sortMethodComboBox.Name = "sortMethodComboBox";
            this.sortMethodComboBox.Size = new System.Drawing.Size(175, 24);
            this.sortMethodComboBox.TabIndex = 11;
            // 
            // orderComboBox
            // 
            this.orderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.orderComboBox.FormattingEnabled = true;
            this.orderComboBox.Location = new System.Drawing.Point(18, 119);
            this.orderComboBox.Name = "orderComboBox";
            this.orderComboBox.Size = new System.Drawing.Size(175, 24);
            this.orderComboBox.TabIndex = 17;
            // 
            // orderArrayLabel
            // 
            this.orderArrayLabel.AutoSize = true;
            this.orderArrayLabel.Location = new System.Drawing.Point(15, 89);
            this.orderArrayLabel.Name = "orderArrayLabel";
            this.orderArrayLabel.Size = new System.Drawing.Size(66, 16);
            this.orderArrayLabel.TabIndex = 16;
            this.orderArrayLabel.Text = "Sort order";
            // 
            // confirmMethodButton
            // 
            this.confirmMethodButton.Location = new System.Drawing.Point(18, 164);
            this.confirmMethodButton.Name = "confirmMethodButton";
            this.confirmMethodButton.Size = new System.Drawing.Size(188, 43);
            this.confirmMethodButton.TabIndex = 10;
            this.confirmMethodButton.Text = "Confirm method";
            this.confirmMethodButton.UseVisualStyleBackColor = true;
            // 
            // createGroupBox
            // 
            this.createGroupBox.Controls.Add(this.fileRadioButton);
            this.createGroupBox.Controls.Add(this.ramdomRadioButton);
            this.createGroupBox.Controls.Add(this.arraySourcePanel);
            this.createGroupBox.Location = new System.Drawing.Point(3, 22);
            this.createGroupBox.Name = "createGroupBox";
            this.createGroupBox.Size = new System.Drawing.Size(244, 159);
            this.createGroupBox.TabIndex = 19;
            this.createGroupBox.TabStop = false;
            this.createGroupBox.Text = "Array source";
            // 
            // fileRadioButton
            // 
            this.fileRadioButton.AutoSize = true;
            this.fileRadioButton.Location = new System.Drawing.Point(12, 16);
            this.fileRadioButton.Name = "fileRadioButton";
            this.fileRadioButton.Size = new System.Drawing.Size(50, 20);
            this.fileRadioButton.TabIndex = 8;
            this.fileRadioButton.TabStop = true;
            this.fileRadioButton.Text = "File";
            this.fileRadioButton.UseVisualStyleBackColor = true;
            // 
            // ramdomRadioButton
            // 
            this.ramdomRadioButton.AutoSize = true;
            this.ramdomRadioButton.Checked = true;
            this.ramdomRadioButton.Location = new System.Drawing.Point(120, 16);
            this.ramdomRadioButton.Name = "ramdomRadioButton";
            this.ramdomRadioButton.Size = new System.Drawing.Size(80, 20);
            this.ramdomRadioButton.TabIndex = 9;
            this.ramdomRadioButton.TabStop = true;
            this.ramdomRadioButton.Text = "Random";
            this.ramdomRadioButton.UseVisualStyleBackColor = true;
            // 
            // processPanel
            // 
            this.processPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.processPanel.Controls.Add(this.processGridView);
            this.processPanel.Location = new System.Drawing.Point(250, 44);
            this.processPanel.Name = "processPanel";
            this.processPanel.Size = new System.Drawing.Size(969, 451);
            this.processPanel.TabIndex = 15;
            // 
            // processGridView
            // 
            this.processGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.processGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processGridView.Location = new System.Drawing.Point(0, 0);
            this.processGridView.Name = "processGridView";
            this.processGridView.RowHeadersWidth = 51;
            this.processGridView.RowTemplate.Height = 24;
            this.processGridView.Size = new System.Drawing.Size(969, 451);
            this.processGridView.TabIndex = 0;
            // 
            // speedDownButton
            // 
            this.speedDownButton.Location = new System.Drawing.Point(817, 10);
            this.speedDownButton.Name = "speedDownButton";
            this.speedDownButton.Size = new System.Drawing.Size(70, 28);
            this.speedDownButton.TabIndex = 14;
            this.speedDownButton.Text = "Down";
            this.speedDownButton.UseVisualStyleBackColor = true;
            // 
            // speedUpButton
            // 
            this.speedUpButton.Location = new System.Drawing.Point(738, 10);
            this.speedUpButton.Name = "speedUpButton";
            this.speedUpButton.Size = new System.Drawing.Size(73, 28);
            this.speedUpButton.TabIndex = 13;
            this.speedUpButton.Text = "Up";
            this.speedUpButton.UseVisualStyleBackColor = true;
            // 
            // startSortingButton
            // 
            this.startSortingButton.Location = new System.Drawing.Point(575, 10);
            this.startSortingButton.Name = "startSortingButton";
            this.startSortingButton.Size = new System.Drawing.Size(146, 28);
            this.startSortingButton.TabIndex = 12;
            this.startSortingButton.Text = "Start sorting";
            this.startSortingButton.UseVisualStyleBackColor = true;
            // 
            // historytabPage
            // 
            this.historytabPage.Controls.Add(this.updateHistoryButton);
            this.historytabPage.Controls.Add(this.sortButton);
            this.historytabPage.Controls.Add(this.sortingProcessDataGridView);
            this.historytabPage.Location = new System.Drawing.Point(4, 25);
            this.historytabPage.Name = "historytabPage";
            this.historytabPage.Padding = new System.Windows.Forms.Padding(3);
            this.historytabPage.Size = new System.Drawing.Size(1219, 495);
            this.historytabPage.TabIndex = 1;
            this.historytabPage.Text = "History";
            this.historytabPage.UseVisualStyleBackColor = true;
            // 
            // updateHistoryButton
            // 
            this.updateHistoryButton.Location = new System.Drawing.Point(8, 6);
            this.updateHistoryButton.Name = "updateHistoryButton";
            this.updateHistoryButton.Size = new System.Drawing.Size(150, 33);
            this.updateHistoryButton.TabIndex = 2;
            this.updateHistoryButton.Text = "Update history";
            this.updateHistoryButton.UseVisualStyleBackColor = true;
            // 
            // sortButton
            // 
            this.sortButton.Location = new System.Drawing.Point(186, 6);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(160, 33);
            this.sortButton.TabIndex = 1;
            this.sortButton.Text = "Sort by Date";
            this.sortButton.UseVisualStyleBackColor = true;
            // 
            // sortingProcessDataGridView
            // 
            this.sortingProcessDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sortingProcessDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sortingProcessDataGridView.Location = new System.Drawing.Point(3, 45);
            this.sortingProcessDataGridView.Name = "sortingProcessDataGridView";
            this.sortingProcessDataGridView.RowHeadersWidth = 51;
            this.sortingProcessDataGridView.RowTemplate.Height = 24;
            this.sortingProcessDataGridView.Size = new System.Drawing.Size(1216, 451);
            this.sortingProcessDataGridView.TabIndex = 0;
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(929, 10);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(70, 28);
            this.pauseButton.TabIndex = 15;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(1005, 10);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(70, 28);
            this.stopButton.TabIndex = 16;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            // 
            // ArrayDesk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 524);
            this.Controls.Add(this.arrayTabControl);
            this.Name = "ArrayDesk";
            this.Text = "Array Sorter";
            this.arrayTabControl.ResumeLayout(false);
            this.sortingTabPage.ResumeLayout(false);
            this.sortingTabPage.PerformLayout();
            this.methodGroupBox.ResumeLayout(false);
            this.methodGroupBox.PerformLayout();
            this.createGroupBox.ResumeLayout(false);
            this.createGroupBox.PerformLayout();
            this.processPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.processGridView)).EndInit();
            this.historytabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sortingProcessDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        private void RamdomRadioButton_Click(object sender, EventArgs e)
        {

        }

        #endregion
        private System.Windows.Forms.Label sortingProcessLabel;
        private System.Windows.Forms.Label selectMethodLabel;
        private System.Windows.Forms.Panel arraySourcePanel;
        private System.Windows.Forms.TabControl arrayTabControl;
        private System.Windows.Forms.TabPage sortingTabPage;
        private System.Windows.Forms.TabPage historytabPage;
        private System.Windows.Forms.Button sortButton;
        private System.Windows.Forms.DataGridView sortingProcessDataGridView;
        private System.Windows.Forms.RadioButton ramdomRadioButton;
        private System.Windows.Forms.RadioButton fileRadioButton;
        private System.Windows.Forms.Button confirmMethodButton;
        private System.Windows.Forms.Button updateHistoryButton;
        private System.Windows.Forms.ComboBox sortMethodComboBox;
        private System.Windows.Forms.Button speedDownButton;
        private System.Windows.Forms.Button speedUpButton;
        private System.Windows.Forms.Button startSortingButton;
        private System.Windows.Forms.Panel processPanel;
        private System.Windows.Forms.DataGridView processGridView;
        private System.Windows.Forms.ComboBox orderComboBox;
        private System.Windows.Forms.Label orderArrayLabel;
        private System.Windows.Forms.GroupBox methodGroupBox;
        private System.Windows.Forms.GroupBox createGroupBox;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button pauseButton;
    }
}

