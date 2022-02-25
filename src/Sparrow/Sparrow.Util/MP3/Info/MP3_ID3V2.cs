using System.Collections.Generic;

namespace Sparrow.Util.MP3
{
    /// <summary>
    /// ID3V2信息
    /// </summary>
    public class MP3_ID3V2
    {
        /// <summary>
        /// 标签头
        /// </summary>
        public MP3TagHeader MP3TagHeader { get; set; }
        /// <summary>
        /// 标签帧
        /// </summary>
        public List<MP3TagFrame> MP3TagFrames { get; set; }

    }
}
