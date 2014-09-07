using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample.UI
{
    public enum DataType
    {
        None = 0,
        Integer,
        Decimal,
        String,
        Date,
        DateTime,
        Binary, // file or image

        Guid, // foreign key
        Table // list
    }

    public enum ControlType
    {
        Hidden = 0,
        TextField,
        NumberField,
        DateField,
        FileUpload,
        Combobox,
        LookupField,
        TextArea,

        GridEdit
    }

    public class Metadata
    {
        public Metadata()
        {
        }

        public Metadata(
            string entityName,
            string groupName,
            string fieldName,
            string displayName,
            DataType dataType,
            ControlType controlType,
            bool required,
            int order)
        {
            this.EntityName = entityName;
            this.GroupName = groupName;
            this.FieldName = fieldName;
            this.DisplayName = displayName;
            this.DataType = dataType;
            this.ControlType = controlType;
            this.Required = required;
            this.Order = order;
        }

        public string Id
        {
            get
            {
                return "ctl_" + this.EntityName + "_" + this.FieldName;
            }
        }

        public string EntityName { get; set; }
        public string GroupName { get; set; }
        public string FieldName { get; set; }
        public string DisplayName { get; set; }
        public DataType DataType { get; set; }
        public ControlType ControlType { get; set; }
        public bool Required { get; set; }
        public int Order { get; set; }
    }
}