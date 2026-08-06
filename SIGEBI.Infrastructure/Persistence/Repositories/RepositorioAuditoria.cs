using Microsoft.EntityFrameworkCore;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Infrastructure.Persistence.Repositories
{
    public class RepositorioAuditoria : InmutableRepository<RegistroAuditoria>, IRepositorioAuditoria
    {
        public RepositorioAuditoria(SIGEBIDbContext context) : base(context) { }

        public async Task<IEnumerable<RegistroAuditoria>> ConsultarHistorialAsync(
            DateTime? fechaInicio = null,
            DateTime? fechaFin = null,
            string? accion = null,
            string? entidadAfectada = null)
        {
            IQueryable<RegistroAuditoria> consulta = _dbSet.AsNoTracking();

            
            if (fechaInicio.HasValue)
                consulta = consulta.Where(r => r.FechaHora >= fechaInicio.Value.Date);

            if (fechaFin.HasValue)
            {
                var fechaFinDia = fechaFin.Value.Date.AddDays(1).AddTicks(-1); // Hasta las 23:59:59
                consulta = consulta.Where(r => r.FechaHora <= fechaFinDia);
            }

            
            var lista = await consulta.OrderByDescending(r => r.FechaHora).ToListAsync();

            
            if (!string.IsNullOrWhiteSpace(accion))
            {
                string accionBuscada = RemoverAcentos(accion);
                lista = lista.Where(r => RemoverAcentos(r.Accion)
                    .Contains(accionBuscada, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrWhiteSpace(entidadAfectada) && !entidadAfectada.Equals("Todos", StringComparison.OrdinalIgnoreCase))
            {
                string entidadBuscada = RemoverAcentos(entidadAfectada);
                lista = lista.Where(r => RemoverAcentos(r.EntidadAfectada)
                    .Contains(entidadBuscada, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return lista;
        }

        
        private static string RemoverAcentos(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return string.Empty;

            var textoNormalizado = texto.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (var c in textoNormalizado)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}