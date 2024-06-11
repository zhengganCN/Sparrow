namespace Sparrow.StandardResult
{
    /// <summary>
    /// 附件字段接口
    /// </summary>
    public interface IAdditionalField
    {
        /// <summary>
        /// 为对象添加附加字段
        /// </summary>
        /// <param name="name">附加字段名</param>
        /// <param name="value">附加字段值</param>
        /// <returns></returns>
        void AddAdditionalField(string name, object value);
    }
}
