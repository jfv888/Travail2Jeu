namespace Travail_2_Jeu
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.EnemiesWalkAnimationTimer = new System.Windows.Forms.Timer(this.components);
            this.PlayerWalkAnimationTimer = new System.Windows.Forms.Timer(this.components);
            this.CastCooldown = new System.Windows.Forms.Timer(this.components);
            this.EnemySpawnTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 15;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // EnemiesWalkAnimationTimer
            // 
            this.EnemiesWalkAnimationTimer.Interval = 250;
            this.EnemiesWalkAnimationTimer.Tick += new System.EventHandler(this.EnemiesWalkAnimationTimer_Tick);
            // 
            // PlayerWalkAnimationTimer
            // 
            this.PlayerWalkAnimationTimer.Interval = 250;
            this.PlayerWalkAnimationTimer.Tick += new System.EventHandler(this.PlayerWalkAnimationTimer_Tick);
            // 
            // CastCooldown
            // 
            this.CastCooldown.Interval = 500;
            this.CastCooldown.Tick += new System.EventHandler(this.CastCooldown_Tick);
            // 
            // EnemySpawnTimer
            // 
            this.EnemySpawnTimer.Interval = 1000;
            this.EnemySpawnTimer.Tick += new System.EventHandler(this.EnemySpawnTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Timer EnemiesWalkAnimationTimer;
        private System.Windows.Forms.Timer PlayerWalkAnimationTimer;
        private System.Windows.Forms.Timer CastCooldown;
        private System.Windows.Forms.Timer EnemySpawnTimer;
    }
}

