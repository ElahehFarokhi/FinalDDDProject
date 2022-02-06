using System;

namespace Framework.Tools.Enums
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum @enum)
        {
            Type genericEnumType = @enum.GetType();
            System.Reflection.MemberInfo[] memberInfos = genericEnumType.GetMember(@enum.ToString());

            if (memberInfos !=null && memberInfos.Length>0)
            {
                var attribs = memberInfos[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute),false);
                if (attribs !=null && attribs.Length > 0)
                {
                    return ((System.ComponentModel.DescriptionAttribute)attribs[0]).Description;
                }
            }
            return @enum.ToString();
        }

    }
}
