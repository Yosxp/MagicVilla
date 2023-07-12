using MagicVilla.Infraestructura.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MagicVilla.Infraestructura.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        public IContextoDB Contexto { get; }

        public UnitOfWork(IContextoDB pCcontexto, IServiceProvider pServicesProvider)
        {
            Contexto = pCcontexto;
        }

        public void Commit()
        {
            Contexto.Instance.SaveChanges();
        }

        public void CommitAndRefreshChanges()
        {
            bool saved = false;
            while (!saved)
            {
                try
                {
                    Contexto.Instance.SaveChanges();
                    saved = true;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    foreach (EntityEntry entry in ex.Entries)
                    {
                        PropertyValues proposedValues = entry.CurrentValues;
                        PropertyValues databaseValues = entry.GetDatabaseValues();

                        foreach (IProperty property in proposedValues.Properties)
                        {
                            object proposedValue = proposedValues[property];
                            object databaseValue = databaseValues[property];

                            if (property.Name == "Version")
                            {
                                proposedValues[property] = databaseValue;
                            }
                            else
                            {
                                proposedValues[property] = proposedValue;
                            }

                        }
                        entry.OriginalValues.SetValues(databaseValues);
                    }
                }
            }
        }

        public void Dispose()
        {
            Contexto.Dispose();
        }
    }
}
