namespace HelloWord
{
    public class DbMigrator
    {
        private readonly Logger _logger;
        public DbMigrator(Logger logger)
        {
            _logger = logger;
        }
        public void Migrate()
        {
            _logger.Log("数据迁移开始");
            // TODO: 处理数据迁移
        }
    }
}
