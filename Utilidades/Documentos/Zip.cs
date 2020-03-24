using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO.Compression;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;
using Arctodus.Utilidades.Documentos;

namespace Arctodus.Utilidades.Documentos
{
    public class Zip
    {
        public static byte[] CreateZip(List<eFile> files)
        {
            MemoryStream outputMemStream = new MemoryStream();
            ZipOutputStream zipStream = new ZipOutputStream(outputMemStream);

            zipStream.SetLevel(5); //0-9, 9 being the highest level of compression

            foreach (eFile file in files)
            {
                var newEntry = new ZipEntry(file.FileName);

                newEntry.DateTime = DateTime.Now;
                zipStream.PutNextEntry(newEntry);
                MemoryStream inStream = new MemoryStream(file.FileStream);
                StreamUtils.Copy(inStream, zipStream, new byte[4096]);
                inStream.Close();
                zipStream.CloseEntry();
            }

            zipStream.IsStreamOwner = false;    // False stops the Close also Closing the underlying stream.
            zipStream.Close();          // Must finish the ZipOutputStream before using outputMemStream.
            outputMemStream.Position = 0;
            return outputMemStream.ToArray();
            //return File(outputMemStream.ToArray(), "application/octet-stream", "reports.zip");
        }
    }
}