/*
 *  Pkcs11Admin - GUI tool for administration of PKCS#11 enabled devices
 *  Copyright (c) 2014-2015 Jaroslav Imrich <jimrich@jimrich.sk>
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License version 3 
 *  as published by the Free Software Foundation.
 *  
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *  
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using Net.Pkcs11Admin.Configuration;
using Net.Pkcs11Interop.Common;
using System;
using System.IO;
using System.Net;
using System.Reflection;

namespace Net.Pkcs11Admin
{
    public class Pkcs11Admin : IDisposable
    {
        private bool _disposed = false;

        #region LoadLibrary parameters

        private string _pkcs11Library = null;
        private bool _enableLogging = false;
        private string _logFile = null;
        private bool _overwriteLogFile = false;
        private string _pkcs11Logger = null;
        private bool _enablePkcs11Logger = false;

        #endregion

        private object _logFileLock = new object();

        public string LogFile
        {
            get;
            private set;
        }

        public Pkcs11AdminConfig Config
        {
            get;
            private set;
        }

        public Pkcs11Library Library
        {
            get;
            private set;
        }

        public static readonly Pkcs11Admin Instance = new Pkcs11Admin();

        private Pkcs11Admin()
        {
            Config = Pkcs11AdminConfig.GetDefault();
        }

        public void LoadLibrary(string pkcs11Library, bool enableLogging, string logFile, bool overwriteLogFile, string pkcs11Logger, bool enablePkcs11Logger)
        {
            if (string.IsNullOrEmpty(pkcs11Library))
                throw new ArgumentNullException("pkcs11Library");

            if (enableLogging)
            {
                if (string.IsNullOrEmpty(logFile))
                    throw new ArgumentNullException("logFile");

                if (string.IsNullOrEmpty(pkcs11Logger))
                    throw new ArgumentNullException("pkcs11Logger");
            }

            if (Library != null)
            {
                Library.Dispose();
                Library = null;
            }

            if (enableLogging)
            {
                LogFile = logFile;
                InitializeLogging(overwriteLogFile);

                if (enablePkcs11Logger)
                {
                    // Setup PKCS11-LOGGER
                    System.Environment.SetEnvironmentVariable("PKCS11_LOGGER_LIBRARY_PATH", pkcs11Library);
                    System.Environment.SetEnvironmentVariable("PKCS11_LOGGER_LOG_FILE_PATH", logFile);
                    System.Environment.SetEnvironmentVariable("PKCS11_LOGGER_FLAGS", "0");

                    // Support also PKCS#11 Spy from OpenSC project
                    System.Environment.SetEnvironmentVariable("PKCS11SPY", pkcs11Library);
                    System.Environment.SetEnvironmentVariable("PKCS11SPY_OUTPUT", logFile);

                    Library = new Pkcs11Library(pkcs11Library, pkcs11Logger);
                }
                else
                {
                    Library = new Pkcs11Library(pkcs11Library);
                }
            }
            else
            {
                LogFile = null;
                Library = new Pkcs11Library(pkcs11Library);
            }

            // Keep input parameters for ReloadLibrary() method
            _pkcs11Library = pkcs11Library;
            _enableLogging = enableLogging;
            _logFile = logFile;
            _overwriteLogFile = overwriteLogFile;
            _pkcs11Logger = pkcs11Logger;
            _enablePkcs11Logger = enablePkcs11Logger;
        }

        public void ReloadLibrary()
        {
            if (Library == null)
                throw new Exception("No library loaded");

            LoadLibrary(_pkcs11Library, _enableLogging, _logFile, _overwriteLogFile, _pkcs11Logger, _enablePkcs11Logger);
        }

        public string GetDefaultLoggerPath()
        {
            string fileName = "pkcs11-logger-";
            fileName += (Platform.Uses32BitRuntime) ? "x86" : "x64";

            if (Platform.IsWindows)
                fileName += ".dll";
            else if (Platform.IsLinux)
                fileName += ".so";
            else if (Platform.IsMacOsX)
                fileName += ".dylib";

            return Path.Combine(Pkcs11AdminInfo.ExecutingAssemblyDirectory, "pkcs11-logger", fileName);
        }

        public string GetDefaultLogPath()
        {
            string dirPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return Path.Combine(dirPath, "Pkcs11Admin.txt");
        }

        public void InitializeLogging(bool overwriteLogFile)
        {
            if (overwriteLogFile && File.Exists(LogFile))
                File.Delete(LogFile);

            Log(string.Format("{0} {1} {2} on {3}", Pkcs11AdminInfo.AppTitle, Pkcs11AdminInfo.AppVersion, Pkcs11AdminInfo.RuntimeBitness, Pkcs11AdminInfo.OperatingSystem));
            Log(string.Format("{0}", Pkcs11AdminInfo.AppDescription));
            Log("Please visit www.pkcs11admin.net for more information");
        }

        public void Log(string message)
        {
            if (string.IsNullOrEmpty(LogFile))
                return;

            lock (_logFileLock)
                File.AppendAllText(LogFile, string.Format("{0:yyyy-MM-dd HH:mm:ss} : {1}{2}", DateTime.Now, message, Environment.NewLine));
        }

        #region CurrentVersionInfo

        private CurrentVersionInfo _currentVersionInfo = null;

        public CurrentVersionInfo CurrentVersionInfo
        {
            get
            {
                return _currentVersionInfo;
            }
            private set
            {
                _currentVersionInfo = value;
            }
        }

        public void DownloadCurrentVersionInfo()
        {
            using (WebResponse webResponse = WebRequest.CreateHttp("http://www.pkcs11admin.net/CurrentVersionInfo.xml").GetResponse())
            using (Stream webResponseStream = webResponse.GetResponseStream())
                _currentVersionInfo = XmlSerializer.Deserialize<CurrentVersionInfo>(webResponseStream);
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    // Dispose managed objects

                    if (Library != null)
                    {
                        Library.Dispose();
                        Library = null;
                    }
                }

                // Dispose unmanaged objects

                _disposed = true;
            }
        }

        ~Pkcs11Admin()
        {
            Dispose(false);
        }

        #endregion
    }
}
