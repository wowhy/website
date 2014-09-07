using Ext.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;

namespace Sample.UI
{
    public sealed class UIHelper
    {
        public UIHelper(
            IMetadataProvider metadataProvider,
            ILayoutProvider layoutProvider)
        {
            Contract.Assert(metadataProvider != null, "metadataProvider");

            this.MetadataProvider = metadataProvider;
            this.LayoutProvider = layoutProvider;
        }

        public IMetadataProvider MetadataProvider { get; private set; }

        public ILayoutProvider LayoutProvider { get; private set; }

        public void CreateUI(AbstractContainer container)
        {
        }
    }
}