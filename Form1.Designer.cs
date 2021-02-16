
namespace WindowsFormsApp1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.formBrand = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnStockIn = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.brandButton = new System.Windows.Forms.Button();
            this.categoryButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblRole = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonCategory = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.ForestGreen;
            this.panel1.Controls.Add(this.formBrand);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 40);
            this.panel1.TabIndex = 0;
            // 
            // formBrand
            // 
            this.formBrand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.formBrand.FlatAppearance.BorderSize = 0;
            this.formBrand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formBrand.ForeColor = System.Drawing.Color.White;
            this.formBrand.Location = new System.Drawing.Point(1141, 4);
            this.formBrand.Name = "formBrand";
            this.formBrand.Size = new System.Drawing.Size(31, 30);
            this.formBrand.TabIndex = 2;
            this.formBrand.Text = "X";
            this.formBrand.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.formBrand.UseVisualStyleBackColor = false;
            this.formBrand.Click += new System.EventHandler(this.formBrand_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.panel2.Controls.Add(this.btnStockIn);
            this.panel2.Controls.Add(this.lblName);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.button9);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.button8);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.brandButton);
            this.panel2.Controls.Add(this.categoryButton);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.lblRole);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 575);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnStockIn
            // 
            this.btnStockIn.FlatAppearance.BorderSize = 0;
            this.btnStockIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockIn.Font = new System.Drawing.Font("Sitka Small", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStockIn.ForeColor = System.Drawing.Color.White;
            this.btnStockIn.Location = new System.Drawing.Point(0, 305);
            this.btnStockIn.Name = "btnStockIn";
            this.btnStockIn.Size = new System.Drawing.Size(262, 45);
            this.btnStockIn.TabIndex = 12;
            this.btnStockIn.Text = "Stock Entry";
            this.btnStockIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStockIn.UseVisualStyleBackColor = true;
            this.btnStockIn.Click += new System.EventHandler(this.button5_Click);
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.SpringGreen;
            this.lblName.Location = new System.Drawing.Point(7, 132);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(279, 39);
            this.lblName.TabIndex = 1;
            this.lblName.Text = " Username";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblName.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Sitka Small", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(0, 203);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(262, 45);
            this.button1.TabIndex = 3;
            this.button1.Text = " Dashboard";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.Location = new System.Drawing.Point(0, 530);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(300, 45);
            this.button9.TabIndex = 11;
            this.button9.Text = " Logout";
            this.button9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Sitka Small", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(0, 475);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(262, 45);
            this.button7.TabIndex = 10;
            this.button7.Text = "User Settings";
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Sitka Small", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(0, 440);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(262, 45);
            this.button8.TabIndex = 9;
            this.button8.Text = "System Settings";
            this.button8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Sitka Small", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(0, 407);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(262, 45);
            this.button4.TabIndex = 8;
            this.button4.Text = "Records";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // brandButton
            // 
            this.brandButton.FlatAppearance.BorderSize = 0;
            this.brandButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.brandButton.Font = new System.Drawing.Font("Sitka Small", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brandButton.ForeColor = System.Drawing.Color.White;
            this.brandButton.Location = new System.Drawing.Point(0, 372);
            this.brandButton.Name = "brandButton";
            this.brandButton.Size = new System.Drawing.Size(262, 45);
            this.brandButton.TabIndex = 7;
            this.brandButton.Text = "Manage Brand";
            this.brandButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.brandButton.UseVisualStyleBackColor = true;
            this.brandButton.Click += new System.EventHandler(this.brandButton_Click);
            // 
            // categoryButton
            // 
            this.categoryButton.FlatAppearance.BorderSize = 0;
            this.categoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.categoryButton.Font = new System.Drawing.Font("Sitka Small", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryButton.ForeColor = System.Drawing.Color.White;
            this.categoryButton.Location = new System.Drawing.Point(0, 338);
            this.categoryButton.Name = "categoryButton";
            this.categoryButton.Size = new System.Drawing.Size(262, 45);
            this.categoryButton.TabIndex = 6;
            this.categoryButton.Text = "Manage Catagory";
            this.categoryButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.categoryButton.UseVisualStyleBackColor = true;
            this.categoryButton.Click += new System.EventHandler(this.bt_Click);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Sitka Small", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(0, 272);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(262, 45);
            this.button3.TabIndex = 5;
            this.button3.Text = "Manage Products";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Sitka Small", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(0, 237);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(262, 45);
            this.button2.TabIndex = 4;
            this.button2.Text = "POS";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblRole
            // 
            this.lblRole.ForeColor = System.Drawing.Color.White;
            this.lblRole.Location = new System.Drawing.Point(13, 161);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(265, 39);
            this.lblRole.TabIndex = 2;
            this.lblRole.Text = " Administrator";
            this.lblRole.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRole.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(107, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // buttonCategory
            // 
            this.buttonCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCategory.Location = new System.Drawing.Point(300, 40);
            this.buttonCategory.Name = "buttonCategory";
            this.buttonCategory.Size = new System.Drawing.Size(884, 575);
            this.buttonCategory.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1184, 615);
            this.ControlBox = false;
            this.Controls.Add(this.buttonCategory);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button brandButton;
		private System.Windows.Forms.Button categoryButton;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel buttonCategory;
        private System.Windows.Forms.Button btnStockIn;
        private System.Windows.Forms.Button formBrand;
        public System.Windows.Forms.Label lblName;
        public System.Windows.Forms.Label lblRole;
    }
}

