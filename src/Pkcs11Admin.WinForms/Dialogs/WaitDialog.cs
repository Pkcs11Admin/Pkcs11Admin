/*
 *  Pkcs11Admin - GUI tool for administration of PKCS#11 enabled devices
 *  Copyright (c) 2014-2016 Jaroslav Imrich <jimrich@jimrich.sk>
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

using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Net.Pkcs11Admin.WinForms.Dialogs
{
    public partial class WaitDialog : Form
    {
        private static WaitDialog _instance = null;

        private static object _lockObject = new object();

        private WaitDialog()
        {
            InitializeComponent();

            if (_instance != null)
                throw new Exception("Dialog instance already exists");
        }

        private void WaitDialog_Load(object sender, EventArgs e)
        {
            // Manually center dialog
            Location = new System.Drawing.Point(
                Owner.Location.X + ((Owner.Width - Width) / 2),
                Owner.Location.Y + ((Owner.Height - Height) / 2)
            );
        }

        private void WaitDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            // User should not be able to close this form
            if (e.CloseReason == CloseReason.UserClosing)
                e.Cancel = true;
        }

        private static void ShowInstance(Form owner)
        {
            lock (_lockObject)
            {
                if (_instance != null)
                    throw new Exception("Dialog instance already exists");

                _instance = new WaitDialog();
                _instance.Show(owner);
                _instance.Owner.Enabled = false;
                   
            }
        }

        private static void CloseInstance()
        {
            lock (_lockObject)
            {
                if (_instance == null)
                    throw new Exception("Dialog instance does not exist");

                _instance.Owner.Enabled = true;
                _instance.Close();
                _instance.Dispose();
                _instance = null;
            }
        }

        public static async Task Execute(Form owner, Action action)
        {
            if (owner == null)
                throw new ArgumentNullException("owner");

            if (action == null)
                throw new ArgumentNullException("action");

            await Execute(owner, null, action, null);
        }

        public static async Task Execute(Form owner, Action actionBeforeTask, Action actionInTask, Action actionAfterTask)
        {
            if (owner == null)
                throw new ArgumentNullException("owner");

            if (actionInTask == null)
                throw new ArgumentNullException("actionInTask");

            try
            {
                ShowInstance(owner);

                if (actionBeforeTask != null)
                    actionBeforeTask();
                
                await Task.Run(actionInTask);

                if (actionAfterTask != null)
                    actionAfterTask();

                CloseInstance();
            }
            catch
            {
                CloseInstance();
                throw;
            }
        }
    }
}
