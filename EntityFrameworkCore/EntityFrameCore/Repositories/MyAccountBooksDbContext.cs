using Microsoft.EntityFrameworkCore;
using MyAccountBooks.Core.MyAccountBooksCore;
using System.Text.RegularExpressions;
namespace MyAccountBooks.EntityFrameworkCore.EntityFrameCore.Repositories
{
    public class MyAccountBooksDbContext : DbContext
    {

        #region  实体
        public DbSet<User> CrmDownpayment { get; set; }

        #endregion

        public MyAccountBooksDbContext(DbContextOptions<MyAccountBooksDbContext> options) :base(options) { 
        
        }

        #region  重写
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            OracelConverter(modelBuilder);
          
        }

        #endregion 
        #region > 表名与列名转换 <
        private void OracelConverter(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // 覆写表名              
                entity.SetTableName(ToSnakeCase(entity.GetTableName()));

                foreach (var property in entity.GetProperties())
                {

                    property.SetColumnName(ToSnakeCase(property.GetColumnName()));
                }

                // 覆写主键
                foreach (var key in entity.GetKeys())
                {
                    key.SetName(ToSnakeCase(key.GetName()));
                }

                // 覆写外键
                foreach (var key in entity.GetForeignKeys())
                {
                    key.SetConstraintName(ToSnakeCase(key.GetConstraintName()));
                    key.DeleteBehavior = DeleteBehavior.Restrict;
                }

                // 覆写索引
                foreach (var index in entity.GetIndexes())
                {
                    index.SetName(ToSnakeCase(index.GetName()));
                }


            }
        }
        #endregion

        #region 表字段的命名规则
        /// <summary>
        /// 转换为 main_keys_id 这种形式的字符串方式
        /// </summary>
        public string ToSnakeCase(string input)
        {
            if (string.IsNullOrEmpty(input)) { return input; }

            var startUnderscores = Regex.Match(input, @"^_+");
            return startUnderscores + Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
        }
        #endregion
    }
}
