using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using System.Globalization;

using QDocument = QuestPDF.Fluent.Document;
using QPdfContainer = QuestPDF.Infrastructure.IContainer;

namespace SIGEBI.Application.Services
{
    public class GeneradorReportePDF : IPDFService
    {
        private const string ColorPrimario = "#1E3A8A";
        private const string ColorSecundario = "#2563EB";
        private const string ColorFondo = "#F8FAFC";
        private const string ColorBorde = "#CBD5E1";
        private const string ColorTexto = "#0F172A";
        private const string ColorTextoClaro = "#64748B";
        private const string ColorBlanco = "#FFFFFF";

        public byte[] GenerarReportePrestamosPDF(ReportePrestamosResponseDTO reporte)
        {
            var porcentajePuntualidad = reporte.TotalPrestamos == 0
                ? 0
                : (double)reporte.PrestamosDevueltosATiempo * 100 / reporte.TotalPrestamos;

            return QDocument.Create(document =>
            {
                document.Page(page =>
                {
                    ConfigurarPagina(page);

                    page.Header().Element(container =>
                        CrearEncabezado(container, "REPORTE DE PRÉSTAMOS", "Resumen general de préstamos registrados en el sistema"));

                    page.Content().PaddingVertical(15).Column(column =>
                    {
                        column.Spacing(15);

                        column.Item().Element(container => CrearFechaGeneracion(container));

                        column.Item().Row(row =>
                        {
                            row.Spacing(10);

                            row.RelativeItem().Element(container =>
                                CrearTarjetaResumen(container, "Total préstamos", reporte.TotalPrestamos.ToString()));

                            row.RelativeItem().Element(container =>
                                CrearTarjetaResumen(container, "Devueltos a tiempo", reporte.PrestamosDevueltosATiempo.ToString()));

                            row.RelativeItem().Element(container =>
                                CrearTarjetaResumen(container, "Préstamos vencidos", reporte.PrestamosVencidos.ToString()));

                            row.RelativeItem().Element(container =>
                                CrearTarjetaResumen(container, "Puntualidad", $"{porcentajePuntualidad:N2}%"));
                        });

                        column.Item().Element(container =>
                            CrearTituloSeccion(container, "Detalle de préstamos"));

                        if (reporte.prestamos == null || !reporte.prestamos.Any())
                        {
                            column.Item().Element(container => CrearMensajeSinDatos(container));
                        }
                        else
                        {
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(70);
                                    columns.RelativeColumn();
                                    columns.ConstantColumn(90);
                                    columns.ConstantColumn(90);
                                    columns.ConstantColumn(80);
                                });

                                table.Header(header =>
                                {
                                    CrearCeldaEncabezado(header, "ID");
                                    CrearCeldaEncabezado(header, "Recurso");
                                    CrearCeldaEncabezado(header, "Préstamo");
                                    CrearCeldaEncabezado(header, "Devolución");
                                    CrearCeldaEncabezado(header, "Estado");
                                });

                                foreach (var prestamo in reporte.prestamos)
                                {
                                    CrearCeldaTexto(table, prestamo.IdPrestamo.ToString());
                                    CrearCeldaTexto(table, prestamo.IdRecurso);
                                    CrearCeldaTexto(table, FormatearFecha(prestamo.FechaPrestamo));
                                    CrearCeldaTexto(table, prestamo.FechaDevolucion.HasValue
                                        ? FormatearFecha(prestamo.FechaDevolucion.Value)
                                        : "Pendiente");
                                    CrearCeldaTexto(table, prestamo.Estado);
                                }
                            });
                        }
                    });

                    page.Footer().Element(CrearPiePagina);
                });
            }).GeneratePdf();
        }

        public byte[] GenerarReporteInventarioPDF(ReporteInventarioResponseDTO reporte)
        {
            return QDocument.Create(document =>
            {
                document.Page(page =>
                {
                    ConfigurarPagina(page);

                    page.Header().Element(container =>
                        CrearEncabezado(container, "REPORTE DE INVENTARIO", "Estado general de los recursos físicos registrados"));

                    page.Content().PaddingVertical(15).Column(column =>
                    {
                        column.Spacing(15);

                        column.Item().Element(container => CrearFechaGeneracion(container));

                        column.Item().Row(row =>
                        {
                            row.Spacing(10);

                            row.RelativeItem().Element(container =>
                                CrearTarjetaResumen(container, "Total recursos", reporte.TotalRecursos.ToString()));

                            row.RelativeItem().Element(container =>
                                CrearTarjetaResumen(container, "Disponibles", reporte.RecursoDisponibles.ToString()));

                            row.RelativeItem().Element(container =>
                                CrearTarjetaResumen(container, "Prestados", reporte.RecursosPrestados.ToString()));

                            row.RelativeItem().Element(container =>
                                CrearTarjetaResumen(container, "Fuera de servicio", reporte.RecursosDaniados.ToString()));
                        });

                        column.Item().Element(container =>
                            CrearTituloSeccion(container, "Detalle de inventario"));

                        if (reporte.Recursos == null || !reporte.Recursos.Any())
                        {
                            column.Item().Element(container => CrearMensajeSinDatos(container));
                        }
                        else
                        {
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(90);
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.ConstantColumn(100);
                                });

                                table.Header(header =>
                                {
                                    CrearCeldaEncabezado(header, "Código");
                                    CrearCeldaEncabezado(header, "Título");
                                    CrearCeldaEncabezado(header, "Categoría");
                                    CrearCeldaEncabezado(header, "Estado");
                                });

                                foreach (var recurso in reporte.Recursos)
                                {
                                    CrearCeldaTexto(table, recurso.Codigo);
                                    CrearCeldaTexto(table, recurso.Titulo);
                                    CrearCeldaTexto(table, recurso.Categoria);
                                    CrearCeldaTexto(table, recurso.Estado);
                                }
                            });
                        }
                    });

                    page.Footer().Element(CrearPiePagina);
                });
            }).GeneratePdf();
        }

        public byte[] GenerarReporteUsoCatalogoPDF(ReporteCatalogoResponseDTO reporte)
        {
            return QDocument.Create(document =>
            {
                document.Page(page =>
                {
                    ConfigurarPagina(page);

                    page.Header().Element(container =>
                        CrearEncabezado(container, "REPORTE DE USO DEL CATÁLOGO", "Recursos más solicitados y demanda por categoría"));

                    page.Content().PaddingVertical(15).Column(column =>
                    {
                        column.Spacing(15);

                        column.Item().Element(container => CrearFechaGeneracion(container));

                        var totalSolicitudes = reporte.RecursosMasSolicitados?.Sum(r => r.CantidadSolicitudes) ?? 0;
                        var totalCategorias = reporte.DemandaCategorias?.Count ?? 0;

                        column.Item().Row(row =>
                        {
                            row.Spacing(10);

                            row.RelativeItem().Element(container =>
                                CrearTarjetaResumen(container, "Total solicitudes", totalSolicitudes.ToString()));

                            row.RelativeItem().Element(container =>
                                CrearTarjetaResumen(container, "Recursos solicitados", (reporte.RecursosMasSolicitados?.Count ?? 0).ToString()));

                            row.RelativeItem().Element(container =>
                                CrearTarjetaResumen(container, "Categorías con demanda", totalCategorias.ToString()));
                        });

                        column.Item().Element(container =>
                            CrearTituloSeccion(container, "Recursos más solicitados"));

                        if (reporte.RecursosMasSolicitados == null || !reporte.RecursosMasSolicitados.Any())
                        {
                            column.Item().Element(container => CrearMensajeSinDatos(container));
                        }
                        else
                        {
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(90);
                                    columns.RelativeColumn();
                                    columns.ConstantColumn(100);
                                });

                                table.Header(header =>
                                {
                                    CrearCeldaEncabezado(header, "Recurso ID");
                                    CrearCeldaEncabezado(header, "Título");
                                    CrearCeldaEncabezado(header, "Solicitudes");
                                });

                                foreach (var recurso in reporte.RecursosMasSolicitados)
                                {
                                    CrearCeldaTexto(table, recurso.RecursoId);
                                    CrearCeldaTexto(table, recurso.titulo);
                                    CrearCeldaTexto(table, recurso.CantidadSolicitudes.ToString());
                                }
                            });
                        }

                        column.Item().PaddingTop(10).Element(container =>
                            CrearTituloSeccion(container, "Demanda por categoría"));

                        if (reporte.DemandaCategorias == null || !reporte.DemandaCategorias.Any())
                        {
                            column.Item().Element(container => CrearMensajeSinDatos(container));
                        }
                        else
                        {
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                    columns.ConstantColumn(120);
                                });

                                table.Header(header =>
                                {
                                    CrearCeldaEncabezado(header, "Categoría");
                                    CrearCeldaEncabezado(header, "Cantidad solicitada");
                                });

                                foreach (var categoria in reporte.DemandaCategorias)
                                {
                                    CrearCeldaTexto(table, categoria.Categoria);
                                    CrearCeldaTexto(table, categoria.CantidadSolicitada.ToString());
                                }
                            });
                        }
                    });

                    page.Footer().Element(CrearPiePagina);
                });
            }).GeneratePdf();
        }

        public byte[] GenerarReportePenalizacionesPDF(ReportePenalizacionesDTO reporte)
        {
            return QDocument.Create(document =>
            {
                document.Page(page =>
                {
                    ConfigurarPagina(page);

                    page.Header().Element(container =>
                        CrearEncabezado(container, "REPORTE DE PENALIZACIONES", "Resumen de penalizaciones emitidas en el sistema"));

                    page.Content().PaddingVertical(15).Column(column =>
                    {
                        column.Spacing(15);

                        column.Item().Element(container => CrearFechaGeneracion(container));

                        var penalizacionesPagadas = reporte.DetallesPenalizaciones?.Count(p => p.Pagada) ?? 0;
                        var penalizacionesPendientes = reporte.DetallesPenalizaciones?.Count(p => !p.Pagada) ?? 0;

                        column.Item().Row(row =>
                        {
                            row.Spacing(10);

                            row.RelativeItem().Element(container =>
                                CrearTarjetaResumen(container, "Total penalizaciones", reporte.TotalPenalizaciones.ToString()));

                            row.RelativeItem().Element(container =>
                                CrearTarjetaResumen(container, "Monto total", FormatearMonto(reporte.MontoTotal)));

                            row.RelativeItem().Element(container =>
                                CrearTarjetaResumen(container, "Pagadas", penalizacionesPagadas.ToString()));

                            row.RelativeItem().Element(container =>
                                CrearTarjetaResumen(container, "Pendientes", penalizacionesPendientes.ToString()));
                        });

                        column.Item().Element(container =>
                            CrearTituloSeccion(container, "Detalle de penalizaciones"));

                        if (reporte.DetallesPenalizaciones == null || !reporte.DetallesPenalizaciones.Any())
                        {
                            column.Item().Element(container => CrearMensajeSinDatos(container));
                        }
                        else
                        {
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(70);
                                    columns.RelativeColumn();
                                    columns.ConstantColumn(90);
                                    columns.ConstantColumn(90);
                                    columns.ConstantColumn(80);
                                });

                                table.Header(header =>
                                {
                                    CrearCeldaEncabezado(header, "Usuario");
                                    CrearCeldaEncabezado(header, "Motivo");
                                    CrearCeldaEncabezado(header, "Monto");
                                    CrearCeldaEncabezado(header, "Fecha");
                                    CrearCeldaEncabezado(header, "Pagada");
                                });

                                foreach (var penalizacion in reporte.DetallesPenalizaciones)
                                {
                                    CrearCeldaTexto(table, penalizacion.IdUsuario.ToString());
                                    CrearCeldaTexto(table, penalizacion.Motivo);
                                    CrearCeldaTexto(table, FormatearMonto(penalizacion.Monto));
                                    CrearCeldaTexto(table, FormatearFecha(penalizacion.Fecha));
                                    CrearCeldaTexto(table, penalizacion.Pagada ? "Sí" : "No");
                                }
                            });
                        }
                    });

                    page.Footer().Element(CrearPiePagina);
                });
            }).GeneratePdf();
        }

        public byte[] GenerarReporteAuditoriaPDF(IEnumerable<AuditoriaResponseDTO> auditorias)
        {
            var registros = auditorias?
                .OrderByDescending(a => a.FechaHora)
                .ToList() ?? new List<AuditoriaResponseDTO>();

            var totalRegistros = registros.Count;

            var totalUsuarios = registros
                .Select(a => a.IdResponsable)
                .Distinct()
                .Count();

            var totalEntidades = registros
                .Where(a => !string.IsNullOrWhiteSpace(a.EntidadAfectada))
                .Select(a => a.EntidadAfectada.Trim().ToLowerInvariant())
                .Distinct()
                .Count();

            var totalAcciones = registros
                .Where(a => !string.IsNullOrWhiteSpace(a.Accion))
                .Select(a => a.Accion.Trim().ToLowerInvariant())
                .Distinct()
                .Count();

            return QDocument.Create(document =>
            {
                document.Page(page =>
                {
                    ConfigurarPaginaHorizontal(page);

                    page.Header().Element(container =>
                        CrearEncabezado(
                            container,
                            "LOG DE AUDITORÍA",
                            "Registro de acciones realizadas por los usuarios dentro del sistema"));

                    page.Content().PaddingVertical(15).Column(column =>
                    {
                        column.Spacing(15);

                        column.Item().Element(container => CrearFechaGeneracion(container));

                        column.Item().Row(row =>
                        {
                            row.Spacing(10);

                            row.RelativeItem().Element(container =>
                                CrearTarjetaResumen(container, "Total registros", totalRegistros.ToString()));

                            row.RelativeItem().Element(container =>
                                CrearTarjetaResumen(container, "Usuarios actores", totalUsuarios.ToString()));

                            row.RelativeItem().Element(container =>
                                CrearTarjetaResumen(container, "Entidades afectadas", totalEntidades.ToString()));

                            row.RelativeItem().Element(container =>
                                CrearTarjetaResumen(container, "Tipos de acciones", totalAcciones.ToString()));
                        });

                        column.Item().Element(container =>
                            CrearTituloSeccion(container, "Detalle del historial de auditoría"));

                        if (!registros.Any())
                        {
                            column.Item().Element(container => CrearMensajeSinDatos(container));
                        }
                        else
                        {
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(60);
                                    columns.ConstantColumn(75);
                                    columns.ConstantColumn(115);
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn(2);
                                });

                                table.Header(header =>
                                {
                                    CrearCeldaEncabezado(header, "ID");
                                    CrearCeldaEncabezado(header, "Usuario");
                                    CrearCeldaEncabezado(header, "Fecha y hora");
                                    CrearCeldaEncabezado(header, "Acción");
                                    CrearCeldaEncabezado(header, "Entidad");
                                    CrearCeldaEncabezado(header, "Detalles");
                                });

                                foreach (var registro in registros)
                                {
                                    CrearCeldaTexto(table, registro.IdAuditoria.ToString());
                                    CrearCeldaTexto(table, registro.IdResponsable.ToString());
                                    CrearCeldaTexto(table, FormatearFechaHora(registro.FechaHora));
                                    CrearCeldaTexto(table, registro.Accion);
                                    CrearCeldaTexto(table, registro.EntidadAfectada);
                                    CrearCeldaTexto(table, RecortarTexto(registro.Detalles, 160));
                                }
                            });
                        }
                    });

                    page.Footer().Element(CrearPiePagina);
                });
            }).GeneratePdf();
        }

        private static void ConfigurarPagina(PageDescriptor page)
        {
            page.Size(PageSizes.A4);
            page.Margin(30);
            page.PageColor(ColorBlanco);
            page.DefaultTextStyle(text => text.FontSize(10).FontColor(ColorTexto));
        }

        private static void CrearEncabezado(QPdfContainer container, string titulo, string subtitulo)
        {
            container
                .Background(ColorPrimario)
                .Padding(18)
                .Column(column =>
                {
                    column.Spacing(4);

                    column.Item()
                        .Text("SIGEBI")
                        .FontSize(26)
                        .Bold()
                        .FontColor(ColorBlanco);

                    column.Item()
                        .Text(titulo)
                        .FontSize(16)
                        .SemiBold()
                        .FontColor(ColorBlanco);

                    column.Item()
                        .Text(subtitulo)
                        .FontSize(10)
                        .FontColor("#DBEAFE");
                });
        }

        private static void CrearFechaGeneracion(QPdfContainer container)
        {
            container
                .Background(ColorFondo)
                .Border(1)
                .BorderColor(ColorBorde)
                .Padding(10)
                .Row(row =>
                {
                    row.RelativeItem()
                        .Text("Documento generado automáticamente por el Sistema de Gestión Bibliotecaria")
                        .FontSize(9)
                        .FontColor(ColorTextoClaro);

                    row.ConstantItem(160)
                        .AlignRight()
                        .Text($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}")
                        .FontSize(9)
                        .SemiBold()
                        .FontColor(ColorTexto);
                });
        }

        private static void CrearTarjetaResumen(QPdfContainer container, string titulo, string valor)
        {
            container
                .Background(ColorFondo)
                .Border(1)
                .BorderColor(ColorBorde)
                .Padding(12)
                .Column(column =>
                {
                    column.Spacing(5);

                    column.Item()
                        .Text(titulo)
                        .FontSize(9)
                        .FontColor(ColorTextoClaro);

                    column.Item()
                        .Text(valor)
                        .FontSize(15)
                        .Bold()
                        .FontColor(ColorPrimario);
                });
        }

        private static void CrearTituloSeccion(QPdfContainer container, string titulo)
        {
            container
                .PaddingTop(5)
                .PaddingBottom(5)
                .BorderBottom(1)
                .BorderColor(ColorBorde)
                .Text(titulo)
                .FontSize(13)
                .Bold()
                .FontColor(ColorPrimario);
        }

        private static void CrearMensajeSinDatos(QPdfContainer container)
        {
            container
                .Background("#FEF3C7")
                .Border(1)
                .BorderColor("#F59E0B")
                .Padding(12)
                .Text("No hay datos disponibles para este reporte.")
                .FontSize(10)
                .FontColor("#92400E");
        }

        private static void CrearPiePagina(QPdfContainer container)
        {
            container
                .BorderTop(1)
                .BorderColor(ColorBorde)
                .PaddingTop(8)
                .Row(row =>
                {
                    row.RelativeItem()
                        .Text("SIGEBI - Sistema de Gestión Bibliotecaria")
                        .FontSize(9)
                        .FontColor(ColorTextoClaro);

                    row.ConstantItem(120)
                        .AlignRight()
                        .Text(text =>
                        {
                            text.Span("Página ").FontSize(9).FontColor(ColorTextoClaro);
                            text.CurrentPageNumber().FontSize(9).FontColor(ColorTextoClaro);
                            text.Span(" de ").FontSize(9).FontColor(ColorTextoClaro);
                            text.TotalPages().FontSize(9).FontColor(ColorTextoClaro);
                        });
                });
        }

        private static void CrearCeldaEncabezado(TableCellDescriptor header, string texto)
        {
            header.Cell()
                .Background(ColorSecundario)
                .Border(1)
                .BorderColor(ColorSecundario)
                .PaddingVertical(7)
                .PaddingHorizontal(5)
                .Text(texto)
                .FontSize(9)
                .Bold()
                .FontColor(ColorBlanco);
        }

        private static void CrearCeldaTexto(TableDescriptor table, string? texto)
        {
            table.Cell()
                .BorderBottom(1)
                .BorderColor(ColorBorde)
                .PaddingVertical(6)
                .PaddingHorizontal(5)
                .Text(string.IsNullOrWhiteSpace(texto) ? "N/A" : texto)
                .FontSize(9)
                .FontColor(ColorTexto);
        }

        private static void ConfigurarPaginaHorizontal(PageDescriptor page)
        {
            page.Size(PageSizes.A4.Landscape());
            page.Margin(25);
            page.PageColor(ColorBlanco);
            page.DefaultTextStyle(text => text.FontSize(9).FontColor(ColorTexto));
        }

        private static string FormatearFechaHora(DateTime fecha)
        {
            return fecha.ToString("dd/MM/yyyy HH:mm");
        }

        private static string RecortarTexto(string? texto, int longitudMaxima)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return "N/A";

            texto = texto.Trim();

            if (texto.Length <= longitudMaxima)
                return texto;

            return texto.Substring(0, longitudMaxima) + "...";
        }

        private static string FormatearFecha(DateTime fecha)
        {
            return fecha.ToString("dd/MM/yyyy");
        }

        private static string FormatearMonto(double monto)
        {
            return $"RD$ {monto.ToString("N2", CultureInfo.InvariantCulture)}";
        }
    }
}