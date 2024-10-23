namespace Domain.Entities.Prestatario
{
    public record Prestatario(
int PrestatarioId,
 int? ClientId,
  string? EstadoPrestatario,
int? CantidadPrestamos);
}