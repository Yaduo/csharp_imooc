using System;

namespace HelloWord
{
    public class Installer
    {
        private readonly Logger logger;

        public Installer(Logger logger)
        {
            this.logger = logger;
        }

        public void Install()
        {
            logger.Log("安装开始");
            // TODO: 安装过程
        }
    }
}
