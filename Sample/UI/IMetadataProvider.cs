namespace Sample.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IMetadataProvider
    {
        MetadataList GetMetadatas(string entity);
    }
}
