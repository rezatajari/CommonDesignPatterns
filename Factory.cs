using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CommonDesignPatterns
{
    internal class FactoryPattern
    {
    }

    interface IDocument
    {
        void Write();
    }
    internal class WordDocument : IDocument
    {
        public void Write()
        {
            Console.WriteLine("The word file is run..");
        }
    }
    internal class ExelDocument : IDocument
    {
        public void Write()
        {
            Console.WriteLine("The exel file is run..");
        }
    }
    public enum DocumentType { Word, Excel }

    internal class DocumentFactory
    {
        public static IDocument CreateDocument(DocumentType docType)
        {
            return docType switch
            {
                DocumentType.Word => new WordDocument(),
                DocumentType.Excel => new ExelDocument(),
                _ => throw new NotSupportedException()
            };


        }
    }
}
