///////////////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation. All rights reserved.
///////////////////////////////////////////////////////////////////////////////

namespace ILStubDiagnostic
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonControlSession = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonCodeModel = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonZoomIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabelRunning = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonAPILookup = new System.Windows.Forms.ToolStripButton();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.dataGridViewFilter = new System.Windows.Forms.DataGridView();
            this.Field = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Operation = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxFilterMessage = new System.Windows.Forms.TextBox();
            this.splitContainerILStubEvents = new System.Windows.Forms.SplitContainer();
            this.dataGridViewILStubEvents = new System.Windows.Forms.DataGridView();
            this.labelStubHelperAPI = new System.Windows.Forms.Label();
            this.richTextBoxILCode = new System.Windows.Forms.RichTextBox();
            this.contextMenuStripOnFilterRowHeader = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemDeleteFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripNavigation = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonNavigationHide = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelNavigation = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonNextBlock = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPreviousBlock = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelFind = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxFind = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonFindNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFindPrevious = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelFindRepeat = new System.Windows.Forms.ToolStripLabel();
            this.contextMenuStripOnEventsColumnHeader = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMain.SuspendLayout();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFilter)).BeginInit();
            this.splitContainerILStubEvents.Panel1.SuspendLayout();
            this.splitContainerILStubEvents.Panel2.SuspendLayout();
            this.splitContainerILStubEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewILStubEvents)).BeginInit();
            this.contextMenuStripOnFilterRowHeader.SuspendLayout();
            this.toolStripNavigation.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMain
            // 
            this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonControlSession,
            this.toolStripButtonRefresh,
            this.toolStripSeparator4,
            this.toolStripButtonCodeModel,
            this.toolStripButtonZoomIn,
            this.toolStripButtonZoomOut,
            this.toolStripLabelRunning,
            this.toolStripButtonFind,
            this.toolStripSeparator5,
            this.toolStripButtonAPILookup});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(906, 52);
            this.toolStripMain.TabIndex = 1;
            // 
            // toolStripButtonControlSession
            // 
            this.toolStripButtonControlSession.AutoSize = false;
            this.toolStripButtonControlSession.Image = global::ILStubDiagnostic.Properties.Resources.Start;
            this.toolStripButtonControlSession.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonControlSession.Name = "toolStripButtonControlSession";
            this.toolStripButtonControlSession.Size = new System.Drawing.Size(60, 49);
            this.toolStripButtonControlSession.Text = "Start";
            this.toolStripButtonControlSession.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonControlSession.ToolTipText = "Start Monitoring";
            this.toolStripButtonControlSession.Click += new System.EventHandler(this.toolStripButtonControlSession_Click);
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.AutoSize = false;
            this.toolStripButtonRefresh.Image = global::ILStubDiagnostic.Properties.Resources.Refresh;
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(60, 49);
            this.toolStripButtonRefresh.Text = "Refresh";
            this.toolStripButtonRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonRefresh.ToolTipText = "Refresh the Filter";
            this.toolStripButtonRefresh.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 52);
            // 
            // toolStripButtonCodeModel
            // 
            this.toolStripButtonCodeModel.AutoSize = false;
            this.toolStripButtonCodeModel.CheckOnClick = true;
            this.toolStripButtonCodeModel.Image = global::ILStubDiagnostic.Properties.Resources.CodeModel;
            this.toolStripButtonCodeModel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCodeModel.Name = "toolStripButtonCodeModel";
            this.toolStripButtonCodeModel.Size = new System.Drawing.Size(60, 49);
            this.toolStripButtonCodeModel.Text = "IL Code";
            this.toolStripButtonCodeModel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonCodeModel.ToolTipText = "Only Show IL Code";
            this.toolStripButtonCodeModel.Click += new System.EventHandler(this.toolStripButtonCodeModel_Click);
            // 
            // toolStripButtonZoomIn
            // 
            this.toolStripButtonZoomIn.AutoSize = false;
            this.toolStripButtonZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonZoomIn.Image")));
            this.toolStripButtonZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonZoomIn.Name = "toolStripButtonZoomIn";
            this.toolStripButtonZoomIn.Size = new System.Drawing.Size(60, 49);
            this.toolStripButtonZoomIn.Text = "Zoom In";
            this.toolStripButtonZoomIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonZoomIn.Click += new System.EventHandler(this.toolStripButtonZoomIn_Click);
            // 
            // toolStripButtonZoomOut
            // 
            this.toolStripButtonZoomOut.AutoSize = false;
            this.toolStripButtonZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonZoomOut.Image")));
            this.toolStripButtonZoomOut.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.toolStripButtonZoomOut.Name = "toolStripButtonZoomOut";
            this.toolStripButtonZoomOut.Size = new System.Drawing.Size(60, 49);
            this.toolStripButtonZoomOut.Text = "Zoom Out";
            this.toolStripButtonZoomOut.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.toolStripButtonZoomOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonZoomOut.Click += new System.EventHandler(this.toolStripButtonZoomOut_Click);
            // 
            // toolStripLabelRunning
            // 
            this.toolStripLabelRunning.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabelRunning.AutoSize = false;
            this.toolStripLabelRunning.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLabelRunning.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabelRunning.Image")));
            this.toolStripLabelRunning.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripLabelRunning.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripLabelRunning.Name = "toolStripLabelRunning";
            this.toolStripLabelRunning.Size = new System.Drawing.Size(50, 49);
            this.toolStripLabelRunning.Visible = false;
            // 
            // toolStripButtonFind
            // 
            this.toolStripButtonFind.AutoSize = false;
            this.toolStripButtonFind.Checked = true;
            this.toolStripButtonFind.CheckOnClick = true;
            this.toolStripButtonFind.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonFind.Image = global::ILStubDiagnostic.Properties.Resources.Find;
            this.toolStripButtonFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFind.Name = "toolStripButtonFind";
            this.toolStripButtonFind.Size = new System.Drawing.Size(60, 49);
            this.toolStripButtonFind.Text = "Find";
            this.toolStripButtonFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonFind.ToolTipText = "Show Find Bar";
            this.toolStripButtonFind.Click += new System.EventHandler(this.toolStripButtonFind_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 52);
            // 
            // toolStripButtonAPILookup
            // 
            this.toolStripButtonAPILookup.AutoSize = false;
            this.toolStripButtonAPILookup.Image = global::ILStubDiagnostic.Properties.Resources.APILookup;
            this.toolStripButtonAPILookup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAPILookup.Name = "toolStripButtonAPILookup";
            this.toolStripButtonAPILookup.Size = new System.Drawing.Size(60, 49);
            this.toolStripButtonAPILookup.Text = "Stub API";
            this.toolStripButtonAPILookup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonAPILookup.ToolTipText = "StubHelpers API Lookup";
            this.toolStripButtonAPILookup.Click += new System.EventHandler(this.toolStripButtonAPILookup_Click);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 52);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.dataGridViewFilter);
            this.splitContainerMain.Panel1.Controls.Add(this.textBoxFilterMessage);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.splitContainerILStubEvents);
            this.splitContainerMain.Size = new System.Drawing.Size(906, 540);
            this.splitContainerMain.SplitterDistance = 119;
            this.splitContainerMain.TabIndex = 3;
            // 
            // dataGridViewFilter
            // 
            this.dataGridViewFilter.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFilter.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewFilter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFilter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Field,
            this.Operation,
            this.Value});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewFilter.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFilter.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewFilter.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewFilter.MultiSelect = false;
            this.dataGridViewFilter.Name = "dataGridViewFilter";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFilter.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewFilter.Size = new System.Drawing.Size(906, 99);
            this.dataGridViewFilter.TabIndex = 0;
            this.dataGridViewFilter.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFilter_CellValueChanged);
            this.dataGridViewFilter.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridViewFilter_CurrentCellDirtyStateChanged);
            this.dataGridViewFilter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridViewFilter_MouseDown);
            // 
            // Field
            // 
            this.Field.HeaderText = "Field";
            this.Field.Name = "Field";
            this.Field.Width = 150;
            // 
            // Operation
            // 
            this.Operation.HeaderText = "Operation";
            this.Operation.Name = "Operation";
            this.Operation.Width = 150;
            // 
            // Value
            // 
            this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // textBoxFilterMessage
            // 
            this.textBoxFilterMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxFilterMessage.ForeColor = System.Drawing.Color.Brown;
            this.textBoxFilterMessage.Location = new System.Drawing.Point(0, 99);
            this.textBoxFilterMessage.Name = "textBoxFilterMessage";
            this.textBoxFilterMessage.ReadOnly = true;
            this.textBoxFilterMessage.Size = new System.Drawing.Size(906, 20);
            this.textBoxFilterMessage.TabIndex = 1;
            // 
            // splitContainerILStubEvents
            // 
            this.splitContainerILStubEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerILStubEvents.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerILStubEvents.Location = new System.Drawing.Point(0, 0);
            this.splitContainerILStubEvents.Name = "splitContainerILStubEvents";
            this.splitContainerILStubEvents.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerILStubEvents.Panel1
            // 
            this.splitContainerILStubEvents.Panel1.Controls.Add(this.dataGridViewILStubEvents);
            // 
            // splitContainerILStubEvents.Panel2
            // 
            this.splitContainerILStubEvents.Panel2.Controls.Add(this.labelStubHelperAPI);
            this.splitContainerILStubEvents.Panel2.Controls.Add(this.richTextBoxILCode);
            this.splitContainerILStubEvents.Size = new System.Drawing.Size(906, 417);
            this.splitContainerILStubEvents.SplitterDistance = 120;
            this.splitContainerILStubEvents.TabIndex = 3;
            // 
            // dataGridViewILStubEvents
            // 
            this.dataGridViewILStubEvents.AllowUserToAddRows = false;
            this.dataGridViewILStubEvents.AllowUserToDeleteRows = false;
            this.dataGridViewILStubEvents.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewILStubEvents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewILStubEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewILStubEvents.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewILStubEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewILStubEvents.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewILStubEvents.MultiSelect = false;
            this.dataGridViewILStubEvents.Name = "dataGridViewILStubEvents";
            this.dataGridViewILStubEvents.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewILStubEvents.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewILStubEvents.RowHeadersVisible = false;
            this.dataGridViewILStubEvents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewILStubEvents.Size = new System.Drawing.Size(906, 120);
            this.dataGridViewILStubEvents.TabIndex = 0;
            this.dataGridViewILStubEvents.SelectionChanged += new System.EventHandler(this.dataGridViewILStubEvents_SelectionChanged);
            this.dataGridViewILStubEvents.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridViewILStubEvents_MouseDown);
            // 
            // labelStubHelperAPI
            // 
            this.labelStubHelperAPI.AutoSize = true;
            this.labelStubHelperAPI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.labelStubHelperAPI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelStubHelperAPI.Location = new System.Drawing.Point(424, 81);
            this.labelStubHelperAPI.MaximumSize = new System.Drawing.Size(300, 300);
            this.labelStubHelperAPI.Name = "labelStubHelperAPI";
            this.labelStubHelperAPI.Size = new System.Drawing.Size(101, 15);
            this.labelStubHelperAPI.TabIndex = 1;
            this.labelStubHelperAPI.Text = "labelStubHelperAPI";
            this.labelStubHelperAPI.Visible = false;
            // 
            // richTextBoxILCode
            // 
            this.richTextBoxILCode.BackColor = System.Drawing.Color.White;
            this.richTextBoxILCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxILCode.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxILCode.HideSelection = false;
            this.richTextBoxILCode.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxILCode.Name = "richTextBoxILCode";
            this.richTextBoxILCode.ReadOnly = true;
            this.richTextBoxILCode.Size = new System.Drawing.Size(906, 293);
            this.richTextBoxILCode.TabIndex = 0;
            this.richTextBoxILCode.Text = "";
            this.richTextBoxILCode.TextChanged += new System.EventHandler(this.richTextBoxILCode_TextChanged);
            this.richTextBoxILCode.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.richTextBoxILCode_MouseDoubleClick);
            this.richTextBoxILCode.MouseMove += new System.Windows.Forms.MouseEventHandler(this.richTextBoxILCode_MouseMove);
            // 
            // contextMenuStripOnFilterRowHeader
            // 
            this.contextMenuStripOnFilterRowHeader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemDeleteFilter});
            this.contextMenuStripOnFilterRowHeader.Name = "contextMenuStripOnFilterRowHeader";
            this.contextMenuStripOnFilterRowHeader.Size = new System.Drawing.Size(133, 26);
            // 
            // toolStripMenuItemDeleteFilter
            // 
            this.toolStripMenuItemDeleteFilter.Name = "toolStripMenuItemDeleteFilter";
            this.toolStripMenuItemDeleteFilter.Size = new System.Drawing.Size(132, 22);
            this.toolStripMenuItemDeleteFilter.Text = "Delete Filter";
            this.toolStripMenuItemDeleteFilter.Click += new System.EventHandler(this.toolStripMenuItemDeleteFilter_Click);
            // 
            // toolStripNavigation
            // 
            this.toolStripNavigation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripNavigation.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripNavigation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNavigationHide,
            this.toolStripSeparator2,
            this.toolStripLabelNavigation,
            this.toolStripButtonNextBlock,
            this.toolStripButtonPreviousBlock,
            this.toolStripSeparator1,
            this.toolStripLabelFind,
            this.toolStripTextBoxFind,
            this.toolStripButtonFindNext,
            this.toolStripButtonFindPrevious,
            this.toolStripSeparator3,
            this.toolStripLabelFindRepeat});
            this.toolStripNavigation.Location = new System.Drawing.Point(0, 592);
            this.toolStripNavigation.Name = "toolStripNavigation";
            this.toolStripNavigation.Size = new System.Drawing.Size(906, 25);
            this.toolStripNavigation.TabIndex = 4;
            this.toolStripNavigation.Text = "toolStripNavigation";
            // 
            // toolStripButtonNavigationHide
            // 
            this.toolStripButtonNavigationHide.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNavigationHide.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonNavigationHide.Image")));
            this.toolStripButtonNavigationHide.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolStripButtonNavigationHide.Name = "toolStripButtonNavigationHide";
            this.toolStripButtonNavigationHide.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonNavigationHide.Text = "Hide";
            this.toolStripButtonNavigationHide.Click += new System.EventHandler(this.toolStripButtonNavigationHide_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabelNavigation
            // 
            this.toolStripLabelNavigation.Name = "toolStripLabelNavigation";
            this.toolStripLabelNavigation.Size = new System.Drawing.Size(54, 22);
            this.toolStripLabelNavigation.Text = "Navigate:";
            // 
            // toolStripButtonNextBlock
            // 
            this.toolStripButtonNextBlock.AutoToolTip = false;
            this.toolStripButtonNextBlock.Image = global::ILStubDiagnostic.Properties.Resources.FindNextBlock;
            this.toolStripButtonNextBlock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNextBlock.Name = "toolStripButtonNextBlock";
            this.toolStripButtonNextBlock.Size = new System.Drawing.Size(77, 22);
            this.toolStripButtonNextBlock.Text = "Next Block";
            this.toolStripButtonNextBlock.Click += new System.EventHandler(this.toolStripButtonNextBlock_Click);
            // 
            // toolStripButtonPreviousBlock
            // 
            this.toolStripButtonPreviousBlock.AutoToolTip = false;
            this.toolStripButtonPreviousBlock.Image = global::ILStubDiagnostic.Properties.Resources.FindPreviousBlock;
            this.toolStripButtonPreviousBlock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPreviousBlock.Name = "toolStripButtonPreviousBlock";
            this.toolStripButtonPreviousBlock.Size = new System.Drawing.Size(95, 22);
            this.toolStripButtonPreviousBlock.Text = "Previous Block";
            this.toolStripButtonPreviousBlock.Click += new System.EventHandler(this.toolStripButtonPreviousBlock_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabelFind
            // 
            this.toolStripLabelFind.Name = "toolStripLabelFind";
            this.toolStripLabelFind.Size = new System.Drawing.Size(31, 22);
            this.toolStripLabelFind.Text = "Find:";
            // 
            // toolStripTextBoxFind
            // 
            this.toolStripTextBoxFind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBoxFind.Name = "toolStripTextBoxFind";
            this.toolStripTextBoxFind.Size = new System.Drawing.Size(100, 25);
            this.toolStripTextBoxFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBoxFind_KeyDown);
            this.toolStripTextBoxFind.TextChanged += new System.EventHandler(this.toolStripTextBoxFind_TextChanged);
            // 
            // toolStripButtonFindNext
            // 
            this.toolStripButtonFindNext.AutoToolTip = false;
            this.toolStripButtonFindNext.Enabled = false;
            this.toolStripButtonFindNext.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFindNext.Image")));
            this.toolStripButtonFindNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFindNext.Name = "toolStripButtonFindNext";
            this.toolStripButtonFindNext.Size = new System.Drawing.Size(50, 22);
            this.toolStripButtonFindNext.Text = "Next";
            this.toolStripButtonFindNext.Click += new System.EventHandler(this.toolStripButtonFindNext_Click);
            // 
            // toolStripButtonFindPrevious
            // 
            this.toolStripButtonFindPrevious.AutoToolTip = false;
            this.toolStripButtonFindPrevious.Enabled = false;
            this.toolStripButtonFindPrevious.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFindPrevious.Image")));
            this.toolStripButtonFindPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFindPrevious.Name = "toolStripButtonFindPrevious";
            this.toolStripButtonFindPrevious.Size = new System.Drawing.Size(68, 22);
            this.toolStripButtonFindPrevious.Text = "Previous";
            this.toolStripButtonFindPrevious.Click += new System.EventHandler(this.toolStripButtonFindPrevious_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabelFindRepeat
            // 
            this.toolStripLabelFindRepeat.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.toolStripLabelFindRepeat.Name = "toolStripLabelFindRepeat";
            this.toolStripLabelFindRepeat.Size = new System.Drawing.Size(0, 22);
            // 
            // contextMenuStripOnEventsColumnHeader
            // 
            this.contextMenuStripOnEventsColumnHeader.Name = "contextMenuStripOnEventsColumnHeader";
            this.contextMenuStripOnEventsColumnHeader.Size = new System.Drawing.Size(61, 4);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 617);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.toolStripNavigation);
            this.Controls.Add(this.toolStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "IL Stub Diagnostic";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel1.PerformLayout();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFilter)).EndInit();
            this.splitContainerILStubEvents.Panel1.ResumeLayout(false);
            this.splitContainerILStubEvents.Panel2.ResumeLayout(false);
            this.splitContainerILStubEvents.Panel2.PerformLayout();
            this.splitContainerILStubEvents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewILStubEvents)).EndInit();
            this.contextMenuStripOnFilterRowHeader.ResumeLayout(false);
            this.toolStripNavigation.ResumeLayout(false);
            this.toolStripNavigation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripButtonControlSession;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainerILStubEvents;
        private System.Windows.Forms.RichTextBox richTextBoxILCode;
        private System.Windows.Forms.DataGridView dataGridViewILStubEvents;
        private System.Windows.Forms.DataGridView dataGridViewFilter;
        private System.Windows.Forms.DataGridViewComboBoxColumn Field;
        private System.Windows.Forms.DataGridViewComboBoxColumn Operation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripOnFilterRowHeader;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDeleteFilter;
        private System.Windows.Forms.TextBox textBoxFilterMessage;
        private System.Windows.Forms.ToolStrip toolStripNavigation;
        private System.Windows.Forms.ToolStripButton toolStripButtonNavigationHide;
        private System.Windows.Forms.ToolStripLabel toolStripLabelNavigation;
        private System.Windows.Forms.ToolStripButton toolStripButtonNextBlock;
        private System.Windows.Forms.ToolStripButton toolStripButtonPreviousBlock;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabelFind;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxFind;
        private System.Windows.Forms.ToolStripButton toolStripButtonFindNext;
        private System.Windows.Forms.ToolStripButton toolStripButtonFindPrevious;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabelFindRepeat;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButtonCodeModel;
        private System.Windows.Forms.ToolStripButton toolStripButtonZoomIn;
        private System.Windows.Forms.ToolStripButton toolStripButtonZoomOut;
        private System.Windows.Forms.ToolStripLabel toolStripLabelRunning;
        private System.Windows.Forms.ToolStripButton toolStripButtonFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButtonAPILookup;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripOnEventsColumnHeader;
        private System.Windows.Forms.Label labelStubHelperAPI;
    }
}

