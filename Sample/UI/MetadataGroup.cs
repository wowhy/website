namespace Sample.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class MetadataGroup
    {
        public string GroupName { get; set; }
        public MetadataList Metadatas { get; set; }

        public MetadataGroup()
        { 
        }

        internal MetadataGroup(string groupName, MetadataList metadatas) 
        {
            this.GroupName = groupName;
            this.Metadatas = metadatas;
        }
    }

}