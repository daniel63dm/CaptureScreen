using System;
using System.Collections.Generic;

namespace DocEditor
{
    public interface IDocEditor
    {
        /// <summary>
        /// File names to insert in the document
        /// </summary>
        List<String> FileNames { get; set; }

        String BuildDocument(string docName = "");
    }
}

