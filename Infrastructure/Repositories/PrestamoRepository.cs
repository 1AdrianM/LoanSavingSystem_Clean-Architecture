using Application.CronogramaPagos.Query;
using Application.SeedOfWork;
using Domain.Entities.Prestamo;
using Infrastructure.Mapper;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PrestamoRepository : IPrestamo
    {
        private readonly AhorrosPrestamosDb2Context _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public PrestamoRepository(AhorrosPrestamosDb2Context dbContext) {
            _dbContext = dbContext ?? throw new ArgumentException(nameof(DbContext));

        }
        public void CreatePrestamoRequest(Prestamo prestamo)
        {
            var prestatario = _dbContext.Prestatarios.Include(p => p.Client).FirstOrDefault(p => p.PrestatarioId == prestamo.PrestatarioId);
            var fiador = _dbContext.Fiadors.Include(f=> f.Client).FirstOrDefault(f =>f.FiadorId ==prestamo.FiadorId);
 
            if (prestatario == null)
            {
                throw new Exception("not found prestatario");
            }
            if( fiador == null)
            {
              throw new Exception("not found fiador");

            }
 
            var mappedPrestamo  = Prestamo.CreateSolicitud(
                prestamo.PrestamoId,
                prestatario.PrestatarioId,
                fiador.FiadorId,
                prestamo.Garantia ,
                prestamo.CodigoPrestamo,
                prestamo.FechaSolicitud,prestamo.Monto, prestamo.Interes
                );
            
           var newPrestamo = PrestamoMapper.PrestamoDomainToEF(mappedPrestamo);

            _dbContext.Prestamos.Add(newPrestamo);
 
        }

        public void Delete(Domain.Entities.Prestamo.Prestamo prestamo)
        {
            var Prestamo = PrestamoMapper.PrestamoDomainToEF(prestamo);

            _dbContext.Prestamos.Remove(Prestamo);
        }

        public async Task<IEnumerable<Prestamo>> GetAllPrestamos()
        {
          var PrestamoList= await _dbContext.Prestamos.ToListAsync();
           return PrestamoList.Select(PrestamoMapper.PrestamoEFtoDomain);


        }

        public async Task<Prestamo> GetPrestamoByCodigoPrestamo(string Codigo)
        {
           var prestamo = await _dbContext.Prestamos.AsNoTracking().FirstOrDefaultAsync(i => i.CodigoPrestamo.Equals(Codigo));
            if(prestamo == null)
            {
                throw new PrestamoNotFoundException(Codigo.ToString());
            }
            return PrestamoMapper.PrestamoEFtoDomain(prestamo);

        }

        public void UpdateDataPostApproval(Prestamo prestamo)
        {
            var Prestamo = PrestamoMapper.PrestamoDomainToEF(prestamo);

            _dbContext.Prestamos.Update(Prestamo);
        }

        public void AprobarPrestamo(Prestamo prestamo)
        {
          
          var Prestamo = PrestamoMapper.PrestamoDomainToEF(prestamo);
         
           _dbContext.Prestamos.Update(Prestamo);
        }

        public void Update(Prestamo prestamo)
        {
            var Prestamo = PrestamoMapper.PrestamoDomainToEF(prestamo);
            _dbContext.Prestamos.Update(Prestamo);

        }

        public List<Cronograma_Pagos> GenerarCronogramaPagos(Prestamo prestamo)
        {
            prestamo.GenerarCronogramaDePagos();
            List<Cronograma_Pagos> listaPrestamo = new List<Cronograma_Pagos>();
            // Calcula el número de meses del plazo del préstamo
            var totalMeses = (int)(prestamo.plazo.TotalDays / 30.44);
            Log.Information($"CANTIDAD DE MESES : {totalMeses}");
            var x = (double)(1 + prestamo.Interes);

            var n = Math.Pow(x, totalMeses);
            // Calcula el monto de la cuota mensual
            var monto_pagar = (double)prestamo.Monto * (double)prestamo.Interes * n / n - 1;
            Log.Information($" CANTIDAD DE MONTO :{monto_pagar}");
            // Inicializamos la fecha de inicio del préstamo
            DateTime? fechaPago = prestamo.FechaInicio;
            if (!fechaPago.HasValue)
            {
                throw new Exception("NULL FECHA DE PAGO");
            }
            
            if(fechaPago.Value < DateTime.Now)
            {
                fechaPago = fechaPago.Value.AddMonths(1);

            }

            Log.Information($"FECHA PAGO INICIAL :{fechaPago.ToString()}");
           
            for (int i = 0; i <= totalMeses; i++)
            {
   

                // Creamos un nuevo objeto CronogramaResponse con la fecha de pago y el monto a pagar
                var response = new Cronograma_Pagos((DateTime)fechaPago, (decimal)monto_pagar);

                // Añadimos el cronograma a la lista
                listaPrestamo.Add(response);

                // Incrementamos la fecha de pago un mes
             fechaPago = fechaPago.Value.AddMonths(1);
            }
            if (listaPrestamo.Any() == false)
            {
                Log.Information("Monto capturado : " + listaPrestamo.First().Monto);
                throw new Exception("Empty List");

            }
            return listaPrestamo;

        }

        public async Task<Prestamo> GetPrestamoByIdPrestamo(int id)
        {
            var prestamo = await _dbContext.Prestamos.AsNoTracking().FirstOrDefaultAsync(i => i.PrestamoId == id);
            if (prestamo == null)
            {
                throw new PrestamoNotFoundException(id.ToString());
            }
            return PrestamoMapper.PrestamoEFtoDomain(prestamo);
        }
    }
}
