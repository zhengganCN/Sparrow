namespace Sparrow.Util.MP3
{
    /// <summary>
    /// mp3标签帧
    /// </summary>
    public class MP3TagFrame
    {
        /// <summary>
        /// mp3帧头部信息
        /// </summary>
        public MP3FrameHeader MP3FrameHeader { get; set; }
        /// <summary>
        /// mp3帧内容
        /// </summary>
        public MP3FrameContent MP3FrameContent { get; set; }
    }
}
