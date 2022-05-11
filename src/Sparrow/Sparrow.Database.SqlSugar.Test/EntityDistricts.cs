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
        public long Id { get; set; }
        /// <summary>
        /// 上级地区代码
        /// </summary>
        [Description("上级地区代码")]
        [MaxLength(20)]
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
        /// <summary>
        /// 地区等级
        /// </summary>
        [Description("地区等级")]
        public int DistrictLevel { get; set; }
    }
}
