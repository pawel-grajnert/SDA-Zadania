using System.Data;
using System.Text;

namespace CsvReader.ConsoleApp.CsvReader;

public class CsvReader
{
    private string _separators = ";";
    private string _textContentMarkers = "\"";
    private string _rowEndingCharacters = "\n\r";

    public DataTable Read(byte[] binaryData)
    {
        var dataTable = new DataTable();

        char[] textContent = Encoding.GetEncoding("UTF-8").GetString(binaryData).ToCharArray();

        int charCount = textContent.Length;

        bool isTextContent = false;
        bool isStillSearchingNewLine = false;

        var csvFileLines = new Dictionary<int, List<string>>();
        var cellContentBuilder = new StringBuilder();

        int currentRowIndex = 0;
        csvFileLines.Add(currentRowIndex, new List<string>());
        List<string> currentRow = csvFileLines[currentRowIndex];


        for (int charIndex = 0; charIndex < charCount; charIndex++)
        {
            char lastCharacter = charIndex - 1 < 0 ? '\0' : textContent[charIndex - 1];
            char character = textContent[charIndex];
            char nextCharacter = charCount - 1 == charIndex ? '\0' : textContent[charIndex + 1];

            if (isStillSearchingNewLine && _rowEndingCharacters.Contains(character))
            {
                continue;
            }

            isStillSearchingNewLine = false;

            if (charIndex == 0 && _textContentMarkers.Contains(character))
            {
                isTextContent = true;
                continue;
            }

            if (!isTextContent && (_separators.Contains(lastCharacter) || _rowEndingCharacters.Contains(lastCharacter)) && _textContentMarkers.Contains(character))
            {
                isTextContent = true;
                continue;
            }

            if (!isTextContent && _separators.Contains(character))
            {
                currentRow.Add(cellContentBuilder.ToString());
                cellContentBuilder.Clear();
                continue;
            }

            if (isTextContent && _textContentMarkers.Contains(character) && _separators.Contains(nextCharacter))
            {
                isTextContent = false;
                currentRow.Add(cellContentBuilder.ToString());
                cellContentBuilder.Clear();
                charIndex++;
                continue;
            }

            if (!isTextContent && _rowEndingCharacters.Contains(character))
            {
                currentRow.Add(cellContentBuilder.ToString());
                cellContentBuilder.Clear();
                currentRowIndex++;
                csvFileLines.Add(currentRowIndex, new List<string>());
                currentRow = csvFileLines[currentRowIndex];
                isStillSearchingNewLine = true;
                continue;
            }

            if (isTextContent && _textContentMarkers.Contains(character) && _rowEndingCharacters.Contains(nextCharacter))
            {
                isTextContent = false;
                currentRow.Add(cellContentBuilder.ToString());
                cellContentBuilder.Clear();
                charIndex++;
                currentRowIndex++;
                csvFileLines.Add(currentRowIndex, new List<string>());
                currentRow = csvFileLines[currentRowIndex];
                isStillSearchingNewLine = true;
                continue;
            }

            cellContentBuilder.Append(character);
        }

        int tableRowIndex = 0;

        foreach (KeyValuePair<int, List<string>> fileLine in csvFileLines)
        {
            DataRow dataRow = dataTable.NewRow();
            int tableColumnIndex = 0;

            foreach (string cellValue in fileLine.Value)
            {
                if (tableRowIndex == 0)
                {
                    dataTable.Columns.Add(new DataColumn($"[{tableColumnIndex:0000}] {cellValue}", typeof(string)));
                    tableColumnIndex++;
                    continue;
                }

                dataRow[tableColumnIndex] = cellValue;
                tableColumnIndex++;
            }

            if (tableRowIndex > 0)
            {
                dataTable.Rows.Add(dataRow);
            }

            tableRowIndex++;
        }

        return dataTable;
    }
}