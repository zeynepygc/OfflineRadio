using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using OfflineRadio.Models;
using OfflineRadio.DataAccess;
using OfflineRadio.Utilities;
using System.Text.Json;
using System.Diagnostics;

namespace OfflineRadio.Forms
{
    public partial class MainForm : Form
    {
        private BindingList<RadioProgram> _programs;


        public MainForm()
        {
            InitializeComponent();
            var loadedPrograms = FileManager.LoadPrograms(); // Mevcut programları yükle
            _programs = new BindingList<RadioProgram>(loadedPrograms); // BindingList'e aktar
            dgvPrograms.DataSource = _programs; // DataGridView'e bağla
        }

        private void UpdateProgramList()
        {
            dgvPrograms.DataSource = null;
            dgvPrograms.DataSource = _programs;
        }

        private void btnAddProgram_Click(object sender, EventArgs e)
        {
            var addForm = new AddProgramForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                _programs.Add(addForm.NewProgram); // BindingList'e ekle
            }
        }


        private void btnRemoveProgram_Click(object sender, EventArgs e)
        {
            if (dgvPrograms.CurrentRow != null)
            {
                var selectedProgram = (RadioProgram)dgvPrograms.CurrentRow.DataBoundItem;
                _programs.Remove(selectedProgram);
            }
            else
            {
                MessageBox.Show("Please select a program to remove.", "Error");
            }
        }
        public class FFmpegDownloader
        {
            public string DownloadStream(string url, string outputPath)
            {

                string ffmpegPath = "ffmpeg";


                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    FileName = ffmpegPath,
                    Arguments = $"-i \"{url}\" -acodec libmp3lame -ab 128k -f mp3 \"{outputPath}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = new Process())
                {
                    process.StartInfo = processStartInfo;
                    process.Start();

                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    if (process.ExitCode != 0)
                    {
                        throw new Exception($"FFmpeg error: {error}");
                    }
                }

                return outputPath;
            }
        }


        private async void btnDownload_Click(object sender, EventArgs e)
        {
            if (dgvPrograms.CurrentRow != null)
            {
                var selectedProgram = (RadioProgram)dgvPrograms.CurrentRow.DataBoundItem;

                if (string.IsNullOrEmpty(selectedProgram.URL) || string.IsNullOrEmpty(selectedProgram.Title))
                {
                    MessageBox.Show("Invalid program data. Please check the URL and title.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    FFmpegDownloader downloader = new FFmpegDownloader();
                    string filePath = downloader.DownloadStream(selectedProgram.URL, $"{selectedProgram.Title}.mp3");

                    // Başarıyla indirildiyse, dosya yolunu kaydet
                    selectedProgram.FilePath = filePath;
                    selectedProgram.LastDownloaded = DateTime.Now;

                    MessageBox.Show($"Program downloaded successfully to: {filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to download program: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a program to download.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void RecordStream(string url, string outputPath)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "ffmpeg",
                    Arguments = $"-i \"{url}\" -c copy -t 00:10:00 \"{outputPath}\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };
            process.Start();
            process.WaitForExit();
        }

        private void PlayProgramWithFFmpeg(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                MessageBox.Show("This program is not downloaded yet or file does not exist. Please download it first.", "Error");
                return;
            }

            try
            {
                // FFmpeg ile çalma komutu
                var ffplayPath = "ffplay"; // FFmpeg/ffplay'in kurulu olduğu dizin, gerekirse tam yolu verin
                var process = new System.Diagnostics.Process
                {
                    StartInfo = new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = ffplayPath,
                        Arguments = $"-autoexit \"{filePath}\"", // -autoexit: Oynatma tamamlandığında kapanır
                        RedirectStandardOutput = false,
                        UseShellExecute = true,
                        CreateNoWindow = false
                    }
                };
                process.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while playing the file: {ex.Message}", "Error");
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (dgvPrograms.CurrentRow != null)
            {
                var selectedProgram = (RadioProgram)dgvPrograms.CurrentRow.DataBoundItem;

                if (!string.IsNullOrEmpty(selectedProgram.FilePath) && File.Exists(selectedProgram.FilePath))
                {
                    PlayProgramWithFFmpeg(selectedProgram.FilePath);
                }
                else
                {
                    MessageBox.Show("This program is not downloaded yet or file does not exist. Please download it first.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Please select a program to play.", "Error");
            }
        }




        private void dgvPrograms_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _programs.Count)
            {
                RadioProgram selectedProgram = _programs[e.RowIndex];

                // Seçilen programın dosya yolunu kontrol edin
                if (!string.IsNullOrEmpty(selectedProgram.FilePath) && File.Exists(selectedProgram.FilePath))
                {
                    PlayProgramWithFFmpeg(selectedProgram.FilePath);
                }
                else
                {
                    MessageBox.Show("This program is not downloaded yet or file does not exist. Please download it first.", "Error");
                }
            }
        }

    }
}





