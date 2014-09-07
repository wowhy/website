namespace Sample.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Ext.Net;

    public sealed partial class UIHelper
    {
        internal delegate AbstractComponent CreationMethod(AbstractContainer container, Metadata metadata);

        internal static Dictionary<ControlType, CreationMethod> creationMethods;

        internal static Dictionary<ControlType, CreationMethod> CreationMethods
        {
            get { return creationMethods; }
        }

        static UIHelper()
        {
            creationMethods = new Dictionary<ControlType, CreationMethod>() 
            {
                { ControlType.Hidden, CreateHidden },
                { ControlType.TextField, CreateTextField },
                { ControlType.NumberField, CreateNumberField },
                { ControlType.DateField, CreateDateField },
                { ControlType.FileUpload, CreateFileUpload },
                { ControlType.LookupField, CreateLookupField },
                { ControlType.Combobox, CreateCombobox },
                { ControlType.TextArea, CreateTextArea },
            };
        }

        private static AbstractComponent CreateHidden(AbstractContainer container, Metadata metadata)
        {
            var control = new Hidden { ID = metadata.Id, Name = metadata.FieldName };
            return control;
        }

        private static AbstractComponent CreateTextField(AbstractContainer container, Metadata metadata)
        {
            throw new NotImplementedException();
        }

        private static AbstractComponent CreateNumberField(AbstractContainer container, Metadata metadata)
        {
            throw new NotImplementedException();
        }

        private static AbstractComponent CreateDateField(AbstractContainer container, Metadata metadata)
        {
            throw new NotImplementedException();
        }

        private static AbstractComponent CreateFileUpload(AbstractContainer container, Metadata metadata)
        {
            throw new NotImplementedException();
        }

        private static AbstractComponent CreateLookupField(AbstractContainer container, Metadata metadata)
        {
            throw new NotImplementedException();
        }

        private static AbstractComponent CreateCombobox(AbstractContainer container, Metadata metadata)
        {
            throw new NotImplementedException();
        }

        private static AbstractComponent CreateTextArea(AbstractContainer container, Metadata metadata)
        {
            throw new NotImplementedException();
        }
    }
}