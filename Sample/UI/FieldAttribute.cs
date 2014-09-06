using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample.UI
{
    public class FieldAttribute : Attribute
    {
        public FieldAttribute(string fieldLabel) : this(fieldLabel, "基础信息") { }
        public FieldAttribute(string fieldLabel, string fieldGroup) : this(fieldLabel, fieldGroup, "string", "textfield")
        { 
        }

        public FieldAttribute(string fieldLabel, string fieldGroup, string dataType, string controlType)
        {
            this.FieldLabel = fieldLabel;
            this.FieldGroup = fieldGroup;
            this.DataType = dataType;
            this.ControlType = controlType;
        }

        public string FieldLabel { get; set; }
        public string FieldGroup { get; set; }
        public string DataType { get; set; }
        public string ControlType { get; set; }
    }
}