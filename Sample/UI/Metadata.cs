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
        Boolean = 1,
        Integer = 2,
        Decimal = 3,
        String = 4,
        Date = 5,
        DateTime = 6,
        Binary = 7, // file or image

        Guid = 100, // foreign key
        List = 101, // list        
    }

    public enum ControlType
    {
        Hidden = 0,
        TextField = 1,
        NumberField = 2,
        DateField = 3,
        FileUpload = 4,
        Combobox = 5,
        LookupField = 6,
        TextArea = 7,
        MultiCombobox = 8,

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

        private string groupName;
        public string GroupName
        {
            get
            {
                if (this.Group != null)
                    return this.Group.GroupName;
                return this.groupName;
            }
            set { this.groupName = value; }
        }

        public string FieldName { get; set; }

        public string DisplayName { get; set; }

        private DataType dataType;
        public DataType DataType
        {
            get { return this.dataType; }
            set { this.dataType = value; }
        }

        public string DataTypeName
        {
            get
            {
                return this.dataType.ToString();
            }
            set
            {
                this.dataType = this.ParseDataType(value);
            }
        }

        private ControlType controlType;
        public ControlType ControlType
        {
            get { return this.controlType; }
            set { this.controlType = value; }
        }

        public string ControlTypeName
        {
            get
            {
                return this.controlType.ToString();
            }
            set
            {
                this.controlType = this.ParseControlType(value);
            }
        }

        public bool Required { get; set; }

        public int Order { get; set; }

        public MetadataGroup Group { get; set; }

        internal DataType ParseDataType(string value)
        {
            var type = default(DataType);
            switch (value.ToLower())
            {
                case "bool":
                case "boolean":
                    type = DataType.Boolean;
                    break;

                case "int":
                case "integer":
                    type = DataType.Integer;
                    break;

                case "double":
                case "float":
                case "decimal":
                    type = DataType.Decimal;
                    break;

                case "string":
                case "str":
                    type = DataType.String;
                    break;

                case "date":
                    type = DataType.Date;
                    break;

                case "datetime":
                case "time":
                    type = DataType.DateTime;
                    break;

                case "bytes":
                case "binary":
                case "byte[]":
                    type = DataType.Binary;
                    break;

                case "foreign key":
                case "guid":
                    type = DataType.Guid;
                    break;

                case "table":
                case "list":
                    type = DataType.List;
                    break;

                default:
                    Enum.TryParse<DataType>(value, out type);
                    break;
            }

            return type;
        }

        internal ControlType ParseControlType(string value)
        {
            var type = default(ControlType);
            switch (value.ToLower())
            {
                case "hidden":
                case "hiddenfield":
                    type = ControlType.Hidden;
                    break;

                case "text":
                case "textbox":
                case "textfield":
                    type = ControlType.TextField;
                    break;

                case "number":
                case "numberfield":
                    type = ControlType.NumberField;
                    break;

                case "date":
                case "datefield":
                    type = ControlType.DateField;
                    break;

                case "file":
                case "fileupload":
                case "fileinput":
                    type = ControlType.FileUpload;
                    break;

                case "combo":
                case "combobox":
                    type = ControlType.Combobox;
                    break;

                case "lookup":
                case "lookupfield":
                    type = ControlType.LookupField;
                    break;

                case "textarea":
                case "area":
                    type = ControlType.TextArea;
                    break;

                case "multi":
                case "multicombo":
                case "multicombobox":
                    type = ControlType.MultiCombobox;
                    break;

                default:
                    Enum.TryParse<ControlType>(value, out type);
                    break;
            }

            return type;
        }
    }
}