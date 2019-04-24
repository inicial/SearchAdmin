namespace CruiseSearchAdmin.Forms.Itinerary
{
    partial class FormRegionsByItinerary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegionsByItinerary));
            this.clbRegions = new System.Windows.Forms.CheckedListBox();
            this.tbItinerary = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbCrLine = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tbShip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDuration = new System.Windows.Forms.TextBox();
            this.cbCruiseDate = new System.Windows.Forms.ComboBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpRegions = new System.Windows.Forms.TabPage();
            this.btnRegeonRedactor = new System.Windows.Forms.Button();
            this.tvRegions = new System.Windows.Forms.TreeView();
            this.tpActions = new System.Windows.Forms.TabPage();
            this.tvAction = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnRemoveAction = new System.Windows.Forms.Button();
            this.btnAddAction = new System.Windows.Forms.Button();
            this.tpSpecialOffers = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbPeresadka = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbTo = new System.Windows.Forms.TextBox();
            this.tbFrom = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbPaket = new System.Windows.Forms.ComboBox();
            this.tbCostFly = new System.Windows.Forms.TextBox();
            this.tbTimeFly = new System.Windows.Forms.TextBox();
            this.tbTemp = new System.Windows.Forms.TextBox();
            this.tbCountrys = new System.Windows.Forms.TextBox();
            this.tbCitys = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnRenameSpecOffer = new System.Windows.Forms.Button();
            this.btnRemSpecOffer = new System.Windows.Forms.Button();
            this.btnAddSpecOffer = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbSpecialOffers = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbCost = new System.Windows.Forms.TextBox();
            this.chbHasSO = new System.Windows.Forms.CheckBox();
            this.clbActions = new System.Windows.Forms.CheckedListBox();
            this.gbMap = new System.Windows.Forms.GroupBox();
            this.btnSaveMap = new System.Windows.Forms.Button();
            this.btnRefreshMap = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.pbMap = new System.Windows.Forms.PictureBox();
            this.formErorrProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl.SuspendLayout();
            this.tpRegions.SuspendLayout();
            this.tpActions.SuspendLayout();
            this.tpSpecialOffers.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formErorrProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // clbRegions
            // 
            this.clbRegions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbRegions.FormattingEnabled = true;
            this.clbRegions.Location = new System.Drawing.Point(26, 111);
            this.clbRegions.Name = "clbRegions";
            this.clbRegions.Size = new System.Drawing.Size(330, 64);
            this.clbRegions.TabIndex = 0;
            this.clbRegions.Visible = false;
            this.clbRegions.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbRegions_ItemCheck);
            // 
            // tbItinerary
            // 
            this.tbItinerary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tbItinerary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbItinerary.Location = new System.Drawing.Point(12, 111);
            this.tbItinerary.Multiline = true;
            this.tbItinerary.Name = "tbItinerary";
            this.tbItinerary.ReadOnly = true;
            this.tbItinerary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbItinerary.Size = new System.Drawing.Size(438, 116);
            this.tbItinerary.TabIndex = 5;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(659, 419);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "Применить";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(740, 419);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Назад";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbCrLine
            // 
            this.tbCrLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbCrLine.Location = new System.Drawing.Point(113, 26);
            this.tbCrLine.Name = "tbCrLine";
            this.tbCrLine.ReadOnly = true;
            this.tbCrLine.Size = new System.Drawing.Size(226, 20);
            this.tbCrLine.TabIndex = 5;
            this.tbCrLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPort
            // 
            this.tbPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPort.Location = new System.Drawing.Point(12, 66);
            this.tbPort.Name = "tbPort";
            this.tbPort.ReadOnly = true;
            this.tbPort.Size = new System.Drawing.Size(217, 20);
            this.tbPort.TabIndex = 6;
            this.tbPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbShip
            // 
            this.tbShip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbShip.Location = new System.Drawing.Point(235, 66);
            this.tbShip.Name = "tbShip";
            this.tbShip.ReadOnly = true;
            this.tbShip.Size = new System.Drawing.Size(215, 20);
            this.tbShip.TabIndex = 7;
            this.tbShip.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Дата";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Компания";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(90, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Порт";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(311, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Лайнер";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(341, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Продолжительность";
            // 
            // tbDuration
            // 
            this.tbDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbDuration.Location = new System.Drawing.Point(344, 26);
            this.tbDuration.Name = "tbDuration";
            this.tbDuration.ReadOnly = true;
            this.tbDuration.Size = new System.Drawing.Size(106, 20);
            this.tbDuration.TabIndex = 13;
            this.tbDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbCruiseDate
            // 
            this.cbCruiseDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCruiseDate.FormattingEnabled = true;
            this.cbCruiseDate.Location = new System.Drawing.Point(12, 26);
            this.cbCruiseDate.Name = "cbCruiseDate";
            this.cbCruiseDate.Size = new System.Drawing.Size(97, 21);
            this.cbCruiseDate.TabIndex = 15;
            this.cbCruiseDate.SelectedIndexChanged += new System.EventHandler(this.cbCruiseDate_SelectedIndexChanged);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tpRegions);
            this.tabControl.Controls.Add(this.tpActions);
            this.tabControl.Controls.Add(this.tpSpecialOffers);
            this.tabControl.Location = new System.Drawing.Point(456, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(358, 401);
            this.tabControl.TabIndex = 16;
            // 
            // tpRegions
            // 
            this.tpRegions.Controls.Add(this.btnRegeonRedactor);
            this.tpRegions.Controls.Add(this.tvRegions);
            this.tpRegions.Location = new System.Drawing.Point(4, 22);
            this.tpRegions.Name = "tpRegions";
            this.tpRegions.Padding = new System.Windows.Forms.Padding(3);
            this.tpRegions.Size = new System.Drawing.Size(350, 375);
            this.tpRegions.TabIndex = 0;
            this.tpRegions.Text = "Регионы";
            this.tpRegions.UseVisualStyleBackColor = true;
            // 
            // btnRegeonRedactor
            // 
            this.btnRegeonRedactor.Location = new System.Drawing.Point(172, 3);
            this.btnRegeonRedactor.Name = "btnRegeonRedactor";
            this.btnRegeonRedactor.Size = new System.Drawing.Size(172, 23);
            this.btnRegeonRedactor.TabIndex = 16;
            this.btnRegeonRedactor.Text = "Редактировать регионы";
            this.btnRegeonRedactor.UseVisualStyleBackColor = true;
            this.btnRegeonRedactor.Click += new System.EventHandler(this.btnRegeonRedactor_Click);
            // 
            // tvRegions
            // 
            this.tvRegions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvRegions.Location = new System.Drawing.Point(7, 32);
            this.tvRegions.Name = "tvRegions";
            this.tvRegions.Size = new System.Drawing.Size(337, 332);
            this.tvRegions.TabIndex = 15;
            this.tvRegions.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvRegions_AfterCheck);
            // 
            // tpActions
            // 
            this.tpActions.Controls.Add(this.tvAction);
            this.tpActions.Controls.Add(this.button1);
            this.tpActions.Controls.Add(this.btnRemoveAction);
            this.tpActions.Controls.Add(this.btnAddAction);
            this.tpActions.Location = new System.Drawing.Point(4, 22);
            this.tpActions.Name = "tpActions";
            this.tpActions.Padding = new System.Windows.Forms.Padding(3);
            this.tpActions.Size = new System.Drawing.Size(350, 375);
            this.tpActions.TabIndex = 1;
            this.tpActions.Text = "Круизы по тематике";
            this.tpActions.UseVisualStyleBackColor = true;
            // 
            // tvAction
            // 
            this.tvAction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvAction.Location = new System.Drawing.Point(6, 32);
            this.tvAction.Name = "tvAction";
            this.tvAction.Size = new System.Drawing.Size(338, 336);
            this.tvAction.TabIndex = 18;
            this.tvAction.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvAction_AfterCheck);
            // 
            // button1
            // 
            this.button1.Image = global::CruiseSearchAdmin.Properties.Resources.tag_blue_edit;
            this.button1.Location = new System.Drawing.Point(280, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 23);
            this.button1.TabIndex = 11;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnEditActions_Click);
            // 
            // btnRemoveAction
            // 
            this.btnRemoveAction.Image = global::CruiseSearchAdmin.Properties.Resources.delete;
            this.btnRemoveAction.Location = new System.Drawing.Point(6, 5);
            this.btnRemoveAction.Name = "btnRemoveAction";
            this.btnRemoveAction.Size = new System.Drawing.Size(29, 24);
            this.btnRemoveAction.TabIndex = 10;
            this.btnRemoveAction.UseVisualStyleBackColor = true;
            this.btnRemoveAction.Click += new System.EventHandler(this.btnRemoveAction_Click);
            // 
            // btnAddAction
            // 
            this.btnAddAction.Image = global::CruiseSearchAdmin.Properties.Resources.add;
            this.btnAddAction.Location = new System.Drawing.Point(317, 5);
            this.btnAddAction.Name = "btnAddAction";
            this.btnAddAction.Size = new System.Drawing.Size(27, 23);
            this.btnAddAction.TabIndex = 9;
            this.btnAddAction.UseVisualStyleBackColor = true;
            this.btnAddAction.Click += new System.EventHandler(this.btnAddAction_Click);
            // 
            // tpSpecialOffers
            // 
            this.tpSpecialOffers.Controls.Add(this.groupBox3);
            this.tpSpecialOffers.Controls.Add(this.btnRenameSpecOffer);
            this.tpSpecialOffers.Controls.Add(this.btnRemSpecOffer);
            this.tpSpecialOffers.Controls.Add(this.btnAddSpecOffer);
            this.tpSpecialOffers.Controls.Add(this.groupBox2);
            this.tpSpecialOffers.Controls.Add(this.groupBox1);
            this.tpSpecialOffers.Controls.Add(this.chbHasSO);
            this.tpSpecialOffers.Location = new System.Drawing.Point(4, 22);
            this.tpSpecialOffers.Name = "tpSpecialOffers";
            this.tpSpecialOffers.Padding = new System.Windows.Forms.Padding(3);
            this.tpSpecialOffers.Size = new System.Drawing.Size(350, 375);
            this.tpSpecialOffers.TabIndex = 2;
            this.tpSpecialOffers.Text = "Спецпредложения";
            this.tpSpecialOffers.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbPeresadka);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.tbTo);
            this.groupBox3.Controls.Add(this.tbFrom);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.cbPaket);
            this.groupBox3.Controls.Add(this.tbCostFly);
            this.groupBox3.Controls.Add(this.tbTimeFly);
            this.groupBox3.Controls.Add(this.tbTemp);
            this.groupBox3.Controls.Add(this.tbCountrys);
            this.groupBox3.Controls.Add(this.tbCitys);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(6, 153);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(338, 215);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // cbPeresadka
            // 
            this.cbPeresadka.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPeresadka.FormattingEnabled = true;
            this.cbPeresadka.Location = new System.Drawing.Point(171, 191);
            this.cbPeresadka.Name = "cbPeresadka";
            this.cbPeresadka.Size = new System.Drawing.Size(162, 21);
            this.cbPeresadka.TabIndex = 18;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 199);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 13);
            this.label14.TabIndex = 17;
            this.label14.Text = "Пересадок ";
            // 
            // tbTo
            // 
            this.tbTo.Location = new System.Drawing.Point(170, 170);
            this.tbTo.Name = "tbTo";
            this.tbTo.Size = new System.Drawing.Size(162, 20);
            this.tbTo.TabIndex = 16;
            // 
            // tbFrom
            // 
            this.tbFrom.Location = new System.Drawing.Point(170, 147);
            this.tbFrom.Name = "tbFrom";
            this.tbFrom.Size = new System.Drawing.Size(163, 20);
            this.tbFrom.TabIndex = 15;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 173);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "Куда";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 147);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Откудо";
            // 
            // cbPaket
            // 
            this.cbPaket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPaket.FormattingEnabled = true;
            this.cbPaket.Location = new System.Drawing.Point(169, 120);
            this.cbPaket.Name = "cbPaket";
            this.cbPaket.Size = new System.Drawing.Size(163, 21);
            this.cbPaket.TabIndex = 11;
            // 
            // tbCostFly
            // 
            this.tbCostFly.Location = new System.Drawing.Point(170, 94);
            this.tbCostFly.Name = "tbCostFly";
            this.tbCostFly.Size = new System.Drawing.Size(163, 20);
            this.tbCostFly.TabIndex = 10;
            // 
            // tbTimeFly
            // 
            this.tbTimeFly.Location = new System.Drawing.Point(169, 73);
            this.tbTimeFly.Name = "tbTimeFly";
            this.tbTimeFly.Size = new System.Drawing.Size(163, 20);
            this.tbTimeFly.TabIndex = 9;
            // 
            // tbTemp
            // 
            this.tbTemp.Location = new System.Drawing.Point(169, 52);
            this.tbTemp.Name = "tbTemp";
            this.tbTemp.Size = new System.Drawing.Size(163, 20);
            this.tbTemp.TabIndex = 8;
            // 
            // tbCountrys
            // 
            this.tbCountrys.Location = new System.Drawing.Point(169, 29);
            this.tbCountrys.Name = "tbCountrys";
            this.tbCountrys.Size = new System.Drawing.Size(163, 20);
            this.tbCountrys.TabIndex = 7;
            // 
            // tbCitys
            // 
            this.tbCitys.Location = new System.Drawing.Point(169, 8);
            this.tbCitys.Name = "tbCitys";
            this.tbCitys.Size = new System.Drawing.Size(163, 20);
            this.tbCitys.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 123);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(127, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Дополнительный пакет";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Стоимость полета";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Время полета";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Температура";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Кол-во Стран";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Кол-во Городов";
            // 
            // btnRenameSpecOffer
            // 
            this.btnRenameSpecOffer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRenameSpecOffer.Image = global::CruiseSearchAdmin.Properties.Resources.tag_blue_edit;
            this.btnRenameSpecOffer.Location = new System.Drawing.Point(278, 8);
            this.btnRenameSpecOffer.Name = "btnRenameSpecOffer";
            this.btnRenameSpecOffer.Size = new System.Drawing.Size(30, 21);
            this.btnRenameSpecOffer.TabIndex = 3;
            this.btnRenameSpecOffer.UseVisualStyleBackColor = true;
            // 
            // btnRemSpecOffer
            // 
            this.btnRemSpecOffer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemSpecOffer.Image = global::CruiseSearchAdmin.Properties.Resources.delete;
            this.btnRemSpecOffer.Location = new System.Drawing.Point(247, 8);
            this.btnRemSpecOffer.Name = "btnRemSpecOffer";
            this.btnRemSpecOffer.Size = new System.Drawing.Size(27, 21);
            this.btnRemSpecOffer.TabIndex = 2;
            this.btnRemSpecOffer.UseVisualStyleBackColor = true;
            // 
            // btnAddSpecOffer
            // 
            this.btnAddSpecOffer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSpecOffer.Image = global::CruiseSearchAdmin.Properties.Resources.add;
            this.btnAddSpecOffer.Location = new System.Drawing.Point(314, 8);
            this.btnAddSpecOffer.Name = "btnAddSpecOffer";
            this.btnAddSpecOffer.Size = new System.Drawing.Size(30, 21);
            this.btnAddSpecOffer.TabIndex = 1;
            this.btnAddSpecOffer.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cbSpecialOffers);
            this.groupBox2.Location = new System.Drawing.Point(5, 94);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(341, 53);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Спецпредложение";
            // 
            // cbSpecialOffers
            // 
            this.cbSpecialOffers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSpecialOffers.Enabled = false;
            this.cbSpecialOffers.FormattingEnabled = true;
            this.cbSpecialOffers.Location = new System.Drawing.Point(5, 19);
            this.cbSpecialOffers.Name = "cbSpecialOffers";
            this.cbSpecialOffers.Size = new System.Drawing.Size(171, 21);
            this.cbSpecialOffers.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbCost);
            this.groupBox1.Location = new System.Drawing.Point(6, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 53);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Базовая цена";
            // 
            // tbCost
            // 
            this.tbCost.Enabled = false;
            this.tbCost.Location = new System.Drawing.Point(5, 19);
            this.tbCost.Name = "tbCost";
            this.tbCost.Size = new System.Drawing.Size(171, 20);
            this.tbCost.TabIndex = 0;
            // 
            // chbHasSO
            // 
            this.chbHasSO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chbHasSO.AutoSize = true;
            this.chbHasSO.Location = new System.Drawing.Point(5, 12);
            this.chbHasSO.Name = "chbHasSO";
            this.chbHasSO.Size = new System.Drawing.Size(170, 17);
            this.chbHasSO.TabIndex = 0;
            this.chbHasSO.Text = "Включить спецпредложения";
            this.chbHasSO.UseVisualStyleBackColor = true;
            // 
            // clbActions
            // 
            this.clbActions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbActions.FormattingEnabled = true;
            this.clbActions.Location = new System.Drawing.Point(42, 169);
            this.clbActions.Name = "clbActions";
            this.clbActions.Size = new System.Drawing.Size(347, 34);
            this.clbActions.TabIndex = 0;
            this.clbActions.Visible = false;
            this.clbActions.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbActions_ItemCheck);
            // 
            // gbMap
            // 
            this.gbMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbMap.Controls.Add(this.btnSaveMap);
            this.gbMap.Controls.Add(this.btnRefreshMap);
            this.gbMap.Controls.Add(this.btnLoad);
            this.gbMap.Controls.Add(this.pbMap);
            this.gbMap.Location = new System.Drawing.Point(12, 233);
            this.gbMap.Name = "gbMap";
            this.gbMap.Size = new System.Drawing.Size(437, 180);
            this.gbMap.TabIndex = 17;
            this.gbMap.TabStop = false;
            this.gbMap.Text = "Карта";
            // 
            // btnSaveMap
            // 
            this.btnSaveMap.Image = global::CruiseSearchAdmin.Properties.Resources.save;
            this.btnSaveMap.Location = new System.Drawing.Point(386, 127);
            this.btnSaveMap.Name = "btnSaveMap";
            this.btnSaveMap.Size = new System.Drawing.Size(46, 42);
            this.btnSaveMap.TabIndex = 3;
            this.btnSaveMap.UseVisualStyleBackColor = true;
            // 
            // btnRefreshMap
            // 
            this.btnRefreshMap.Image = global::CruiseSearchAdmin.Properties.Resources.reload;
            this.btnRefreshMap.Location = new System.Drawing.Point(200, 127);
            this.btnRefreshMap.Name = "btnRefreshMap";
            this.btnRefreshMap.Size = new System.Drawing.Size(46, 42);
            this.btnRefreshMap.TabIndex = 2;
            this.btnRefreshMap.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Image = global::CruiseSearchAdmin.Properties.Resources.folder;
            this.btnLoad.Location = new System.Drawing.Point(334, 127);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(46, 42);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.UseVisualStyleBackColor = true;
            // 
            // pbMap
            // 
            this.pbMap.ErrorImage = global::CruiseSearchAdmin.Properties.Resources.empty;
            this.pbMap.InitialImage = global::CruiseSearchAdmin.Properties.Resources.loading;
            this.pbMap.Location = new System.Drawing.Point(10, 19);
            this.pbMap.Name = "pbMap";
            this.pbMap.Size = new System.Drawing.Size(184, 150);
            this.pbMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMap.TabIndex = 0;
            this.pbMap.TabStop = false;
            // 
            // formErorrProvider
            // 
            this.formErorrProvider.ContainerControl = this;
            // 
            // FormRegionsByItinerary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 468);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.clbRegions);
            this.Controls.Add(this.cbCruiseDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.clbActions);
            this.Controls.Add(this.tbDuration);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbShip);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.tbCrLine);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbItinerary);
            this.Controls.Add(this.gbMap);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormRegionsByItinerary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование ";
            this.tabControl.ResumeLayout(false);
            this.tpRegions.ResumeLayout(false);
            this.tpActions.ResumeLayout(false);
            this.tpSpecialOffers.ResumeLayout(false);
            this.tpSpecialOffers.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formErorrProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbRegions;
        private System.Windows.Forms.TextBox tbItinerary;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbCrLine;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox tbShip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDuration;
        private System.Windows.Forms.ComboBox cbCruiseDate;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpRegions;
        private System.Windows.Forms.TabPage tpActions;
        private System.Windows.Forms.CheckedListBox clbActions;
        private System.Windows.Forms.Button btnRemoveAction;
        private System.Windows.Forms.Button btnAddAction;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox gbMap;
        private System.Windows.Forms.PictureBox pbMap;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnRefreshMap;
        private System.Windows.Forms.Button btnSaveMap;
        private System.Windows.Forms.TabPage tpSpecialOffers;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbCost;
        private System.Windows.Forms.CheckBox chbHasSO;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbSpecialOffers;
        private System.Windows.Forms.ErrorProvider formErorrProvider;
        private System.Windows.Forms.Button btnRemSpecOffer;
        private System.Windows.Forms.Button btnAddSpecOffer;
        private System.Windows.Forms.Button btnRenameSpecOffer;
        private System.Windows.Forms.TreeView tvRegions;
        private System.Windows.Forms.Button btnRegeonRedactor;
        private System.Windows.Forms.TreeView tvAction;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbPaket;
        private System.Windows.Forms.TextBox tbCostFly;
        private System.Windows.Forms.TextBox tbTimeFly;
        private System.Windows.Forms.TextBox tbTemp;
        private System.Windows.Forms.TextBox tbCountrys;
        private System.Windows.Forms.TextBox tbCitys;
        private System.Windows.Forms.TextBox tbTo;
        private System.Windows.Forms.TextBox tbFrom;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbPeresadka;
        private System.Windows.Forms.Label label14;
    }
}