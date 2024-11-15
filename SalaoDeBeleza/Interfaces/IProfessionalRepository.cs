using SalaoDeBeleza.Classes;

namespace SalaoDeBeleza.Interfaces
{
    public interface IProfessionalRepository
    {
        List<Professional> GetAllProfessionals();
        Professional GetProfessionalById(int id);
        void AddProfessional(Professional professional);
        void UpdateProfessional(Professional professional);
        void DeleteProfessional(Professional professional);
    }
}
