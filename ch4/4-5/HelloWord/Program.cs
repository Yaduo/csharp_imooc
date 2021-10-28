using System;

namespace HelloWord
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new Logger();
            var dbMigrater = new DbMigrator(logger);
            var installer = new Installer(logger);

            installer.Install();
            dbMigrater.Migrate();

            Console.Read();
        }
    }
}
