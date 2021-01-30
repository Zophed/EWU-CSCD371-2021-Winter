using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment4.Writer
{
    public class SetWriter : IDisposable
    {
        private bool _DisposedValue;

        private string? _filePath;
        public string? FilePath { get => _filePath; set => _filePath = value; }

        private StreamWriter? fileWriter;
        public StreamWriter? FileWriter { get => fileWriter; set => fileWriter = value; }

        
        public SetWriter(string? filePath)
        {
            FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
            FileWriter = new StreamWriter(FilePath);
        }

        public void WriteToFile(NumSet numSet)
        {
            if(numSet == null || numSet.IntSet == null)
            {
                throw new ArgumentNullException(nameof(numSet), "SetWriter.WriterToFile() -- null param");
            }

            if(FileWriter == null)
            {
                throw new ArgumentNullException(nameof(FileWriter), "SetWriter.WriterToFile() -- StreamWriter not set up");
            }

            FileWriter.Write(numSet.ToString());
        }
        protected void Dispose(bool disposing)
        {
            if (!_DisposedValue)
            {
                if (disposing)
                {
                    if(FileWriter == null)
                    {
                        throw new ArgumentNullException(nameof(FileWriter), "SetWriter.Dispose -- FileWrtier is null");
                    }

                    FileWriter.Close();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _DisposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
