/*
 *  Pkcs11Admin - GUI tool for administration of PKCS#11 enabled devices
 *  Copyright (c) 2014 Jaroslav Imrich <jimrich@jimrich.sk>
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
using System.Reflection;

namespace Net.Pkcs11Admin
{
    public class Pkcs11Admin : IDisposable
    {
        private bool _disposed = false;

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

        public static Pkcs11Admin Instance = new Pkcs11Admin();

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
                    System.Environment.SetEnvironmentVariable("PKCS11_LOGGER_LIBRARY_PATH", pkcs11Library);
                    System.Environment.SetEnvironmentVariable("PKCS11_LOGGER_LOG_FILE_PATH", logFile);
                    System.Environment.SetEnvironmentVariable("PKCS11_LOGGER_FLAGS", "0");

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
        }

        public string GetDefaultLoggerPath()
        {
            string path = Pkcs11AdminInfo.ExecutingAssemblyDirectory;
            path += Path.DirectorySeparatorChar + "pkcs11-logger-";
            path += (Platform.Uses32BitRuntime) ? "x86" : "x64";

            if (Platform.IsWindows)
                path += ".dll";
            else if (Platform.IsLinux)
                path += ".so";
            else if (Platform.IsMacOsX)
                path += ".dylib";

            return path;
        }

        public string GetDefaultLogPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + Path.DirectorySeparatorChar + "Pkcs11Admin.txt";
        }

        public void InitializeLogging(bool overwriteLogFile)
        {
            if (overwriteLogFile && File.Exists(LogFile))
                File.Delete(LogFile);

            Log(string.Format("{0} {1} ({2} {3})", Pkcs11AdminInfo.AppTitle, Pkcs11AdminInfo.AppVersion, Pkcs11AdminInfo.OperatingSystem, Pkcs11AdminInfo.RuntimePlatform));
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
