namespace Sample.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class MetadataList : SortedSet<Metadata>
    {
        internal class MetadataComaper : IComparer<Metadata>
        {
            private static MetadataComaper _default = new MetadataComaper();
            public static MetadataComaper Default { get { return _default; } }

            public int Compare(Metadata x, Metadata y)
            {
                var compare = x.Order - y.Order;

                if (compare == 0)
                {
                    return string.Compare(x.Id, y.Id);
                }

                return compare;
            }
        }

        public MetadataList()
            : base(MetadataComaper.Default)
        {
        }

        public MetadataList(IEnumerable<Metadata> collection)
            : base(collection, MetadataComaper.Default)
        {
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