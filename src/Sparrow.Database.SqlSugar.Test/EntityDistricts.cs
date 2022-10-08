using Sparrow.Database.EntityInfo;
using SqlSugar;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sparrow.Database.SqlSugar.Test
{
    [Description("地区")]
    public class EntityDistricts : Entity
    {
        [SugarColumn(IsIdentity = true, IsPrimaryKey = true)]
        public int Id { get; set; }
        /// <summary>
        /// 上级地区代码
        /// </summary>
        [Description("上级地区代码")]
        [MaxLength(20)]
#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
        public string ParentDistrictCode { get; set; }

        /// <summary>
        /// 地区代码
        /// </summary>
        [Description("地区代码")]
        [MaxLength(20)]
        public string DistrictCode { get; set; }
        /// <summary>
        /// 地区名称
        /// </summary>
        [Description("地区名称")]
        [MaxLength(500)]
        public string DistrictName { get; set; }
#pragma warning restore CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
        /// <summary>
        /// 地区等级
        /// </summary>
        [Description("地区等级")]
        public int DistrictLevel { get; set; }
    }
}
