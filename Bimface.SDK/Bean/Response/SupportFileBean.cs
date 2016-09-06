using System;
using System.Collections.Generic;

/// <summary>
///     支持文件格式和文件大小
///     @author bimface, 2016-09-01.
/// </summary>
namespace Bimface.SDK.Bean.Response
{
    public class SupportFileBean
    {
        private long? length; // 支持的最大文件长度，单位Byte
        private IList<string> types; //支持的文件格式

        public virtual long? Length
        {
            get { return length; }
            set { length = value; }
        }

        public virtual IList<string> Types
        {
            get { return types; }
            set { types = value; }
        }


        public override string ToString()
        {
            return string.Format("FileBean [length={0}, types={1}]", length, types.ToString());
        }

    }
}
