using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Diagnostics;

public class MinecraftAuthentication {
    public string MinecraftUsername { get; set; }
    public string MinecraftPassword { private get; set; }
    public string MinecraftAuthToken { get; private set; }
    public bool PremiumUser { get; private set; }
    public bool BadLogin { get; private set; }
    public bool AccountMigrated { get; private set; }
    public bool AuthenticationAttempted { get; private set; }
    public int MinecraftVersion { get; set; }

    public MinecraftAuthentication(string Username, string Password) {
        this.MinecraftUsername = Username;
        this.MinecraftPassword = Password;
        this.MinecraftVersion = 99999;
        this.AuthenticationAttempted = false;
    }

    public static class AuthenticationStatus {
        public static int BadLogin = 1;
        public static int NotPremium = 3;
        public static int AccountMigrated = 5;
        public static int Success = 7;
    }

    public int DoAuthentication() {
        try {
            Debug.WriteLine("[MinecraftAuthentication] Starting authentication of user " + this.MinecraftUsername);

            string AuthURI;
            AuthURI  = "https://login.minecraft.net/?user=";
            AuthURI += Uri.EscapeUriString(MinecraftUsername);
            AuthURI += "&password=";
            AuthURI += Uri.EscapeUriString(MinecraftPassword);
            AuthURI += "&version=";
            AuthURI += Uri.EscapeUriString(MinecraftVersion.ToString());

            Debug.WriteLine("[MinecraftAuthentication] Requesting URI: \"" + AuthURI + "\"");

            WebClient webClient = new WebClient();
            string MinecraftAuthString = webClient.DownloadString(AuthURI);
            MinecraftAuthString = MinecraftAuthString.Trim();
            Debug.WriteLine("[MinecraftAuthentication] Returned string: \"" + MinecraftAuthString + "\"");

            this.BadLogin = MinecraftAuthString == "Bad login";
            this.PremiumUser = MinecraftAuthString != "User not premium";
            this.AccountMigrated = MinecraftAuthString == "Account migrated, use e-mail as username.";

            if (this.BadLogin) {
                Debug.WriteLine("[MinecraftAuthentication] Bad login, continuing with unauthenticated username");
                this.MinecraftAuthToken = this.MinecraftUsername;
                this.AuthenticationAttempted = true;
                return AuthenticationStatus.BadLogin;
            } else if (!this.PremiumUser) {
                Debug.WriteLine("[MinecraftAuthentication] User not premium, continuing with unauthenticated username");
                this.MinecraftAuthToken = this.MinecraftUsername;
                this.AuthenticationAttempted = true;
                return AuthenticationStatus.NotPremium;
            } else if (this.AccountMigrated) {
                Debug.WriteLine("[MinecraftAuthentication] Account migrated and username used for login, continuing with unauthenticated username");
                this.MinecraftAuthToken = this.MinecraftUsername;
                this.AuthenticationAttempted = true;
                return AuthenticationStatus.AccountMigrated;
            } else {
                Debug.WriteLine("[MinecraftAuthentication] User authenticated successfully");
                string[] AuthComponents = MinecraftAuthString.Split(new string[] { ":" }, StringSplitOptions.None);
                Debug.WriteLine("[MinecraftAuthentication] Returned username: \"" + AuthComponents[2] + "\"");
                this.MinecraftUsername = AuthComponents[2];
                Debug.WriteLine("[MinecraftAuthentication] Returned authentication token: \"" + AuthComponents[3] + "\"");
                this.MinecraftAuthToken = AuthComponents[2] + " " + AuthComponents[3];
                this.AuthenticationAttempted = true;
                return AuthenticationStatus.Success;
            }
        }
        catch (Exception ex) {
            Debug.WriteLine("[MinecraftAuthentication] Exception encountered: " + ex.Message);
            Debug.Indent();
            Debug.WriteLine("Target site: " + ex.TargetSite);
            Debug.WriteLine("Source: " + ex.Source);
            Debug.WriteLine("Stack trace: ");
            Debug.Indent();
            Debug.WriteLine(ex.StackTrace);
            Debug.Unindent();
            Debug.Unindent();
            throw;
        }
    }
}

