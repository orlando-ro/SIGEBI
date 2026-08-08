using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using System.Globalization;
using System.Linq;

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

            var prestamosDevueltos = reporte.prestamos.Where(p => p.Estado.ToLower() == "devuelto").ToList();
            var prestamosPendientes = reporte.prestamos.Where(p => p.Estado.ToLower() != "devuelto").ToList();

            return QDocument.Create(document =>
            {
                document.Page(page =>
                {
                    ConfigurarPagina(page);
                    page.Header().Element(container => CrearEncabezado(container, "REPORTE DE PRÉSTAMOS", "Resumen general de préstamos divididos por estado"));

                    page.Content().PaddingVertical(15).Column(column =>
                    {
                        column.Spacing(15);
                        column.Item().Element(container => CrearFechaGeneracion(container));

                        column.Item().Row(row =>
                        {
                            row.Spacing(10);
                            row.RelativeItem().Element(container => CrearTarjetaResumen(container, "Total préstamos", reporte.TotalPrestamos.ToString()));
                            row.RelativeItem().Element(container => CrearTarjetaResumen(container, "Devueltos a tiempo", reporte.PrestamosDevueltosATiempo.ToString()));
                            row.RelativeItem().Element(container => CrearTarjetaResumen(container, "Préstamos vencidos", reporte.PrestamosVencidos.ToString()));
                            row.RelativeItem().Element(container => CrearTarjetaResumen(container, "Puntualidad", $"{porcentajePuntualidad:N2}%"));
                        });

                        // SECCIÓN 1: DEVUELTOS
                        column.Item().Element(container => CrearTituloSeccion(container, "✅ Préstamos Devueltos"));
                        if (!prestamosDevueltos.Any())
                        {
                            column.Item().Element(CrearMensajeSinDatos);
                        }
                        else
                        {
                            GenerarTablaPrestamos(column, prestamosDevueltos);
                        }

                        column.Item().PageBreak();

                        // SECCIÓN 2: PENDIENTES / ACTIVOS
                        column.Item().Element(container => CrearTituloSeccion(container, "⏳ Préstamos Pendientes / Activos"));
                        if (!prestamosPendientes.Any())
                        {
                            column.Item().Element(CrearMensajeSinDatos);
                        }
                        else
                        {
                            GenerarTablaPrestamos(column, prestamosPendientes);
                        }
                    });

                    page.Footer().Element(CrearPiePagina);
                });
            }).GeneratePdf();
        }

        private void GenerarTablaPrestamos(ColumnDescriptor column, System.Collections.Generic.List<SIGEBI.Application.DTOs.ReportesDTO.DetallesPrestamoDTO> lista)
        {
            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(2); // Usuario
                    columns.RelativeColumn(3); // Libros
                    columns.RelativeColumn(1.5f); // Préstamo
                    columns.RelativeColumn(1.5f); // Devolución
                });

                table.Header(header =>
                {
                    CrearCeldaEncabezado(header, "Usuario");
                    CrearCeldaEncabezado(header, "Libro(s) Solicitado(s)");
                    CrearCeldaEncabezado(header, "Préstamo");
                    CrearCeldaEncabezado(header, "Devolución");
                });

                foreach (var p in lista)
                {
                    CrearCeldaTexto(table, p.NombreUsuario);
                    CrearCeldaTexto(table, string.Join("\n• ", p.Libros.Select(l => l).Prepend("• " + p.Libros.FirstOrDefault())));
                    CrearCeldaTexto(table, FormatearFecha(p.FechaPrestamo));
                    CrearCeldaTexto(table, p.FechaDevolucion.HasValue ? FormatearFecha(p.FechaDevolucion.Value) : "Pendiente");
                }
            });
        }

        public byte[] GenerarReportePenalizacionesPDF(ReportePenalizacionesDTO reporte)
        {
            var pagadas = reporte.DetallesPenalizaciones.Where(p => p.Pagada).ToList();
            var pendientes = reporte.DetallesPenalizaciones.Where(p => !p.Pagada).ToList();

            return QDocument.Create(document =>
            {
                document.Page(page =>
                {
                    ConfigurarPagina(page);
                    page.Header().Element(container => CrearEncabezado(container, "REPORTE DE PENALIZACIONES", "Resumen de multas categorizadas por estado de pago"));

                    page.Content().PaddingVertical(15).Column(column =>
                    {
                        column.Spacing(15);
                        column.Item().Element(container => CrearFechaGeneracion(container));

                        column.Item().Row(row =>
                        {
                            row.Spacing(10);
                            row.RelativeItem().Element(container => CrearTarjetaResumen(container, "Total penalizaciones", reporte.TotalPenalizaciones.ToString()));
                            row.RelativeItem().Element(container => CrearTarjetaResumen(container, "Monto total", FormatearMonto(reporte.MontoTotal)));
                            row.RelativeItem().Element(container => CrearTarjetaResumen(container, "Pagadas", pagadas.Count.ToString()));
                            row.RelativeItem().Element(container => CrearTarjetaResumen(container, "Pendientes", pendientes.Count.ToString()));
                        });

                        // SECCIÓN 1: PENDIENTES
                        column.Item().Element(container => CrearTituloSeccion(container, "⚠️ Penalizaciones Pendientes de Pago"));
                        if (!pendientes.Any()) column.Item().Element(CrearMensajeSinDatos);
                        else GenerarTablaPenalizaciones(column, pendientes);

                        column.Item().PageBreak();

                        // SECCIÓN 2: PAGADAS
                        column.Item().Element(container => CrearTituloSeccion(container, "✅ Penalizaciones Pagadas"));
                        if (!pagadas.Any()) column.Item().Element(CrearMensajeSinDatos);
                        else GenerarTablaPenalizaciones(column, pagadas);
                    });

                    page.Footer().Element(CrearPiePagina);
                });
            }).GeneratePdf();
        }

        private void GenerarTablaPenalizaciones(ColumnDescriptor column, System.Collections.Generic.List<SIGEBI.Application.DTOs.ReportesDTO.DetallePenalizacionDTO> lista)
        {
            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(2);
                    columns.RelativeColumn(3);
                    columns.RelativeColumn(1.5f);
                    columns.RelativeColumn(1.5f);
                });

                table.Header(header =>
                {
                    CrearCeldaEncabezado(header, "Usuario");
                    CrearCeldaEncabezado(header, "Motivo");
                    CrearCeldaEncabezado(header, "Monto");
                    CrearCeldaEncabezado(header, "Fecha");
                });

                foreach (var pen in lista)
                {
                    CrearCeldaTexto(table, pen.NombreUsuario);
                    CrearCeldaTexto(table, pen.Motivo);
                    CrearCeldaTexto(table, FormatearMonto(pen.Monto));
                    CrearCeldaTexto(table, FormatearFecha(pen.Fecha));
                }
            });
        }

        public byte[] GenerarReporteInventarioPDF(ReporteInventarioResponseDTO reporte)
        {
            var inventarioPorCategoria = reporte.Recursos
                .GroupBy(r => r.Categoria)
                .OrderBy(g => g.Key)
                .ToList();

            return QDocument.Create(document =>
            {
                document.Page(page =>
                {
                    ConfigurarPagina(page);
                    page.Header().Element(container => CrearEncabezado(container, "REPORTE DE INVENTARIO", "Estado de recursos físicos divididos por categorías"));

                    page.Content().PaddingVertical(15).Column(column =>
                    {
                        column.Spacing(15);
                        column.Item().Element(container => CrearFechaGeneracion(container));

                        column.Item().Row(row =>
                        {
                            row.Spacing(10);
                            row.RelativeItem().Element(container => CrearTarjetaResumen(container, "Total recursos", reporte.TotalRecursos.ToString()));
                            row.RelativeItem().Element(container => CrearTarjetaResumen(container, "Disponibles", reporte.RecursoDisponibles.ToString()));
                            row.RelativeItem().Element(container => CrearTarjetaResumen(container, "Prestados", reporte.RecursosPrestados.ToString()));
                            row.RelativeItem().Element(container => CrearTarjetaResumen(container, "Fuera de servicio", reporte.RecursosDaniados.ToString()));
                        });

                        if (!inventarioPorCategoria.Any())
                        {
                            column.Item().Element(CrearMensajeSinDatos);
                        }
                        else
                        {
                            foreach (var categoria in inventarioPorCategoria)
                            {
                                column.Item().PaddingTop(10).Element(container => CrearTituloSeccion(container, $"📂 Categoría: {categoria.Key}"));

                                column.Item().Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn(3);
                                        columns.RelativeColumn(1);
                                    });

                                    table.Header(header =>
                                    {
                                        CrearCeldaEncabezado(header, "Título del Recurso");
                                        CrearCeldaEncabezado(header, "Estado Físico");
                                    });

                                    foreach (var recurso in categoria.OrderBy(r => r.Estado))
                                    {
                                        CrearCeldaTexto(table, recurso.Titulo);
                                        CrearCeldaTexto(table, recurso.Estado);
                                    }
                                });
                            }
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
                    page.Header().Element(container => CrearEncabezado(container, "USO DEL CATÁLOGO", "Recursos más solicitados y demanda por categoría"));

                    page.Content().PaddingVertical(15).Column(column =>
                    {
                        column.Spacing(15);
                        column.Item().Element(container => CrearFechaGeneracion(container));

                        var totalSolicitudes = reporte.RecursosMasSolicitados?.Sum(r => r.CantidadSolicitudes) ?? 0;
                        var totalCategorias = reporte.DemandaCategorias?.Count ?? 0;

                        column.Item().Row(row =>
                        {
                            row.Spacing(10);
                            row.RelativeItem().Element(container => CrearTarjetaResumen(container, "Total solicitudes", totalSolicitudes.ToString()));
                            row.RelativeItem().Element(container => CrearTarjetaResumen(container, "Recursos solicitados", (reporte.RecursosMasSolicitados?.Count ?? 0).ToString()));
                            row.RelativeItem().Element(container => CrearTarjetaResumen(container, "Categorías con demanda", totalCategorias.ToString()));
                        });

                        column.Item().Element(container => CrearTituloSeccion(container, "Top Recursos Más Solicitados"));

                        if (reporte.RecursosMasSolicitados == null || !reporte.RecursosMasSolicitados.Any())
                        {
                            column.Item().Element(CrearMensajeSinDatos);
                        }
                        else
                        {
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(4);
                                    columns.RelativeColumn(1);
                                });

                                table.Header(header =>
                                {
                                    CrearCeldaEncabezado(header, "Título del Libro");
                                    CrearCeldaEncabezado(header, "Veces Solicitado");
                                });

                                foreach (var recurso in reporte.RecursosMasSolicitados)
                                {
                                    CrearCeldaTexto(table, recurso.Titulo);
                                    CrearCeldaTexto(table, recurso.CantidadSolicitudes.ToString());
                                }
                            });
                        }

                        column.Item().PaddingTop(15).Element(container => CrearTituloSeccion(container, "Demanda Agrupada por Categoría"));

                        if (reporte.DemandaCategorias != null && reporte.DemandaCategorias.Any())
                        {
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(4);
                                    columns.RelativeColumn(1);
                                });

                                table.Header(header =>
                                {
                                    CrearCeldaEncabezado(header, "Categoría Temática");
                                    CrearCeldaEncabezado(header, "Total Solicitudes");
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

        public byte[] GenerarReporteAuditoriaPDF(IEnumerable<AuditoriaResponseDTO> auditorias)
        {
            var registros = auditorias?.OrderByDescending(a => a.FechaHora).ToList() ?? new List<AuditoriaResponseDTO>();

            var agrupacion = registros
                .GroupBy(r => r.EntidadAfectada)
                .OrderBy(g => g.Key)
                .ToList();

            return QDocument.Create(document =>
            {
                document.Page(page =>
                {
                    ConfigurarPaginaHorizontal(page);
                    page.Header().Element(container => CrearEncabezado(container, "LOG DE AUDITORÍA", "Registro clasificado por entidad y tipo de acción"));

                    page.Content().PaddingVertical(15).Column(column =>
                    {
                        column.Spacing(15);
                        column.Item().Element(container => CrearFechaGeneracion(container));

                        column.Item().Row(row =>
                        {
                            row.Spacing(10);
                            row.RelativeItem().Element(container => CrearTarjetaResumen(container, "Total registros", registros.Count.ToString()));
                            row.RelativeItem().Element(container => CrearTarjetaResumen(container, "Usuarios actores", registros.Select(a => a.NombreUsuario).Distinct().Count().ToString()));
                            row.RelativeItem().Element(container => CrearTarjetaResumen(container, "Entidades afectadas", agrupacion.Count.ToString()));
                            row.RelativeItem().Element(container => CrearTarjetaResumen(container, "Tipos de acciones", registros.Select(a => a.Accion).Distinct().Count().ToString()));
                        });

                        if (!registros.Any())
                        {
                            column.Item().Element(CrearMensajeSinDatos);
                        }
                        else
                        {
                            foreach (var entidad in agrupacion)
                            {
                                column.Item().PaddingTop(15).Element(c => CrearTituloSeccion(c, $"📦 Módulo / Entidad: {entidad.Key}"));

                                var acciones = entidad.GroupBy(a => a.Accion).OrderBy(a => a.Key);

                                foreach (var accion in acciones)
                                {
                                    column.Item().PaddingTop(5).PaddingBottom(2).Text($"   ⚡ Acción: {accion.Key}").FontSize(11).Bold().FontColor(ColorSecundario);

                                    column.Item().PaddingLeft(15).Table(table =>
                                    {
                                        table.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(1.5f);
                                            columns.RelativeColumn(2);
                                            columns.RelativeColumn(5);
                                        });

                                        table.Header(header =>
                                        {
                                            CrearCeldaEncabezado(header, "Fecha y hora");
                                            CrearCeldaEncabezado(header, "Usuario Responsable");
                                            CrearCeldaEncabezado(header, "Detalles de la Operación");
                                        });

                                        foreach (var reg in accion)
                                        {
                                            CrearCeldaTexto(table, FormatearFechaHora(reg.FechaHora));
                                            CrearCeldaTexto(table, reg.NombreUsuario);
                                            CrearCeldaTexto(table, reg.Detalles);
                                        }
                                    });
                                }
                            }
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

        private static void ConfigurarPaginaHorizontal(PageDescriptor page)
        {
            page.Size(PageSizes.A4.Landscape());
            page.Margin(25);
            page.PageColor(ColorBlanco);
            page.DefaultTextStyle(text => text.FontSize(9).FontColor(ColorTexto));
        }

        private static void CrearEncabezado(QPdfContainer container, string titulo, string subtitulo)
        {
            container.Background(ColorPrimario).Padding(18).Column(column =>
            {
                column.Spacing(4);
                column.Item().Text("SIGEBI").FontSize(26).Bold().FontColor(ColorBlanco);
                column.Item().Text(titulo).FontSize(16).SemiBold().FontColor(ColorBlanco);
                column.Item().Text(subtitulo).FontSize(10).FontColor("#DBEAFE");
            });
        }

        private static void CrearFechaGeneracion(QPdfContainer container)
        {
            container.Background(ColorFondo).Border(1).BorderColor(ColorBorde).Padding(10).Row(row =>
            {
                row.RelativeItem().Text("Documento generado automáticamente por el Sistema de Gestión Bibliotecaria").FontSize(9).FontColor(ColorTextoClaro);
                row.ConstantItem(160).AlignRight().Text($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}").FontSize(9).SemiBold().FontColor(ColorTexto);
            });
        }

        private static void CrearTarjetaResumen(QPdfContainer container, string titulo, string valor)
        {
            container.Background(ColorFondo).Border(1).BorderColor(ColorBorde).Padding(12).Column(column =>
            {
                column.Spacing(5);
                column.Item().Text(titulo).FontSize(9).FontColor(ColorTextoClaro);
                column.Item().Text(valor).FontSize(15).Bold().FontColor(ColorPrimario);
            });
        }

        private static void CrearTituloSeccion(QPdfContainer container, string titulo)
        {
            container.PaddingTop(5).PaddingBottom(5).BorderBottom(1).BorderColor(ColorBorde).Text(titulo).FontSize(13).Bold().FontColor(ColorPrimario);
        }

        private static void CrearMensajeSinDatos(QPdfContainer container)
        {
            container.Background("#FEF3C7").Border(1).BorderColor("#F59E0B").Padding(12).Text("No hay datos disponibles para esta sección.").FontSize(10).FontColor("#92400E");
        }

        private static void CrearPiePagina(QPdfContainer container)
        {
            container.BorderTop(1).BorderColor(ColorBorde).PaddingTop(8).Row(row =>
            {
                row.RelativeItem().Text("SIGEBI - Sistema de Gestión Bibliotecaria").FontSize(9).FontColor(ColorTextoClaro);
                row.ConstantItem(120).AlignRight().Text(text =>
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
            header.Cell().Background(ColorSecundario).Border(1).BorderColor(ColorSecundario).PaddingVertical(7).PaddingHorizontal(5).Text(texto).FontSize(9).Bold().FontColor(ColorBlanco);
        }

        private static void CrearCeldaTexto(TableDescriptor table, string? texto)
        {
            table.Cell().BorderBottom(1).BorderColor(ColorBorde).PaddingVertical(6).PaddingHorizontal(5).Text(string.IsNullOrWhiteSpace(texto) ? "N/A" : texto).FontSize(9).FontColor(ColorTexto);
        }

        private static string FormatearFechaHora(DateTime fecha) => fecha.ToString("dd/MM/yyyy HH:mm");
        private static string FormatearFecha(DateTime fecha) => fecha.ToString("dd/MM/yyyy");
        private static string FormatearMonto(double monto) => $"RD$ {monto.ToString("N2", CultureInfo.InvariantCulture)}";
    }
}