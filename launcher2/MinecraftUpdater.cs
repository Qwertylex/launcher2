using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Xml;
using System.Diagnostics;
using System.IO;

public class MinecraftUpdater {
	public MinecraftUpdater() {
        /*
        do we actually need to do anything here? at the moment, no
        but if i end up caching the XML from assets.minecraft.net, here's where to do it.
        */

        Debug.WriteLine("[MinecraftUpdater] New MinecraftUpdater created");
    }

    /*
    Quick and dirty rundown of GetAvailableVersions()
    -------------------------------------------------
    Here's the basics of how the XML we get from assets.minecraft.net is structured:

        <ListBucketResult>
            <Name>assets.minecraft.net</Name>
            ...
            <Contents>
                <Key>11w47a/minecraft.jar</Key>
                ...
            </Contents>
            <Contents>
                ...
            </Contents>
            ...
        </ListBucketResult>

    We just loop through looking for <Key> elements, grabbing their values, checking if they
    have "minecraft.jar" in them, and if they do, shoving them in a List<string> and returning
    that when we've iterated through the entire XML.

    We also do some really dirty string replacement so that what we return isn't filled with 
    underscores just so it looks nice when displayed in the user interface. (yes, that should
    have been done in the UI, shut up. it was easier to do here, and I'm **horribly** lazy)
    */
    
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
