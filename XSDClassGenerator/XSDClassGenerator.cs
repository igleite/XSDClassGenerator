using System.Diagnostics;

namespace XSDClassGenerator
{
    public partial class XSDClassGenerator : Form
    {
        private const string XsdCommandTemplate = "xsd \"{0}\" \"{1}\" /classes /language:{2} /f /out:\"{3}\"";
        private const string SdkBinPath = @"C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.7.1 Tools\";
        private const string XmlSchemaFileExtension = ".xsd";
        private const string OutputDirectoryName = "ClassesXML";

        public XSDClassGenerator()
        {
            InitializeComponent();
            ConfigureForm();
        }

        private void ConfigureForm()
        {
            MaximizeBox = false;
            MinimizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;
            EnableControls(false);
        }

        private void GetDirectory_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                listagemDiretorios.Items.Add(folderBrowserDialog1.SelectedPath);
                EnableControls(true);
            }
        }

        private void DirectoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listagemDiretorios.SelectedItem != null)
            {
                listagemDiretorios.Items.Remove(listagemDiretorios.SelectedItem);
            }

            EnableControls(listagemDiretorios.Items.Count > 0);
        }

        private void Process_Click(object sender, EventArgs e)
        {
            if (listagemDiretorios.Items.Count == 0)
            {
                ShowErrorMessage("Selecione ao menos um diretório para continuar!");
                return;
            }

            if (!rdb_csharp.Checked && !rdb_vbnet.Checked)
            {
                ShowErrorMessage("Selecione ao menos uma opção para continuar!");
                return;
            }

            GenerateClassesFromXsdFilesAsync();
        }

        private async void GenerateClassesFromXsdFilesAsync()
        {
            try
            {
                string? extension = GetSelectedExtension();
                if (extension == null)
                {
                    ShowErrorMessage("Extensão não encontrada!");
                    return;
                }

                foreach (string directory in listagemDiretorios.Items)
                {
                    string[] xsdFiles = GetXsdFilesInDirectory(directory);
                    if (xsdFiles.Length == 0)
                    {
                        ShowSuccessMessage("Nenhum arquivo .xsd foi encontrado no diretório: " + directory);
                        continue;
                    }

                    progressBar.Maximum = xsdFiles.Length;
                    progressBar.Value = 0;

                    foreach (string xsdFile in xsdFiles)
                    {
                        progressBar.Value += 1;

                        string outputDirectory = Path.Combine(directory, OutputDirectoryName);
                        Directory.CreateDirectory(outputDirectory);

                        string xsdCommand = GetXsdCommand(xsdFile, extension);

                        await ExecuteCommandAsync("cmd.exe", xsdCommand);

                        string defaultOutputFilePath = GetDefaultOutputFilePath(outputDirectory, extension);
                        string desiredOutputFilePath = GetDesiredOutputFilePath(xsdFile, outputDirectory, extension);

                        bool fileCopied = await CopyFileWithRetryAsync(defaultOutputFilePath, desiredOutputFilePath);
                        if (!fileCopied)
                        {
                            ShowErrorMessage("Não foi possível copiar o arquivo: " + defaultOutputFilePath);
                            return;
                        }
                    }
                }

                ShowSuccessMessage("Classes geradas com sucesso!");
                progressBar.Value = 0;

            }
            catch (Exception ex)
            {
                progressBar.Value = 0;
                ShowErrorMessage(ex.Message);
            }
        }

        private string[] GetXsdFilesInDirectory(string directory)
        {
            return Directory.GetFiles(directory, "*" + XmlSchemaFileExtension, SearchOption.AllDirectories);
        }

        private string GetDefaultOutputFilePath(string outputDirectory, string extension)
        {
            return Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension("xmldsig-core-schema") + "." + extension);
        }

        private string GetDesiredOutputFilePath(string xsdFile, string outputDirectory, string extension)
        {
            string fileName = Path.GetFileName(xsdFile);
            return Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(fileName) + "." + extension);
        }

        private async Task<bool> CopyFileWithRetryAsync(string sourceFilePath, string destinationFilePath, int maxRetryAttempts = 3, int retryDelayMilliseconds = 100)
        {
            for (int retryCount = 0; retryCount < maxRetryAttempts; retryCount++)
            {
                try
                {
                    File.Copy(sourceFilePath, destinationFilePath, true);
                    File.Delete(sourceFilePath);
                    return true; // A cópia foi bem-sucedida, retorne true
                }
                catch (IOException)
                {
                    // O arquivo está sendo usado por outro processo, aguarde um curto período de tempo
                    await Task.Delay(retryDelayMilliseconds);
                }
            }

            return false; // Não foi possível copiar o arquivo
        }

        private string? GetSelectedExtension()
        {
            if (rdb_csharp.Checked)
            {
                return "cs";
            }
            else if (rdb_vbnet.Checked)
            {
                return "vb";
            }

            return null;
        }

        private string GetXsdCommand(string filePath, string extension)
        {
            string xsdPath = Path.Combine(Path.GetDirectoryName(filePath), "..", "xmldsig-core-schema.xsd");
            string outputDirectory = Path.Combine(Path.GetDirectoryName(filePath), OutputDirectoryName);

            return string.Format(XsdCommandTemplate, filePath, xsdPath, extension, outputDirectory);
        }

        private async Task ExecuteCommandAsync(string command, string arguments)
        {
            Process process = new Process();
            process.StartInfo.FileName = command;
            process.StartInfo.WorkingDirectory = SdkBinPath;
            process.StartInfo.Arguments = $"/C {arguments}";
            process.StartInfo.CreateNoWindow = true;

            process.Start();
            await process.WaitForExitAsync();
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowSuccessMessage(string message)
        {
            MessageBox.Show(message, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EnableControls(bool value)
        {
            processa.Enabled = value;
            rdb_csharp.Enabled = value;
            rdb_vbnet.Enabled = value;
        }
    }
}

