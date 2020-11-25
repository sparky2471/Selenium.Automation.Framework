using System.IO;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

namespace Selenium.Automation.Framework.Base.FileIO
{
    public class ExcelReader
    {
        private string fileName;

        private IWorkbook workbook;
        private ISheet sheet;
        private IRow row;
        private DataFormatter dataFormatter;
        private IFormulaEvaluator formulaEvaluator;

        public string FileName
        {
            get
            {
                return fileName;
            }
        }

        public void LoadFile(string filePath)
        {
            fileName = filePath;
            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                workbook = new XSSFWorkbook(file);
                formulaEvaluator = new XSSFFormulaEvaluator(workbook);
                dataFormatter = new DataFormatter();
                sheet = workbook.GetSheetAt(0);
                row = sheet.GetRow(1);
            }
        }

        public ExcelReader(string filePath)
        {
            LoadFile(filePath);
        }

        public void SetSheet(string sheetName)
        {
            sheet = workbook.GetSheet(sheetName);
        }

        public string GetCell(int cellID)
        {
            ICell cell = row.GetCell(cellID, MissingCellPolicy.RETURN_BLANK_AS_NULL);
            formulaEvaluator.Evaluate(cell);
            return dataFormatter.FormatCellValue(cell, formulaEvaluator);
        }

        public void setRow(int rowID)
        {
            row = sheet.GetRow(rowID);
        }
    }
}
