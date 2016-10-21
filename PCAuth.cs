using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json; // Include Json.NET 
using Newtonsoft.Json.Linq;
using System.Net;

using System.Windows.Forms;

namespace PremiumCheatsLoader
{
    class PCAuth
    {
        string APIUrl = "http://Xenforo.com/forums/api.php?"; // Change the url to XenApi's api.php

        //Initialize Objects
        WebClient Client = new WebClient();
        JObject AuthHash; // hash located in AuthHash["hash"]
        JObject UserData;
        bool LoggedIn = false;

        #region Responses
        public void Authenticate(string username, string password)
        {
            var JsonObject = Client.DownloadString(APIUrl + "action=authenticate&username=" + username + "&password=" + password);
            AuthHash = JObject.Parse(JsonObject);
            string LogHash = AuthHash["hash"].ToString();
            if (LogHash != "")
            {
                LoggedIn = true;
            }
        }
        
        public void GatherUserData(string username)
        {
            var JsonObject = Client.DownloadString(APIUrl + "action=getUser&hash=" + username + ":" + AuthHash["hash"]);
            UserData = JObject.Parse(JsonObject);
        }
        #endregion

        #region Functions

        #region Custom Information
        public JObject getUserData() { return UserData; }

        public JObject getAuthHash() { return AuthHash; }

        public bool isAuthenticated() { return LoggedIn; }

        public string requestData(string dataName) { return UserData[dataName].ToString(); }
        #endregion

        #region User Information
        public string getUsername() { return UserData["username"].ToString(); }

        public string getEmail() { return UserData["email"].ToString(); }
        #endregion

        #region Avatar
        public string getAvatar() 
        {
            var JsonObject = Client.DownloadString(APIUrl + "action=getAvatar&hash=" + UserData["username"] + ":" + AuthHash["hash"]);
            JObject AvatarJson = JObject.Parse(JsonObject);
            string AvatarUrl = AvatarJson["avatar"].ToString();
            AvatarUrl = AvatarUrl.Replace("http://premiumcheats.io", "http://premiumcheats.io/forums");
            return AvatarUrl;
        }

        public string getAvatarWidth() { return UserData["avatar_width"].ToString(); }

        public string getAvatarHeight() { return UserData["avatar_height"].ToString(); }
        #endregion

        #region Rank
        public string getPrimaryGroupID() { return UserData["user_group_id"].ToString(); }

        public string getSecondaryGroupIDs() { return UserData["secondary_group_ids"].ToString(); }

        public string getIsAdmin() { return UserData["is_admin"].ToString(); }

        public string getIsMod() { return UserData["is_moderator"].ToString(); }

        public string getIsBanned() { return UserData["is_banned"].ToString(); }

        public string getIsStaff() { return UserData["is_staff"].ToString(); }

        public string getUserState() { return UserData["user_state"].ToString(); }
        #endregion
        #endregion
    }
}
