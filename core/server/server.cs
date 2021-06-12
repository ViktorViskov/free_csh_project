// libs
using utils;
using server.connection;


namespace server
{
    // main class for server
    class Server
    {
        // variables
        Connection connection;


        // constructor
        public Server()
        {
            // create connection
            connection = new Connection();

            // app controll
            Controll();
        }

        // methods

        // method for controll (exit) server
        private void Controll()
        {
            Utils.Menu(new string[] { });
        }
    }
}