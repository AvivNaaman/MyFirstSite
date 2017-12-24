using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Globals
/// </summary>
namespace GlobalVariables
{
    public class GlobalingRegisterSignOutMessage
    {
        // parameterless constructor required for static class
        static GlobalingRegisterSignOutMessage() { GlobalRegisterSignOutMessage = null; } // default value

        // public get, and private set for strict access control
        public static string GlobalRegisterSignOutMessage { get; private set; }

        // GlobalInt can be changed only via this method
        public static void SetGlobalRegisterSignOutMessageValue(string newString)
        {
            GlobalRegisterSignOutMessage = newString;
        }
    }
    public class GlobalingVr
    {
        static GlobalingVr() { GlobalVr = "2.6"; }
        public static string GlobalVr { get; private set; }
    }
    public class GlobalingRedirectedFrom
    {
        static GlobalingRedirectedFrom() { GlobalRedirectedFrom = null; }
        public static string GlobalRedirectedFrom { get; set; }
        public static void SetGlobalRedirectedFromValue(string newString)
        {
            GlobalRedirectedFrom = newString;
        }
    }
}