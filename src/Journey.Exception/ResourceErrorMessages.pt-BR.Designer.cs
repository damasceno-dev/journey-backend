﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Journey.Exception {
    using System;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ResourceErrorMessages_pt_BR {
        
        private static System.Resources.ResourceManager resourceMan;
        
        private static System.Globalization.CultureInfo resourceCulture;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ResourceErrorMessages_pt_BR() {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.Equals(null, resourceMan)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("Journey.Exception.ResourceErrorMessages_pt_BR", typeof(ResourceErrorMessages_pt_BR).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        internal static string DATE_TRIP_MUST_BE_LATER_THAN_TODAY {
            get {
                return ResourceManager.GetString("DATE_TRIP_MUST_BE_LATER_THAN_TODAY", resourceCulture);
            }
        }
        
        internal static string END_DATE_TRIP_MUST_BE_LATER_THAN_START_DATE {
            get {
                return ResourceManager.GetString("END_DATE_TRIP_MUST_BE_LATER_THAN_START_DATE", resourceCulture);
            }
        }
        
        internal static string NAME_EMPTY {
            get {
                return ResourceManager.GetString("NAME_EMPTY", resourceCulture);
            }
        }
        
        internal static string TRIP_NOT_FOUND {
            get {
                return ResourceManager.GetString("TRIP_NOT_FOUND", resourceCulture);
            }
        }
        
        internal static string UNKNOWN_ERROR {
            get {
                return ResourceManager.GetString("UNKNOWN_ERROR", resourceCulture);
            }
        }
        
        internal static string DATE_NOT_WITHIN_TRAVEL_PERIOD {
            get {
                return ResourceManager.GetString("DATE_NOT_WITHIN_TRAVEL_PERIOD", resourceCulture);
            }
        }
        
        internal static string ACTIVITY_NOT_FOUND {
            get {
                return ResourceManager.GetString("ACTIVITY_NOT_FOUND", resourceCulture);
            }
        }
    }
}
