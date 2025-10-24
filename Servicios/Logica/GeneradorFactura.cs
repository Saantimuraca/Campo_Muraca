using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using DAO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Servicios.Datos;
using Servicios.Entidades;

namespace Servicios.Logica
{
    public class GeneradorFactura
    {
        DatosFactura df = new DatosFactura();
        DALPedido dalPedido = new DALPedido();
        ServicioMail mail = new ServicioMail();
        public void GenerarFactura(BEPedido pPedido, string metodoPago)
        {
            string carpeta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Facturas");
            if (!Directory.Exists(carpeta)) { Directory.CreateDirectory(carpeta); }
            string nombreArchivo = $"Factura_{pPedido.cliente.dni}_Pedido{pPedido.id}.pdf";
            string rutaCompleta = Path.Combine(carpeta, nombreArchivo); 
            Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
            using (FileStream fs = new FileStream(rutaCompleta, FileMode.Create))
            {
                // Le digo al documento que todo lo que escriba lo guarde en el archivo PDF que abrí con fs
                PdfWriter.GetInstance(doc, fs);
                doc.Open();
                //Titulo
                string tipo;
                if (pPedido.cliente.condicionIVA == "Responsable inscripto") { tipo = "A"; }
                else { tipo = "B"; }
                doc.Add(new Paragraph("TecnoSoft S.A", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16)));
                Paragraph titulo = new Paragraph($"FACTURA {tipo}", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18));
                titulo.Alignment = Element.ALIGN_CENTER;
                doc.Add(titulo);
                doc.Add(new Paragraph(" "));
                //Encabezado
                string nroFactura = $"0001-{df.UltimoNroFactura() + 1}";
                string fecha = DateTime.Now.ToShortDateString();
                string nombreCliente = pPedido.cliente.nombre;
                string dniCliente = pPedido.cliente.dni;
                string dniVendedor = pPedido.dniVendedor;
                string condicionIVA = pPedido.cliente.condicionIVA;
                doc.Add(new Paragraph($"Número de Factura: {nroFactura}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                doc.Add(new Paragraph($"Fecha y Hora de Emisión: {DateTime.Now:dd/MM/yyyy HH:mm:ss}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph($"DNI Cliente: {dniCliente}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                doc.Add(new Paragraph($"Nombre y Apellido: {nombreCliente}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                doc.Add(new Paragraph($"Condición Frente al IVA: {condicionIVA}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                doc.Add(new Paragraph($"DNI Vendedor: {dniVendedor}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                doc.Add(new Paragraph($"Método de Pago: {metodoPago}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                //Detalle
                doc.Add(new Paragraph(" "));
                decimal totalSinIVA = 0;
                decimal precio = 0;
                decimal ivaItem = 0;
                decimal totalIVA = 0;
                decimal subtotalProducto = 0;
                decimal subtotalIVA = 0;
                PdfPTable tabla = (tipo == "A") ? new PdfPTable(5) : new PdfPTable(4);
                tabla.WidthPercentage = 100;

                if (tipo == "A")
                    tabla.SetWidths(new float[] { 40f, 20f, 20f, 20f, 20f});
                else
                    tabla.SetWidths(new float[] { 50f, 25f, 25f, 25f });

                // 2. Encabezados
                tabla.AddCell("Producto");
                tabla.AddCell("Cantidad");
                tabla.AddCell("Precio Unitario");
                tabla.AddCell("Subtotal");

                if (tipo == "A") tabla.AddCell("Subtotal c/IVA");

                // 3. Filas del detalle
                foreach (string[] detalle in dalPedido.ItemsFactura(pPedido.id))
                {
                    tabla.AddCell(detalle[0]); // Producto
                    tabla.AddCell(detalle[1]); // Cantidad

                    precio = decimal.Parse(detalle[2]);
                    tabla.AddCell($"${precio:N2}");

                    subtotalProducto = precio * int.Parse(detalle[1]);
                    tabla.AddCell($"${subtotalProducto:N2}");

                    if (tipo == "A")
                    {
                        ivaItem = Math.Round(precio * 0.21m, 2);
                        subtotalIVA = ivaItem * int.Parse(detalle[1]);
                        tabla.AddCell($"${subtotalIVA:N2}"); //IVA
                        totalIVA += ivaItem * int.Parse(detalle[1]);
                    }

                    totalSinIVA += precio * int.Parse(detalle[1]);
                }
                doc.Add(tabla);
                doc.Add(new Paragraph(" "));
                //Totales
                decimal totalConIVA = totalSinIVA + totalIVA;
                Paragraph totalTexto = new Paragraph();
                totalTexto.Alignment = Element.ALIGN_RIGHT;
                totalTexto.Add(new Phrase($"Subtotal: ${totalSinIVA:N2}\n"));
                if (tipo == "A") { totalTexto.Add(new Phrase($"IVA (21%): ${totalIVA:N2}\n")); }
                totalTexto.Add(new Phrase($"Total Final: ${totalConIVA:N2}", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));
                doc.Add(totalTexto);
                doc.Add(new Paragraph("\nGracias por su compra.", FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 10)));
                doc.Add(new Paragraph("Este comprobante no tiene validez fiscal.", FontFactory.GetFont(FontFactory.HELVETICA, 8)));
                string rutaImagen = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogoFactura.jpeg");
                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(rutaImagen);
                logo.ScaleAbsolute(100f, 50f);
                logo.SetAbsolutePosition(doc.PageSize.Width - doc.RightMargin - logo.ScaledWidth, doc.PageSize.Height - logo.ScaledHeight - doc.TopMargin);
                doc.Add(logo);
                doc.Close();
                EntidadFactura factura = new EntidadFactura(df.UltimoNroFactura() + 1, tipo, DateTime.Now, totalSinIVA, totalConIVA, metodoPago);
                df.GuardarFactura(factura);
                df.AgregarDvh(df.DevolverRow(factura.nroFactura), DatosDV.INSTANCIA.CalcularDVHRegistroBase64(df.DevolverRow(factura.nroFactura)));
                DatosDV.INSTANCIA.CalcularDvvTabla("Factura");
                dalPedido.AdjuntarFactura(factura.nroFactura, pPedido.id);
                /*dalPedido.AgregarDvhPedido(dalPedido.DevolverRowPedido(pPedido.id), DatosDV.INSTANCIA.CalcularDVHRegistroBase64(dalPedido.DevolverRowPedido(pPedido.id)));
                DatosDV.INSTANCIA.CalcularDvvTabla("Pedido");*/
                string[] vectorMail = pPedido.cliente.mail.Split('@');
                if (vectorMail[1] == "gmail.com")
                {
                    string destinatario = pPedido.cliente.mail;
                    string asunto = "Factura de su compra - TecnoSoft S.A.";
                    string cuerpo = $"Estimado/a {pPedido.cliente.nombre},\r\n\r\nLe enviamos adjunta la factura correspondiente a su compra realizada el día {fecha}.\r\n\r\n📄 Número de Factura: {nroFactura}  \r\n💳 Método de Pago: {metodoPago}  \r\n💰 Total: ${totalConIVA}  \r\n\r\nSi tiene alguna duda o necesita un comprobante adicional, no dude en responder a este correo.\r\n\r\nGracias por confiar en **TecnoSoft S.A.**  \r\nEstamos a su disposición para lo que necesite.\r\n\r\nSaludos cordiales,  \r\nEl equipo de TecnoSoft  ";
                    mail.EnviarCorreo(destinatario, asunto, cuerpo, "saantimuraca12@gmail.com", "nspp vaef zhgg cqsd", rutaCompleta);
                }
                VerFactura(rutaCompleta);
            }
        }

        public void VerFactura(string rutaCompleta)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
            {
                FileName = rutaCompleta,
                UseShellExecute = true
            });
        }

    }
}
