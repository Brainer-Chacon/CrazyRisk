namespace CrazyRisk.WinUI
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Controles del formulario
        private System.Windows.Forms.ListBox listBoxJugadores;
        private System.Windows.Forms.Button buttonTurno;
        private System.Windows.Forms.Panel panelMapa;
        private System.Windows.Forms.Label labelJugadores;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.listBoxJugadores = new System.Windows.Forms.ListBox();
            this.buttonTurno = new System.Windows.Forms.Button();
            this.panelMapa = new System.Windows.Forms.Panel();
            this.labelJugadores = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // 
            // panelMapa
            // 
            this.panelMapa.Location = new System.Drawing.Point(12, 12);
            this.panelMapa.Size = new System.Drawing.Size(500, 400);
            this.panelMapa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMapa.BackColor = System.Drawing.Color.Beige;

            // 
            // labelJugadores
            // 
            this.labelJugadores.Text = "Jugadores";
            this.labelJugadores.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelJugadores.Location = new System.Drawing.Point(530, 45);
            this.labelJugadores.AutoSize = true;

            // 
            // listBoxJugadores
            // 
            this.listBoxJugadores.FormattingEnabled = true;
            this.listBoxJugadores.ItemHeight = 15;
            this.listBoxJugadores.Location = new System.Drawing.Point(530, 70);
            this.listBoxJugadores.Size = new System.Drawing.Size(250, 300);
            this.listBoxJugadores.Name = "listBoxJugadores";
            this.listBoxJugadores.Font = new System.Drawing.Font("Segoe UI", 9F);

            // 
            // buttonTurno
            // 
            this.buttonTurno.Location = new System.Drawing.Point(530, 12);
            this.buttonTurno.Size = new System.Drawing.Size(250, 30);
            this.buttonTurno.Name = "buttonTurno";
            this.buttonTurno.Text = "Siguiente Turno";
            this.buttonTurno.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.buttonTurno.UseVisualStyleBackColor = true;
            this.buttonTurno.Click += new System.EventHandler(this.buttonTurno_Click);

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelMapa);
            this.Controls.Add(this.labelJugadores);
            this.Controls.Add(this.listBoxJugadores);
            this.Controls.Add(this.buttonTurno);
            this.Name = "Form1";
            this.Text = "Crazy Risk";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}