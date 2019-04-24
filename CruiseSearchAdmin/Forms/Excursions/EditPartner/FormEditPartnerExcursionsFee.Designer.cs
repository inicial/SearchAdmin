namespace CruiseSearchAdmin.Forms.Excursions.EditPartner
{
    partial class FormEditPartnerExcursionsFee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditPartnerExcursionsFee));
            this.dgcPartnerExcursionsFee = new DevExpress.XtraGrid.GridControl();
            this.gvPExFee = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcEtUId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.glueExType = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gluevExTypes = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcAdultID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.glueAdult = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gluevAdult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcChildId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.glueChild = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gluevChild = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcAdultFee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.glueAdultFee = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gluevAdultFee = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcChildFee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.glueChildFee = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gluevChildFee = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcTransport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.glueTransport = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gluevTransport = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.riExType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgcPartnerExcursionsFee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPExFee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.glueExType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gluevExTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.glueAdult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gluevAdult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.glueChild)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gluevChild)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.glueAdultFee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gluevAdultFee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.glueChildFee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gluevChildFee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.glueTransport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gluevTransport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riExType)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgcPartnerExcursionsFee
            // 
            this.dgcPartnerExcursionsFee.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgcPartnerExcursionsFee.Location = new System.Drawing.Point(3, 44);
            this.dgcPartnerExcursionsFee.MainView = this.gvPExFee;
            this.dgcPartnerExcursionsFee.Name = "dgcPartnerExcursionsFee";
            this.dgcPartnerExcursionsFee.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riExType,
            this.glueExType,
            this.glueAdult,
            this.glueChild,
            this.glueAdultFee,
            this.glueChildFee,
            this.glueTransport});
            this.dgcPartnerExcursionsFee.Size = new System.Drawing.Size(546, 196);
            this.dgcPartnerExcursionsFee.TabIndex = 0;
            this.dgcPartnerExcursionsFee.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPExFee});
            // 
            // gvPExFee
            // 
            this.gvPExFee.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcEtUId,
            this.gcAdultID,
            this.gcChildId,
            this.gcAdultFee,
            this.gcChildFee,
            this.gcTransport});
            this.gvPExFee.GridControl = this.dgcPartnerExcursionsFee;
            this.gvPExFee.Name = "gvPExFee";
            // 
            // gcEtUId
            // 
            this.gcEtUId.Caption = "Тип";
            this.gcEtUId.ColumnEdit = this.glueExType;
            this.gcEtUId.FieldName = "ExcursionTypeId";
            this.gcEtUId.Name = "gcEtUId";
            this.gcEtUId.Visible = true;
            this.gcEtUId.VisibleIndex = 0;
            // 
            // glueExType
            // 
            this.glueExType.AutoHeight = false;
            this.glueExType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.glueExType.Name = "glueExType";
            this.glueExType.View = this.gluevExTypes;
            // 
            // gluevExTypes
            // 
            this.gluevExTypes.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gluevExTypes.Name = "gluevExTypes";
            this.gluevExTypes.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gluevExTypes.OptionsView.ShowGroupPanel = false;
            // 
            // gcAdultID
            // 
            this.gcAdultID.Caption = "Услуга взрослый";
            this.gcAdultID.ColumnEdit = this.glueAdult;
            this.gcAdultID.FieldName = "AdultId";
            this.gcAdultID.Name = "gcAdultID";
            this.gcAdultID.Visible = true;
            this.gcAdultID.VisibleIndex = 1;
            // 
            // glueAdult
            // 
            this.glueAdult.AutoHeight = false;
            this.glueAdult.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.glueAdult.Name = "glueAdult";
            this.glueAdult.View = this.gluevAdult;
            // 
            // gluevAdult
            // 
            this.gluevAdult.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gluevAdult.Name = "gluevAdult";
            this.gluevAdult.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gluevAdult.OptionsView.ShowGroupPanel = false;
            // 
            // gcChildId
            // 
            this.gcChildId.Caption = "Услуга дети";
            this.gcChildId.ColumnEdit = this.glueChild;
            this.gcChildId.FieldName = "ChildId";
            this.gcChildId.Name = "gcChildId";
            this.gcChildId.Visible = true;
            this.gcChildId.VisibleIndex = 2;
            // 
            // glueChild
            // 
            this.glueChild.AutoHeight = false;
            this.glueChild.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.glueChild.Name = "glueChild";
            this.glueChild.View = this.gluevChild;
            // 
            // gluevChild
            // 
            this.gluevChild.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gluevChild.Name = "gluevChild";
            this.gluevChild.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gluevChild.OptionsView.ShowGroupPanel = false;
            // 
            // gcAdultFee
            // 
            this.gcAdultFee.Caption = "Комиссия взрослый";
            this.gcAdultFee.ColumnEdit = this.glueAdultFee;
            this.gcAdultFee.FieldName = "AdultFee";
            this.gcAdultFee.Name = "gcAdultFee";
            this.gcAdultFee.Visible = true;
            this.gcAdultFee.VisibleIndex = 3;
            // 
            // glueAdultFee
            // 
            this.glueAdultFee.AutoHeight = false;
            this.glueAdultFee.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.glueAdultFee.Name = "glueAdultFee";
            this.glueAdultFee.View = this.gluevAdultFee;
            // 
            // gluevAdultFee
            // 
            this.gluevAdultFee.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gluevAdultFee.Name = "gluevAdultFee";
            this.gluevAdultFee.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gluevAdultFee.OptionsView.ShowGroupPanel = false;
            // 
            // gcChildFee
            // 
            this.gcChildFee.Caption = "Комиссия дети";
            this.gcChildFee.ColumnEdit = this.glueChildFee;
            this.gcChildFee.FieldName = "ChildFee";
            this.gcChildFee.Name = "gcChildFee";
            this.gcChildFee.Visible = true;
            this.gcChildFee.VisibleIndex = 4;
            // 
            // glueChildFee
            // 
            this.glueChildFee.AutoHeight = false;
            this.glueChildFee.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.glueChildFee.Name = "glueChildFee";
            this.glueChildFee.View = this.gluevChildFee;
            // 
            // gluevChildFee
            // 
            this.gluevChildFee.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gluevChildFee.Name = "gluevChildFee";
            this.gluevChildFee.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gluevChildFee.OptionsView.ShowGroupPanel = false;
            // 
            // gcTransport
            // 
            this.gcTransport.Caption = "Транспорт";
            this.gcTransport.ColumnEdit = this.glueTransport;
            this.gcTransport.FieldName = "TransportId";
            this.gcTransport.Name = "gcTransport";
            this.gcTransport.Visible = true;
            this.gcTransport.VisibleIndex = 5;
            // 
            // glueTransport
            // 
            this.glueTransport.AutoHeight = false;
            this.glueTransport.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.glueTransport.Name = "glueTransport";
            this.glueTransport.View = this.gluevTransport;
            // 
            // gluevTransport
            // 
            this.gluevTransport.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gluevTransport.Name = "gluevTransport";
            this.gluevTransport.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gluevTransport.OptionsView.ShowGroupPanel = false;
            // 
            // riExType
            // 
            this.riExType.AutoHeight = false;
            this.riExType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riExType.Name = "riExType";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(488, 271);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnRemove);
            this.groupBox1.Controls.Add(this.btnCopy);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.dgcPartnerExcursionsFee);
            this.groupBox1.Location = new System.Drawing.Point(12, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(551, 243);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Услуги";
            // 
            // btnRemove
            // 
            this.btnRemove.Image = global::CruiseSearchAdmin.Properties.Resources.delete;
            this.btnRemove.Location = new System.Drawing.Point(5, 14);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(26, 24);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.Image = global::CruiseSearchAdmin.Properties.Resources.copy;
            this.btnCopy.Location = new System.Drawing.Point(484, 11);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(28, 27);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Image = global::CruiseSearchAdmin.Properties.Resources.add;
            this.btnAdd.Location = new System.Drawing.Point(518, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(28, 27);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(408, 271);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 30);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // FormEditPartnerExcursionsFee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 306);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormEditPartnerExcursionsFee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Цены";
            this.Load += new System.EventHandler(this.FormEditPartnerExcursionsFee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgcPartnerExcursionsFee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPExFee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.glueExType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gluevExTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.glueAdult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gluevAdult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.glueChild)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gluevChild)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.glueAdultFee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gluevAdultFee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.glueChildFee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gluevChildFee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.glueTransport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gluevTransport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riExType)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgcPartnerExcursionsFee;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPExFee;
        private DevExpress.XtraGrid.Columns.GridColumn gcEtUId;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox riExType;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit glueExType;
        private DevExpress.XtraGrid.Views.Grid.GridView gluevExTypes;
        private DevExpress.XtraGrid.Columns.GridColumn gcAdultID;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit glueAdult;
        private DevExpress.XtraGrid.Views.Grid.GridView gluevAdult;
        private DevExpress.XtraGrid.Columns.GridColumn gcChildId;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit glueChild;
        private DevExpress.XtraGrid.Views.Grid.GridView gluevChild;
        private DevExpress.XtraGrid.Columns.GridColumn gcAdultFee;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit glueAdultFee;
        private DevExpress.XtraGrid.Views.Grid.GridView gluevAdultFee;
        private DevExpress.XtraGrid.Columns.GridColumn gcChildFee;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit glueChildFee;
        private DevExpress.XtraGrid.Views.Grid.GridView gluevChildFee;
        private DevExpress.XtraGrid.Columns.GridColumn gcTransport;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit glueTransport;
        private DevExpress.XtraGrid.Views.Grid.GridView gluevTransport;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnBack;
    }
}