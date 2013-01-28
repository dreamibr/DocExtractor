// Project: DocExtractor Utility for SharePoint
// By Eng. Ibrahem A. Ibraheem 2012
// v1.0.0.0

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace DocExtractor
{
    public partial class DownloaderForm : Form
    {
        public List<string> FilesList;
        public Dictionary<string, int> FileCopies = new Dictionary<string, int>(200);
        public string OutputDir;
        DocExtractor de2;
        int FilesMissed, FilesDownloaded;
        float FilesProcessed;

        string DownloadType;

        public DownloaderForm(string SCurl, List<string> FileRefUrls, string DestDir, string WhatToDownload)
        {
            InitializeComponent();

            FilesList = FileRefUrls;
            OutputDir = DestDir;
            DownloadType = WhatToDownload;

            de2 = new DocExtractor();
            de2.SiteUrl = SCurl;
            progressBar1.Value = 0;
            FilesDownloaded = 0;
            FilesMissed = 0;
            FilesProcessed = 0;        
        }

        private void DownloaderForm_Load(object sender, EventArgs e)
        {
            // using backgroundworker thread
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            if (backgroundWorker1.IsBusy != true)
            {
                btnCancel.Enabled = true;
                btnClose.Enabled = false;

                // Start the asynchronous operation.
                backgroundWorker1.RunWorkerAsync();
            }
        }
        
        // Begin the downloading of files with the ability to cancel 
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
          
            string fileName = "";
            string diskFullPath = "";
            
            int FileCount = FilesList.Count;
            int ProgressValue = 0;
            float ProgressIndex = (float)FileCount / 100;
            
            string LogMsg = "***** DocExtractor for SharePoint Log File *****\r\n" +
                             "*****    V1.0.0.0 by Eng. Ibraheem 2012    *****\r\n" +
                             "************************************************\r\n\r\n" +
                             "Created at: " + System.DateTime.Now.ToString() + "\r\n" +
                             "Site Collection: " + de2.SiteUrl + "\r\n" +
                             "\r\n\r\n";
                            // enhancement: add the crieteria info

            string LogErrorFiles = "";

            if (DownloadType == "Files_and_Folders")
            {
                string FolderName = "";
                string[] UrlSplitArray;
                foreach (string relativeUrl in FilesList)
                {
                    diskFullPath = OutputDir;
                   
                    UrlSplitArray = relativeUrl.Split('/');
                    for (int i = 0; i < UrlSplitArray.Length - 1; i++)
                    {
                        FolderName = UrlSplitArray[i];
                        if (FolderName == "" || FolderName == null)
                        {
                            //FolderName = "Home";
                            i++; continue; // to neglect the '/Lists/' portion
                        }
                        diskFullPath += @"/" + FolderName;
                            
                        if (!File.Exists(diskFullPath))
                        {
                            System.IO.Directory.CreateDirectory(diskFullPath);  // create the dir
                        }                 
                    }
                    fileName = UrlSplitArray[UrlSplitArray.Length - 1]; // last item is the file name
                    diskFullPath += @"/" + fileName;

                    try
                    {
                        byte[] fileData = de2.getFileData(relativeUrl); // works for files in doc libs

                        using (FileStream outStream = new FileStream(diskFullPath, FileMode.Create))// create file in that directory
                        {
                            outStream.Write(fileData, 0, fileData.Count());
                            //outStream.Close();
                        }
                        
                        // prepare a row in log file
                        LogMsg += relativeUrl + " downloaded.\r\n";
                    }
                    catch (Exception ex)
                    {
                        // write file name and error msg in log file
                        LogErrorFiles += relativeUrl + " download failed: " + ex.Message + "\r\n";
                        
                        FilesMissed++;
                    }

                    // Updating progress bar
                    FilesProcessed++;
                    ProgressValue = (int)Math.Ceiling(FilesProcessed / ProgressIndex);
                    if (ProgressValue > 100) ProgressValue = 100;
                    worker.ReportProgress(ProgressValue);

                    // for cancelling the download by user
                    if (worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        break;
                    }

                }
            }
            else // if (DownloadType == "Files_only")
            {
                foreach (string relativeUrl in FilesList)
                {
                    fileName = relativeUrl.Substring(relativeUrl.LastIndexOf("/") + 1);
                    diskFullPath = OutputDir + fileName;

                    // make entry for each file count
                    try
                    {
                        FileCopies.Add(diskFullPath, 0); // 1st time for file
                    }
                    catch (ArgumentException)
                    {
                        FileCopies[diskFullPath] = FileCopies[diskFullPath] + 1; // file entry already exists
                    }

                    // make a file copy when file already exists in output dir
                    if (File.Exists(diskFullPath))
                    {
                        // add the "_Copy(x)" before the file extension
                        // ext = fileName.Substring(fileName.IndexOf('.')); // .jpg
                        // name_before_ext = fileName.Remove(fileName.LastIndexOf('.'))
                        diskFullPath = OutputDir + fileName.Remove(fileName.LastIndexOf('.')) + "_Copy(" + FileCopies[diskFullPath] + ")" + fileName.Substring(fileName.IndexOf('.'));
                    }

                    try
                    {
                        byte[] fileData = de2.getFileData(relativeUrl); // works for files in doc libs

                        using (FileStream outStream = new FileStream(diskFullPath, FileMode.Create))// create file in that directory
                        {
                            outStream.Write(fileData, 0, fileData.Count());
                            //outStream.Close();
                        }

                        // prepare a row in log file
                        LogMsg += relativeUrl + " downloaded.\r\n";
                    }
                    catch (Exception ex)
                    {
                        // write file name and error msg in log file
                        LogErrorFiles += relativeUrl + " download failed: " + ex.Message + "\r\n";

                        FilesMissed++;
                    }

                    // Updating progress bar
                    FilesProcessed++;
                    ProgressValue = (int)Math.Ceiling(FilesProcessed / ProgressIndex);
                    if (ProgressValue > 100) ProgressValue = 100;
                    worker.ReportProgress(ProgressValue);

                    // for cancelling the download by user
                    if (worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        break;
                    }

                }
            }
            
            // add the section for failed files in log
            LogMsg += "\r\n------------------------------ Files that failed to download ------------------------------\r\n";
            LogMsg += "\r\n- " + LogErrorFiles + "\r\n";
            LogMsg += "\r\n-------------------------------------------------------------------------------------------\r\n";

            LogMsg += "\r\nTotal number of files processed: " + FileCount.ToString() + " files\r\n";
            
            FilesDownloaded = (int)FilesProcessed - FilesMissed;
            LogMsg += "Total number of files downloaded: " + FilesDownloaded.ToString() + " files\r\n";

            // create the log file
            string LogPath = OutputDir + "_DocExtractor Log_" +
                             System.DateTime.Now.Year.ToString() + "_" + System.DateTime.Now.Month + "_" + System.DateTime.Now.Day +
                             ".txt";
            System.IO.File.WriteAllText(LogPath, LogMsg);

            FileCopies = null;
            FilesList = null;
            de2 = null;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // reflect progress on UI component
            progressBar1.Value = e.ProgressPercentage;

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnCancel.Enabled = false;
            btnClose.Enabled = true;

            if (e.Cancelled == true)
            {
                // download cancelled
                lDownloadStatus.ForeColor = Color.Blue ;
                lDownloadStatus.Text = "Only " + FilesDownloaded.ToString() + " files downloaded. \n\rFor details, please review the log file in specified Output Directory.";
            }
            else if (e.Error != null)
            {
                // download error
                lDownloadStatus.ForeColor = Color.Red;
                lDownloadStatus.Text = "An error occured. Only " + FilesDownloaded.ToString() + 
                    " files downloaded. \n\rFor details, please review the log file in specified Output Directory.";
            }
            else
            {
                // download complete
                lDownloadStatus.ForeColor = Color.Green;
                lDownloadStatus.Text = FilesDownloaded.ToString() + " out of " + FilesProcessed.ToString() +
                    " files downloaded successfully. \n\rFor details, please review the log file in specified Output Directory.";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // when downloading is cancelled before finished
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                backgroundWorker1.CancelAsync();
            }
        }

        
    }
}
