using System.Collections.Generic;
using System.Threading.Tasks;
using WestCoastEducationAvalonia.Models;

namespace WestCoastEducationAvalonia.Interfaces;

public interface IKnowledgeAreaService
{
    Task<List<KnowledgeArea>> GetKnowledgeAreasAsync();

}