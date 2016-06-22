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
// TopTenUsersModel.cs - Top ten user's model.
// 
// Email: lealves_82@yahoo.com.br
// RetroAchievements username: FitaOuCartucho
// --------------------------------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace RetroAchievementsApp.Model
{
    /// <summary>
    /// Top ten users model.
    /// </summary>
    public class TopTenUsersModel
    {
        public List<TopTenUser> Users = new List<TopTenUser>();

        public class TopTenUser
        {
            [JsonPropertyAttribute("1")]
            public string Name { get; set; }

            [JsonPropertyAttribute("2")]
            public string BluePoints { get; set; }

            [JsonPropertyAttribute("3")]
            public string WhitePoints { get; set; }
        }
    }
}
