using ProjectManager.Business.Repositories;
using ProjectManager.Data.Contexts;
using ProjectManager.Data.Entities;
using ProjectManager.Data.Interfaces;

namespace ProjectManager.Data.Repositories;

public class DocumentRepository(DataContext context) : BaseRepository<DocumentEntity>(context), IDocumentRepository
{
}

