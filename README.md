# XenApiAuth

C# Class for XenApi

##Features
- Authenticate
- Gather User Data
- Get Username
- Get Email
- Get Avatar
- Get Group ID's
- Get IsAdmin
- Get IsMod
- Get IsBanned
- Get IsStaff
- Get UserState


##Setup
First you have to change the following piece of code to your XenAPI's api.php
```
string APIUrl = "http://Xenforo.com/forums/api.php?"; // Change the url to XenApi's api.php
```
##Getting Started
###Initialize
To initialize XenApiAuth use this line
```
XenApiAuth Auth = new XenApiAuth();
```
###Authentication
```
Auth.Authenticate("username", "password");
```
###Check if Authenticated
Returns bool
```
if (Auth.isAuthenticated())
{
  // Is Authenticated
}
```
###Gather User Data
**Required**, Gathers all data for you to request.
```
Auth.GatherUserData("username")
```
###Functions
####Get RAW User Data
Returns JObject
```
Auth.getUserData();
```
####Get Auth Hash
Returns JObject
```
Auth.getAuthHash();
```
####Request Data From UserData
Returns requested data from UserData
```
Auth.requestData("dataName");
```
####Get Username
Returns string
```
Auth.getUsername();
```
####Get Email
Returns string
```
Auth.getEmail();
```
####Get Primary Group ID
Returns string
```
Auth.getPrimaryGroupID();
```
####Get Secondary Group IDs
Returns string
```
Auth.getSecondaryGroupIDs();
```
####Get User State
Returns string
```
Auth.getUserState();
```
####Get IsAdmin
Returns string
```
Auth.getIsAdmin();
```
####Get IsMod
Returns string
```
Auth.getIsMod();
```
####Get IsStaff
Returns string
```
Auth.getIsStaff();
```
####Get IsBanned
Returns string
```
Auth.getIsBanned();
```
####Avatar
#####Get Avatar
Returns URL to Avatar
```
Auth.getAvatar();
```
#####Get Avatar Width
Returns String
```
Auth.getAvatarWidth();
```
#####Get Avatar Height
Returns String
```
Auth.getAvatarHeight();
```

##Built for
[XenAPI](https://github.com/Contex/XenAPI) - Xenforo PHP REST API
