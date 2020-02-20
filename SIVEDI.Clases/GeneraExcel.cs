using System;
using System.Collections.Generic;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using SIVEDI.Clases.TABLAS;
using System.IO;

namespace SIVEDI.Clases
{
    public class GeneraExcel
    {
        public string generaArchivo(object ListaPrecios, string strRutaArchivo)
        {
            int i = 0;
            int j = 0;
            XSSFWorkbook wb = new XSSFWorkbook();
            ISheet sheet = wb.CreateSheet("ListaPrecios");

            //Definición de los estilos de cada celda 
            var font = wb.CreateFont();
            font.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
            font.FontHeightInPoints = 10;
            font.FontName = "Calibri";

            ICellStyle testeStyle = wb.CreateCellStyle();
            ICellStyle testeStyle1 = wb.CreateCellStyle();
            var font1 = wb.CreateFont();

            testeStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            testeStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            testeStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            testeStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            testeStyle.SetFont(font);

            testeStyle1.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            testeStyle1.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            testeStyle1.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            testeStyle1.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;

            font1.FontHeightInPoints = 10;
            font1.FontName = "Calibri";
            testeStyle1.SetFont(font1);

            //Creación de los encabezados de cada columna
            var r = sheet.CreateRow(0);

            List<ListaPreciosProducto> ListaExportable = new List<ListaPreciosProducto>((IEnumerable<ListaPreciosProducto>)ListaPrecios);


            foreach (ListaPreciosProducto Lista in ListaExportable)
            {
                IRow row = sheet.GetRow(i);
                foreach (var prop in Lista.GetType().GetProperties())
                {
                    var cell = r.CreateCell(j);
                    var atts = prop.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                    cell.SetCellValue((atts[0] as DisplayNameAttribute).DisplayName);
                    cell.CellStyle = testeStyle;
                    cell.CellStyle.SetFont(font);
                    j++;
                }
                break;
            }
            i = 1;
            foreach (ListaPreciosProducto Lista in ListaExportable)
            {
                var z = sheet.CreateRow(i);
                IRow row = sheet.GetRow(i);
                ICell cell0 = row.CreateCell(0);
                cell0.SetCellValue(Convert.ToDouble(Lista.CODIGO));
                cell0.CellStyle = testeStyle1;

                ICell cell1 = row.CreateCell(1);
                cell1.SetCellValue(Lista.CODIGO_VENTA);
                cell1.CellStyle = testeStyle1;

                ICell cell2 = row.CreateCell(2);
                cell2.SetCellValue(Lista.REFERENCIA);
                cell2.CellStyle = testeStyle1;

                ICell cell3 = row.CreateCell(3);
                cell3.SetCellValue(Lista.NOMBRE);
                cell3.CellStyle = testeStyle1;

                ICell cell4 = row.CreateCell(4);
                cell4.SetCellValue(Lista.PRECIO.ToString());
                cell4.CellStyle = testeStyle1;

                ICell cell5 = row.CreateCell(5);
                cell5.SetCellValue(Lista.LIMITE);
                cell5.CellStyle = testeStyle1;

                ICell cell6 = row.CreateCell(6);
                cell6.SetCellValue(Lista.PRINCIPAL);
                cell6.CellStyle = testeStyle1;

                ICell cell7 = row.CreateCell(7);
                cell7.SetCellValue(Lista.DIGITA);
                cell7.CellStyle = testeStyle1;

                ICell cell8 = row.CreateCell(8);
                cell8.SetCellValue(Lista.SUMA_PUBLICO);
                cell8.CellStyle = testeStyle1;

                ICell cell9 = row.CreateCell(9);
                cell9.SetCellValue(Lista.SUMA_ESCALA);
                cell9.CellStyle = testeStyle1;

                ICell cell10 = row.CreateCell(10);
                cell10.SetCellValue(Lista.APLICA_ESCALA);
                cell10.CellStyle = testeStyle1;

                ICell cell11 = row.CreateCell(11);
                cell11.SetCellValue(Lista.SUMA_MINIMO);
                cell11.CellStyle = testeStyle1;

                ICell cell12 = row.CreateCell(12);
                cell12.SetCellValue(Lista.SUMA_NETO);
                cell12.CellStyle = testeStyle1;

                ICell cell13 = row.CreateCell(13);
                cell13.SetCellValue(Lista.ES_ACCESORIO);
                cell13.CellStyle = testeStyle1;

                ICell cell14 = row.CreateCell(14);
                cell14.SetCellValue(Lista.IVA.ToString());
                cell14.CellStyle = testeStyle1;

                ICell cell15 = row.CreateCell(15);
                cell15.SetCellValue(Lista.COSTO.ToString());
                cell15.CellStyle = testeStyle1;

                ICell cell16 = row.CreateCell(16);
                cell16.SetCellValue(Lista.PUNTOS);
                cell16.CellStyle = testeStyle1;

                ICell cell17 = row.CreateCell(17);
                cell17.SetCellValue(Lista.ES_FALTANTE);
                cell17.CellStyle = testeStyle1;

                ICell cell18 = row.CreateCell(18);
                cell18.SetCellValue(Lista.PRECIO_CATALOGO.ToString());
                cell18.CellStyle = testeStyle1;


                i++;
            }

            if (!Directory.Exists(Path.GetDirectoryName(strRutaArchivo)))
            {
                DirectoryInfo di = Directory.CreateDirectory(Path.GetDirectoryName(strRutaArchivo));
            }


            string strArchivo = strRutaArchivo; //+ DateTime.Now.ToString("yyyyMMdd") + ".xls";

            using (var fs = new FileStream(strArchivo, FileMode.Create, FileAccess.Write))
            {
                sheet.AutoSizeColumn(0);
                sheet.AutoSizeColumn(1);
                sheet.AutoSizeColumn(2);
                sheet.AutoSizeColumn(3);
                sheet.AutoSizeColumn(4);
                sheet.AutoSizeColumn(5);
                sheet.AutoSizeColumn(6);
                sheet.AutoSizeColumn(7);
                sheet.AutoSizeColumn(8);
                sheet.AutoSizeColumn(9);
                sheet.AutoSizeColumn(10);
                sheet.AutoSizeColumn(11);
                sheet.AutoSizeColumn(12);
                sheet.AutoSizeColumn(13);
                sheet.AutoSizeColumn(14);
                sheet.AutoSizeColumn(15);
                sheet.AutoSizeColumn(16);
                sheet.AutoSizeColumn(17);
                sheet.AutoSizeColumn(18);
                wb.Write(fs);
            }
            return strArchivo;
        }



    }
}
