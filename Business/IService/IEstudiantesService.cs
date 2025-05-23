﻿using Commun;
using Dtos;

namespace Business.IService
{
    public interface IEstudiantesService
    {
        Task<Result> CrearEstudiante(EstudiantesCrearDto crear);
        Task<Result> ConsultarEstudiantes();
        Task<Result> ConsultarEstudianteId(int id);
        Task<Result> ActualizarEstudiante(EstudiantesActualizarDto estudiantes);        
        Task<Result> EliminarEstudiante(int id);
        Task<Result> ConsultarEstudianteEmail(string correo);
        Task<Result> ValidarLogin(InicioSesionDto validar);


    }
}
