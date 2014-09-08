namespace Sample.UI
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Web;
    
    public class ReflectionProvider : IMetadataProvider
    {
        public MetadataList GetMetadatas(string entity)
        {
            var list = new MetadataList();
            var type = Type.GetType(entity);
            
            Contract.Assert(type != null, "type");

            var props = type.GetProperties();
            foreach (var prop in props)
            {
            }

            return list;
        }
    }
}