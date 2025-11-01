using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primerApi.Services.Cargues
{
    public interface ICargarExcel<T>
    {
        //XLWorkbook CreacionExcel(IFormFile rutaArchivo);
        //IXLWorksheet ObtenerHojaExcel(XLWorkbook workbook);
        //void CrearExcel(string rutaArchivo);
        //List<string> LeerExcel(string rutaArchivo);
        string CrearExcel(IFormFile rutaArchivo);
    }
    public class CargarExcel<T> : ICargarExcel<T>
    {
        public XLWorkbook CreacionExcel(Stream archivo)
        {
            return new XLWorkbook((Stream)archivo);
        }

        public IXLWorksheet ObtenerHojaExcel(XLWorkbook workbook)
        {
            var hoja = workbook.Worksheets.FirstOrDefault(x => x.Name == "Datos");
            return hoja ?? workbook.Worksheets.Add("Datos");
        }

        public string CrearExcel(IFormFile rutaArchivo)
        {
            var stream = rutaArchivo.OpenReadStream();

            using (var libro = CreacionExcel(stream))
            {
                var hoja = ObtenerHojaExcel(libro);
                hoja.Cell(1, 1).Value = "Nombre";
                libro.SaveAs(stream);
            }
            return "Excel creado correctamente";
        }

        //public List<string> LeerExcel(string rutaArchivo)
        //{
        //    var lista = new List<string>();
        //    if(!File.Exists(rutaArchivo))
        //    {
        //        return lista;
        //    }
        //    using (var libro = CreacionExcel(rutaArchivo))
        //    {
        //        var hoja = ObtenerHojaExcel(libro);
        //        foreach (var fila in hoja.RowsUsed().Skip(1)) // saltar encabezado
        //        {
        //            lista.Add(fila.Cell(1).GetValue<string>());
        //        }
        //    }

        //    return lista;
        //}
    }
}
