using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using XCode;

namespace Cloud.Domain
{
    /// <summary>主键为整型的实体树基类</summary>
    /// <remarks>该扩展是为了满足jqGrid树结构展示</remarks>
    /// <typeparam name="TEntity"></typeparam>
    [Serializable]
    public class EntityTreeExtend<TEntity> : EntityTree<TEntity> where TEntity : EntityTree<TEntity>, new()
    {
        /// <summary>树形节点名，根据深度带全角空格前缀</summary>
        /// <remarks>这里之所以重写，是因为需要支持json序列化</remarks>
        [XmlIgnore]
        public override String TreeNodeText
        {
            get
            {
                return base.TreeNodeText;
            }
        }
        /// <summary>层级</summary>
        [XmlIgnore]
        public Int32 Level { get { return Deepth - 1; } }
        /// <summary>是否是叶子节点</summary>
        [XmlIgnore]
        public Boolean IsLeaf { get { return Childs == null || Childs.Count == 0; } }
        /// <summary>是否需要展开</summary>
        [XmlIgnore]
        public Boolean Expanded { get { return Childs != null && Childs.Count > 0; } }
    }
}
