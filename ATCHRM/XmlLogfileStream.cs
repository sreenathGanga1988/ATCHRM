/***************************
 This code is copyright by 
 
 Norbert Ruessmann
 http://www.devtracer.com
 Mail: nruessmann@devtracer.com
 
 License : The Code Project Open License
           http://www.codeproject.com/info/cpol10.aspx
 
***************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace at.XMLforLogFiles
{
    public class XmlLogfileStream : Stream
    {
        FileStream _fileStream = null;
        private bool _firstTime = true;
        private bool _closingTagRead = false;

        public XmlLogfileStream(string filename)
        {
            _fileStream = new FileStream(filename, FileMode.Open);
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            if (_closingTagRead) return 0; // file completely read
            if (_firstTime)  // nothing read so far, therefore provide the opening tag
            {
                _firstTime = false;
                Byte[] data = System.Text.Encoding.ASCII.GetBytes("<x>");
                //
                // this code is not foolprof. Here I return "<x>" in one go, even if buffer does not provide enough space. Therefore the assert.
                // From experience I know that the buffer is always big enough.
                //
                Debug.Assert(data.Length <= count);
                for (int idx = 0; idx < data.Length; idx++)
                    buffer[offset + idx] = data[idx];
                return data.Length;
            }
            int bytesRead = _fileStream.Read(buffer, offset, count);
            if (bytesRead == 0 && !_closingTagRead)   // all contents of file read, but closing tag not provided yet
            {
                _closingTagRead = true;
                Byte[] data = System.Text.Encoding.ASCII.GetBytes("</x>");
                Debug.Assert(data.Length <= count);
                for (int idx = 0; idx < data.Length; idx++)
                    buffer[offset + idx] = data[idx];
                return data.Length;
            }
            return bytesRead;
        }

        protected override void Dispose(bool disposing)
        {
            if (_fileStream != null)
            {
                _fileStream.Dispose();
                _fileStream = null;
            }
            base.Dispose(disposing);
        }
        public new void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // 
        // the foollowing methods nned to be overridden, equired by base class
        // just do default processing calling default implementations of FileStream

        public override bool CanRead
        {
            get { return _fileStream.CanRead; }
        }
        public override bool CanSeek
        {
            get { return _fileStream.CanSeek; }
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override long Length
        {
            get { return _fileStream.Length; }
        }
        public override long Position
        {
            get
            {
                return _fileStream.Position;
            }
            set
            {
                _fileStream.Position = value;
            }
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            return _fileStream.Seek(offset, origin);
        }
        public override void Flush()
        {
            _fileStream.Flush();
        }
        public override void SetLength(long value)
        {
            _fileStream.SetLength(value);
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
