﻿#region copyright

// --------------------------------------------------------------------------------------------------------------------
// Copyright (C) 2016 L.A.S - LAS Soft
//
// This program is free software: you can redistribute it and/or modify
// it under the +terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see http://www.gnu.org/licenses/. 
//
// TopTenUsers.cs - Shows the top ten rank users.
// 
// Email: lealves_82@yahoo.com.br
// RetroAchievements username: FitaOuCartucho
// --------------------------------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RetroAchievementsApp.Model;
using RetroAchievementsApp.Converter;
using System.Net;
using Newtonsoft.Json;

namespace RetroAchievementsApp.UserControls
{
    /// <summary>
    /// Top ten users control.
    /// </summary>
    public partial class TopTenUsers : UserControl
    {
        public TopTenUsers()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Get the top ten users to show on usercontrol.
        /// </summary>
        /// <param name="sender">The user control.</param>
        /// <param name="e">Event arguments.</param>
        private void TopTenUsers_Load(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(UserInfo.Login))
                    this.LoadTopTenUsers();
            }
            catch (WebException ex)
            {
                timerTopTenUsers.Enabled = false;
                DefaultMessageAlerts.ShowErrorMessage(ex);
            }
            catch (JsonReaderException ex)
            {
                timerTopTenUsers.Enabled = false;
                DefaultMessageAlerts.ShowErrorMessage(ex);
            }
            catch (Exception ex)
            {
                timerTopTenUsers.Enabled = false;
                DefaultMessageAlerts.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Reload the top ten user info.
        /// </summary>
        /// <param name="sender">The timer object.</param>
        /// <param name="e">Event arguments.</param>
        private void timerTopTenUsers_Tick(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(UserInfo.Login) && (this.Parent.Parent as TabControl).SelectedIndex == 0)
            {
                try
                {
                    this.LoadTopTenUsers();
                }
                catch (WebException ex)
                {
                    timerTopTenUsers.Enabled = false;
                    DefaultMessageAlerts.ShowErrorMessage(ex);
                }
                catch (JsonReaderException ex)
                {
                    timerTopTenUsers.Enabled = false;
                    DefaultMessageAlerts.ShowErrorMessage(ex);
                }
                catch (Exception ex)
                {
                    timerTopTenUsers.Enabled = false;
                    DefaultMessageAlerts.ShowErrorMessage(ex);
                }
            }
        }

        /// <summary>
        /// Loads the Top ten users in a table object, including
        /// their profile image.
        /// </summary>
        /// <param name="model">Top ten users model.</param>
        private void LoadTopTenUsers()
        {
            TopTenUsersModel model = GetRATopTenUsers();

            this.tableTopTenUsers.Controls.Clear();

            Label lbl;
            Int32 y = 0;
            const Int32 toNextY = 40;
            for (Int32 i = 0; i < model.Users.Count; ++i)
            {
                PictureBox p = new PictureBox();                
                p.Location = new System.Drawing.Point(3, y);
                p.Size = new System.Drawing.Size(20, 15);
                p.ImageLocation = String.Format("http://retroachievements.org/UserPic/{0}.png", model.Users[i].Name);
                p.SizeMode = PictureBoxSizeMode.StretchImage;
                this.tableTopTenUsers.Controls.Add(p, 0, i);

                lbl = new Label();
                lbl.AutoSize = true;
                lbl.Font = new System.Drawing.Font("AR CENA", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lbl.Location = new System.Drawing.Point(100, y);
                lbl.Size = new System.Drawing.Size(50, 25);
                lbl.Text = string.Format("{0}  {1}", i+1, model.Users[i].Name);
                this.tableTopTenUsers.Controls.Add(lbl, 1, i);

                lbl = new Label();
                lbl.AutoSize = true;
                lbl.Font = new System.Drawing.Font("AR CENA", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lbl.Location = new System.Drawing.Point(308, y);
                lbl.Size = new System.Drawing.Size(56, 25);
                lbl.Text = String.Format("{0}({1})", model.Users[i].BluePoints, model.Users[i].WhitePoints);
                this.tableTopTenUsers.Controls.Add(lbl, 2, i);

                y += toNextY;
            }
        }

        /// <summary>
        /// Get top ten user's data
        /// </summary>
        /// <returns>Top ten users model</returns>
        private TopTenUsersModel GetRATopTenUsers()
        {
            TopTenUsersModel topTenUsersModel = null;
            topTenUsersModel = GeneralConverter.GetTopTenUsers();                

            return topTenUsersModel;
        }
    }
}
