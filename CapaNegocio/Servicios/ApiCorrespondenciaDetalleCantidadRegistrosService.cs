﻿using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using CapaDatos.Data;
using CapaDatos.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CapaNegocio.Servicios
{
   public class ApiCorrespondenciaDetalleCantidadRegistrosService: IApiCorrespondenciaDetalleCantidadRegistrosService
    {
        private readonly AppSettings _appSettings;
        private readonly ApicacionDbContextCorrespondencia _context;
        public ApiCorrespondenciaDetalleCantidadRegistrosService(IOptions<AppSettings> appSettings, ApicacionDbContextCorrespondencia context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }
        public clsCorrespondenciaDetalleCantidadRegistrosResponse obtenerCorrespondenciaDetalleCantidadRegistros(string UsuCodigo)
        {
            //
            SqlConnection conn = (SqlConnection)_context.Database.GetDbConnection();
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;


            cmd.CommandText = "pa_CorrespondenciaDetalleCantidadRegistros";

            cmd.Parameters.Add("@UsuCodigo", System.Data.SqlDbType.Int).Value = UsuCodigo;


            var cantidad = new clsCorrespondenciaDetalleCantidadRegistrosResponse();
            var reader = cmd.ExecuteReader();



            while (reader.Read())
            {
                cantidad = MapToValue(reader);
            }
            conn.Close();


            //
            //Si el buscador no tiene elementos
            if (cantidad == null)
            {
                return null;
            }
            //Si existe Material
            return cantidad;

        }
        private clsCorrespondenciaDetalleCantidadRegistrosResponse MapToValue(SqlDataReader reader)
        {

            return new clsCorrespondenciaDetalleCantidadRegistrosResponse()
            {
                cdeRegistros = Convert.ToInt32(reader["cdeRegistros"]),

            };

        }

    }
}
