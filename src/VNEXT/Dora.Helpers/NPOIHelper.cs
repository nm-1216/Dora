namespace Dora.Helpers
{
    using NPOI.SS.UserModel;

    /// <summary>
    /// Excel解析帮助类
    /// </summary>
    public class NpoiHelper
    {
        public static string GetValue(ICell cell)
        {
            if (cell == null)
            {
                return null;
            }

            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (cell.CellType)
            {
                case CellType.Boolean: return cell.BooleanCellValue.ToString();
                case CellType.Numeric: return cell.NumericCellValue.ToString("0.####");
                default: return cell.StringCellValue.Trim();
            }            
        }
    }
}