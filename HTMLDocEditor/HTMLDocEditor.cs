
using System;
using System.Collections.Generic;
using DocEditor;
using System.IO;

namespace HTMLDocEditor
{
    public class HTMLDocEditor : IDocEditor
    {
        private List<string> fileNames; 
        public List<string> FileNames
        {
            get
            {
                return this.fileNames;
            }

            set
            {
                this.fileNames = value;
            }
        }

        public string BuildDocument(string docName = "")
        {
            GetPath();
            return "";
        }

        private String GetPath()
        {
            return @"E:\999_T";
        }
    }
}
