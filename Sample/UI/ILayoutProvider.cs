namespace Sample.UI
{
    using Ext.Net;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ILayoutProvider
    {
        void DoLayout(IEnumerable<MetadataGroup> groups, IEnumerable<AbstractComponent> controls);
    }
}
