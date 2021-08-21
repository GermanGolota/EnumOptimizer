using System.Collections.Generic;

namespace EnumOptimizer.Models
{
    public class EnumsModel
    {
        public List<EnumNamespaceModel> Namespaces { get; set; }
        public List<EnumModel> Enums { get; set; }
    }
}
