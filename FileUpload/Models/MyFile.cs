using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.Models
{
    public class MyFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string SimpleDescr { get; set; }
        public string Description { get; set; }

        public void Create()
        {

        }
    }
}
