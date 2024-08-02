using FluentNHibernate.Mapping;
using MultiTenantWebApiStarter.Entities;

namespace MultiTenantWebApiStarter.Mappings
{
    public class BookMap : ClassMap<Book>
    {
        public BookMap()
        {
            Table("book");
            LazyLoad();
            Id(x => x.Id).Column("id").GeneratedBy.Assigned();
            Map(x => x.Title).Column("title").Not.Nullable().Length(50);
            Map(x => x.Author).Column("author").Not.Nullable().Length(100);
        }
    }
}
