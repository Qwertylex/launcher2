using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Xml;
using System.Diagnostics;
using System.IO;

public class MinecraftUpdater {
	public MinecraftUpdater() {
		Debug.WriteLine("[MinecraftUpdater] New MinecraftUpdater created");
    }

    public List<string> GetAvailableVersions() {
        List<string> _collection = new List<string>();
    	WebClient webClient = new WebClient();
        string AssetsString = webClient.DownloadString("http://assets.minecraft.net");
        using (XmlReader reader = XmlReader.Create(new StringReader(AssetsString))) {
            while(reader.ReadToFollowing("Key")) {
                string val = reader.ReadElementContentAsString();
                if(val.Contains("minecraft.jar")) {
                    val = val.Split('/')[0];
                    val = val.Replace('_', '.');
                    _collection.Add(val);
                }
            }
        }   	
    	return _collection;
    }

    public bool DownloadVersion(string VersionString) {
        // TODO: stub
        return false;
    }
}