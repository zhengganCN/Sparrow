using System.IO;

namespace Sparrow.Export.iTextSharp
{
    public partial class SparrowPdf
    {
        private void BaseSave()
        {
            SetPdfBookmark();
            Document.Close();
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public byte[] Save()
        {
            BaseSave();
            return File.ReadAllBytes(FileName);
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="path">路径</param>
        public void Save(string path)
        {
            BaseSave();
            File.Move(FileName, path);
        }
    }
}
