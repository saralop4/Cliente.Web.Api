﻿using Cliente.Web.Api.Aplicacion.Interfaces;
using Cliente.Web.Api.Dominio.DTOs;
using Cliente.Web.Api.Dominio.Interfaces;
using Cliente.Web.Api.Transversal.Interfaces;
using Cliente.Web.Api.Transversal.Modelos;

namespace Cliente.Web.Api.Aplicacion.Servicios;

public class IndicativoServicio : IIndicativoServicio
{
    private readonly IIndicativoRepositorio _indicativoRepositorio;
    private readonly IAppLogger<IndicativoServicio> _logger;

    public IndicativoServicio(IIndicativoRepositorio indicativoRepositorio,IAppLogger<IndicativoServicio> logger)
    {
        _indicativoRepositorio = indicativoRepositorio;
        _logger = logger;

    }

    public async Task<Response<IEnumerable<IndicativoDto>>> ObtenerTodos()
    {
        var response = new Response<IEnumerable<IndicativoDto>>();

        try
        {
            var resultado = await _indicativoRepositorio.ObtenerTodo();

            if (resultado != null && resultado.Any())
            {
                response.Data = resultado;
                response.IsSuccess = true;
                _logger.LogInformation("Consulta exitosa!!");
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "No hay información disponible";
                _logger.LogInformation("La consulta de obtener todo de base de datos está vacia");
            }
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = $"Ocurrió un error: {ex.Message}";
            _logger.LogError(ex.Message);
        }

        return response;
    }
}
