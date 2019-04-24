using DevExpress.XtraEditors;

namespace CruiseSearchAdmin.Forms.SaleManagement
{
    partial class FormSaleManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSaleManagement));
            this.gcDiscount = new DevExpress.XtraGrid.GridControl();
            this.gvDiscount = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCruiseLineName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcShipName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDateBegin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDateEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcActionText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gcDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDiscount)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gcDiscount
            // 
            this.gcDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcDiscount.Location = new System.Drawing.Point(3, 46);
            this.gcDiscount.MainView = this.gvDiscount;
            this.gcDiscount.Name = "gcDiscount";
            this.gcDiscount.Size = new System.Drawing.Size(814, 287);
            this.gcDiscount.TabIndex = 0;
            this.gcDiscount.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDiscount});
            // 
            // gvDiscount
            // 
            this.gvDiscount.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcName,
            this.gcCruiseLineName,
            this.gcShipName,
            this.gcValue,
            this.gcDateBegin,
            this.gcDateEnd,
            this.gcActionText});
            this.gvDiscount.GridControl = this.gcDiscount;
            this.gvDiscount.Name = "gvDiscount";
            this.gvDiscount.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gvDiscount_RowCellClick);
            this.gvDiscount.DoubleClick += new System.EventHandler(this.gvDiscount_DoubleClick);
            // 
            // gcName
            // 
            this.gcName.Caption = "Название";
            this.gcName.FieldName = "Text";
            this.gcName.MaxWidth = 300;
            this.gcName.MinWidth = 200;
            this.gcName.Name = "gcName";
            this.gcName.OptionsColumn.AllowEdit = false;
            this.gcName.Visible = true;
            this.gcName.VisibleIndex = 0;
            this.gcName.Width = 200;
            // 
            // gcCruiseLineName
            // 
            this.gcCruiseLineName.Caption = "Круизная компания";
            this.gcCruiseLineName.FieldName = "CruiseLine.EnName";
            this.gcCruiseLineName.MaxWidth = 250;
            this.gcCruiseLineName.MinWidth = 150;
            this.gcCruiseLineName.Name = "gcCruiseLineName";
            this.gcCruiseLineName.OptionsColumn.AllowEdit = false;
            this.gcCruiseLineName.Visible = true;
            this.gcCruiseLineName.VisibleIndex = 1;
            this.gcCruiseLineName.Width = 150;
            // 
            // gcShipName
            // 
            this.gcShipName.Caption = "Лайнер";
            this.gcShipName.FieldName = "Ship.Name";
            this.gcShipName.MaxWidth = 150;
            this.gcShipName.MinWidth = 150;
            this.gcShipName.Name = "gcShipName";
            this.gcShipName.OptionsColumn.AllowEdit = false;
            this.gcShipName.Visible = true;
            this.gcShipName.VisibleIndex = 2;
            this.gcShipName.Width = 150;
            // 
            // gcValue
            // 
            this.gcValue.AppearanceCell.Options.UseTextOptions = true;
            this.gcValue.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gcValue.Caption = "Скидка";
            this.gcValue.FieldName = "StrValue";
            this.gcValue.MaxWidth = 50;
            this.gcValue.MinWidth = 50;
            this.gcValue.Name = "gcValue";
            this.gcValue.OptionsColumn.AllowEdit = false;
            this.gcValue.Visible = true;
            this.gcValue.VisibleIndex = 3;
            this.gcValue.Width = 50;
            // 
            // gcDateBegin
            // 
            this.gcDateBegin.Caption = "Дата начала";
            this.gcDateBegin.DisplayFormat.FormatString = "d";
            this.gcDateBegin.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcDateBegin.FieldName = "DateBegin";
            this.gcDateBegin.MaxWidth = 100;
            this.gcDateBegin.MinWidth = 100;
            this.gcDateBegin.Name = "gcDateBegin";
            this.gcDateBegin.OptionsColumn.AllowEdit = false;
            this.gcDateBegin.Visible = true;
            this.gcDateBegin.VisibleIndex = 4;
            this.gcDateBegin.Width = 100;
            // 
            // gcDateEnd
            // 
            this.gcDateEnd.Caption = "Дата окончания";
            this.gcDateEnd.DisplayFormat.FormatString = "d";
            this.gcDateEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcDateEnd.FieldName = "DateEnd";
            this.gcDateEnd.MaxWidth = 100;
            this.gcDateEnd.MinWidth = 100;
            this.gcDateEnd.Name = "gcDateEnd";
            this.gcDateEnd.OptionsColumn.AllowEdit = false;
            this.gcDateEnd.Visible = true;
            this.gcDateEnd.VisibleIndex = 5;
            this.gcDateEnd.Width = 100;
            // 
            // gcActionText
            // 
            this.gcActionText.Caption = "ActionText";
            this.gcActionText.FieldName = "Action.Text";
            this.gcActionText.MaxWidth = 150;
            this.gcActionText.MinWidth = 150;
            this.gcActionText.Name = "gcActionText";
            this.gcActionText.OptionsColumn.AllowEdit = false;
            this.gcActionText.Width = 150;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnCopy);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnRemove);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.gcDiscount);
            this.groupBox1.Location = new System.Drawing.Point(10, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(819, 336);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Скидки";
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.Image = global::CruiseSearchAdmin.Properties.Resources.copy;
            this.btnCopy.Location = new System.Drawing.Point(722, 12);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(26, 28);
            this.btnCopy.TabIndex = 4;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Image = global::CruiseSearchAdmin.Properties.Resources.tag_blue_edit;
            this.btnEdit.Location = new System.Drawing.Point(753, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(27, 28);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Image = global::CruiseSearchAdmin.Properties.Resources.delete;
            this.btnRemove.Location = new System.Drawing.Point(5, 12);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(28, 28);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Image = global::CruiseSearchAdmin.Properties.Resources.add;
            this.btnAdd.Location = new System.Drawing.Point(785, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(29, 28);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(752, 354);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 30);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // FormSaleManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 405);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSaleManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Управление продажами";
            this.Load += new System.EventHandler(this.FormSaleManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDiscount)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcDiscount;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDiscount;
        private DevExpress.XtraGrid.Columns.GridColumn gcName;
        private DevExpress.XtraGrid.Columns.GridColumn gcCruiseLineName;
        private DevExpress.XtraGrid.Columns.GridColumn gcShipName;
        private DevExpress.XtraGrid.Columns.GridColumn gcValue;
        private DevExpress.XtraGrid.Columns.GridColumn gcDateBegin;
        private DevExpress.XtraGrid.Columns.GridColumn gcDateEnd;
        private DevExpress.XtraGrid.Columns.GridColumn gcActionText;
        private System.Windows.Forms.GroupBox groupBox1;
        //private DevExpress.XtraEditors.SimpleButton btnBack;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCopy;
        
    }
}