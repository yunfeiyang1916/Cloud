using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Domain.Dto
{
    /// <summary>菜单权限，仅用来转换前台传来的json</summary>
    public class MenuPermissionDto
    {
        private Int32 _ID;
        /// <summary>菜单ID</summary>
        public Int32 ID { get { return _ID; } set { _ID = value; } }

        private String _FieldNames;
        /// <summary>字段名称集合，以逗号分隔</summary>
        public String FieldNames { get { return _FieldNames; } set { _FieldNames = value; } }

        private Boolean _IsAllow;
        /// <summary>字段权限类型：1 允许 0 拒绝</summary>
        public Boolean IsAllow { get { return _IsAllow; } set { _IsAllow = value; } }

        private List<MenuButtonDto> _MenuButtons;
        /// <summary>该菜单所拥有的菜单按钮集合</summary>
        public List<MenuButtonDto> MenuButtons { get { return _MenuButtons; } set { _MenuButtons = value; } }

        /// <summary>菜单按钮</summary>
        public class MenuButtonDto
        {
            private Int32 _MenuButtonID;
            /// <summary>菜单按钮映射表ID</summary>
            public Int32 MenuButtonID { get { return _MenuButtonID; } set { _MenuButtonID = value; } }

            private Int32 _ButtonID;
            /// <summary>按钮ID</summary>
            public Int32 ButtonID { get { return _ButtonID; } set { _ButtonID = value; } }
        }
    }
}
