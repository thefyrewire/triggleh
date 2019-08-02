namespace Triggleh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dgv_Triggers = new System.Windows.Forms.DataGridView();
            this.dgv_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_AddTrigger = new System.Windows.Forms.Button();
            this.tab_TriggerDetails = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_ResetLastTriggered = new System.Windows.Forms.Button();
            this.lbl_LastTriggered = new System.Windows.Forms.Label();
            this.lbl_LastTriggeredAt = new System.Windows.Forms.Label();
            this.cmb_CooldownUnit = new System.Windows.Forms.ComboBox();
            this.lbl_Cooldown = new System.Windows.Forms.Label();
            this.nud_Cooldown = new System.Windows.Forms.NumericUpDown();
            this.lbl_ValidationError = new System.Windows.Forms.Label();
            this.btn_SaveTrigger = new System.Windows.Forms.Button();
            this.btn_RecordTrigger = new System.Windows.Forms.Button();
            this.lbl_CHTriggerKey = new System.Windows.Forms.Label();
            this.lbl_CHTrigger = new System.Windows.Forms.Label();
            this.nud_Bits2 = new System.Windows.Forms.NumericUpDown();
            this.lbl_BitsInfo2 = new System.Windows.Forms.Label();
            this.lbl_BitsInfo1 = new System.Windows.Forms.Label();
            this.nud_Bits1 = new System.Windows.Forms.NumericUpDown();
            this.txt_Keywords = new System.Windows.Forms.TextBox();
            this.btn_RemoveKeyword = new System.Windows.Forms.Button();
            this.btn_AddKeyword = new System.Windows.Forms.Button();
            this.chk_Bits = new System.Windows.Forms.CheckBox();
            this.cmb_Bits = new System.Windows.Forms.ComboBox();
            this.chk_ULMods = new System.Windows.Forms.CheckBox();
            this.chk_ULSubs = new System.Windows.Forms.CheckBox();
            this.chk_ULEveryone = new System.Windows.Forms.CheckBox();
            this.txt_TriggerName = new System.Windows.Forms.TextBox();
            this.lst_Keywords = new System.Windows.Forms.ListBox();
            this.lbl_Keywords = new System.Windows.Forms.Label();
            this.lbl_UserLevel = new System.Windows.Forms.Label();
            this.lbl_Bits = new System.Windows.Forms.Label();
            this.lbl_TriggerName = new System.Windows.Forms.Label();
            this.btn_RemoveTrigger = new System.Windows.Forms.Button();
            this.lbl_CharAnimStatus = new System.Windows.Forms.Label();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.btn_Settings = new System.Windows.Forms.Button();
            this.pic_ProfilePicture = new System.Windows.Forms.PictureBox();
            this.lbl_ChatStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Triggers)).BeginInit();
            this.tab_TriggerDetails.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Cooldown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Bits2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Bits1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ProfilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Triggers
            // 
            this.dgv_Triggers.AllowUserToAddRows = false;
            this.dgv_Triggers.AllowUserToDeleteRows = false;
            this.dgv_Triggers.AllowUserToResizeColumns = false;
            this.dgv_Triggers.AllowUserToResizeRows = false;
            this.dgv_Triggers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Triggers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv_Name});
            this.dgv_Triggers.Location = new System.Drawing.Point(12, 12);
            this.dgv_Triggers.MultiSelect = false;
            this.dgv_Triggers.Name = "dgv_Triggers";
            this.dgv_Triggers.ReadOnly = true;
            this.dgv_Triggers.RowHeadersVisible = false;
            this.dgv_Triggers.RowHeadersWidth = 60;
            this.dgv_Triggers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_Triggers.RowTemplate.Height = 24;
            this.dgv_Triggers.Size = new System.Drawing.Size(220, 377);
            this.dgv_Triggers.TabIndex = 1;
            this.dgv_Triggers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Triggers_CellClick);
            this.dgv_Triggers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Triggers_CellClick);
            // 
            // dgv_Name
            // 
            this.dgv_Name.HeaderText = "Name";
            this.dgv_Name.MinimumWidth = 6;
            this.dgv_Name.Name = "dgv_Name";
            this.dgv_Name.ReadOnly = true;
            this.dgv_Name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgv_Name.Width = 217;
            // 
            // btn_AddTrigger
            // 
            this.btn_AddTrigger.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddTrigger.Location = new System.Drawing.Point(125, 395);
            this.btn_AddTrigger.Name = "btn_AddTrigger";
            this.btn_AddTrigger.Size = new System.Drawing.Size(107, 43);
            this.btn_AddTrigger.TabIndex = 0;
            this.btn_AddTrigger.Text = "+";
            this.btn_AddTrigger.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_AddTrigger.UseVisualStyleBackColor = true;
            this.btn_AddTrigger.Click += new System.EventHandler(this.Btn_AddTrigger_Click);
            // 
            // tab_TriggerDetails
            // 
            this.tab_TriggerDetails.Controls.Add(this.tabPage1);
            this.tab_TriggerDetails.Location = new System.Drawing.Point(238, 12);
            this.tab_TriggerDetails.Name = "tab_TriggerDetails";
            this.tab_TriggerDetails.SelectedIndex = 0;
            this.tab_TriggerDetails.Size = new System.Drawing.Size(683, 377);
            this.tab_TriggerDetails.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_ResetLastTriggered);
            this.tabPage1.Controls.Add(this.lbl_LastTriggered);
            this.tabPage1.Controls.Add(this.lbl_LastTriggeredAt);
            this.tabPage1.Controls.Add(this.cmb_CooldownUnit);
            this.tabPage1.Controls.Add(this.lbl_Cooldown);
            this.tabPage1.Controls.Add(this.nud_Cooldown);
            this.tabPage1.Controls.Add(this.lbl_ValidationError);
            this.tabPage1.Controls.Add(this.btn_SaveTrigger);
            this.tabPage1.Controls.Add(this.btn_RecordTrigger);
            this.tabPage1.Controls.Add(this.lbl_CHTriggerKey);
            this.tabPage1.Controls.Add(this.lbl_CHTrigger);
            this.tabPage1.Controls.Add(this.nud_Bits2);
            this.tabPage1.Controls.Add(this.lbl_BitsInfo2);
            this.tabPage1.Controls.Add(this.lbl_BitsInfo1);
            this.tabPage1.Controls.Add(this.nud_Bits1);
            this.tabPage1.Controls.Add(this.txt_Keywords);
            this.tabPage1.Controls.Add(this.btn_RemoveKeyword);
            this.tabPage1.Controls.Add(this.btn_AddKeyword);
            this.tabPage1.Controls.Add(this.chk_Bits);
            this.tabPage1.Controls.Add(this.cmb_Bits);
            this.tabPage1.Controls.Add(this.chk_ULMods);
            this.tabPage1.Controls.Add(this.chk_ULSubs);
            this.tabPage1.Controls.Add(this.chk_ULEveryone);
            this.tabPage1.Controls.Add(this.txt_TriggerName);
            this.tabPage1.Controls.Add(this.lst_Keywords);
            this.tabPage1.Controls.Add(this.lbl_Keywords);
            this.tabPage1.Controls.Add(this.lbl_UserLevel);
            this.tabPage1.Controls.Add(this.lbl_Bits);
            this.tabPage1.Controls.Add(this.lbl_TriggerName);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(675, 341);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Details";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_ResetLastTriggered
            // 
            this.btn_ResetLastTriggered.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_ResetLastTriggered.Location = new System.Drawing.Point(363, 235);
            this.btn_ResetLastTriggered.Name = "btn_ResetLastTriggered";
            this.btn_ResetLastTriggered.Size = new System.Drawing.Size(74, 23);
            this.btn_ResetLastTriggered.TabIndex = 17;
            this.btn_ResetLastTriggered.Text = "Reset";
            this.btn_ResetLastTriggered.UseVisualStyleBackColor = true;
            this.btn_ResetLastTriggered.Click += new System.EventHandler(this.Btn_ResetLastTriggered_Click);
            // 
            // lbl_LastTriggered
            // 
            this.lbl_LastTriggered.AutoSize = true;
            this.lbl_LastTriggered.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_LastTriggered.Location = new System.Drawing.Point(305, 217);
            this.lbl_LastTriggered.Name = "lbl_LastTriggered";
            this.lbl_LastTriggered.Size = new System.Drawing.Size(170, 20);
            this.lbl_LastTriggered.TabIndex = 0;
            this.lbl_LastTriggered.Text = "01/01/2000 00:00:00 AM";
            // 
            // lbl_LastTriggeredAt
            // 
            this.lbl_LastTriggeredAt.AutoSize = true;
            this.lbl_LastTriggeredAt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_LastTriggeredAt.Location = new System.Drawing.Point(305, 202);
            this.lbl_LastTriggeredAt.Name = "lbl_LastTriggeredAt";
            this.lbl_LastTriggeredAt.Size = new System.Drawing.Size(121, 20);
            this.lbl_LastTriggeredAt.TabIndex = 0;
            this.lbl_LastTriggeredAt.Text = "Last triggered at:";
            // 
            // cmb_CooldownUnit
            // 
            this.cmb_CooldownUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_CooldownUnit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmb_CooldownUnit.FormattingEnabled = true;
            this.cmb_CooldownUnit.Items.AddRange(new object[] {
            "Seconds",
            "Minutes",
            "Hours"});
            this.cmb_CooldownUnit.Location = new System.Drawing.Point(224, 205);
            this.cmb_CooldownUnit.Name = "cmb_CooldownUnit";
            this.cmb_CooldownUnit.Size = new System.Drawing.Size(75, 31);
            this.cmb_CooldownUnit.TabIndex = 16;
            // 
            // lbl_Cooldown
            // 
            this.lbl_Cooldown.AutoSize = true;
            this.lbl_Cooldown.Location = new System.Drawing.Point(27, 207);
            this.lbl_Cooldown.Name = "lbl_Cooldown";
            this.lbl_Cooldown.Size = new System.Drawing.Size(87, 23);
            this.lbl_Cooldown.TabIndex = 0;
            this.lbl_Cooldown.Text = "Cooldown";
            // 
            // nud_Cooldown
            // 
            this.nud_Cooldown.Location = new System.Drawing.Point(143, 205);
            this.nud_Cooldown.Name = "nud_Cooldown";
            this.nud_Cooldown.Size = new System.Drawing.Size(75, 30);
            this.nud_Cooldown.TabIndex = 15;
            this.nud_Cooldown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // lbl_ValidationError
            // 
            this.lbl_ValidationError.AutoSize = true;
            this.lbl_ValidationError.Location = new System.Drawing.Point(140, 312);
            this.lbl_ValidationError.Name = "lbl_ValidationError";
            this.lbl_ValidationError.Size = new System.Drawing.Size(356, 23);
            this.lbl_ValidationError.TabIndex = 0;
            this.lbl_ValidationError.Text = "Need at least either a single bit or a keyword!";
            this.lbl_ValidationError.Visible = false;
            // 
            // btn_SaveTrigger
            // 
            this.btn_SaveTrigger.Location = new System.Drawing.Point(538, 298);
            this.btn_SaveTrigger.Name = "btn_SaveTrigger";
            this.btn_SaveTrigger.Size = new System.Drawing.Size(107, 33);
            this.btn_SaveTrigger.TabIndex = 19;
            this.btn_SaveTrigger.Text = "Save";
            this.btn_SaveTrigger.UseVisualStyleBackColor = true;
            this.btn_SaveTrigger.Click += new System.EventHandler(this.Btn_SaveTrigger_Click);
            // 
            // btn_RecordTrigger
            // 
            this.btn_RecordTrigger.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_RecordTrigger.Location = new System.Drawing.Point(143, 266);
            this.btn_RecordTrigger.Name = "btn_RecordTrigger";
            this.btn_RecordTrigger.Size = new System.Drawing.Size(101, 31);
            this.btn_RecordTrigger.TabIndex = 18;
            this.btn_RecordTrigger.Text = "Record";
            this.btn_RecordTrigger.UseVisualStyleBackColor = true;
            this.btn_RecordTrigger.Click += new System.EventHandler(this.Btn_RecordTrigger_Click);
            // 
            // lbl_CHTriggerKey
            // 
            this.lbl_CHTriggerKey.AutoSize = true;
            this.lbl_CHTriggerKey.Location = new System.Drawing.Point(262, 272);
            this.lbl_CHTriggerKey.Name = "lbl_CHTriggerKey";
            this.lbl_CHTriggerKey.Size = new System.Drawing.Size(52, 23);
            this.lbl_CHTriggerKey.TabIndex = 0;
            this.lbl_CHTriggerKey.Text = "None";
            // 
            // lbl_CHTrigger
            // 
            this.lbl_CHTrigger.Location = new System.Drawing.Point(26, 251);
            this.lbl_CHTrigger.Name = "lbl_CHTrigger";
            this.lbl_CHTrigger.Size = new System.Drawing.Size(95, 68);
            this.lbl_CHTrigger.TabIndex = 0;
            this.lbl_CHTrigger.Text = "Character Animator Trigger";
            // 
            // nud_Bits2
            // 
            this.nud_Bits2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nud_Bits2.Location = new System.Drawing.Point(356, 74);
            this.nud_Bits2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_Bits2.Name = "nud_Bits2";
            this.nud_Bits2.Size = new System.Drawing.Size(64, 30);
            this.nud_Bits2.TabIndex = 7;
            this.nud_Bits2.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // lbl_BitsInfo2
            // 
            this.lbl_BitsInfo2.AutoSize = true;
            this.lbl_BitsInfo2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_BitsInfo2.Location = new System.Drawing.Point(426, 76);
            this.lbl_BitsInfo2.Name = "lbl_BitsInfo2";
            this.lbl_BitsInfo2.Size = new System.Drawing.Size(37, 23);
            this.lbl_BitsInfo2.TabIndex = 0;
            this.lbl_BitsInfo2.Text = "bits";
            // 
            // lbl_BitsInfo1
            // 
            this.lbl_BitsInfo1.AutoSize = true;
            this.lbl_BitsInfo1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_BitsInfo1.Location = new System.Drawing.Point(320, 76);
            this.lbl_BitsInfo1.Name = "lbl_BitsInfo1";
            this.lbl_BitsInfo1.Size = new System.Drawing.Size(39, 23);
            this.lbl_BitsInfo1.TabIndex = 0;
            this.lbl_BitsInfo1.Text = "and";
            // 
            // nud_Bits1
            // 
            this.nud_Bits1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nud_Bits1.Location = new System.Drawing.Point(250, 73);
            this.nud_Bits1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_Bits1.Name = "nud_Bits1";
            this.nud_Bits1.Size = new System.Drawing.Size(64, 30);
            this.nud_Bits1.TabIndex = 6;
            this.nud_Bits1.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // txt_Keywords
            // 
            this.txt_Keywords.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_Keywords.Location = new System.Drawing.Point(143, 160);
            this.txt_Keywords.Name = "txt_Keywords";
            this.txt_Keywords.Size = new System.Drawing.Size(207, 30);
            this.txt_Keywords.TabIndex = 11;
            this.txt_Keywords.Enter += new System.EventHandler(this.Txt_Keywords_Enter);
            // 
            // btn_RemoveKeyword
            // 
            this.btn_RemoveKeyword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_RemoveKeyword.Location = new System.Drawing.Point(447, 160);
            this.btn_RemoveKeyword.Name = "btn_RemoveKeyword";
            this.btn_RemoveKeyword.Size = new System.Drawing.Size(85, 25);
            this.btn_RemoveKeyword.TabIndex = 13;
            this.btn_RemoveKeyword.Text = "Remove";
            this.btn_RemoveKeyword.UseVisualStyleBackColor = true;
            this.btn_RemoveKeyword.Click += new System.EventHandler(this.Btn_RemoveKeyword_Click);
            // 
            // btn_AddKeyword
            // 
            this.btn_AddKeyword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_AddKeyword.Location = new System.Drawing.Point(356, 160);
            this.btn_AddKeyword.Name = "btn_AddKeyword";
            this.btn_AddKeyword.Size = new System.Drawing.Size(85, 25);
            this.btn_AddKeyword.TabIndex = 12;
            this.btn_AddKeyword.Text = "Add";
            this.btn_AddKeyword.UseVisualStyleBackColor = true;
            this.btn_AddKeyword.Click += new System.EventHandler(this.Btn_AddKeyword_Click);
            // 
            // chk_Bits
            // 
            this.chk_Bits.AutoSize = true;
            this.chk_Bits.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chk_Bits.Location = new System.Drawing.Point(143, 80);
            this.chk_Bits.Name = "chk_Bits";
            this.chk_Bits.Size = new System.Drawing.Size(18, 17);
            this.chk_Bits.TabIndex = 4;
            this.chk_Bits.UseVisualStyleBackColor = true;
            this.chk_Bits.CheckedChanged += new System.EventHandler(this.Chk_Bits_CheckedChanged);
            // 
            // cmb_Bits
            // 
            this.cmb_Bits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Bits.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmb_Bits.FormattingEnabled = true;
            this.cmb_Bits.Items.AddRange(new object[] {
            "At least",
            "At most",
            "Exactly",
            "Between"});
            this.cmb_Bits.Location = new System.Drawing.Point(167, 73);
            this.cmb_Bits.Name = "cmb_Bits";
            this.cmb_Bits.Size = new System.Drawing.Size(77, 31);
            this.cmb_Bits.TabIndex = 5;
            this.cmb_Bits.SelectedIndexChanged += new System.EventHandler(this.Cmb_Bits_SelectedIndexChanged);
            // 
            // chk_ULMods
            // 
            this.chk_ULMods.AutoSize = true;
            this.chk_ULMods.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chk_ULMods.Location = new System.Drawing.Point(363, 118);
            this.chk_ULMods.Name = "chk_ULMods";
            this.chk_ULMods.Size = new System.Drawing.Size(74, 27);
            this.chk_ULMods.TabIndex = 10;
            this.chk_ULMods.Text = "Mods";
            this.chk_ULMods.UseVisualStyleBackColor = true;
            // 
            // chk_ULSubs
            // 
            this.chk_ULSubs.AutoSize = true;
            this.chk_ULSubs.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chk_ULSubs.Location = new System.Drawing.Point(266, 118);
            this.chk_ULSubs.Name = "chk_ULSubs";
            this.chk_ULSubs.Size = new System.Drawing.Size(68, 27);
            this.chk_ULSubs.TabIndex = 9;
            this.chk_ULSubs.Text = "Subs";
            this.chk_ULSubs.UseVisualStyleBackColor = true;
            // 
            // chk_ULEveryone
            // 
            this.chk_ULEveryone.AutoSize = true;
            this.chk_ULEveryone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chk_ULEveryone.Location = new System.Drawing.Point(143, 118);
            this.chk_ULEveryone.Name = "chk_ULEveryone";
            this.chk_ULEveryone.Size = new System.Drawing.Size(101, 27);
            this.chk_ULEveryone.TabIndex = 8;
            this.chk_ULEveryone.Text = "Everyone";
            this.chk_ULEveryone.UseVisualStyleBackColor = true;
            this.chk_ULEveryone.CheckedChanged += new System.EventHandler(this.Chk_ULEveryone_CheckedChanged);
            // 
            // txt_TriggerName
            // 
            this.txt_TriggerName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_TriggerName.Location = new System.Drawing.Point(143, 30);
            this.txt_TriggerName.Name = "txt_TriggerName";
            this.txt_TriggerName.Size = new System.Drawing.Size(301, 30);
            this.txt_TriggerName.TabIndex = 3;
            // 
            // lst_Keywords
            // 
            this.lst_Keywords.FormattingEnabled = true;
            this.lst_Keywords.ItemHeight = 23;
            this.lst_Keywords.Location = new System.Drawing.Point(538, 160);
            this.lst_Keywords.Name = "lst_Keywords";
            this.lst_Keywords.Size = new System.Drawing.Size(107, 96);
            this.lst_Keywords.TabIndex = 14;
            // 
            // lbl_Keywords
            // 
            this.lbl_Keywords.AutoSize = true;
            this.lbl_Keywords.Location = new System.Drawing.Point(26, 163);
            this.lbl_Keywords.Name = "lbl_Keywords";
            this.lbl_Keywords.Size = new System.Drawing.Size(82, 23);
            this.lbl_Keywords.TabIndex = 0;
            this.lbl_Keywords.Text = "Keywords";
            // 
            // lbl_UserLevel
            // 
            this.lbl_UserLevel.AutoSize = true;
            this.lbl_UserLevel.Location = new System.Drawing.Point(26, 119);
            this.lbl_UserLevel.Name = "lbl_UserLevel";
            this.lbl_UserLevel.Size = new System.Drawing.Size(87, 23);
            this.lbl_UserLevel.TabIndex = 0;
            this.lbl_UserLevel.Text = "User Level";
            // 
            // lbl_Bits
            // 
            this.lbl_Bits.AutoSize = true;
            this.lbl_Bits.Location = new System.Drawing.Point(26, 75);
            this.lbl_Bits.Name = "lbl_Bits";
            this.lbl_Bits.Size = new System.Drawing.Size(37, 23);
            this.lbl_Bits.TabIndex = 0;
            this.lbl_Bits.Text = "Bits";
            // 
            // lbl_TriggerName
            // 
            this.lbl_TriggerName.AutoSize = true;
            this.lbl_TriggerName.Location = new System.Drawing.Point(26, 31);
            this.lbl_TriggerName.Name = "lbl_TriggerName";
            this.lbl_TriggerName.Size = new System.Drawing.Size(56, 23);
            this.lbl_TriggerName.TabIndex = 0;
            this.lbl_TriggerName.Text = "Name";
            // 
            // btn_RemoveTrigger
            // 
            this.btn_RemoveTrigger.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RemoveTrigger.Location = new System.Drawing.Point(12, 395);
            this.btn_RemoveTrigger.Name = "btn_RemoveTrigger";
            this.btn_RemoveTrigger.Size = new System.Drawing.Size(107, 43);
            this.btn_RemoveTrigger.TabIndex = 20;
            this.btn_RemoveTrigger.Text = "-";
            this.btn_RemoveTrigger.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_RemoveTrigger.UseVisualStyleBackColor = true;
            this.btn_RemoveTrigger.Click += new System.EventHandler(this.Btn_RemoveTrigger_Click);
            // 
            // lbl_CharAnimStatus
            // 
            this.lbl_CharAnimStatus.AutoSize = true;
            this.lbl_CharAnimStatus.Location = new System.Drawing.Point(326, 405);
            this.lbl_CharAnimStatus.Name = "lbl_CharAnimStatus";
            this.lbl_CharAnimStatus.Size = new System.Drawing.Size(215, 23);
            this.lbl_CharAnimStatus.TabIndex = 0;
            this.lbl_CharAnimStatus.Text = "Character Animator found!";
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Location = new System.Drawing.Point(238, 395);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(82, 43);
            this.btn_Refresh.TabIndex = 21;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.Btn_Refresh_Click);
            // 
            // btn_Settings
            // 
            this.btn_Settings.Location = new System.Drawing.Point(835, 395);
            this.btn_Settings.Name = "btn_Settings";
            this.btn_Settings.Size = new System.Drawing.Size(82, 43);
            this.btn_Settings.TabIndex = 22;
            this.btn_Settings.Text = "Settings";
            this.btn_Settings.UseVisualStyleBackColor = true;
            this.btn_Settings.Click += new System.EventHandler(this.Btn_Settings_Click);
            // 
            // pic_ProfilePicture
            // 
            this.pic_ProfilePicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_ProfilePicture.Location = new System.Drawing.Point(598, 395);
            this.pic_ProfilePicture.Name = "pic_ProfilePicture";
            this.pic_ProfilePicture.Size = new System.Drawing.Size(43, 43);
            this.pic_ProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_ProfilePicture.TabIndex = 7;
            this.pic_ProfilePicture.TabStop = false;
            // 
            // lbl_ChatStatus
            // 
            this.lbl_ChatStatus.AutoSize = true;
            this.lbl_ChatStatus.Location = new System.Drawing.Point(647, 405);
            this.lbl_ChatStatus.Name = "lbl_ChatStatus";
            this.lbl_ChatStatus.Size = new System.Drawing.Size(131, 23);
            this.lbl_ChatStatus.TabIndex = 0;
            this.lbl_ChatStatus.Text = "Chat connected";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(933, 444);
            this.Controls.Add(this.lbl_ChatStatus);
            this.Controls.Add(this.pic_ProfilePicture);
            this.Controls.Add(this.btn_Settings);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.lbl_CharAnimStatus);
            this.Controls.Add(this.btn_RemoveTrigger);
            this.Controls.Add(this.tab_TriggerDetails);
            this.Controls.Add(this.btn_AddTrigger);
            this.Controls.Add(this.dgv_Triggers);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Triggleh v1.0 by thefyrewire (@MikeyHay)";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Triggers)).EndInit();
            this.tab_TriggerDetails.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Cooldown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Bits2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Bits1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ProfilePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Triggers;
        private System.Windows.Forms.Button btn_AddTrigger;
        private System.Windows.Forms.TabControl tab_TriggerDetails;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lbl_Keywords;
        private System.Windows.Forms.Label lbl_UserLevel;
        private System.Windows.Forms.Label lbl_Bits;
        private System.Windows.Forms.Label lbl_TriggerName;
        private System.Windows.Forms.ListBox lst_Keywords;
        private System.Windows.Forms.TextBox txt_Keywords;
        private System.Windows.Forms.Button btn_RemoveKeyword;
        private System.Windows.Forms.Button btn_AddKeyword;
        private System.Windows.Forms.CheckBox chk_Bits;
        private System.Windows.Forms.ComboBox cmb_Bits;
        private System.Windows.Forms.CheckBox chk_ULMods;
        private System.Windows.Forms.CheckBox chk_ULSubs;
        private System.Windows.Forms.CheckBox chk_ULEveryone;
        private System.Windows.Forms.TextBox txt_TriggerName;
        private System.Windows.Forms.Label lbl_BitsInfo2;
        private System.Windows.Forms.Label lbl_BitsInfo1;
        private System.Windows.Forms.NumericUpDown nud_Bits1;
        private System.Windows.Forms.NumericUpDown nud_Bits2;
        private System.Windows.Forms.Label lbl_CHTrigger;
        private System.Windows.Forms.Button btn_SaveTrigger;
        private System.Windows.Forms.Button btn_RecordTrigger;
        private System.Windows.Forms.Label lbl_CHTriggerKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_Name;
        private System.Windows.Forms.Button btn_RemoveTrigger;
        private System.Windows.Forms.Label lbl_CharAnimStatus;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.Button btn_Settings;
        private System.Windows.Forms.PictureBox pic_ProfilePicture;
        private System.Windows.Forms.Label lbl_ChatStatus;
        private System.Windows.Forms.Label lbl_ValidationError;
        private System.Windows.Forms.ComboBox cmb_CooldownUnit;
        private System.Windows.Forms.Label lbl_Cooldown;
        private System.Windows.Forms.NumericUpDown nud_Cooldown;
        private System.Windows.Forms.Label lbl_LastTriggeredAt;
        private System.Windows.Forms.Label lbl_LastTriggered;
        private System.Windows.Forms.Button btn_ResetLastTriggered;
    }
}

