
namespace TP_DSI.Presentacion
{
    partial class Frm_seguro_Cancelar
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
            this.btn_NO = new System.Windows.Forms.Button();
            this.btn_SI = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_NO
            // 
            this.btn_NO.BackColor = System.Drawing.Color.Tan;
            this.btn_NO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NO.Location = new System.Drawing.Point(152, 49);
            this.btn_NO.Margin = new System.Windows.Forms.Padding(2);
            this.btn_NO.Name = "btn_NO";
            this.btn_NO.Size = new System.Drawing.Size(72, 36);
            this.btn_NO.TabIndex = 5;
            this.btn_NO.Text = "Volver";
            this.btn_NO.UseVisualStyleBackColor = false;
            this.btn_NO.Click += new System.EventHandler(this.btn_NO_Click);
            // 
            // btn_SI
            // 
            this.btn_SI.BackColor = System.Drawing.Color.Tan;
            this.btn_SI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SI.Location = new System.Drawing.Point(46, 49);
            this.btn_SI.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SI.Name = "btn_SI";
            this.btn_SI.Size = new System.Drawing.Size(76, 36);
            this.btn_SI.TabIndex = 4;
            this.btn_SI.Text = "Si";
            this.btn_SI.UseVisualStyleBackColor = false;
            this.btn_SI.Click += new System.EventHandler(this.btn_SI_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Seguro/a que desea Cancelar?";
            // 
            // Frm_seguro_Cancelar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(285, 101);
            this.Controls.Add(this.btn_NO);
            this.Controls.Add(this.btn_SI);
            this.Controls.Add(this.label1);
            this.Name = "Frm_seguro_Cancelar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atención";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_NO;
        private System.Windows.Forms.Button btn_SI;
        private System.Windows.Forms.Label label1;
    }
}