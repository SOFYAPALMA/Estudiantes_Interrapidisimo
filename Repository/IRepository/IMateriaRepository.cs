﻿using Domain.Model;

namespace Repository.IRepository
{
    public interface IMateriaRepository
    {
        /// <summary>
        /// Nelly Palma
        /// Metodo para Consultar Materia
        /// </summary>
        /// <returns></returns>
        Task<List<MateriaModel>?> ConsultarMaterias();

        /// <summary>
        /// Nelly Palma
        /// Metodo para Consultar Materia por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<MateriaModel>? ConsultarMateriaId(int id);

        Task<EstudianteMateriaModel>? EstudianteMateriaId(int id);

    }
}
