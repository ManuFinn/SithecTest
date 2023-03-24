using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.Repositories
{
    public class HumanoRepository : Repository<Humanotable>
    {
        public HumanoRepository(DbContext context) : base(context) { }

        public override IEnumerable<Humanotable> GetAll()
        {
            return Context
                .Set<Humanotable>()
                .OrderBy(x => x.Id);
        }

        public Humanotable? GetById(int id)
        {
            return Context
                .Set<Humanotable>()
                .FirstOrDefault(x => x.Id == id);
        }

        public override void Insert(Humanotable entity)
        {
            base.Insert(entity);
        }

        public override void Update(Humanotable entity)
        {
            base.Update(entity);
        }

        public override bool IsValid(Humanotable entity, out List<string> validationErrors)
        {
            validationErrors = new List<string>();

            if (string.IsNullOrEmpty(entity.Nombre))
            {
                validationErrors.Add("El nombre no debe estar vacio");
            }
            if (string.IsNullOrEmpty(entity.Sexo))
            {
                validationErrors.Add("El sexo no debe estar vacio");
            }
            if (entity.Edad <= 0 || entity.Edad > 120 )
            {
                validationErrors.Add("La edad debe de tener un valor valido");
            }
            if (entity.Peso <= 0)
            {
                validationErrors.Add("El peso debe de tener un valor valido");
            }
            if (entity.Altura <= 0)
            {
                validationErrors.Add("La altura debe de tener un valor valido");
            }
            return validationErrors.Count == 0;
        }
    }
}
