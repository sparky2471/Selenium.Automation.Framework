using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Selenium.Automation.Framework.Base.FileIO
{
    public class CSVReader
    {
        private readonly Dictionary<int, List<string>> data;

        public CSVReader()
        {
            data = new Dictionary<int, List<string>>();
        }

        public Dictionary<int, List<string>> ReadFile(string file)
        {
            int rowNum = 0;
            data.Clear();

            using (var reader = new StreamReader(file))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',').ToList();

                    data.Add(rowNum, values);
                    rowNum++;
                }
            }

            return data;
        }


        public List<string> GetDataSet(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("Value:" + index.ToString() + "is out of range.", "Index must be greater than 0.");
            }
            else if (index >= data.Count)
            {
                throw new ArgumentOutOfRangeException("Value:" + index.ToString() + "is out of range.", "Index must be less than the size of the entire collection.");
            }

            return data[index];
        }
    }
}
