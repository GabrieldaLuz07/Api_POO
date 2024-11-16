using SalaoDeBeleza.Classes;

namespace SalaoDeBeleza.Interfaces
{
    // Interface contendo todos os métodos padrões para manipulação das tabelas do banco
    public interface IProfessionalRepository
    {
        List<Professional> GetAllProfessionals();
        Professional GetProfessionalById(int id);
        void AddProfessional(Professional professional);
        void UpdateProfessional(Professional professional);
        void DeleteProfessional(Professional professional);
    }
}
