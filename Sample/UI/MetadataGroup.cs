namespace Sample.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class MetadataGroup
    {
        private MetadataList metadatas;

        public string GroupName { get; set; }

        public MetadataList Metadatas
        {
            get { return this.metadatas; }
            set
            {
                this.metadatas = value;
                if (this.metadatas != null)
                {
                    foreach (var item in this.metadatas)
                    {
                        item.Group = this;
                    }
                }
            }
        }

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