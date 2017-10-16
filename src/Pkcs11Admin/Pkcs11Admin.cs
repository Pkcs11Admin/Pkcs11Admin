/*
 *  Pkcs11Admin - GUI tool for administration of PKCS#11 enabled devices
 *  Copyright (c) 2014-2017 Jaroslav Imrich <jimrich@jimrich.sk>
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

namespace Net.Pkcs11Admin
{
    public class Pkcs11Admin : IDisposable
    {
        private bool _disposed = false;

        #region LoadLibrary parameters

        private string _pkcs11Library = null;
        private string _pkcs11Logger = null;
        private string _logFile = null;
        private bool _enableLogging = false;
        private bool _overwriteLogFile = false;

        #endregion

        public string LogFile
        {
            get
            {
                return _logFile;
            }
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

        public void LoadLibrary(string pkcs11Library, string pkcs11Logger, string logFile, bool enableLogging, bool overwriteLogFile)
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
                if (overwriteLogFile && File.Exists(logFile))
                    File.Delete(logFile);

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
                logFile = null;
                Library = new Pkcs11Library(pkcs11Library);
            }

            // Keep input parameters for ReloadLibrary() method
            _pkcs11Library = pkcs11Library;
            _enableLogging = enableLogging;
            _logFile = logFile;
            _overwriteLogFile = overwriteLogFile;
            _pkcs11Logger = pkcs11Logger;
        }

        public void ReloadLibrary()
        {
            if (Library == null)
                throw new Exception("No library loaded");

            LoadLibrary(_pkcs11Library, _pkcs11Logger, _logFile,  _enableLogging, _overwriteLogFile);
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
            return Path.Combine(dirPath, "Pkcs11Admin.log");
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
            using (WebResponse webResponse = HttpWebRequest.Create("http://www.pkcs11admin.net/CurrentVersionInfo.xml").GetResponse())
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
