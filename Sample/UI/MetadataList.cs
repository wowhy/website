namespace Sample.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    
    public class MetadataList : List<Metadata>
    {
        public MetadataList()
        {
        }

        public MetadataList(IEnumerable<Metadata> collection)
        {
            this.AddRange(collection);
        }

        public IEnumerable<MetadataGroup> GroupBy()
        {
            var groups = this.GroupBy(k => k.GroupName);
            foreach (var item in groups)
            {
                yield return new MetadataGroup(item.Key, new MetadataList(item));
            }
        }
    }
}