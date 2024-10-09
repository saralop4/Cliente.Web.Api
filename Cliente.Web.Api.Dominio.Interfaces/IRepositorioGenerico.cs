﻿namespace Cliente.Web.Api.Dominio.Interfaces;

public interface IRepositorioGenerico<T> where T : class //agregamos una restriccion para que T siempre sea de tipo class
{
    #region Metodos Asincronos
    Task<T> Guardar(T Modelo);
    Task<bool> Actualizar(T Modelo);
    Task<bool> Eliminar(long Id);
    Task<T> Obtener(long Id);
    Task<IEnumerable<T>> ObtenerTodo();
    Task<IEnumerable<T>> ObtenerTodoConPaginacion(int NumeroDePagina, int TamañoPagina);
    Task<int> Contar();

    #endregion
}
