﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Installer.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Installer.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to curl -k -L https://gamebanana.com/maps/download/211946?api=FilesModule -o config.json
        ///node url.
        /// </summary>
        internal static string Run {
            get {
                return ResourceManager.GetString("Run", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to // Made by Lord-Giganticus
        ///const fs = require(&apos;fs&apos;);
        ///const data = require(&apos;./config.json&apos;)
        ///var files = data._aCellValues._aFiles
        ///var line = &quot;&quot;
        ///for (var key in files) {
        ///    var value = files[key];
        ///    var url = value._sDownloadUrl
        ///    line = line + &quot;curl -k -L &quot;+ url+ &quot; -o &quot;+ value._sFile + &quot;\n&quot; 
        ///}
        ///fs.writeFile(&apos;download.cmd&apos;, line, err =&gt; {
        ///    if (err) {
        ///        console.error(err)
        ///        return
        ///    }
        ///    return console.log(&quot;Complete.&quot;);
        ///}).
        /// </summary>
        internal static string URL {
            get {
                return ResourceManager.GetString("URL", resourceCulture);
            }
        }
    }
}
