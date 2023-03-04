using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace FangameUtil
{

    internal class SaveBackup
    {
        FileSystemWatcher _watcher = new FileSystemWatcher();
        volatile string _dir;
        volatile int _maxFileSize = 4096;
        volatile int _maxBackups = 100;

        public string Dir { set { _watcher.EnableRaisingEvents = false; _dir = value; SetupWatcher(value); } }
        public int MaxFileSize { set => _maxFileSize = value; }
        public int MaxBackups { set => _maxBackups = value; }

        const string BackupDirName = "FangameUtilBackup";
        const string BackupFileStem = "save";
        const string BackupFileExtension = ".zip";

        public SaveBackup()
        {
            _watcher = new FileSystemWatcher
            {
                NotifyFilter = NotifyFilters.Attributes
                                  | NotifyFilters.CreationTime
                                  | NotifyFilters.DirectoryName
                                  | NotifyFilters.FileName
                                  | NotifyFilters.LastAccess
                                  | NotifyFilters.LastWrite
                                  | NotifyFilters.Security
                                  | NotifyFilters.Size
            };

            _watcher.Changed += OnChanged;
            _watcher.Created += OnCreated;
            _watcher.Deleted += OnDeleted;
            _watcher.Renamed += OnRenamed;
        }

        void SetupWatcher(string dir)
        {
            var backupDir = Path.Combine(dir, BackupDirName);
            Directory.CreateDirectory(backupDir);
            _watcher.Path = dir;
            _watcher.EnableRaisingEvents = true;
        }

        void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.Name.Contains(BackupDirName))
                return;

            Backup();
        }

        void OnCreated(object sender, FileSystemEventArgs e)
        {
            if (e.Name.Contains(BackupDirName))
                return;

            Backup();
        }

        void OnDeleted(object sender, FileSystemEventArgs e)
        {
            if (e.Name.Contains(BackupDirName))
                return;

            Backup();
        }

        void OnRenamed(object sender, RenamedEventArgs e)
        {
            if (e.Name.Contains(BackupDirName))
                return;

            Backup();
        }

        void Rotate(string dir)
        {
            var backupDir = Path.Combine(dir, BackupDirName);
            int maxBackups = _maxBackups;
            if (0 == maxBackups)
                return;

            try
            {
                {
                    var oldestBackup = Path.Combine(backupDir, $"{BackupFileStem}_{maxBackups}{BackupFileExtension}");
                    if (File.Exists(oldestBackup))
                        File.Delete(oldestBackup);
                }

                for (int i = maxBackups; i > 0; i--)
                {
                    var newPath = Path.Combine(backupDir, $"{BackupFileStem}_{i}{BackupFileExtension}");
                    var oldPath = i == 1 ? Path.Combine(backupDir, BackupFileStem + BackupFileExtension) : Path.Combine(backupDir, $"{BackupFileStem}_{i - 1}{BackupFileExtension}");
                    if (File.Exists(oldPath))
                    {
                        File.Move(oldPath, newPath);
                    }
                }
            }
            catch(Exception)
            {
            }
        }

        void Backup()
        {
            string dir = _dir;
            if (!(dir is object))
                return;

            Rotate(dir);
            try
            {
                var backupPath = Path.Combine(dir, BackupDirName, BackupFileStem + BackupFileExtension);
                if (File.Exists(backupPath))
                {
                    File.Delete(backupPath);
                }

                using (ZipArchive backupArchive = ZipFile.Open(backupPath, ZipArchiveMode.Create))
                {
                    foreach (var path in Directory.GetFiles(dir))
                    {
                        try
                        {
                            FileInfo fileInfo = new FileInfo(path);
                            if (!fileInfo.Exists)
                                continue;

                            if (fileInfo.Length > _maxFileSize)
                                continue;

                            if (fileInfo.Name.Contains(BackupDirName))
                                continue;

                            var content = File.ReadAllBytes(path);
                            ZipArchiveEntry entry = backupArchive.CreateEntry(fileInfo.Name);
                            using (StreamWriter writer = new StreamWriter(entry.Open()))
                            {
                                writer.Write(content);
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
