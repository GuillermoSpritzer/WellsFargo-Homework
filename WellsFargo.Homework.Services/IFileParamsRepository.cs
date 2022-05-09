using WellsFargo.Homework.Services.Domain;

namespace WellsFargo.Homework.Services
{
    public interface IFileParamsRepository
    {
        public FileParams getFileParams(string id);
    }
}