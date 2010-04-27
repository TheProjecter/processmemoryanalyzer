namespace ProcessMemoryAnalyzerService
{
    partial class ProjectInstaller
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serviceProcessInstallerPMA = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstallerPMA = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceProcessInstallerPMA
            // 
            this.serviceProcessInstallerPMA.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceProcessInstallerPMA.Password = null;
            this.serviceProcessInstallerPMA.Username = null;
            // 
            // serviceInstallerPMA
            // 
            this.serviceInstallerPMA.Description = "Process Memory analyzer service";
            this.serviceInstallerPMA.DisplayName = "PMAService";
            this.serviceInstallerPMA.ServiceName = "PMAService";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstallerPMA,
            this.serviceInstallerPMA});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstallerPMA;
        private System.ServiceProcess.ServiceInstaller serviceInstallerPMA;
    }
}