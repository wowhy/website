namespace Sample.UI
{
    using Ext.Net;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Web;

    public sealed partial class UIHelper
    {
        public UIHelper(
            IMetadataProvider metadataProvider,
            ILayoutProvider layoutProvider)
        {
            Contract.Assert(metadataProvider != null, "metadataProvider");
            Contract.Assert(layoutProvider != null, "layoutProvider");

            this.MetadataProvider = metadataProvider;
            this.LayoutProvider = layoutProvider;
        }

        public IMetadataProvider MetadataProvider { get; private set; }

        public ILayoutProvider LayoutProvider { get; private set; }

        internal AbstractContainer CurrentContainer { get; set; }

        public void CreateUI(AbstractContainer container, string entity)
        {
            Contract.Assert(container != null, "container");
            Contract.Assert(!string.IsNullOrWhiteSpace(entity), "entity");

            var metadatas = this.MetadataProvider.GetMetadatas(entity);
            var groups = metadatas.GroupBy();

            var controls = new List<AbstractComponent>();
            foreach (var item in metadatas)
            {
                controls.Add(this.CreateControl(item)); 
            }

            this.LayoutProvider.DoLayout(groups, controls);
        }

        private AbstractComponent CreateControl(Metadata metadata)
        {
            Contract.Assert(metadata != null, "metadata");

            return CreationMethods[metadata.ControlType](this.CurrentContainer, metadata);
        }
    }
}